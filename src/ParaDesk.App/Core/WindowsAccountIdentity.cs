using System;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace ParaDesk.Core
{
    /// <summary>建议新建凭据时的当前账户名；不改写用户已保存的登录身份。</summary>
    internal static class WindowsAccountIdentity
    {
        private const string MicrosoftAccountProvider = "MicrosoftAccount";

        public static string CurrentCredentialName
        {
            get { return ResolveCredentialName(CurrentSamName); }
        }

        private static string CurrentSamName
        {
            get
            {
                string domain = Environment.UserDomainName;
                return string.IsNullOrEmpty(domain) ? Environment.UserName
                    : domain + "\\" + Environment.UserName;
            }
        }

        private static string ResolveCredentialName(string suppliedName)
        {
            string principal;
            if (!TryGetCurrentMicrosoftAccount(out principal)) return suppliedName;
            return NormalizeCurrentAlias(suppliedName, Environment.UserName,
                CurrentSamName, Environment.MachineName, principal);
        }

        // principal 仅来自 SID 已与当前进程身份核对的 USER_INFO_24。
        internal static string NormalizeCurrentAlias(string suppliedName, string localUser,
            string currentSamName, string machineName, string principal)
        {
            if (string.IsNullOrEmpty(suppliedName) || string.IsNullOrEmpty(principal))
                return suppliedName;
            bool currentAlias = Same(suppliedName, localUser) || Same(suppliedName, currentSamName)
                || Same(suppliedName, machineName + "\\" + localUser)
                || Same(suppliedName, ".\\" + localUser) || Same(suppliedName, principal);
            return currentAlias ? MicrosoftAccountProvider + "\\" + principal : suppliedName;
        }

        private static bool Same(string left, string right)
        {
            return string.Equals(left, right, StringComparison.OrdinalIgnoreCase);
        }

        private static bool TryGetCurrentMicrosoftAccount(out string principal)
        {
            principal = null;
            IntPtr buffer = IntPtr.Zero;
            try
            {
                if (NetUserGetInfo(null, Environment.UserName, 24, out buffer) != 0
                    || buffer == IntPtr.Zero) return false;
                var info = (UserInfo24)Marshal.PtrToStructure(buffer, typeof(UserInfo24));
                if (info.InternetIdentity == 0 || info.Sid == IntPtr.Zero) return false;
                string provider = Marshal.PtrToStringUni(info.Provider);
                string internetName = Marshal.PtrToStringUni(info.Principal);
                if (!Same(provider, MicrosoftAccountProvider) || string.IsNullOrEmpty(internetName))
                    return false;
                // 域账户与同名本地账户可能共存，必须核对 SID 后才能映射。
                using (var identity = WindowsIdentity.GetCurrent())
                {
                    if (identity.User == null || !new SecurityIdentifier(info.Sid).Equals(identity.User))
                        return false;
                }
                principal = internetName;
                return true;
            }
            catch (Exception ex)
            {
                Log.Debug("读取当前账户的关联身份失败，沿用填写的账户名: " + ex.GetType().Name);
                return false;
            }
            finally
            {
                if (buffer != IntPtr.Zero) NetApiBufferFree(buffer);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct UserInfo24
        {
            public int InternetIdentity;
            public uint Flags;
            public IntPtr Provider;
            public IntPtr Principal;
            public IntPtr Sid;
        }

        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode)]
        private static extern int NetUserGetInfo(string serverName, string userName,
            int level, out IntPtr buffer);

        [DllImport("Netapi32.dll")]
        private static extern int NetApiBufferFree(IntPtr buffer);
    }
}
