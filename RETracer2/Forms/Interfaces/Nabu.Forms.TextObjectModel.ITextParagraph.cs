using System.Runtime.InteropServices;

namespace Nabu.Forms.TextObjectModel;

[ComImport, Guid("8CC497C4-A1DF-11CE-8098-00AA0047BE5D"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
public interface ITextParagraph
{
    [DispId(0)]
    ITextParagraph Duplicate
    {
        [return: MarshalAs(UnmanagedType.Interface)]
        [DispId(0)]
        get;
        [param: In, MarshalAs(UnmanagedType.Interface)]
        [DispId(0)]
        set;
    }

    [DispId(0x401)]
    int CanChange();

    [DispId(0x402)]
    int IsEqual([In, MarshalAs(UnmanagedType.Interface)] ITextParagraph textParagraph);

    [DispId(0x403)]
    void Reset([In, MarshalAs(UnmanagedType.U4)] ResetFlags value);

    [DispId(            0x404)]
    int Style { [DispId(0x404)] get; [param: In] [DispId(0x404)] set; }

    [DispId(0x405)]
    AlignmentFlags Alignment
    {
        [return: MarshalAs(UnmanagedType.U4)]
        [DispId(0x405)]
        get;
        [param: In, MarshalAs(UnmanagedType.U4)]
        [DispId(0x405)]
        set;
    }

    [DispId(0x406)]
    FormatFlags Hyphenation
    {
        [return: MarshalAs(UnmanagedType.U4)]
        [DispId(0x406)]
        get;
        [param: In, MarshalAs(UnmanagedType.U4)]
        [DispId(0x406)]
        set;
    }

    [DispId(                        0x407)]
    float FirstLineIndent { [DispId(0x407)] get; }

    [DispId(0x408)]
    FormatFlags KeepTogether
    {
        [return: MarshalAs(UnmanagedType.U4)]
        [DispId(0x408)]
        get;
        [param: In, MarshalAs(UnmanagedType.U4)]
        [DispId(0x408)]
        set;
    }

    [DispId(0x409)]
    FormatFlags KeepWithNext
    {
        [return: MarshalAs(UnmanagedType.U4)]
        [DispId(0x409)]
        get;
        [param: In, MarshalAs(UnmanagedType.U4)]
        [DispId(0x409)]
        set;
    }

    [DispId(                   0x410)]
    float LeftIndent { [DispId(0x410)] get; }

    [DispId(                    0x411)]
    float LineSpacing { [DispId(0x411)] get; }

    [DispId(0x412)]
    LineSpacingFlags LineSpacingRule
    {
        [return: MarshalAs(UnmanagedType.U4)]
        [DispId(0x412)]
        get;
    }

    [DispId(0x413)]
    AlignmentFlags ListAlignment
    {
        [return: MarshalAs(UnmanagedType.U4)]
        [DispId(0x413)]
        get;
        [param: In, MarshalAs(UnmanagedType.U4)]
        [DispId(0x413)]
        set;
    }

    [DispId(                     0x414)]
    int ListLevelIndex { [DispId(0x414)] get; [param: In] [DispId(0x414)] set; }

    [DispId(                0x415)]
    int ListStart { [DispId(0x415)] get; [param: In] [DispId(0x415)] set; }

    [DispId(                0x416)]
    float ListTab { [DispId(0x416)] get; [param: In] [DispId(0x416)] set; }

    [DispId(0x417)]
    ListTypeFlags ListType
    {
        [return: MarshalAs(UnmanagedType.U4)]
        [DispId(0x417)]
        get;
        [param: In, MarshalAs(UnmanagedType.U4)]
        [DispId(0x417)]
        set;
    }

    [DispId(0x418)]
    FormatFlags NoLineNumber
    {
        [return: MarshalAs(UnmanagedType.U4)]
        [DispId(0x418)]
        get;
        [param: In, MarshalAs(UnmanagedType.U4)]
        [DispId(0x418)]
        set;
    }

    [DispId(0x419)]
    FormatFlags PageBreakBefore
    {
        [return: MarshalAs(UnmanagedType.U4)]
        [DispId(0x419)]
        get;
        [param: In, MarshalAs(UnmanagedType.U4)]
        [DispId(0x419)]
        set;
    }

    [DispId(                    0x420)]
    float RightIndent { [DispId(0x420)] get; [param: In] [DispId(0x420)] set; }

    [DispId(0x421)]
    void SetIndents([In] float StartIndent, [In] float LeftIndent, [In] float RightIndent);

    [DispId(0x422)]
    void SetLineSpacing([In, MarshalAs(UnmanagedType.U4)] LineSpacingFlags LineSpacingRule, [In] float LineSpacing);

    [DispId(                   0x423)]
    float SpaceAfter { [DispId(0x423)] get; [param: In] [DispId(0x423)] set; }

    [DispId(                    0x424)]
    float SpaceBefore { [DispId(0x424)] get; [param: In] [DispId(0x424)] set; }

    [DispId(0x425)]
    FormatFlags WidowControl
    {
        [return: MarshalAs(UnmanagedType.U4)]
        [DispId(0x425)]
        get;
        [param: In, MarshalAs(UnmanagedType.U4)]
        [DispId(0x425)]
        set;
    }

    [DispId(               0x426)]
    int TabCount { [DispId(0x426)] get; }

    [DispId(0x427)]
    void AddTab([In] float position, [In, MarshalAs(UnmanagedType.U4)] AlignmentFlags alignment, [In, MarshalAs(UnmanagedType.U4)] TabLeaderFlags leader);

    [DispId(0x428)]
    void ClearAllTabs();

    [DispId(0x429)]
    void DeleteTab([In] float position);

    [DispId(0x430)]
    void GetTab([In] int index, out float position, [MarshalAs(UnmanagedType.U4)] out AlignmentFlags alignment, [MarshalAs(UnmanagedType.U4)] out TabLeaderFlags leader);
}