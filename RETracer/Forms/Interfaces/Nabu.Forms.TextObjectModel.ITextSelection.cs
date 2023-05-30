using System.Runtime.InteropServices;

namespace Nabu.Forms.TextObjectModel;

[ComImport, Guid("8CC497C1-A1DF-11CE-8098-00AA0047BE5D"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
public interface ITextSelection : ITextRange
{
    [DispId(0x101)]
    SelectionFlags Flags
    {
        [return: MarshalAs(UnmanagedType.U4)]
        [DispId(0x101)]
        get;
        [param: In, MarshalAs(UnmanagedType.U4)]
        [DispId(0x101)]
        set;
    }

    [DispId(0x102)]
    SelectionTypeFlags Type
    {
        [return: MarshalAs(UnmanagedType.U4)]
        [DispId(0x102)]
        get;
    }

    [DispId(0x103)]
    int MoveLeft([In, MarshalAs(UnmanagedType.U4)] UnitFlags unit, [In] int count, [In] int extend);

    [DispId(260)]
    int MoveRight([In, MarshalAs(UnmanagedType.U4)] UnitFlags unit, [In] int count, [In] int extend);

    [DispId(0x105)]
    int MoveUp([In, MarshalAs(UnmanagedType.U4)] UnitFlags unit, [In] int count, [In] int extend);

    [DispId(0x106)]
    int MoveDown([In, MarshalAs(UnmanagedType.U4)] UnitFlags unit, [In] int count, [In] int extend);

    [DispId(0x107)]
    int HomeKey([In, MarshalAs(UnmanagedType.U4)] UnitFlags unit, [In] int extend);

    [DispId(0x108)]
    int EndKey([In, MarshalAs(UnmanagedType.U4)] UnitFlags unit, [In] int extend);

    [DispId(0x109)]
    void TypeText([In, MarshalAs(UnmanagedType.BStr)] string text);
}