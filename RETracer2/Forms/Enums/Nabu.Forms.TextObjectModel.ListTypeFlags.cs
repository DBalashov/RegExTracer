namespace Nabu.Forms.TextObjectModel;

public enum ListTypeFlags
{
    ListBullet           = 1,
    ListNone             = 0,
    ListNumberAsArabic   = 2,
    ListNumberAsLCLetter = 3,
    ListNumberAsLCRoman  = 5,
    ListNumberAsSequence = 7,
    ListNumberAsUCLetter = 4,
    ListNumberAsUCRoman  = 6,
    ListParentheses      = 0x10000,
    ListPeriod           = 0x20000,
    ListPlain            = 0x30000
}