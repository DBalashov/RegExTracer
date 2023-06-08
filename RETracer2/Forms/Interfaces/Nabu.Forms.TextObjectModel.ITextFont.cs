using System.Runtime.InteropServices;

namespace Nabu.Forms.TextObjectModel;

[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("8CC497C3-A1DF-11CE-8098-00AA0047BE5D")]
public interface ITextFont
{
    [DispId(0)]
    ITextFont Duplicate
    {
        [return: MarshalAs(UnmanagedType.Interface)]
        [DispId(0)]
        get;
        [param: In, MarshalAs(UnmanagedType.Interface)]
        [DispId(0)]
        set;
    }

    [DispId(0x301)]
    int CanChange();

    [DispId(770)]
    int IsEqual([In, MarshalAs(UnmanagedType.Interface)] ITextFont font);

    [DispId(0x303)]
    void Reset([In, MarshalAs(UnmanagedType.U4)] ResetFlags value);

    [DispId(            0x304)]
    int Style { [DispId(0x304)] get; [param: In] [DispId(0x304)] set; }

    [DispId(0x305)]
    FormatFlags AllCaps
    {
        [return: MarshalAs(UnmanagedType.U4)]
        [DispId(0x305)]
        get;
        [param: In, MarshalAs(UnmanagedType.U4)]
        [DispId(0x305)]
        set;
    }

    [DispId(0x306)]
    AnimationFlags Animation
    {
        [return: MarshalAs(UnmanagedType.U4)]
        [DispId(0x306)]
        get;
        [param: In, MarshalAs(UnmanagedType.U4)]
        [DispId(0x306)]
        set;
    }

    [DispId(                0x307)]
    int BackColor { [DispId(0x307)] get; [param: In] [DispId(0x307)] set; }

    [DispId(0x308)]
    FormatFlags Bold
    {
        [return: MarshalAs(UnmanagedType.U4)]
        [DispId(0x308)]
        get;
        [param: In, MarshalAs(UnmanagedType.U4)]
        [DispId(0x308)]
        set;
    }

    [DispId(0x309)]
    FormatFlags Emboss
    {
        [return: MarshalAs(UnmanagedType.U4)]
        [DispId(0x309)]
        get;
        [param: In, MarshalAs(UnmanagedType.U4)]
        [DispId(0x309)]
        set;
    }

    [DispId(                0x310)]
    int ForeColor { [DispId(0x310)] get; [param: In] [DispId(0x310)] set; }

    [DispId(0x311)]
    FormatFlags Hidden
    {
        [return: MarshalAs(UnmanagedType.U4)]
        [DispId(0x311)]
        get;
        [param: In, MarshalAs(UnmanagedType.U4)]
        [DispId(0x311)]
        set;
    }

    [DispId(0x312)]
    FormatFlags Engrave
    {
        [return: MarshalAs(UnmanagedType.U4)]
        [DispId(0x312)]
        get;
        [param: In, MarshalAs(UnmanagedType.U4)]
        [DispId(0x312)]
        set;
    }

    [DispId(0x313)]
    FormatFlags Italic
    {
        [return: MarshalAs(UnmanagedType.U4)]
        [DispId(0x313)]
        get;
        [param: In, MarshalAs(UnmanagedType.U4)]
        [DispId(0x313)]
        set;
    }

    [DispId(                0x314)]
    float Kerning { [DispId(0x314)] get; [param: In] [DispId(0x314)] set; }

    [DispId(                 0x315)]
    int LanguageID { [DispId(0x315)] get; [param: In] [DispId(0x315)] set; }

    [DispId(790)]
    string Name
    {
        [return: MarshalAs(UnmanagedType.BStr)]
        [DispId(790)]
        get;
        [param: In, MarshalAs(UnmanagedType.BStr)]
        [DispId(790)]
        set;
    }

    [DispId(0x317)]
    FormatFlags Outline
    {
        [return: MarshalAs(UnmanagedType.U4)]
        [DispId(0x317)]
        get;
        [param: In, MarshalAs(UnmanagedType.U4)]
        [DispId(0x317)]
        set;
    }

    [DispId(                 0x318)]
    float Position { [DispId(0x318)] get; [param: In] [DispId(0x318)] set; }

    [DispId(0x319)]
    FormatFlags Protected
    {
        [return: MarshalAs(UnmanagedType.U4)]
        [DispId(0x319)]
        get;
        [param: In, MarshalAs(UnmanagedType.U4)]
        [DispId(0x319)]
        set;
    }

    [DispId(800)]
    FormatFlags Shadow
    {
        [return: MarshalAs(UnmanagedType.U4)]
        [DispId(800)]
        get;
        [param: In, MarshalAs(UnmanagedType.U4)]
        [DispId(800)]
        set;
    }

    [DispId(             0x321)]
    float Size { [DispId(0x321)] get; [param: In] [DispId(0x321)] set; }

    [DispId(0x322)]
    FormatFlags SmallCaps
    {
        [return: MarshalAs(UnmanagedType.U4)]
        [DispId(0x322)]
        get;
        [param: In, MarshalAs(UnmanagedType.U4)]
        [DispId(0x322)]
        set;
    }

    [DispId(                0x323)]
    float Spacing { [DispId(0x323)] get; [param: In] [DispId(0x323)] set; }

    [DispId(0x324)]
    FormatFlags StrikeThrough
    {
        [return: MarshalAs(UnmanagedType.U4)]
        [DispId(0x324)]
        get;
        [param: In, MarshalAs(UnmanagedType.U4)]
        [DispId(0x324)]
        set;
    }

    [DispId(0x325)]
    FormatFlags Subscript
    {
        [return: MarshalAs(UnmanagedType.U4)]
        [DispId(0x325)]
        get;
        [param: In, MarshalAs(UnmanagedType.U4)]
        [DispId(0x325)]
        set;
    }

    [DispId(0x326)]
    FormatFlags Superscript
    {
        [return: MarshalAs(UnmanagedType.U4)]
        [DispId(0x326)]
        get;
        [param: In, MarshalAs(UnmanagedType.U4)]
        [DispId(0x326)]
        set;
    }

    [DispId(0x327)]
    UnderlineFlags Underline
    {
        [return: MarshalAs(UnmanagedType.U4)]
        [DispId(0x327)]
        get;
        [param: In, MarshalAs(UnmanagedType.U4)]
        [DispId(0x327)]
        set;
    }

    [DispId(             0x328)]
    int Weight { [DispId(0x328)] get; [param: In] [DispId(0x328)] set; }
}