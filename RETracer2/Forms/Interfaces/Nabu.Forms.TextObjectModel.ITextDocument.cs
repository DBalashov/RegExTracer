using System.Runtime.InteropServices;

namespace Nabu.Forms.TextObjectModel;

[ComImport, Guid("8CC497C0-A1DF-11CE-8098-00AA0047BE5D"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
public interface ITextDocument
{
    [DispId(0)]
    string Name
    {
        [return: MarshalAs(UnmanagedType.BStr)]
        [DispId(0)]
        get;
    }

    [DispId(1)]
    ITextSelection Selection
    {
        [return: MarshalAs(UnmanagedType.Interface)]
        [DispId(1)]
        get;
    }

    [DispId(                 2)]
    int StoryCount { [DispId(2)] get; }

    [DispId(3)]
    ITextStoryRanges StoryRanges
    {
        [return: MarshalAs(UnmanagedType.Interface)]
        [DispId(3)]
        get;
    }

    [DispId(            4)]
    int Saved { [DispId(4)] get; [param: In] [DispId(4)] set; }

    [DispId(                       5)]
    float DefaultTabStop { [DispId(5)] get; [param: In] [DispId(5)] set; }

    [DispId(6)]
    void New();

    [DispId(7)]
    void Open([In, MarshalAs(UnmanagedType.Struct)] ref object source, [In, MarshalAs(UnmanagedType.U4)] DocumentOpenSaveFlags flags, [In] int codePage);

    [DispId(8)]
    void Save([In, MarshalAs(UnmanagedType.Struct)] ref object destination, [In, MarshalAs(UnmanagedType.U4)] DocumentOpenSaveFlags flags, [In] int codePage);

    [DispId(9)]
    int Freeze();

    [DispId(10)]
    int Unfreeze();

    [DispId(11)]
    void BeginEditCollection();

    [DispId(12)]
    void EndEditCollection();

    [DispId(13)]
    int Undo([In] int count);

    [DispId(14)]
    int Redo([In] int count);

    [return: MarshalAs(UnmanagedType.Interface)]
    [DispId(15)]
    ITextRange Range([In] int charFrom, [In] int charTo);

    [return: MarshalAs(UnmanagedType.Interface)]
    [DispId(0x10)]
    ITextRange RangeFromPoint([In] int x, [In] int y);
}