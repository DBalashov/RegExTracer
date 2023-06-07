using System.Xml.Serialization;

#pragma warning disable CS8618

namespace RegExTracer;

[XmlRoot(ElementName = "regex_document")]
public class RegExDocument
{
    public RegExDocument()
    {
    }

    public RegExDocument(string regexValue,        string inputValue,      int  inputLineBreak,         bool optionECMAScript, bool optionSingleLine, bool optionExplicitCapture, bool optionIgnoreCase,
                         bool   optionRightToLeft, bool   optionMultiline, bool optionCultureInvariant, bool optionIgnoreWhitespace)
    {
        RegExValue             = regexValue;
        InputValue             = inputValue;
        InputLineBreak         = inputLineBreak;
        OptionECMAScript       = optionECMAScript;
        OptionSingleLine       = optionSingleLine;
        OptionExplicitCapture  = optionExplicitCapture;
        OptionIgnoreCase       = optionIgnoreCase;
        OptionRightToLeft      = optionRightToLeft;
        OptionMultiline        = optionMultiline;
        OptionCultureInvariant = optionCultureInvariant;
        OptionIgnoreWhitespace = optionIgnoreWhitespace;
    }

    [XmlElement("input_line_break")]
    public int InputLineBreak { get; set; }

    [XmlElement("input_value")]
    public string InputValue { get; set; }

    [XmlElement("option_culture_invariant")]
    public bool OptionCultureInvariant { get; set; }

    [XmlElement("option_ecma_script")]
    public bool OptionECMAScript { get; set; }

    [XmlElement("option_explicit_capture")]
    public bool OptionExplicitCapture { get; set; }

    [XmlElement("option_ignore_case")]
    public bool OptionIgnoreCase { get; set; }

    [XmlElement("option_ignore_whitespace")]
    public bool OptionIgnoreWhitespace { get; set; }

    [XmlElement("option_multiline")]
    public bool OptionMultiline { get; set; }

    [XmlElement("option_right_to_left")]
    public bool OptionRightToLeft { get; set; }

    [XmlElement("option_single_line")]
    public bool OptionSingleLine { get; set; }

    [XmlElement("regex_value")]
    public string RegExValue { get; set; }
}