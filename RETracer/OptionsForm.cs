using RegExTracer;

namespace RETracer;

public partial class OptionsForm : Form
{
    readonly Settings _settings;

    public OptionsForm(Settings settings)
    {
        InitializeComponent();

        _settings              = settings;
        _labelColor.ForeColor  = Color.FromArgb(_settings.ForeColor);
        _labelColor.BackColor  = Color.FromArgb(_settings.BackColor);
        _numericTextSize.Value = (decimal) _settings.TextSize;
        switch (_settings.HighlighingType)
        {
            case HighlighingType.BackGround:
                _comboHighlightingType.SelectedIndex = 0;
                break;

            case HighlighingType.ForeGround:
                _comboHighlightingType.SelectedIndex = 1;
                break;
        }

        _listColorList.Items.Clear();
        foreach (var color in _settings.HighlightColorList)
            _listColorList.Items.Add(Color.FromArgb(color));

        _listColorList.Refresh();
    }

    void ButtonBackColor_Click(object sender, EventArgs e)
    {
        _colorDialog.Color = _labelColor.BackColor;
        if (_colorDialog.ShowDialog(this) != DialogResult.OK) return;
        _labelColor.BackColor = _colorDialog.Color;
        _listColorList.Refresh();
    }

    void ButtonCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    void ButtonColorAdd_Click(object sender, EventArgs e)
    {
        if (_colorDialog.ShowDialog(this) != DialogResult.OK) return;
        _listColorList.Items.Add(_colorDialog.Color);
    }

    void ButtonColorChoose_Click(object sender, EventArgs e)
    {
        _colorDialog.Color = (Color) _listColorList.Items[_listColorList.SelectedIndex];

        if (_colorDialog.ShowDialog(this) != DialogResult.OK) return;
        _listColorList.Items[_listColorList.SelectedIndex] = _colorDialog.Color;
    }

    void ButtonColorRemove_Click(object sender, EventArgs e) =>
        _listColorList.Items.RemoveAt(_listColorList.SelectedIndex);

    void ButtonForeColor_Click(object sender, EventArgs e)
    {
        _colorDialog.Color = _labelColor.ForeColor;
        if (_colorDialog.ShowDialog(this) != DialogResult.OK) return;

        _labelColor.ForeColor = _colorDialog.Color;
        _listColorList.Refresh();
    }

    void ButtonOK_Click(object sender, EventArgs e)
    {
        _settings.ForeColor = _labelColor.ForeColor.ToArgb();
        _settings.BackColor = _labelColor.BackColor.ToArgb();
        _settings.TextSize  = (float) _numericTextSize.Value;
        switch (_comboHighlightingType.SelectedIndex)
        {
            case 0:
                _settings.HighlighingType = HighlighingType.BackGround;
                break;

            case 1:
                _settings.HighlighingType = HighlighingType.ForeGround;
                break;
        }

        _settings.HighlightColorList.Clear();
        foreach (Color color in _listColorList.Items)
            _settings.HighlightColorList.Add(color.ToArgb());

        _settings.Save();
        DialogResult = DialogResult.OK;
        Close();
    }

    void ComboHighlightingType_SelectedIndexChanged(object sender, EventArgs e) =>
        _listColorList.Refresh();

    void ListColorList_DoubleClick(object sender, EventArgs e) =>
        _buttonColorChoose.PerformClick();

    void ListColorList_DrawItem(object sender, DrawItemEventArgs e)
    {
        var brush  = new SolidBrush((Color) _listColorList.Items[e.Index]);
        var brush2 = new SolidBrush(_labelColor.ForeColor);
        var brush3 = new SolidBrush(_labelColor.BackColor);
        var brush4 = new SolidBrush(_listColorList.ForeColor);
        var brush5 = new SolidBrush(_listColorList.BackColor);

        var bounds = e.Bounds;
        bounds.Inflate(-3, -3);
        RectangleF layoutRectangle = new RectangleF(bounds.X, bounds.Y, bounds.Width, bounds.Height);
        layoutRectangle.Inflate(-3f, -3f);
        switch (_comboHighlightingType.SelectedIndex)
        {
            case 0:
                e.Graphics.FillRectangle(brush, bounds);
                e.Graphics.DrawString(_labelColor.Text, e.Font!, brush2, layoutRectangle);
                break;

            case 1:
                e.Graphics.FillRectangle(brush3, bounds);
                e.Graphics.DrawString(_labelColor.Text, e.Font!, brush, layoutRectangle);
                break;
        }

        bounds = e.Bounds;
        if ((e.State & DrawItemState.Focus) == DrawItemState.Focus)
        {
            bounds.Inflate(-1, -1);
            e.Graphics.DrawRectangle(new Pen(brush4, 1f), bounds);
            bounds.Inflate(-1, -1);
            e.Graphics.DrawRectangle(new Pen(brush5, 1f), bounds);
        }
        else
        {
            bounds.Inflate(-2, -2);
            e.Graphics.DrawRectangle(new Pen(brush5, 4f), bounds);
        }
    }

    void ListColorList_MeasureItem(object sender, MeasureItemEventArgs e)
    {
        e.ItemWidth  = _listColorList.ClientRectangle.Width;
        e.ItemHeight = 12 + (2 * _listColorList.Font.Height);
    }

    void ListColorList_SelectedIndexChanged(object sender, EventArgs e)
    {
        _buttonColorChoose.Enabled = _listColorList.SelectedIndex != -1;
        _buttonColorRemove.Enabled = (_listColorList.SelectedIndex != -1) && (_listColorList.Items.Count > 1);
    }

    void NumericTextSize_ValueChanged(object sender, EventArgs e) =>
        _labelColor.Font = new Font(_labelColor.Font.FontFamily, (float) _numericTextSize.Value);
}