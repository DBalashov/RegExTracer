using Nabu.Forms.TextObjectModel;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Nabu.Forms;

public class RichTextBoxEx : RichTextBox
{
    public RichTextBoxEx()
    {
    }

    public RichTextBoxEx(IContainer container) => container.Add(this);

    [Browsable(false)]
    public ITextDocument? TextDocument
    {
        get
        {
            var zero = IntPtr.Zero;
            try
            {
                return NativeMethods.Window_MessageSend(Handle, 0x43c, 0, out zero) == 0 ? null : Marshal.GetObjectForIUnknown(zero) as ITextDocument;
            }
            finally
            {
                Marshal.Release(zero);
            }
        }
    }
}