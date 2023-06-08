using System.Runtime.InteropServices;

namespace Nabu.Forms;

public class NativeMethods
{
    [DllImport("user32.dll", EntryPoint = "SendMessage")]
    public static extern int Window_MessageSend([In] IntPtr hWnd, [In] int message, [In] int wParam, [In] IntPtr lParam);

    [DllImport("user32.dll", EntryPoint = "SendMessage")]
    public static extern int Window_MessageSend([In] IntPtr hWnd, [In] int message, [In] int wParam, out IntPtr lParam);
}