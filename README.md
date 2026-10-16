# ParaDesk

A second Windows desktop with independent input, sharing your Windows account, apps and files.

[简体中文](#简体中文) · [Download](https://github.com/sinpoce/ParaDesk/releases/latest) · [Changelog](RELEASE_NOTES.md)

## Requirements

- Windows 10 1903+ or Windows 11, Pro / Enterprise / Education. Home does not support parallel desktops.
- Standard package: .NET Framework 4.8.
- Native ARM64 package: Windows 11 on Arm and .NET Framework 4.8.1.

## Quick start

1. Install Setup, or extract the portable ZIP and run `ParaDesk.exe`.
2. Select a monitor and click **Start desktop**. Initial setup requires administrator approval. Restart Windows only if Diagnostics requests it.
3. Use **Reattach** to restore a hidden desktop. Window mode, scale and clipboard changes apply after detaching and reattaching; resolution changes apply live.

| Hotkey | Action |
| --- | --- |
| `Ctrl+Alt+D` | Show / hide desktop |
| `Ctrl+Alt+V` | Toggle view only |
| `Ctrl+Alt+R` | Start / stop recording |

Hotkeys can be changed in the app. Recording, screenshots and desktop profiles are also available.

## Before use

- Only one parallel desktop is supported. It shares your account and files and **provides no security isolation**.
- Clipboard sharing is on by default. Use **Input & sharing → Browser isolation** to create a separate browser profile.
- **Hide / Quit** preserves apps in the parallel desktop. **Close desktop** signs it out and ends its apps. Save work before restarting Windows.
- Setup enables child sessions, the Remote Desktop listener and credential delegation, and may enable Remote Desktop firewall rules on private/domain networks. Diagnostics can undo these changes.
- Update checks are off by default. Enabling them connects to GitHub at startup.

## Sign-in problems

Check **Diagnostics** first. If Windows requires credentials, save the account and password under **Settings → Credentials**.

For a Microsoft account, use `MicrosoftAccount\email` and the account password, **not a Windows Hello PIN**. Changing the saved account requires entering its password again. Saved credentials are encrypted by Windows; saving them does not verify sign-in.

If sign-in still fails, export a diagnostic bundle and [open an issue](https://github.com/sinpoce/ParaDesk/issues). The bundle excludes saved credentials; review it before sharing.

## Command line

PowerShell examples:

```powershell
.\ParaDesk.exe --start --wait --json | Out-String
.\ParaDesk.exe --status --json | Out-String
.\ParaDesk.exe --detach | Out-String
.\ParaDesk.exe --help | Out-String
```

`--wait` waits for Windows sign-in, up to 100 seconds. Recording, screenshots and notifications are also supported; see `--help`.

---

## 简体中文

在同一台电脑上打开第二个 Windows 桌面，键鼠独立，共用当前账户、软件和文件。

[下载](https://github.com/sinpoce/ParaDesk/releases/latest) · [更新记录](RELEASE_NOTES.md)

### 系统要求

- Windows 10 1903+ 或 Windows 11，专业版、企业版或教育版；家庭版不支持分身桌面。
- 普通版需要 .NET Framework 4.8。
- 原生 ARM64 版需要 Arm 版 Windows 11 和 .NET Framework 4.8.1。

### 开始使用

1. 安装 Setup，或解压便携版并运行 `ParaDesk.exe`。
2. 选择显示器，点 **启动桌面**。首次配置需要管理员授权；仅在诊断页提示需要时重启电脑。
3. 收起后可点 **重新接入** 恢复画面。窗口模式、缩放和剪贴板设置需收起后修改、重新接入生效；分辨率可即时修改。

| 热键 | 操作 |
| --- | --- |
| `Ctrl+Alt+D` | 显示 / 收起桌面 |
| `Ctrl+Alt+V` | 切换仅查看 |
| `Ctrl+Alt+R` | 开始 / 停止录制 |

热键可在软件中修改，另有录屏、截图和多方案功能。

### 使用须知

- 同时仅支持一个分身桌面。它与主桌面共用账户和文件，**不提供安全隔离**。
- 剪贴板默认共享；可在 **输入与共享 → 浏览器隔离** 创建独立浏览器配置。
- **收起 / 退出程序** 保留分身桌面中的应用；**关闭桌面** 会注销并结束其中所有应用。重启前请保存工作。
- 首次配置会启用子会话、远程桌面监听器和凭据委派，必要时启用专用/域网络的远程桌面防火墙规则；可在诊断页撤销。
- 更新检查默认关闭，开启后会在启动时连接 GitHub。

### 登录失败

先检查 **诊断**。若 Windows 要求凭据，可在 **设置 → 登录凭据** 保存账户和密码。

Microsoft 账户填写 `MicrosoftAccount\邮箱`，使用账户密码，**不要填写 Windows Hello PIN**。修改账户后需重新输入密码。凭据由 Windows 加密保存，保存成功不代表已通过登录验证。

仍无法登录时，可导出诊断包并[提交问题](https://github.com/sinpoce/ParaDesk/issues)。诊断包不包含保存的凭据，分享前请检查内容。

### 命令行

上方 PowerShell 示例可用于启动、查询状态和收起桌面。`--wait` 等待 Windows 登录完成，最多 100 秒；录制、截图和通知等命令见 `--help`。

## Build / 构建

Requires .NET SDK 8.0 / 需要 .NET SDK 8.0：

```powershell
dotnet build src/ParaDesk.App/ParaDesk.App.csproj -c Release
.\selftest.ps1 -Release
.\publish.ps1 -Version 1.2.0 -SelfTest
```

The installer requires Inno Setup 6.3+. / 安装包需要 Inno Setup 6.3+。

Updating the project version and `RELEASE_NOTES.md` on `main` publishes packages and SHA256 files after x64 and ARM64 checks pass. Existing releases are not overwritten.

更新项目版本号及 `RELEASE_NOTES.md` 后推送 `main`，x64、ARM64 检查通过后自动发布安装包、便携包和 SHA256 文件，已发布版本不会覆盖。

## License

[MIT](LICENSE)
