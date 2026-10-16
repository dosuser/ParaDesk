using System;

namespace ParaDesk.Core
{
    internal static partial class L
    {
        static partial void AddWpfMisc(Action<string, string> Add)
        {
            Add("• {0} 显示 / 收起分身桌面", "• {0} show / hide the parallel desktop");
            Add("• {0} 切换“仅查看”（锁住你的键鼠，防止误触）",
                "• {0} toggle view only (locks your input so you can't disturb it)");
            Add("• {0} 开始 / 停止录制", "• {0} start / stop recording");
            Add("• {0} 暂停 / 继续录制", "• {0} pause / resume recording");
            Add("• {0} 截图", "• {0} take a screenshot");
            Add("• {0} 收起分身桌面（里面的程序继续运行）",
                "• {0} hide the parallel desktop (its programs keep running)");
            Add("• {0} 把剪贴板发送到分身桌面", "• {0} send the clipboard to the parallel desktop");
            Add("• {0} 从分身桌面取回剪贴板", "• {0} fetch the clipboard from the parallel desktop");
            Add("• 还没有启用任何全局热键，可在「热键」页设置",
                "• No global hotkeys are enabled yet — set them up on the Hotkeys page");
            Add("• 关闭主窗口只是收进托盘，程序继续在后台运行",
                "• Closing the main window only tucks it into the tray; the app keeps running");
            Add("登录 Windows 后自动在托盘运行", "Run in the tray when I sign in to Windows");
            Add("默认开启仅查看", "Turn on view only by default");
            Add("完成后立即启动分身桌面", "Start the parallel desktop when I finish");
            Add("关闭向导后马上在选定的屏幕上开出分身桌面",
                "Opens the parallel desktop on the chosen screen as soon as the wizard closes");
            Add("分身桌面已经在运行。", "The parallel desktop is already running.");
            Add("暂时不能直接启动：{0}", "Can't start it directly yet: {0}");
            Add("启动分身桌面失败，详见日志。", "Couldn't start the parallel desktop — see the log.");

            Add("确定清空日志吗？当前日志和上一份滚动日志（paradesk.log.1）都会被删除。",
                "Clear the log? Both the current log and the previous rolled-over log (paradesk.log.1) will be deleted.");
            Add("确定清除已保存的登录凭据吗？清除后立即生效，无法撤销。",
                "Clear the saved sign-in credentials? This takes effect immediately and can't be undone.");
            Add("请填写密码。", "Enter a password.");
            Add("读取已保存的密码失败，请重新输入密码。",
                "Couldn't read the saved password. Please enter the password again.");

            Add("「{0}」已经是另一块显示器的名字，请换一个。",
                "\"{0}\" is already the name of another monitor. Please choose a different name.");

            Add("导出诊断包", "Export diagnostic bundle");
            Add("正在生成诊断包…", "Creating the diagnostic bundle…");
            Add("已生成诊断包", "Diagnostic bundle created");
            Add("生成诊断包失败：{0}", "Couldn't create the diagnostic bundle: {0}");
            Add("重新检查", "Check again");
            Add("环境检查失败", "Environment check failed");
            Add("详见日志。", "See the log.");
        }
    }
}
