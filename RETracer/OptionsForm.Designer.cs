using System.ComponentModel;

namespace RETracer;

partial class OptionsForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    private Button        _buttonBackColor;
    private Button        _buttonCancel;
    private Button        _buttonColorAdd;
    private Button        _buttonColorChoose;
    private Button        _buttonColorRemove;
    private Button        _buttonForeColor;
    private Button        _buttonOK;
    private ColorDialog   _colorDialog;
    private ComboBox      _comboHighlightingType;
    private GroupBox      _groupGeneral;
    private GroupBox      _groupHighlighting;
    private Label         _labelColor;
    private Label         _labelHighlightingType;
    private Label         _labelTextSize;
    private ListBox       _listColorList;
    private NumericUpDown _numericTextSize;
    
    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components    = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize    = new System.Drawing.Size(800, 450);
        this.Text          = "OptionsForm";
        
        ComponentResourceManager manager = new ComponentResourceManager(typeof(OptionsForm));
            this._buttonCancel = new Button();
            this._buttonOK = new Button();
            this._buttonColorChoose = new Button();
            this._buttonColorRemove = new Button();
            this._buttonColorAdd = new Button();
            this._listColorList = new ListBox();
            this._colorDialog = new ColorDialog();
            this._groupGeneral = new GroupBox();
            this._labelTextSize = new Label();
            this._numericTextSize = new NumericUpDown();
            this._buttonForeColor = new Button();
            this._buttonBackColor = new Button();
            this._labelColor = new Label();
            this._groupHighlighting = new GroupBox();
            this._comboHighlightingType = new ComboBox();
            this._labelHighlightingType = new Label();
            this._groupGeneral.SuspendLayout();
            this._numericTextSize.BeginInit();
            this._groupHighlighting.SuspendLayout();
            base.SuspendLayout();
            this._buttonCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this._buttonCancel.Location = new Point(530, 0x197);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new Size(90, 0x17);
            this._buttonCancel.TabIndex = 3;
            this._buttonCancel.Text = "Cancel";
            this._buttonCancel.UseVisualStyleBackColor = true;
            this._buttonCancel.Click += new EventHandler(this.ButtonCancel_Click);
            this._buttonOK.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this._buttonOK.Location = new Point(0x1b2, 0x197);
            this._buttonOK.Name = "_buttonOK";
            this._buttonOK.Size = new Size(90, 0x17);
            this._buttonOK.TabIndex = 2;
            this._buttonOK.Text = "OK";
            this._buttonOK.UseVisualStyleBackColor = true;
            this._buttonOK.Click += new EventHandler(this.ButtonOK_Click);
            this._buttonColorChoose.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this._buttonColorChoose.Location = new Point(0x1a0, 0xfb);
            this._buttonColorChoose.Name = "_buttonColorChoose";
            this._buttonColorChoose.Size = new Size(90, 0x17);
            this._buttonColorChoose.TabIndex = 4;
            this._buttonColorChoose.Text = "Choose…";
            this._buttonColorChoose.UseVisualStyleBackColor = true;
            this._buttonColorChoose.Click += new EventHandler(this.ButtonColorChoose_Click);
            this._buttonColorRemove.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this._buttonColorRemove.Location = new Point(0x200, 0xfb);
            this._buttonColorRemove.Name = "_buttonColorRemove";
            this._buttonColorRemove.Size = new Size(90, 0x17);
            this._buttonColorRemove.TabIndex = 5;
            this._buttonColorRemove.Text = "Remove";
            this._buttonColorRemove.UseVisualStyleBackColor = true;
            this._buttonColorRemove.Click += new EventHandler(this.ButtonColorRemove_Click);
            this._buttonColorAdd.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this._buttonColorAdd.Location = new Point(320, 0xfb);
            this._buttonColorAdd.Name = "_buttonColorAdd";
            this._buttonColorAdd.Size = new Size(90, 0x17);
            this._buttonColorAdd.TabIndex = 3;
            this._buttonColorAdd.Text = "Add…";
            this._buttonColorAdd.UseVisualStyleBackColor = true;
            this._buttonColorAdd.Click += new EventHandler(this.ButtonColorAdd_Click);
            this._listColorList.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this._listColorList.DrawMode = DrawMode.OwnerDrawVariable;
            this._listColorList.Font = new Font("Lucida Console", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xcc);
            this._listColorList.FormattingEnabled = true;
            this._listColorList.IntegralHeight = false;
            this._listColorList.Location = new Point(6, 0x2e);
            this._listColorList.Name = "_listColorList";
            this._listColorList.Size = new Size(0x254, 0xc7);
            this._listColorList.TabIndex = 2;
            this._listColorList.DrawItem += new DrawItemEventHandler(this.ListColorList_DrawItem);
            this._listColorList.DoubleClick += new EventHandler(this.ListColorList_DoubleClick);
            this._listColorList.SelectedIndexChanged += new EventHandler(this.ListColorList_SelectedIndexChanged);
            this._listColorList.MeasureItem += new MeasureItemEventHandler(this.ListColorList_MeasureItem);
            this._colorDialog.AnyColor = true;
            this._colorDialog.FullOpen = true;
            this._groupGeneral.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this._groupGeneral.Controls.Add(this._labelTextSize);
            this._groupGeneral.Controls.Add(this._numericTextSize);
            this._groupGeneral.Controls.Add(this._buttonForeColor);
            this._groupGeneral.Controls.Add(this._buttonBackColor);
            this._groupGeneral.Controls.Add(this._labelColor);
            this._groupGeneral.Location = new Point(12, 12);
            this._groupGeneral.Name = "_groupGeneral";
            this._groupGeneral.Size = new Size(0x260, 0x67);
            this._groupGeneral.TabIndex = 0;
            this._groupGeneral.TabStop = false;
            this._groupGeneral.Text = "General";
            this._labelTextSize.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this._labelTextSize.Location = new Point(0x1e2, 0x4a);
            this._labelTextSize.Name = "_labelTextSize";
            this._labelTextSize.Size = new Size(60, 0x17);
            this._labelTextSize.TabIndex = 3;
            this._labelTextSize.Text = "Text Size";
            this._labelTextSize.TextAlign = ContentAlignment.MiddleLeft;
            this._numericTextSize.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this._numericTextSize.DecimalPlaces = 1;
            this._numericTextSize.Location = new Point(0x224, 0x4d);
            int[] bits = new int[4];
            bits[0] = 0x24;
            this._numericTextSize.Maximum = new decimal(bits);
            int[] numArray2 = new int[4];
            numArray2[0] = 6;
            this._numericTextSize.Minimum = new decimal(numArray2);
            this._numericTextSize.Name = "_numericTextSize";
            this._numericTextSize.Size = new Size(0x37, 20);
            this._numericTextSize.TabIndex = 4;
            this._numericTextSize.TextAlign = HorizontalAlignment.Right;
            int[] numArray3 = new int[4];
            numArray3[0] = 6;
            this._numericTextSize.Value = new decimal(numArray3);
            this._numericTextSize.ValueChanged += new EventHandler(this.NumericTextSize_ValueChanged);
            this._buttonForeColor.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this._buttonForeColor.Location = new Point(0x1e2, 0x13);
            this._buttonForeColor.Name = "_buttonForeColor";
            this._buttonForeColor.Size = new Size(120, 0x17);
            this._buttonForeColor.TabIndex = 1;
            this._buttonForeColor.Text = "Foreground Color…";
            this._buttonForeColor.UseVisualStyleBackColor = true;
            this._buttonForeColor.Click += new EventHandler(this.ButtonForeColor_Click);
            this._buttonBackColor.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this._buttonBackColor.Location = new Point(0x1e2, 0x30);
            this._buttonBackColor.Name = "_buttonBackColor";
            this._buttonBackColor.Size = new Size(120, 0x17);
            this._buttonBackColor.TabIndex = 2;
            this._buttonBackColor.Text = "Background Color…";
            this._buttonBackColor.UseVisualStyleBackColor = true;
            this._buttonBackColor.Click += new EventHandler(this.ButtonBackColor_Click);
            this._labelColor.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this._labelColor.BorderStyle = BorderStyle.FixedSingle;
            this._labelColor.Font = new Font("Lucida Console", 10f);
            this._labelColor.Location = new Point(6, 0x13);
            this._labelColor.Margin = new Padding(3);
            this._labelColor.Name = "_labelColor";
            this._labelColor.Size = new Size(470, 0x4e);
            this._labelColor.TabIndex = 0;
            this._labelColor.Text = "The quick brown fox jumps over the lazy dog.\r\nСъешь ещё этих мягких французских булок, да выпей же чаю.";
            this._labelColor.TextAlign = ContentAlignment.MiddleCenter;
            this._groupHighlighting.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this._groupHighlighting.Controls.Add(this._comboHighlightingType);
            this._groupHighlighting.Controls.Add(this._labelHighlightingType);
            this._groupHighlighting.Controls.Add(this._listColorList);
            this._groupHighlighting.Controls.Add(this._buttonColorRemove);
            this._groupHighlighting.Controls.Add(this._buttonColorAdd);
            this._groupHighlighting.Controls.Add(this._buttonColorChoose);
            this._groupHighlighting.Location = new Point(12, 0x79);
            this._groupHighlighting.Name = "_groupHighlighting";
            this._groupHighlighting.Size = new Size(0x260, 280);
            this._groupHighlighting.TabIndex = 1;
            this._groupHighlighting.TabStop = false;
            this._groupHighlighting.Text = "Highlighting";
            this._comboHighlightingType.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this._comboHighlightingType.DropDownStyle = ComboBoxStyle.DropDownList;
            this._comboHighlightingType.FormattingEnabled = true;
            this._comboHighlightingType.Items.AddRange(new object[] { "Constant text color, different background color.", "Different text color, constant background color." });
            this._comboHighlightingType.Location = new Point(0x34, 0x13);
            this._comboHighlightingType.Name = "_comboHighlightingType";
            this._comboHighlightingType.Size = new Size(550, 0x15);
            this._comboHighlightingType.TabIndex = 1;
            this._comboHighlightingType.SelectedIndexChanged += new EventHandler(this.ComboHighlightingType_SelectedIndexChanged);
            this._labelHighlightingType.Location = new Point(6, 0x10);
            this._labelHighlightingType.Name = "_labelHighlightingType";
            this._labelHighlightingType.Size = new Size(40, 0x17);
            this._labelHighlightingType.TabIndex = 0;
            this._labelHighlightingType.Text = "Type";
            this._labelHighlightingType.TextAlign = ContentAlignment.MiddleLeft;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            //base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x278, 0x1ba);
            base.Controls.Add(this._groupHighlighting);
            base.Controls.Add(this._groupGeneral);
            base.Controls.Add(this._buttonOK);
            base.Controls.Add(this._buttonCancel);
            //base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "FormToolsOptions";
            base.ShowInTaskbar = false;
            //base.SizeGripStyle = SizeGripStyle.Show;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Options";
            this._groupGeneral.ResumeLayout(false);
            this._numericTextSize.EndInit();
            this._groupHighlighting.ResumeLayout(false);
            base.ResumeLayout(false);
    }

    #endregion
}