using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace ParaDesk.Core
{
    /// <summary>产品级常量与路径。改名只需改这里。</summary>
    internal static class AppInfo
    {
        public const string ProductName = "ParaDesk";
        public const string ProductNameZh = "分身桌面";
        public const string Tagline = "给你的电脑开分身";

        public const string MutexNameGlobal = "Global\\ParaDeskSingleInstance";
        public const string MutexNameLocal = "Local\\ParaDeskSingleInstance";

        public static string Version
        {
            get
            {
                var v = Assembly.GetExecutingAssembly().GetName().Version;
                return v == null ? "1.0.0" : v.ToString(3);
            }
        }

        public static string Title
        {
            get { return ProductName + " " + ProductNameZh; }
        }

        public static string DisplayTitle
        {
            get { return L.T(Title); }
        }

        private static string _dataDir;

        public static string DataDir
        {
            get
            {
                string d = _dataDir;
                if (d != null) return d;

                d = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    ProductName);
                try
                {
                    Directory.CreateDirectory(d);
                    _dataDir = d;
                }
                catch (Exception)
                {
                }
                return d;
            }
        }

        public static string SettingsPath { get { return Path.Combine(DataDir, "settings.json"); } }

        public static string LogPath { get { return Log.Path0; } }

        public static string ExecutablePath
        {
            get { return Assembly.GetEntryAssembly().Location; }
        }

        public static string BuildId
        {
            get
            {
                var a = (AssemblyInformationalVersionAttribute)Attribute.GetCustomAttribute(
                    Assembly.GetExecutingAssembly(), typeof(AssemblyInformationalVersionAttribute));
                return a == null ? Version : a.InformationalVersion;
            }
        }

        /// <summary>Resolve the directory handle so packaged launches report redirected storage.</summary>
        public static string ActualDataDir
        {
            get
            {
                try
                {
                    using (var handle = CreateFile(DataDir, 0, 7, IntPtr.Zero, 3, 0x02000000, IntPtr.Zero))
                    {
                        if (handle.IsInvalid) return DataDir;
                        var path = new StringBuilder(32768);
                        uint size = GetFinalPathNameByHandle(handle, path, (uint)path.Capacity, 0);
                        if (size == 0 || size >= path.Capacity) return DataDir;
                        string result = path.ToString();
                        if (result.StartsWith(@"\\?\UNC\", StringComparison.OrdinalIgnoreCase))
                            return @"\\" + result.Substring(8);
                        return result.StartsWith(@"\\?\", StringComparison.Ordinal) ? result.Substring(4) : result;
                    }
                }
                catch { return DataDir; }
            }
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern SafeFileHandle CreateFile(string path, uint access, uint share,
            IntPtr security, uint creation, uint flags, IntPtr template);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern uint GetFinalPathNameByHandle(SafeFileHandle handle,
            StringBuilder path, uint size, uint flags);
    }
}
