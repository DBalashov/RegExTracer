namespace Nabu.Forms.TextObjectModel;

public enum DocumentOpenSaveFlags
{
    FormatHTML           = 3,
    FormatRTF            = 1,
    FormatText           = 2,
    FormatWordDocument   = 4,
    ModeCreateAlways     = 0x20,
    ModeCreateNew        = 0x10,
    ModeOpenAlways       = 0x40,
    ModeOpenExisting     = 0x30,
    ModePasteFile        = 0x1000,
    ModeReadOnly         = 0x100,
    ModeShareDenyRead    = 0x200,
    ModeShareDenyWrite   = 0x400,
    ModeTruncateExisting = 80
}