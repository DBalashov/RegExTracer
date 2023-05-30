using System.Runtime.InteropServices;

namespace Nabu.Forms.TextObjectModel;

[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("8CC497C2-A1DF-11CE-8098-00AA0047BE5D")]
public interface ITextRange
{
    [DispId(0)]
    string Text
    {
        [return: MarshalAs(UnmanagedType.BStr)]
        [DispId(0)]
        get;
        [param: In, MarshalAs(UnmanagedType.BStr)]
        [DispId(0)]
        set;
    }

    [DispId(           0x201)]
    int Char { [DispId(0x201)] get; [param: In] [DispId(0x201)] set; }

    [DispId(0x202)]
    ITextRange Duplicate
    {
        [return: MarshalAs(UnmanagedType.Interface)]
        [DispId(0x202)]
        get;
    }

    [DispId(0x203)]
    ITextRange FormattedText
    {
        [return: MarshalAs(UnmanagedType.Interface)]
        [DispId(0x203)]
        get;
        [param: In, MarshalAs(UnmanagedType.Interface)]
        [DispId(0x203)]
        set;
    }

    [DispId(            0x204)]
    int Start { [DispId(0x204)] get; [param: In] [DispId(0x204)] set; }

    [DispId(          0x205)]
    int End { [DispId(0x205)] get; [param: In] [DispId(0x205)] set; }

    [DispId(0x206)]
    ITextFont Font
    {
        [return: MarshalAs(UnmanagedType.Interface)]
        [DispId(0x206)]
        get;
        [param: In, MarshalAs(UnmanagedType.Interface)]
        [DispId(0x206)]
        set;
    }

    [DispId(0x207)]
    ITextParagraph Para
    {
        [return: MarshalAs(UnmanagedType.Interface)]
        [DispId(0x207)]
        get;
        [param: In, MarshalAs(UnmanagedType.Interface)]
        [DispId(0x207)]
        set;
    }

    [DispId(                  520)]
    int StoryLength { [DispId(520)] get; }

    [DispId(0x209)]
    StoryFlags StoryType
    {
        [return: MarshalAs(UnmanagedType.U4)]
        [DispId(0x209)]
        get;
    }

    [DispId(0x210)]
    void Collapse([In, MarshalAs(UnmanagedType.U4)] PositionFlags flags);

    [DispId(0x211)]
    int Expand([In, MarshalAs(UnmanagedType.U4)] UnitFlags unit);

    [DispId(530)]
    int GetIndex([In, MarshalAs(UnmanagedType.U4)] UnitFlags unit);

    [DispId(0x213)]
    void SetIndex([In, MarshalAs(UnmanagedType.U4)] UnitFlags unit, [In] int index, [In] int extend);

    [DispId(0x214)]
    void SetRange([In] int charFrom, [In] int charTo);

    [DispId(0x215)]
    int InRange([In, MarshalAs(UnmanagedType.Interface)] ITextRange textRange);

    [DispId(0x216)]
    int InStory([In, MarshalAs(UnmanagedType.Interface)] ITextRange textRange);

    [DispId(0x217)]
    int IsEqual([In, MarshalAs(UnmanagedType.Interface)] ITextRange textRange);

    [DispId(0x218)]
    void Select();

    [DispId(0x219)]
    int StartOf([In, MarshalAs(UnmanagedType.U4)] UnitFlags unit, [In] int extend);

    [DispId(0x220)]
    int EndOf([In, MarshalAs(UnmanagedType.U4)] UnitFlags unit, [In] int extend);

    [DispId(0x221)]
    int Move([In, MarshalAs(UnmanagedType.U4)] UnitFlags unit, [In] int count);

    [DispId(0x222)]
    int MoveStart([In, MarshalAs(UnmanagedType.U4)] UnitFlags unit, [In] int count);

    [DispId(0x223)]
    int MoveEnd([In, MarshalAs(UnmanagedType.U4)] UnitFlags unit, [In] int count);

    [DispId(0x224)]
    int MoveWhile([In, MarshalAs(UnmanagedType.Struct)] ref object characterSet, [In] int count);

    [DispId(0x225)]
    int MoveStartWhile([In, MarshalAs(UnmanagedType.Struct)] ref object characterSet, [In] int count);

    [DispId(550)]
    int MoveEndWhile([In, MarshalAs(UnmanagedType.Struct)] ref object characterSet, [In] int count);

    [DispId(0x227)]
    int MoveUntil([In, MarshalAs(UnmanagedType.Struct)] ref object characterSet, [In] int count);

    [DispId(0x228)]
    int MoveStartUntil([In, MarshalAs(UnmanagedType.Struct)] ref object characterSet, [In] int count);

    [DispId(0x229)]
    int MoveEndUntil([In, MarshalAs(UnmanagedType.Struct)] ref object characterSet, [In] int count);

    [DispId(560)]
    int FindText([In, MarshalAs(UnmanagedType.BStr)] string text, [In] int direction, [In, MarshalAs(UnmanagedType.U4)] FingMatchFlags flags);

    [DispId(0x231)]
    int FindTextStart([In, MarshalAs(UnmanagedType.BStr)] string text, [In] int direction, [In, MarshalAs(UnmanagedType.U4)] FingMatchFlags flags);

    [DispId(0x232)]
    int FindTextEnd([In, MarshalAs(UnmanagedType.BStr)] string text, [In] int direction, [In, MarshalAs(UnmanagedType.U4)] FingMatchFlags flags);

    [DispId(0x233)]
    int Delete([In, MarshalAs(UnmanagedType.U4)] UnitFlags unit, [In] int count);

    [DispId(0x234)]
    void Cut([MarshalAs(UnmanagedType.Struct)] out object destination);

    [DispId(0x235)]
    void Copy([MarshalAs(UnmanagedType.Struct)] out object destination);

    [DispId(0x236)]
    void Paste([In, MarshalAs(UnmanagedType.Struct)] ref object source, [In] int clipboardFormat);

    [DispId(0x237)]
    int CanPaste([In, MarshalAs(UnmanagedType.Struct)] ref object source, [In] int clipboardFormat);

    [DispId(0x238)]
    int CanEdit();

    [DispId(0x239)]
    void ChangeCase([In, MarshalAs(UnmanagedType.U4)] CaseFlags flags);

    [DispId(0x240)]
    void GetPoint([In, MarshalAs(UnmanagedType.U4)] PositionFlags flags, out int px, out int py);

    [DispId(0x241)]
    void SetPoint([In] int x, [In] int y, [In, MarshalAs(UnmanagedType.U4)] PositionFlags flags, [In] int extend);

    [DispId(0x242)]
    void ScrollIntoView([In, MarshalAs(UnmanagedType.U4)] PositionFlags flags);

    [return: MarshalAs(UnmanagedType.IUnknown)]
    [DispId(0x243)]
    object GetEmbeddedObject();
}