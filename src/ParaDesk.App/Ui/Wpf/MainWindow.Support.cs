using System;
using System.Diagnostics;
using System.Windows;
using ParaDesk.Core;

namespace ParaDesk.Shell
{
    internal partial class MainWindow
    {
        private void UpdateSaveStatus()
        {
            SaveFailurePanel.Visibility = SettingsStore.LastSaveError == null
                ? Visibility.Collapsed : Visibility.Visible;
        }

        private void OnRetrySave(object sender, RoutedEventArgs e)
        {
            SettingsStore.Save(_app.Settings);
            UpdateSaveStatus();
        }

        private bool ProfileNameTaken(string value, string except)
        {
            foreach (var profile in _app.Settings.Profiles)
                if (profile != null && profile.Name != except &&
                    string.Equals(profile.Name, value, StringComparison.OrdinalIgnoreCase)) return true;
            return false;
        }

        private void OnProfileRename(object sender, RoutedEventArgs e)
        {
            if (_startupEditProfile != null) SaveStartupCommand();
            string old = _app.Settings.GetActiveProfile().Name;
            var dialog = new RenameDialog("重命名方案", old,
                delegate(string value) { return ProfileNameTaken(value, old); }) { Owner = this };
            if (dialog.ShowDialog() != true) return;
            if (!_app.RenameProfile(old, dialog.ResultName)) return;
            RefreshAll();
        }

        private void OnCopyDiagnostics(object sender, RoutedEventArgs e)
        {
            try
            {
                Clipboard.SetText(AppInfo.ProductName + " " + AppInfo.BuildId + Environment.NewLine +
                    AboutEnv.Text + Environment.NewLine + AppInfo.ExecutablePath + Environment.NewLine + AppInfo.ActualDataDir);
            }
            catch (Exception ex) { Log.Error("复制诊断摘要失败", ex); Warn(L.T("复制失败")); }
        }

        private void OnOpenDataDirectory(object sender, RoutedEventArgs e)
        {
            try { Process.Start(new ProcessStartInfo(AppInfo.ActualDataDir) { UseShellExecute = true }); }
            catch (Exception ex) { Log.Error("打开数据目录失败", ex); Warn(L.T("打开文件夹失败，详见日志。")); }
        }
    }
}
