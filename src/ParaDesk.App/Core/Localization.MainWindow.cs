using System;

namespace ParaDesk.Core
{
    internal static partial class L
    {
        static partial void AddMainWindow(Action<string, string> Add)
        {
            Add("系统 {0} (build {1})　子会话 {2}　监听器 {3}　架构 {4}",
                "{0} (build {1})　Child sessions {2}　Listener {3}　Architecture {4}");
            Add("{0}（在 {1} 上模拟运行，建议改用 arm64 版）", "{0} (emulated on {1}; the arm64 build runs natively)");
            Add("知道了", "Got it");
            Add("来自分身桌面的提醒", "Notice from the parallel desktop");
            Add("。热键 {0}", ". Hotkey: {0}");

            Add("分身桌面里", "Inside the parallel desktop");
            Add("登录后自动运行", "Run after sign-in");
            Add("例如 wt -d C:\\repo 或 powershell -NoExit -Command claude",
                "e.g. wt -d C:\\repo or powershell -NoExit -Command claude");
            Add("工作目录（留空为用户主目录）", "Working folder (blank = your user folder)");
            Add("选择工作目录", "Choose working folder");
            Add("选择登录后自动运行的工作目录", "Choose the working folder for Run after sign-in");
            Add("工作目录不存在", "Working folder not found");
            Add("未能注册分身桌面里的守护程序", "Couldn't register the helper inside the parallel desktop");
            Add("登录后自动运行和保持唤醒都靠它执行，没注册时不会生效。详见日志。",
                "Run after sign-in and Keep awake both rely on it and won't work without it. See the log.");
            Add("保持唤醒", "Keep awake");
            Add("分身桌面的声音", "Parallel desktop sound");
            Add("下次启动或重新接入时生效", "Takes effect the next time you start or reattach");
            Add("在本机播放", "Play on this PC");
            Add("静音", "Mute");
            Add("留在分身桌面", "Keep in the parallel desktop");

            Add("截取分身桌面窗口；没开分身桌面时截取方案所在的显示器",
                "Captures the parallel desktop window; if it isn't open, captures the profile's monitor");
            Add("{0} FPS（延时）", "{0} FPS (time-lapse)");
            Add("随分身桌面自动录制", "Record along with the parallel desktop");
            Add("自动分段", "Split into segments");
            Add("不分段", "Don't split");
            Add("每 {0} 分钟", "Every {0} minutes");
            Add("正在截图…", "Taking screenshot…");
            Add("打开文件", "Open file");
            Add("打开所在文件夹", "Show in folder");
            Add("无法打开文件夹：", "Couldn't open the folder: ");
            Add("文件已不存在：", "The file no longer exists: ");
            Add("无法打开该文件：", "Couldn't open the file: ");
            Add("暂停 / 继续录制", "Pause / resume recording");
            Add("录制中才有效", "Only works while recording");
            Add("收起分身桌面", "Hide the parallel desktop");
            Add("把剪贴板发送到分身桌面", "Send clipboard to the parallel desktop");
            Add("从分身桌面取回剪贴板", "Fetch clipboard from the parallel desktop");
            Add("剪贴板设为「手动同步」时使用", "For when the clipboard is set to Manual sync");
            Add("热键冲突，未保存", "Hotkey conflict — not saved");
            Add("{0} 与「{1}」冲突：两个动作不能共用一个组合。请换一个，或先清除那一项。",
                "{0} conflicts with \"{1}\": two actions can't share a combination. Pick another, or clear that one first.");
            Add("以下热键没注册上，组合可能已被其它程序占用，请换一个：{0}",
                "These hotkeys couldn't be registered — another program may be using the combination. Please pick another: {0}");
            Add("有热键占用了保留的组合键", "Some hotkeys use reserved combinations");
            Add("以下热键占用了系统或常用程序在用的组合键：{0}",
                "These hotkeys use combinations that Windows or common programs rely on: {0}");
            Add("启动", "Startup");
            Add("登录 Windows 后自动运行 ParaDesk", "Run ParaDesk when you sign in to Windows");
            Add("启动时最小化到托盘", "Start minimized to the tray");
            Add("程序启动后自动开启分身桌面", "Open the parallel desktop when the app starts");
            Add("启动时检查更新", "Check for updates at startup");
            Add("画面意外断开时自动重新接入", "Reattach automatically if the view drops");
            Add("关闭桌面前确认", "Confirm before closing the desktop");
            Add("关机时自动注销分身桌面", "Sign out the parallel desktop at shutdown");

            Add("AI 工具", "AI tools");
            Add("AI 工具集成", "AI tool integration");
            Add("复制 Claude Code 通知配置", "Copy Claude Code notification config");
            Add("复制命令行用法", "Copy command-line usage");
            Add("已复制 Claude Code 通知配置", "Claude Code notification config copied");
            Add("把其中的 hooks 合并进 Claude Code 的 settings.json（用户级在 ~/.claude/settings.json，也可以放项目里的 .claude/settings.json）。之后任务完成或需要你确认时，主屏会收到提醒。",
                "Merge its hooks into Claude Code's settings.json (per-user at ~/.claude/settings.json, or .claude/settings.json in a project). You'll then get a notice on your main screen when a task finishes or needs your confirmation.");
            Add("已复制命令行用法", "Command-line usage copied");
            Add("可以直接贴给分身桌面里的 agent，或写进项目的说明文件，让它在需要时叫你。",
                "Paste it to the agent in the parallel desktop, or add it to your project's instructions, so it can call you when needed.");
            Add("任务完成", "Task finished");
            Add("需要你确认", "Needs your confirmation");
            Add("ParaDesk 命令行（分身桌面里也能用）。PowerShell 里要在路径前加 & ，例如 & \"...\\ParaDesk.exe\" --status",
                "ParaDesk command line (works inside the parallel desktop too). In PowerShell, put & before the path, e.g. & \"...\\ParaDesk.exe\" --status");
            Add("查询状态；加 --json 输出 JSON。退出码 3 表示 ParaDesk 没在运行",
                "Show status; add --json for JSON. Exit code 3 means ParaDesk isn't running");
            Add("在主屏提醒你（--level warn / error 用醒目样式，--sound 响一声）",
                "Notify you on the main screen (--level warn / error stands out more, --sound plays a sound)");
            Add("截图，输出文件路径", "Take a screenshot and print the file path");
            Add("列出全部命令", "List all commands");
            Add("复制失败", "Copy failed");
            Add("剪贴板正被其它程序占用，请稍后再试。", "Another program is using the clipboard. Try again in a moment.");

            Add("重新检查", "Check again");
            Add("通常一两秒即可完成。", "This usually takes a second or two.");
            Add("环境检查失败", "Environment check failed");
            Add("详见日志。", "See the log.");
            Add("导出诊断包", "Export diagnostic bundle");
            Add("正在生成…", "Creating…");
            Add("正在生成诊断包…", "Creating the diagnostic bundle…");
            Add("正在收集日志与环境信息。", "Collecting logs and environment info.");
            Add("生成诊断包失败", "Couldn't create the diagnostic bundle");
            Add("已生成诊断包", "Diagnostic bundle created");
            Add("系统配置", "System setup");
            Add("撤销系统配置", "Undo system setup");
            Add("撤销配置…", "Undo setup…");
            Add("将撤销 ParaDesk 对系统所做的配置：", "This undoes the changes ParaDesk made to the system:");
            Add("关闭 Windows 的子会话功能", "Turn off Windows child sessions");
            Add("关闭 Windows 的子会话功能（第一次配置前就已开启的保持不变）",
                "Turn off Windows child sessions (left on if they were already on before the first setup)");
            Add("按第一次配置前记录的原值，恢复远程桌面监听器、防火墙规则、免密登录的凭据委派、「始终提示输入密码」和 TermService 启动类型",
                "Restore the Remote Desktop listener, firewall rules, credential delegation for password-free sign-in, “Always prompt for password” and the TermService startup type to the values recorded before the first setup");
            Add("如果没有第一次配置前的记录（例如由旧版本配置过），远程桌面监听器、防火墙规则、「始终提示输入密码」和 TermService 启动类型的原值无从得知，将保持不变，只删除 ParaDesk 写入的凭据委派条目；不需要远程桌面的话，可以在 Windows「设置 → 系统 → 远程桌面」里关闭。",
                "If there's no record from before the first setup (for example, an older version did the setup), the original Remote Desktop listener, firewall rules, “Always prompt for password” and TermService startup type are unknown and stay as they are; only the credential delegation entries ParaDesk wrote are removed. If you don't need Remote Desktop, turn it off in Windows Settings → System → Remote Desktop.");
            Add("移除分身桌面里的守护程序启动项", "Remove the startup entry of the helper inside the parallel desktop");
            Add("需要一次管理员授权。之后若还要使用分身桌面，需要重新配置并重启电脑。",
                "This needs administrator approval once. To use the parallel desktop again afterwards, you'll have to set it up again and restart the PC.");
            Add("分身桌面正在运行，建议先关闭它，里面的程序会随配置撤销而无法继续使用。",
                "The parallel desktop is running. Close it first — programs inside won't keep working once setup is undone.");
            Add("确定撤销吗？", "Undo now?");
            Add("正在撤销…", "Undoing…");
            Add("撤销配置未完成，详见日志：", "Undo didn't finish. See the log: ");
            Add("撤销配置完成", "Undo complete");
            Add("已撤销 ParaDesk 对系统所做的配置。", "ParaDesk's changes to the system have been undone.");
            Add("已撤销配置，重启电脑后完全生效。", "Setup has been undone; restart the PC for it to take full effect.");
            Add("系统配置或撤销正在进行中，请等它完成后再试。",
                "System setup or undo is already in progress. Wait for it to finish, then try again.");
            Add("打开日志查看器失败：", "Couldn't open the log viewer: ");
            Add("日志文件在：", "The log file is at:");

            Add("检查更新", "Check for updates");
            Add("访问 GitHub 查询是否有新版本", "Contacts GitHub to see whether a new version is out");
            Add("打开下载页", "Open download page");
            Add("正在检查…", "Checking…");
            Add("检查更新失败", "Couldn't check for updates");
            Add("发现新版本 {0}", "Version {0} is available");
            Add("当前版本 {0}。点「打开下载页」前往 GitHub 下载。",
                "You have {0}. Click Open download page to get it from GitHub.");
            Add("已是最新版本", "You're up to date");
            Add("当前版本 {0}，GitHub 上最新发布为 {1}。", "You have {0}; the latest release on GitHub is {1}.");
            Add("无法打开浏览器，请手动访问：", "Couldn't open the browser. Please visit:");
            Add("不接收你的键鼠操作；程序注入不受影响", "Blocks your input; automated input still works");
            Add("显示位置与画面质量", "Display location and quality");
            Add("分辨率和缩放选项取自此屏幕。", "Resolution and scale options come from this monitor.");
            Add("收起后可修改，重新接入生效", "Detach to edit; applies when you reattach.");
            Add("连接时即时生效；窗口模式下可跟随窗口大小", "Applies live; windowed desktops can follow the window size.");
            Add("对整台电脑生效，不随方案保存。", "Applies to this PC, across all profiles.");
            Add("键鼠输入与桌面共享", "Input and sharing between desktops");
            Add("默认与主桌面共享；收起后可修改", "Shared by default; detach to change the mode.");
            Add("为分身桌面创建独立的浏览器配置", "Create a separate browser profile for the parallel desktop.");
            Add("每次登录执行一次；已登录的桌面需关闭后再启动", "Runs once at sign-in; close and restart a signed-in desktop to apply changes.");
            Add("阻止睡眠和分身桌面空闲锁屏；运行中约 30 秒内生效", "Prevents sleep and idle locking in the parallel desktop; applies within about 30 seconds.");
            Add("录制窗口或显示器", "Record a window or monitor");
            Add("画质越高，文件越大；1–5 FPS 适合延时录制", "Higher quality uses more space; 1–5 FPS suits time-lapse recording.");
            Add("登录完成后开始录制，收起或关闭时停止", "Starts after sign-in; stops when detached or closed.");
            Add("按有效录制时长分段；意外退出可能损失最后一段", "Splits by recorded time, excluding pauses; an unexpected exit may lose the last segment.");
            Add("在任何程序中均可使用", "Works from any app");
            Add("截取分身窗口；未打开时截取目标屏幕，保存到录制目录", "Captures the desktop window, or the target monitor if detached; saves to the recording folder.");
            Add("收起画面，里面的程序继续运行", "Hides the viewer; apps inside keep running.");
            Add("需搭配 Ctrl / Alt / Shift / Win；Backspace 清除。注册失败时请更换组合。", "Use Ctrl / Alt / Shift / Win; Backspace clears. Choose another combination if registration fails.");
            Add("全局选项，不随方案变化", "Global options, shared by all profiles");
            Add("Language — 切换后重启程序，分身桌面继续运行", "Language — restarts the app; the parallel desktop keeps running.");
            Add("开机自启时仅显示托盘图标", "Shows only the tray icon when starting with Windows.");
            Add("环境就绪时自动启动，已有桌面则重新接入", "Starts when ready, or reattaches to an existing desktop.");
            Add("启动时访问 GitHub 查询新版本", "Checks GitHub for a new version at startup.");
            Add("桌面仍在运行时，自动恢复意外断开的画面", "Restores an interrupted connection while the desktop is still running.");
            Add("关闭会注销分身桌面并结束其中所有程序", "Closing signs out the parallel desktop and ends all apps inside.");
            Add("关机或重启前注销分身桌面，供程序正常退出", "Signs out the parallel desktop before shutdown or restart so apps can exit.");
            Add("通常无需保存；登录失败时可手动设置", "Usually unnecessary; configure manually if sign-in fails.");
            Add("支持命令行通知（--notify）和状态查询（--status）", "Supports notifications (--notify) and status queries (--status).");
            Add("将日志与环境信息导出到桌面，不包含保存的凭据", "Exports logs and environment details to the desktop; excludes saved credentials.");
            Add("仅在系统设置被更改后需要手动修复", "Use if system settings have been changed.");
            Add("撤销 ParaDesk 修改的系统设置", "Reverts system settings changed by ParaDesk.");
            Add("查看首次使用引导", "Review the setup guide");
            Add("第二个 Windows 桌面，键鼠独立，共用当前账户和文件，不提供安全隔离。", "A second Windows desktop with independent input. It shares your account and files and provides no security isolation.");
            Add("账户不变时，密码留空可沿用；更改账户需重新输入。", "Leave the password blank to keep it only if the account is unchanged.");
            Add("使用 Windows 加密保存", "Encrypted by Windows");
            Add("仅本机当前账户可解密；同账户程序仍可访问。", "Only this Windows account on this PC can decrypt it; apps running as you can still access it.");
            Add("留空恢复默认名称；按显示器接口保存。", "Leave blank to restore the default; names are saved per monitor connection.");
            Add("首次登录可能需要一两分钟。", "First sign-in may take a minute or two.");
            Add("正在恢复连接，桌面里的程序继续运行。", "Restoring the connection; apps inside keep running.");
            Add("桌面已就绪，主桌面键鼠不受影响。", "Ready to use; input on your main desktop is unaffected.");
            Add("程序仍在运行，点「重新接入」恢复画面。", "Apps are still running. Reattach to show the desktop.");
            Add("点「启动桌面」即可开始。", "Click Start desktop to begin.");
            Add("已创建方案「{0}」。", "Created profile “{0}”.");
            Add("系统声音包含本机全部播放；麦克风需允许桌面应用访问。", "System audio includes all playback on this PC; microphone access requires desktop-app permission.");
            Add("账户已更改，请重新输入密码。", "Account changed. Enter the password again.");
            Add("设置未保存", "Settings not saved");
            Add("当前更改仅本次有效，请重试保存。", "Changes apply to this session only. Retry saving.");
            Add("重试保存", "Retry saving");
            Add("程序位置", "Program location");
            Add("数据目录", "Data folder");
            Add("复制诊断摘要", "Copy diagnostic summary");
            Add("打开数据目录", "Open data folder");
            Add("正在登录…", "Signing in…");
            Add("登录中", "Signing in");
            Add("已连接，等待 Windows 完成登录。若出现凭据窗口，请使用账户密码。", "Connected. Waiting for Windows sign-in; use your account password if prompted.");
            Add("已建立（桌面运行中）", "Established (desktop running)");
            Add("正在准备录制…", "Preparing to record…");
            Add("正在保存录制…", "Saving recording…");
            Add("录制已暂停", "Recording paused");
            Add("跟随窗口大小", "Match window size");
            Add("复制方案", "Duplicate profile");
            Add("重命名方案", "Rename profile");
            Add("方案名称", "Profile name");
            Add("最多 60 个字符，名称不能重复。", "Up to 60 characters; names must be unique.");
            Add("请输入未使用的方案名称。", "Enter a unique profile name.");
            Add("子会话服务暂不可用。若刚完成配置，请保存工作后重启电脑。", "Child session service unavailable. If setup just completed, save your work and restart Windows.");
            Add("子会话通道不可用：", "Child session transport unavailable: ");
            Add("。请查看诊断日志。", ". See the diagnostic log.");
            Add("RPC 服务不可用", "RPC service unavailable");
            Add("通道已存在", "Transport already exists");
            Add("等待 100 秒仍未完成登录，请检查连接窗口或诊断日志。", "Sign-in did not complete within 100 seconds. Check the connection window or diagnostic log.");
            Add("使用账户密码（非 PIN）。Microsoft 账户填写 MicrosoftAccount\\邮箱。保存后仍需由 Windows 验证登录。", "Use your account password, not a PIN. For Microsoft accounts, use MicrosoftAccount\\email. Windows verifies it when you sign in.");
            Add("在选定的显示器上打开第二个 Windows 桌面，键鼠操作与主桌面互不干扰。", "Opens a second Windows desktop on your chosen monitor, with input independent of your main desktop.");
            Add("共用账户和文件", "Shared account and files");
            Add("分身桌面使用当前 Windows 账户，共用软件和文件，不提供安全隔离。同账户程序的配置可能互相影响。", "Uses your Windows account, apps and files, with no security isolation. Apps sharing this account may affect each other’s settings.");
            Add("家庭版不支持。首次配置需管理员授权，日常使用无需提权。", "Home edition is not supported. Initial setup requires administrator approval; daily use does not.");
            Add("检查运行条件。「启动桌面」会自动配置可修复项，需要管理员授权。", "Checks requirements. Start desktop configures supported fixes with administrator approval.");
            Add("选择目标屏幕；点“识别屏幕”可显示编号。", "Choose a monitor; Identify monitors shows its number.");
            Add("启动前请了解以下操作和限制。", "Review these controls and limits before starting.");
            Add("使用限制", "Limitations");
            Add("启动选项", "Startup options");
            Add("仅显示托盘图标，热键保持可用", "Shows only the tray icon; hotkeys remain available.");
            Add("忽略你的键鼠输入，可用热键或托盘菜单切换", "Ignores your input; toggle with a hotkey or the tray menu.");
            Add("已保存凭据，使用 Windows 加密", "Credentials saved with Windows encryption");
            Add("同时仅支持一个分身桌面；Windows 沙盒提供临时隔离环境。", "Only one parallel desktop is supported; Windows Sandbox provides temporary isolation.");
            Add("需先启用沙盒功能：需要管理员授权并重启电脑。", "Enabling Sandbox requires administrator approval and a Windows restart.");
            Add("即时生效；固定分辨率选项取自 {0}", "Applies live; fixed resolutions come from {0}");
            Add("录制帧率", "Recording frame rate");
            Add("录制码率", "Recording bitrate");
            Add("工作目录", "Working folder");
            Add("名称", "Name");
            Add("筛选日志", "Filter log");
            Add("当前方案：{0}。以下设置随方案保存。", "Profile: {0}. Settings below are saved with it.");
            Add("当前仅一块屏幕；用热键或「收起桌面」切回主桌面。", "One monitor is connected. Use the hotkey or Hide desktop to return to your main desktop.");
            Add("点「启动桌面」自动配置，需要管理员授权。", "Start desktop applies setup with administrator approval.");
            Add("例如 wt -d C:\\repo", "e.g. wt -d C:\\repo");
            Add("系统配置内容", "System changes");
            Add("• 启用子会话、远程桌面监听器和服务自动启动\n• 必要时启用专用/域网络的远程桌面防火墙规则\n• 启用默认凭据委派，关闭「始终提示输入密码」\n• 关闭跨设备恢复，并抑制其在分身桌面中的错误提示", "• Enable child sessions, the Remote Desktop listener and automatic service startup\n• Enable Remote Desktop firewall rules on private/domain networks if required\n• Allow default credential delegation and disable “Always prompt for password”\n• Disable Cross Device Resume and suppress its errors in the parallel desktop");
            Add("• 同时仅支持一个分身桌面\n• 剪贴板默认共享；浏览器需独立配置，可在“输入与共享”创建快捷方式\n• 重启前请保存分身桌面中的工作", "• Only one parallel desktop at a time\n• Clipboard sharing is on by default; create a separate browser profile in Input & sharing\n• Save work in the parallel desktop before restarting Windows");
            Add("日志级别", "Log level");
        }
    }
}
