namespace Nabu.Forms.TextObjectModel;

public enum SelectionFlags
{
    SelActive      = 8,
    SelAtEOL       = 2,
    SelOvertype    = 4,
    SelReplace     = 0x10,
    SelStartActive = 1
}