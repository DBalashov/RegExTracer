using System.Collections;
using System.Runtime.InteropServices;

#pragma warning disable CS0108, CS0114

// ReSharper disable UnusedMember.Global

namespace Nabu.Forms.TextObjectModel;

[ComImport, Guid("8CC497C5-A1DF-11CE-8098-00AA0047BE5D"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
public interface ITextStoryRanges : IEnumerable
{
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "", MarshalCookie = "")]
    [DispId(-4), TypeLibFunc((short) 1)]
    IEnumerator GetEnumerator();

    [return: MarshalAs(UnmanagedType.Interface)]
    [DispId(0)]
    ITextRange Item([In] int index);

    [DispId(            2)]
    int Count { [DispId(2)] get; }
}