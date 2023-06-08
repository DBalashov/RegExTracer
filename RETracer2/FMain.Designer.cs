namespace RETracer2;

partial class FMain
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
        _split_Re_IR = new SplitContainer();
        splitContainer2 = new SplitContainer();
        gbREGEX = new GroupBox();
        panel1 = new Panel();
        txPATTERN = new Nabu.Forms.RichTextBoxEx(components);
        _tableLayoutOptions = new TableLayoutPanel();
        cbWORDWRAP = new CheckBox();
        cbNOBACK = new CheckBox();
        cbECMA = new CheckBox();
        cbIGNORE_CASE = new CheckBox();
        cbSINGLE_LINE = new CheckBox();
        cbLINE_BREAKS = new CheckBox();
        cbMULTILINE = new CheckBox();
        cbEXPLICIT = new CheckBox();
        _split_I_R = new SplitContainer();
        gbINPUT = new GroupBox();
        panel2 = new Panel();
        txINPUT = new Nabu.Forms.RichTextBoxEx(components);
        groupBox4 = new GroupBox();
        lvRESULT = new ListView();
        ((System.ComponentModel.ISupportInitialize) _split_Re_IR).BeginInit();
        _split_Re_IR.Panel1.SuspendLayout();
        _split_Re_IR.Panel2.SuspendLayout();
        _split_Re_IR.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize) splitContainer2).BeginInit();
        splitContainer2.Panel1.SuspendLayout();
        splitContainer2.Panel2.SuspendLayout();
        splitContainer2.SuspendLayout();
        gbREGEX.SuspendLayout();
        panel1.SuspendLayout();
        _tableLayoutOptions.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize) _split_I_R).BeginInit();
        _split_I_R.Panel1.SuspendLayout();
        _split_I_R.Panel2.SuspendLayout();
        _split_I_R.SuspendLayout();
        gbINPUT.SuspendLayout();
        panel2.SuspendLayout();
        groupBox4.SuspendLayout();
        SuspendLayout();
        // 
        // _split_Re_IR
        // 
        _split_Re_IR.Dock = DockStyle.Fill;
        _split_Re_IR.FixedPanel = FixedPanel.Panel1;
        _split_Re_IR.Location = new Point(0, 0);
        _split_Re_IR.Name = "_split_Re_IR";
        _split_Re_IR.Orientation = Orientation.Horizontal;
        // 
        // _split_Re_IR.Panel1
        // 
        _split_Re_IR.Panel1.Controls.Add(splitContainer2);
        _split_Re_IR.Panel1.Padding = new Padding(4, 0, 4, 0);
        // 
        // _split_Re_IR.Panel2
        // 
        _split_Re_IR.Panel2.Controls.Add(_split_I_R);
        _split_Re_IR.Size = new Size(2529, 1412);
        _split_Re_IR.SplitterDistance = 156;
        _split_Re_IR.SplitterWidth = 3;
        _split_Re_IR.TabIndex = 2;
        // 
        // splitContainer2
        // 
        splitContainer2.Dock = DockStyle.Fill;
        splitContainer2.FixedPanel = FixedPanel.Panel2;
        splitContainer2.Location = new Point(4, 0);
        splitContainer2.Name = "splitContainer2";
        // 
        // splitContainer2.Panel1
        // 
        splitContainer2.Panel1.Controls.Add(gbREGEX);
        // 
        // splitContainer2.Panel2
        // 
        splitContainer2.Panel2.Controls.Add(_tableLayoutOptions);
        splitContainer2.Size = new Size(2521, 156);
        splitContainer2.SplitterDistance = 2100;
        splitContainer2.TabIndex = 13;
        // 
        // gbREGEX
        // 
        gbREGEX.Controls.Add(panel1);
        gbREGEX.Dock = DockStyle.Fill;
        gbREGEX.Font = new Font("JetBrains Mono", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        gbREGEX.Location = new Point(0, 0);
        gbREGEX.Name = "gbREGEX";
        gbREGEX.Size = new Size(2100, 156);
        gbREGEX.TabIndex = 12;
        gbREGEX.TabStop = false;
        gbREGEX.Text = " Regular Expression ";
        // 
        // panel1
        // 
        panel1.Controls.Add(txPATTERN);
        panel1.Dock = DockStyle.Fill;
        panel1.Location = new Point(3, 29);
        panel1.Name = "panel1";
        panel1.Size = new Size(2094, 124);
        panel1.TabIndex = 0;
        // 
        // txPATTERN
        // 
        txPATTERN.BorderStyle = BorderStyle.None;
        txPATTERN.DetectUrls = false;
        txPATTERN.Dock = DockStyle.Fill;
        txPATTERN.Font = new Font("JetBrains Mono", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        txPATTERN.HideSelection = false;
        txPATTERN.Location = new Point(0, 0);
        txPATTERN.MaxLength = 32768;
        txPATTERN.Name = "txPATTERN";
        txPATTERN.Size = new Size(2094, 124);
        txPATTERN.TabIndex = 4;
        txPATTERN.Text = "(\\S{4,6})(\\s+)(\\S+)";
        txPATTERN.WordWrap = false;
        txPATTERN.SelectionChanged += txPATTERN_SelectionChanged;
        txPATTERN.TextChanged += txPATTERN_TextChanged;
        // 
        // _tableLayoutOptions
        // 
        _tableLayoutOptions.ColumnCount = 2;
        _tableLayoutOptions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        _tableLayoutOptions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        _tableLayoutOptions.Controls.Add(cbWORDWRAP, 0, 4);
        _tableLayoutOptions.Controls.Add(cbNOBACK, 0, 4);
        _tableLayoutOptions.Controls.Add(cbECMA, 0, 0);
        _tableLayoutOptions.Controls.Add(cbIGNORE_CASE, 3, 0);
        _tableLayoutOptions.Controls.Add(cbSINGLE_LINE, 1, 0);
        _tableLayoutOptions.Controls.Add(cbLINE_BREAKS, 2, 1);
        _tableLayoutOptions.Controls.Add(cbMULTILINE, 1, 1);
        _tableLayoutOptions.Controls.Add(cbEXPLICIT, 2, 0);
        _tableLayoutOptions.Dock = DockStyle.Fill;
        _tableLayoutOptions.Font = new Font("JetBrains Mono", 8.999999F, FontStyle.Regular, GraphicsUnit.Point);
        _tableLayoutOptions.Location = new Point(0, 0);
        _tableLayoutOptions.Margin = new Padding(0);
        _tableLayoutOptions.Name = "_tableLayoutOptions";
        _tableLayoutOptions.RowCount = 5;
        _tableLayoutOptions.RowStyles.Add(new RowStyle());
        _tableLayoutOptions.RowStyles.Add(new RowStyle());
        _tableLayoutOptions.RowStyles.Add(new RowStyle());
        _tableLayoutOptions.RowStyles.Add(new RowStyle());
        _tableLayoutOptions.RowStyles.Add(new RowStyle());
        _tableLayoutOptions.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        _tableLayoutOptions.Size = new Size(417, 156);
        _tableLayoutOptions.TabIndex = 11;
        // 
        // cbWORDWRAP
        // 
        cbWORDWRAP.Dock = DockStyle.Fill;
        cbWORDWRAP.Location = new Point(3, 114);
        cbWORDWRAP.Name = "cbWORDWRAP";
        cbWORDWRAP.Size = new Size(202, 39);
        cbWORDWRAP.TabIndex = 9;
        cbWORDWRAP.Text = "Word wrap";
        cbWORDWRAP.UseVisualStyleBackColor = true;
        cbWORDWRAP.CheckedChanged += cbWORDWRAP_CheckedChanged;
        // 
        // cbNOBACK
        // 
        cbNOBACK.Dock = DockStyle.Fill;
        cbNOBACK.Location = new Point(211, 114);
        cbNOBACK.Name = "cbNOBACK";
        cbNOBACK.Size = new Size(203, 39);
        cbNOBACK.TabIndex = 8;
        cbNOBACK.Text = "No backtrack";
        cbNOBACK.UseVisualStyleBackColor = true;
        cbNOBACK.CheckedChanged += cbECMA_CheckedChanged;
        // 
        // cbECMA
        // 
        cbECMA.Dock = DockStyle.Fill;
        cbECMA.Location = new Point(3, 3);
        cbECMA.Name = "cbECMA";
        cbECMA.Size = new Size(202, 31);
        cbECMA.TabIndex = 0;
        cbECMA.Text = "ECMA syntax";
        cbECMA.UseVisualStyleBackColor = true;
        cbECMA.CheckedChanged += cbECMA_CheckedChanged;
        // 
        // cbIGNORE_CASE
        // 
        cbIGNORE_CASE.Dock = DockStyle.Fill;
        cbIGNORE_CASE.Location = new Point(211, 40);
        cbIGNORE_CASE.Name = "cbIGNORE_CASE";
        cbIGNORE_CASE.Size = new Size(203, 31);
        cbIGNORE_CASE.TabIndex = 3;
        cbIGNORE_CASE.Text = "Ignore case";
        cbIGNORE_CASE.UseVisualStyleBackColor = true;
        cbIGNORE_CASE.CheckedChanged += cbECMA_CheckedChanged;
        // 
        // cbSINGLE_LINE
        // 
        cbSINGLE_LINE.Dock = DockStyle.Fill;
        cbSINGLE_LINE.Location = new Point(211, 3);
        cbSINGLE_LINE.Name = "cbSINGLE_LINE";
        cbSINGLE_LINE.Size = new Size(203, 31);
        cbSINGLE_LINE.TabIndex = 1;
        cbSINGLE_LINE.Text = "Single line";
        cbSINGLE_LINE.UseVisualStyleBackColor = true;
        cbSINGLE_LINE.CheckedChanged += cbECMA_CheckedChanged;
        // 
        // cbLINE_BREAKS
        // 
        cbLINE_BREAKS.Dock = DockStyle.Fill;
        cbLINE_BREAKS.Location = new Point(211, 77);
        cbLINE_BREAKS.Name = "cbLINE_BREAKS";
        cbLINE_BREAKS.Size = new Size(203, 31);
        cbLINE_BREAKS.TabIndex = 6;
        cbLINE_BREAKS.Text = "Line breaks";
        cbLINE_BREAKS.UseVisualStyleBackColor = true;
        cbLINE_BREAKS.CheckedChanged += cbECMA_CheckedChanged;
        // 
        // cbMULTILINE
        // 
        cbMULTILINE.Dock = DockStyle.Fill;
        cbMULTILINE.Location = new Point(3, 77);
        cbMULTILINE.Name = "cbMULTILINE";
        cbMULTILINE.Size = new Size(202, 31);
        cbMULTILINE.TabIndex = 5;
        cbMULTILINE.Text = "Multiline RegEx";
        cbMULTILINE.UseVisualStyleBackColor = true;
        cbMULTILINE.CheckedChanged += cbECMA_CheckedChanged;
        // 
        // cbEXPLICIT
        // 
        cbEXPLICIT.Dock = DockStyle.Fill;
        cbEXPLICIT.Location = new Point(3, 40);
        cbEXPLICIT.Name = "cbEXPLICIT";
        cbEXPLICIT.Size = new Size(202, 31);
        cbEXPLICIT.TabIndex = 2;
        cbEXPLICIT.Text = "Explicit groups";
        cbEXPLICIT.UseVisualStyleBackColor = true;
        cbEXPLICIT.CheckedChanged += cbECMA_CheckedChanged;
        // 
        // _split_I_R
        // 
        _split_I_R.Dock = DockStyle.Fill;
        _split_I_R.Location = new Point(0, 0);
        _split_I_R.Name = "_split_I_R";
        _split_I_R.Orientation = Orientation.Horizontal;
        // 
        // _split_I_R.Panel1
        // 
        _split_I_R.Panel1.Controls.Add(gbINPUT);
        _split_I_R.Panel1.Padding = new Padding(4, 0, 4, 0);
        // 
        // _split_I_R.Panel2
        // 
        _split_I_R.Panel2.Controls.Add(groupBox4);
        _split_I_R.Panel2.Padding = new Padding(4, 0, 4, 0);
        _split_I_R.Size = new Size(2529, 1253);
        _split_I_R.SplitterDistance = 666;
        _split_I_R.SplitterWidth = 3;
        _split_I_R.TabIndex = 0;
        // 
        // gbINPUT
        // 
        gbINPUT.Controls.Add(panel2);
        gbINPUT.Dock = DockStyle.Fill;
        gbINPUT.Font = new Font("JetBrains Mono", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        gbINPUT.Location = new Point(4, 0);
        gbINPUT.Name = "gbINPUT";
        gbINPUT.Size = new Size(2521, 666);
        gbINPUT.TabIndex = 3;
        gbINPUT.TabStop = false;
        gbINPUT.Text = "Input";
        // 
        // panel2
        // 
        panel2.Controls.Add(txINPUT);
        panel2.Dock = DockStyle.Fill;
        panel2.Location = new Point(3, 29);
        panel2.Name = "panel2";
        panel2.Size = new Size(2515, 634);
        panel2.TabIndex = 0;
        // 
        // txINPUT
        // 
        txINPUT.BorderStyle = BorderStyle.None;
        txINPUT.DetectUrls = false;
        txINPUT.Dock = DockStyle.Fill;
        txINPUT.Font = new Font("JetBrains Mono", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        txINPUT.HideSelection = false;
        txINPUT.Location = new Point(0, 0);
        txINPUT.MaxLength = 32768;
        txINPUT.Name = "txINPUT";
        txINPUT.Size = new Size(2515, 634);
        txINPUT.TabIndex = 3;
        txINPUT.Text = "Variables which should not be set for a specific installation are explicitly set to an empty value,\n so that startup script correctly detects which installation you are aiming at.";
        txINPUT.WordWrap = false;
        txINPUT.SelectionChanged += txINPUT_SelectionChanged;
        txINPUT.TextChanged += txINPUT_TextChanged;
        // 
        // groupBox4
        // 
        groupBox4.Controls.Add(lvRESULT);
        groupBox4.Dock = DockStyle.Fill;
        groupBox4.Font = new Font("JetBrains Mono", 8.999999F, FontStyle.Regular, GraphicsUnit.Point);
        groupBox4.Location = new Point(4, 0);
        groupBox4.Name = "groupBox4";
        groupBox4.Size = new Size(2521, 584);
        groupBox4.TabIndex = 1;
        groupBox4.TabStop = false;
        groupBox4.Text = "Result data";
        // 
        // lvRESULT
        // 
        lvRESULT.BorderStyle = BorderStyle.None;
        lvRESULT.Dock = DockStyle.Fill;
        lvRESULT.Font = new Font("JetBrains Mono", 8.999999F, FontStyle.Regular, GraphicsUnit.Point);
        lvRESULT.FullRowSelect = true;
        lvRESULT.GridLines = true;
        lvRESULT.Location = new Point(3, 27);
        lvRESULT.Name = "lvRESULT";
        lvRESULT.Size = new Size(2515, 554);
        lvRESULT.TabIndex = 0;
        lvRESULT.UseCompatibleStateImageBehavior = false;
        lvRESULT.View = View.Details;
        lvRESULT.SelectedIndexChanged += lvRESULT_SelectedIndexChanged;
        lvRESULT.KeyDown += lvRESULT_KeyDown;
        // 
        // FMain
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(2529, 1412);
        Controls.Add(_split_Re_IR);
        Icon = (Icon) resources.GetObject("$this.Icon");
        Name = "FMain";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "RegExpTracer";
        Load += FMain_Load;
        _split_Re_IR.Panel1.ResumeLayout(false);
        _split_Re_IR.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize) _split_Re_IR).EndInit();
        _split_Re_IR.ResumeLayout(false);
        splitContainer2.Panel1.ResumeLayout(false);
        splitContainer2.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize) splitContainer2).EndInit();
        splitContainer2.ResumeLayout(false);
        gbREGEX.ResumeLayout(false);
        panel1.ResumeLayout(false);
        _tableLayoutOptions.ResumeLayout(false);
        _split_I_R.Panel1.ResumeLayout(false);
        _split_I_R.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize) _split_I_R).EndInit();
        _split_I_R.ResumeLayout(false);
        gbINPUT.ResumeLayout(false);
        panel2.ResumeLayout(false);
        groupBox4.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private SplitContainer _split_Re_IR;
    private SplitContainer splitContainer2;
    private GroupBox gbREGEX;
    private Panel panel1;
    private Nabu.Forms.RichTextBoxEx txPATTERN;
    private TableLayoutPanel _tableLayoutOptions;
    private CheckBox cbECMA;
    private CheckBox cbIGNORE_CASE;
    private CheckBox cbSINGLE_LINE;
    private CheckBox cbLINE_BREAKS;
    private CheckBox cbMULTILINE;
    private CheckBox cbEXPLICIT;
    private SplitContainer _split_I_R;
    private GroupBox gbINPUT;
    private Panel panel2;
    private Nabu.Forms.RichTextBoxEx txINPUT;
    private GroupBox groupBox4;
    private ListView lvRESULT;
    private CheckBox cbNOBACK;
    private CheckBox cbWORDWRAP;
}