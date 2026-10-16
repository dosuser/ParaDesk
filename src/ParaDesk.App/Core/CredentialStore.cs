using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ParaDesk.Core
{
    /// <summary>
    /// 可选的凭据保存，在当前登录身份无法自动委派时提供显式账户密码。
    /// 保存成功只表示密文已写入；密码是否有效由 Windows 连接认证决定。
    ///
    /// 安全设计：
    /// - 用 DPAPI（CurrentUser 作用域）加密，密文只有**本机 + 本 Windows 账户**能解开，
    ///   拷到别的机器或别的账户下都是废数据；
    /// - 绝不写明文，绝不写进 settings.json（那是会被随手分享的文件）；
    /// - 单独文件存放，删掉即彻底失效；
    /// - 默认不启用。
    ///
    /// 需要说清楚的取舍：能解密它的进程就是以你的身份运行的进程，所以这**不是**
    /// 对抗本机恶意软件的防线——它防的是密码被明文落盘、被云同步、被顺手看到。
    /// </summary>
    internal static class CredentialStore
    {
        private static string FilePath { get { return Path.Combine(AppInfo.DataDir, "credential.bin"); } }

        /// <summary>额外的熵值，让密文不能被同账户下其它程序随手 Unprotect。</summary>
        private static readonly byte[] Entropy =
            Encoding.UTF8.GetBytes("ParaDesk.ChildSession.Credential.v1");

        public static bool Exists { get { return File.Exists(FilePath); } }

        internal static bool CanKeepPassword(bool hasSaved, string savedUser, string user)
        {
            return hasSaved && !string.IsNullOrEmpty(savedUser) &&
                string.Equals(savedUser, user, StringComparison.Ordinal);
        }

        public static bool Save(string userName, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(userName)) return false;
                // 用 \0 分隔，避免用户名里含冒号等分隔符时解析出错
                string joined = userName + "\0" + (password ?? "");
                byte[] plain = Encoding.UTF8.GetBytes(joined);
                byte[] cipher = ProtectedData.Protect(plain, Entropy, DataProtectionScope.CurrentUser);
                Array.Clear(plain, 0, plain.Length);

                File.WriteAllBytes(FilePath, cipher);
                Log.Info("已保存分身桌面登录凭据（DPAPI 加密，仅本机本账户可解）");
                return true;
            }
            catch (Exception ex)
            {
                Log.Error("保存凭据失败", ex);
                return false;
            }
        }

        public static bool TryLoad(out string userName, out string password)
        {
            userName = null;
            password = null;
            try
            {
                if (!File.Exists(FilePath)) return false;
                byte[] cipher = File.ReadAllBytes(FilePath);
                byte[] plain = ProtectedData.Unprotect(cipher, Entropy, DataProtectionScope.CurrentUser);
                string joined = Encoding.UTF8.GetString(plain);
                Array.Clear(plain, 0, plain.Length);

                int sep = joined.IndexOf('\0');
                if (sep < 0) return false;
                userName = joined.Substring(0, sep);
                password = joined.Substring(sep + 1);
                return !string.IsNullOrEmpty(userName);
            }
            catch (CryptographicException)
            {
                // 换了机器或换了 Windows 账户，密文无法解开——直接作废
                Log.Warn("凭据无法解密（可能换了机器或账户），已忽略");
                Clear();
                return false;
            }
            catch (Exception ex)
            {
                Log.Error("读取凭据失败", ex);
                return false;
            }
        }

        public static void Clear()
        {
            try
            {
                if (File.Exists(FilePath)) File.Delete(FilePath);
                Log.Info("已清除保存的登录凭据");
            }
            catch (Exception ex) { Log.Error("清除凭据失败", ex); }
        }

        /// <summary>关联 Microsoft Account 时使用其登录身份，否则使用当前 Windows 账户名。</summary>
        public static string CurrentUserName
        {
            get
            {
                try
                {
                    return WindowsAccountIdentity.CurrentCredentialName;
                }
                catch { return Environment.UserName; }
            }
        }
    }
}
