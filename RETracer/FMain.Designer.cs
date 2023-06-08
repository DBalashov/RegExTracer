namespace RETracer;

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
        gbINPUT = new GroupBox();
        txINPUT = new Nabu.Forms.RichTextBoxEx(components);
        groupBox4 = new GroupBox();
        lvRESULT = new ListView();
        gbREGEX = new GroupBox();
        panel1 = new Panel();
        txPATTERN = new Nabu.Forms.RichTextBoxEx(components);
        cbWORDWRAP = new CheckBox();
        cbNOBACK = new CheckBox();
        cbIGNORE_CASE = new CheckBox();
        cbSINGLE_LINE = new CheckBox();
        cbMULTILINE = new CheckBox();
        cbEXPLICIT = new CheckBox();
        nudTIMEOUT = new NumericUpDown();
        cbECMA = new CheckBox();
        label1 = new Label();
        groupBox1 = new GroupBox();
        ((System.ComponentModel.ISupportInitialize) _split_Re_IR).BeginInit();
        _split_Re_IR.Panel1.SuspendLayout();
        _split_Re_IR.Panel2.SuspendLayout();
        _split_Re_IR.SuspendLayout();
        gbINPUT.SuspendLayout();
        groupBox4.SuspendLayout();
        gbREGEX.SuspendLayout();
        panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize) nudTIMEOUT).BeginInit();
        groupBox1.SuspendLayout();
        SuspendLayout();
        // 
        // _split_Re_IR
        // 
        _split_Re_IR.Anchor =  AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        _split_Re_IR.FixedPanel = FixedPanel.Panel1;
        _split_Re_IR.Location = new Point(5, 225);
        _split_Re_IR.Name = "_split_Re_IR";
        _split_Re_IR.Orientation = Orientation.Horizontal;
        // 
        // _split_Re_IR.Panel1
        // 
        _split_Re_IR.Panel1.Controls.Add(gbINPUT);
        // 
        // _split_Re_IR.Panel2
        // 
        _split_Re_IR.Panel2.Controls.Add(groupBox4);
        _split_Re_IR.Size = new Size(2529, 1071);
        _split_Re_IR.SplitterDistance = 600;
        _split_Re_IR.SplitterWidth = 3;
        _split_Re_IR.TabIndex = 2;
        // 
        // gbINPUT
        // 
        gbINPUT.Controls.Add(txINPUT);
        gbINPUT.Dock = DockStyle.Fill;
        gbINPUT.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        gbINPUT.Location = new Point(0, 0);
        gbINPUT.Margin = new Padding(0);
        gbINPUT.Name = "gbINPUT";
        gbINPUT.Size = new Size(2529, 600);
        gbINPUT.TabIndex = 0;
        gbINPUT.TabStop = false;
        gbINPUT.Text = "Input";
        // 
        // txINPUT
        // 
        txINPUT.BorderStyle = BorderStyle.None;
        txINPUT.DetectUrls = false;
        txINPUT.Dock = DockStyle.Fill;
        txINPUT.Font = new Font("JetBrains Mono", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        txINPUT.HideSelection = false;
        txINPUT.Location = new Point(3, 27);
        txINPUT.MaxLength = 32768;
        txINPUT.Name = "txINPUT";
        txINPUT.Size = new Size(2523, 570);
        txINPUT.TabIndex = 0;
        txINPUT.Text = "Variables which should not be set for a specific installation are explicitly set to an empty value,\n so that startup script correctly detects which installation you are aiming at.";
        txINPUT.WordWrap = false;
        txINPUT.SelectionChanged += txINPUT_SelectionChanged;
        txINPUT.TextChanged += txINPUT_TextChanged;
        // 
        // groupBox4
        // 
        groupBox4.Controls.Add(lvRESULT);
        groupBox4.Dock = DockStyle.Fill;
        groupBox4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        groupBox4.Location = new Point(0, 0);
        groupBox4.Name = "groupBox4";
        groupBox4.Size = new Size(2529, 468);
        groupBox4.TabIndex = 0;
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
        lvRESULT.Size = new Size(2523, 438);
        lvRESULT.TabIndex = 0;
        lvRESULT.UseCompatibleStateImageBehavior = false;
        lvRESULT.View = View.Details;
        lvRESULT.SelectedIndexChanged += lvRESULT_SelectedIndexChanged;
        lvRESULT.KeyDown += lvRESULT_KeyDown;
        // 
        // gbREGEX
        // 
        gbREGEX.Anchor =  AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        gbREGEX.Controls.Add(panel1);
        gbREGEX.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        gbREGEX.Location = new Point(5, 0);
        gbREGEX.Name = "gbREGEX";
        gbREGEX.Size = new Size(2177, 221);
        gbREGEX.TabIndex = 0;
        gbREGEX.TabStop = false;
        gbREGEX.Text = " Regular Expression ";
        // 
        // panel1
        // 
        panel1.Controls.Add(txPATTERN);
        panel1.Dock = DockStyle.Fill;
        panel1.Location = new Point(3, 27);
        panel1.Name = "panel1";
        panel1.Size = new Size(2171, 191);
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
        txPATTERN.Size = new Size(2171, 191);
        txPATTERN.TabIndex = 0;
        txPATTERN.Text = "(\\S{4,6})(\\s+)(\\S+)";
        txPATTERN.WordWrap = false;
        txPATTERN.SelectionChanged += txPATTERN_SelectionChanged;
        txPATTERN.TextChanged += txPATTERN_TextChanged;
        // 
        // cbWORDWRAP
        // 
        cbWORDWRAP.AutoSize = true;
        cbWORDWRAP.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        cbWORDWRAP.Location = new Point(175, 100);
        cbWORDWRAP.Name = "cbWORDWRAP";
        cbWORDWRAP.Size = new Size(126, 29);
        cbWORDWRAP.TabIndex = 7;
        cbWORDWRAP.Text = "Word wrap";
        cbWORDWRAP.UseVisualStyleBackColor = true;
        cbWORDWRAP.CheckedChanged += cbWORDWRAP_CheckedChanged;
        // 
        // cbNOBACK
        // 
        cbNOBACK.AutoSize = true;
        cbNOBACK.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        cbNOBACK.Location = new Point(175, 64);
        cbNOBACK.Name = "cbNOBACK";
        cbNOBACK.Size = new Size(167, 29);
        cbNOBACK.TabIndex = 6;
        cbNOBACK.Text = "No backtracking";
        cbNOBACK.UseVisualStyleBackColor = true;
        cbNOBACK.CheckedChanged += cbECMA_CheckedChanged;
        // 
        // cbIGNORE_CASE
        // 
        cbIGNORE_CASE.AutoSize = true;
        cbIGNORE_CASE.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        cbIGNORE_CASE.Location = new Point(175, 27);
        cbIGNORE_CASE.Name = "cbIGNORE_CASE";
        cbIGNORE_CASE.Size = new Size(129, 29);
        cbIGNORE_CASE.TabIndex = 4;
        cbIGNORE_CASE.Text = "Ignore case";
        cbIGNORE_CASE.UseVisualStyleBackColor = true;
        cbIGNORE_CASE.CheckedChanged += cbECMA_CheckedChanged;
        // 
        // cbSINGLE_LINE
        // 
        cbSINGLE_LINE.AutoSize = true;
        cbSINGLE_LINE.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        cbSINGLE_LINE.Location = new Point(9, 101);
        cbSINGLE_LINE.Name = "cbSINGLE_LINE";
        cbSINGLE_LINE.Size = new Size(118, 29);
        cbSINGLE_LINE.TabIndex = 2;
        cbSINGLE_LINE.Text = "Single line";
        cbSINGLE_LINE.UseVisualStyleBackColor = true;
        cbSINGLE_LINE.CheckedChanged += cbECMA_CheckedChanged;
        // 
        // cbMULTILINE
        // 
        cbMULTILINE.AutoSize = true;
        cbMULTILINE.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        cbMULTILINE.Location = new Point(9, 138);
        cbMULTILINE.Name = "cbMULTILINE";
        cbMULTILINE.Size = new Size(105, 29);
        cbMULTILINE.TabIndex = 3;
        cbMULTILINE.Text = "Multiline";
        cbMULTILINE.UseVisualStyleBackColor = true;
        cbMULTILINE.CheckedChanged += cbECMA_CheckedChanged;
        // 
        // cbEXPLICIT
        // 
        cbEXPLICIT.AutoSize = true;
        cbEXPLICIT.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        cbEXPLICIT.Location = new Point(9, 64);
        cbEXPLICIT.Name = "cbEXPLICIT";
        cbEXPLICIT.Size = new Size(154, 29);
        cbEXPLICIT.TabIndex = 1;
        cbEXPLICIT.Text = "Explicit groups";
        cbEXPLICIT.UseVisualStyleBackColor = true;
        cbEXPLICIT.CheckedChanged += cbECMA_CheckedChanged;
        // 
        // nudTIMEOUT
        // 
        nudTIMEOUT.Location = new Point(175, 170);
        nudTIMEOUT.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        nudTIMEOUT.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudTIMEOUT.Name = "nudTIMEOUT";
        nudTIMEOUT.Size = new Size(107, 31);
        nudTIMEOUT.TabIndex = 8;
        nudTIMEOUT.Value = new decimal(new int[] { 3000, 0, 0, 0 });
        nudTIMEOUT.ValueChanged += nudTIMEOUT_ValueChanged;
        // 
        // cbECMA
        // 
        cbECMA.AutoSize = true;
        cbECMA.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        cbECMA.Location = new Point(9, 27);
        cbECMA.Name = "cbECMA";
        cbECMA.Size = new Size(141, 29);
        cbECMA.TabIndex = 0;
        cbECMA.Text = "ECMA syntax";
        cbECMA.UseVisualStyleBackColor = true;
        cbECMA.CheckedChanged += cbECMA_CheckedChanged;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(36, 172);
        label1.Name = "label1";
        label1.Size = new Size(133, 25);
        label1.TabIndex = 14;
        label1.Text = "Timeout (msec)";
        // 
        // groupBox1
        // 
        groupBox1.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
        groupBox1.Controls.Add(label1);
        groupBox1.Controls.Add(cbSINGLE_LINE);
        groupBox1.Controls.Add(cbECMA);
        groupBox1.Controls.Add(cbIGNORE_CASE);
        groupBox1.Controls.Add(nudTIMEOUT);
        groupBox1.Controls.Add(cbNOBACK);
        groupBox1.Controls.Add(cbMULTILINE);
        groupBox1.Controls.Add(cbEXPLICIT);
        groupBox1.Controls.Add(cbWORDWRAP);
        groupBox1.Location = new Point(2188, 12);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(345, 209);
        groupBox1.TabIndex = 1;
        groupBox1.TabStop = false;
        groupBox1.Text = "Settings";
        // 
        // FMain
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(2539, 1297);
        Controls.Add(groupBox1);
        Controls.Add(gbREGEX);
        Controls.Add(_split_Re_IR);
        Icon = (Icon) resources.GetObject("$this.Icon");
        Name = "FMain";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "RegExpTracer";
        Load += FMain_Load;
        ResizeEnd += FMain_ResizeEnd;
        _split_Re_IR.Panel1.ResumeLayout(false);
        _split_Re_IR.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize) _split_Re_IR).EndInit();
        _split_Re_IR.ResumeLayout(false);
        gbINPUT.ResumeLayout(false);
        groupBox4.ResumeLayout(false);
        gbREGEX.ResumeLayout(false);
        panel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize) nudTIMEOUT).EndInit();
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private SplitContainer _split_Re_IR;
    private GroupBox gbREGEX;
    private Panel panel1;
    private Nabu.Forms.RichTextBoxEx txPATTERN;
    private CheckBox cbIGNORE_CASE;
    private CheckBox cbSINGLE_LINE;
    private CheckBox cbMULTILINE;
    private CheckBox cbEXPLICIT;
    private GroupBox gbINPUT;
    private Nabu.Forms.RichTextBoxEx txINPUT;
    private GroupBox groupBox4;
    private ListView lvRESULT;
    private CheckBox cbNOBACK;
    private CheckBox cbWORDWRAP;
    private NumericUpDown nudTIMEOUT;
    private CheckBox cbECMA;
    private Label label1;
    private GroupBox groupBox1;
}