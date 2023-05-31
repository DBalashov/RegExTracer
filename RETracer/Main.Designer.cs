using System.ComponentModel;
using Nabu.Forms;

namespace RETracer;

partial class Main
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    private CheckBox coLINE_BREAKS;
    private CheckBox coECMA;
    private CheckBox coEXPLICIT;
    private CheckBox coGNORE_CASE;
    private CheckBox coIGNORE;
    private CheckBox coMULTILINE;
    private CheckBox coSINGLE_LINE;
    private ToolStripMenuItem _menuItemEdit;
    private ToolStripMenuItem _menuItemEditCopy;
    private ToolStripMenuItem _menuItemEditCopyCSharpCode;
    private ToolStripMenuItem _menuItemEditCut;
    private ToolStripMenuItem _menuItemEditPaste;
    private ToolStripMenuItem _menuItemEditRedo;
    private ToolStripMenuItem _menuItemEditSelectAll;
    private ToolStripMenuItem _menuItemEditUndo;
    private ToolStripMenuItem _menuItemFile;
    private ToolStripMenuItem _menuItemFileExit;
    private ToolStripMenuItem _menuItemFileNew;
    private ToolStripMenuItem _menuItemFileOpen;
    private ToolStripMenuItem _menuItemFileSave;
    private ToolStripMenuItem _menuItemFileSaveAs;
    private ToolStripMenuItem _menuItemTools;
    private ToolStripMenuItem _menuItemToolsOptions;
    private MenuStrip _menuMain;
    private ToolStripSeparator _menuSeparatorEdit1;
    private ToolStripSeparator _menuSeparatorEdit2;
    private ToolStripSeparator _menuSeparatorFile1;
    private ToolStripSeparator _menuSeparatorFile2;
    private OpenFileDialog _openFileDialog;
    private SaveFileDialog _saveFileDialog;
    private SplitContainer _split_I_R;
    private SplitContainer _split_Re_IR;
    private TableLayoutPanel _tableLayoutOptions;

    private GroupBox gbREGEX;
    private Panel panel1;
    private RichTextBoxEx txREGEX;
    private GroupBox gbINPUT;
    private Panel panel2;
    private RichTextBoxEx txDATA;
    private GroupBox groupBox3;
    private Panel panel3;
    private RichTextBoxEx txRESULT;
    private SplitContainer spcRESULT;
    private GroupBox groupBox4;
    private Button btnCOLLAPSE;
    private SplitContainer splitContainer2;
    private ListView lvRESULT;

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
        components = new Container();
        var resources = new ComponentResourceManager(typeof(Main));
        _split_Re_IR = new SplitContainer();
        splitContainer2 = new SplitContainer();
        gbREGEX = new GroupBox();
        panel1 = new Panel();
        txREGEX = new RichTextBoxEx(components);
        _tableLayoutOptions = new TableLayoutPanel();
        coECMA = new CheckBox();
        coIGNORE = new CheckBox();
        coGNORE_CASE = new CheckBox();
        coSINGLE_LINE = new CheckBox();
        coLINE_BREAKS = new CheckBox();
        coMULTILINE = new CheckBox();
        coEXPLICIT = new CheckBox();
        _split_I_R = new SplitContainer();
        gbINPUT = new GroupBox();
        panel2 = new Panel();
        txDATA = new RichTextBoxEx(components);
        spcRESULT = new SplitContainer();
        groupBox3 = new GroupBox();
        panel3 = new Panel();
        btnCOLLAPSE = new Button();
        txRESULT = new RichTextBoxEx(components);
        groupBox4 = new GroupBox();
        lvRESULT = new ListView();
        _menuMain = new MenuStrip();
        _menuItemFile = new ToolStripMenuItem();
        _menuItemFileNew = new ToolStripMenuItem();
        _menuItemFileOpen = new ToolStripMenuItem();
        _menuSeparatorFile1 = new ToolStripSeparator();
        _menuItemFileSave = new ToolStripMenuItem();
        _menuItemFileSaveAs = new ToolStripMenuItem();
        _menuSeparatorFile2 = new ToolStripSeparator();
        _menuItemFileExit = new ToolStripMenuItem();
        _menuItemEdit = new ToolStripMenuItem();
        _menuItemEditUndo = new ToolStripMenuItem();
        _menuItemEditRedo = new ToolStripMenuItem();
        _menuSeparatorEdit1 = new ToolStripSeparator();
        _menuItemEditCut = new ToolStripMenuItem();
        _menuItemEditCopy = new ToolStripMenuItem();
        _menuItemEditCopyCSharpCode = new ToolStripMenuItem();
        _menuItemEditPaste = new ToolStripMenuItem();
        _menuSeparatorEdit2 = new ToolStripSeparator();
        _menuItemEditSelectAll = new ToolStripMenuItem();
        _menuItemTools = new ToolStripMenuItem();
        _menuItemToolsOptions = new ToolStripMenuItem();
        _openFileDialog = new OpenFileDialog();
        _saveFileDialog = new SaveFileDialog();
        ((ISupportInitialize) _split_Re_IR).BeginInit();
        _split_Re_IR.Panel1.SuspendLayout();
        _split_Re_IR.Panel2.SuspendLayout();
        _split_Re_IR.SuspendLayout();
        ((ISupportInitialize) splitContainer2).BeginInit();
        splitContainer2.Panel1.SuspendLayout();
        splitContainer2.Panel2.SuspendLayout();
        splitContainer2.SuspendLayout();
        gbREGEX.SuspendLayout();
        panel1.SuspendLayout();
        _tableLayoutOptions.SuspendLayout();
        ((ISupportInitialize) _split_I_R).BeginInit();
        _split_I_R.Panel1.SuspendLayout();
        _split_I_R.Panel2.SuspendLayout();
        _split_I_R.SuspendLayout();
        gbINPUT.SuspendLayout();
        panel2.SuspendLayout();
        ((ISupportInitialize) spcRESULT).BeginInit();
        spcRESULT.Panel1.SuspendLayout();
        spcRESULT.Panel2.SuspendLayout();
        spcRESULT.SuspendLayout();
        groupBox3.SuspendLayout();
        panel3.SuspendLayout();
        groupBox4.SuspendLayout();
        _menuMain.SuspendLayout();
        SuspendLayout();
        // 
        // _split_Re_IR
        // 
        _split_Re_IR.Dock = DockStyle.Fill;
        _split_Re_IR.FixedPanel = FixedPanel.Panel1;
        _split_Re_IR.Location = new Point(0, 33);
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
        _split_Re_IR.Size = new Size(1878, 911);
        _split_Re_IR.SplitterDistance = 190;
        _split_Re_IR.SplitterWidth = 3;
        _split_Re_IR.TabIndex = 1;
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
        splitContainer2.Size = new Size(1870, 190);
        splitContainer2.SplitterDistance = 1482;
        splitContainer2.TabIndex = 13;
        // 
        // gbREGEX
        // 
        gbREGEX.Controls.Add(panel1);
        gbREGEX.Dock = DockStyle.Fill;
        gbREGEX.Font = new Font("JetBrains Mono", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        gbREGEX.Location = new Point(0, 0);
        gbREGEX.Name = "gbREGEX";
        gbREGEX.Size = new Size(1482, 190);
        gbREGEX.TabIndex = 12;
        gbREGEX.TabStop = false;
        gbREGEX.Text = " Regular Expression ";
        // 
        // panel1
        // 
        panel1.Controls.Add(txREGEX);
        panel1.Dock = DockStyle.Fill;
        panel1.Location = new Point(3, 29);
        panel1.Name = "panel1";
        panel1.Size = new Size(1476, 158);
        panel1.TabIndex = 0;
        // 
        // txREGEX
        // 
        txREGEX.BorderStyle = BorderStyle.None;
        txREGEX.DetectUrls = false;
        txREGEX.Dock = DockStyle.Fill;
        txREGEX.Font = new Font("JetBrains Mono", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        txREGEX.HideSelection = false;
        txREGEX.Location = new Point(0, 0);
        txREGEX.MaxLength = 32768;
        txREGEX.Name = "txREGEX";
        txREGEX.Size = new Size(1476, 158);
        txREGEX.TabIndex = 4;
        txREGEX.Text = "(d\\S+).*?(b\\S+)";
        txREGEX.WordWrap = false;
        txREGEX.TextChanged += TextRegEx_TextChanged;
        txREGEX.Enter += TextRegEx_Enter;
        txREGEX.Leave += TextRegEx_Leave;
        // 
        // _tableLayoutOptions
        // 
        _tableLayoutOptions.ColumnCount = 2;
        _tableLayoutOptions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        _tableLayoutOptions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        _tableLayoutOptions.Controls.Add(coECMA, 0, 0);
        _tableLayoutOptions.Controls.Add(coIGNORE, 3, 1);
        _tableLayoutOptions.Controls.Add(coGNORE_CASE, 3, 0);
        _tableLayoutOptions.Controls.Add(coSINGLE_LINE, 1, 0);
        _tableLayoutOptions.Controls.Add(coLINE_BREAKS, 2, 1);
        _tableLayoutOptions.Controls.Add(coMULTILINE, 1, 1);
        _tableLayoutOptions.Controls.Add(coEXPLICIT, 2, 0);
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
        _tableLayoutOptions.Size = new Size(384, 190);
        _tableLayoutOptions.TabIndex = 11;
        // 
        // coECMA
        // 
        coECMA.Dock = DockStyle.Fill;
        coECMA.Location = new Point(3, 3);
        coECMA.Name = "coECMA";
        coECMA.Size = new Size(186, 31);
        coECMA.TabIndex = 0;
        coECMA.Text = "ECMA syntax";
        coECMA.UseVisualStyleBackColor = true;
        coECMA.CheckedChanged += CheckOption_CheckedChanged;
        // 
        // coIGNORE
        // 
        coIGNORE.Dock = DockStyle.Fill;
        coIGNORE.Location = new Point(3, 114);
        coIGNORE.Name = "coIGNORE";
        coIGNORE.Size = new Size(186, 31);
        coIGNORE.TabIndex = 7;
        coIGNORE.Text = "Ignore whitespace";
        coIGNORE.UseVisualStyleBackColor = true;
        coIGNORE.CheckedChanged += CheckOption_CheckedChanged;
        // 
        // coGNORE_CASE
        // 
        coGNORE_CASE.Dock = DockStyle.Fill;
        coGNORE_CASE.Location = new Point(195, 40);
        coGNORE_CASE.Name = "coGNORE_CASE";
        coGNORE_CASE.Size = new Size(186, 31);
        coGNORE_CASE.TabIndex = 3;
        coGNORE_CASE.Text = "Ignore case";
        coGNORE_CASE.UseVisualStyleBackColor = true;
        coGNORE_CASE.CheckedChanged += CheckOption_CheckedChanged;
        // 
        // coSINGLE_LINE
        // 
        coSINGLE_LINE.Dock = DockStyle.Fill;
        coSINGLE_LINE.Location = new Point(195, 3);
        coSINGLE_LINE.Name = "coSINGLE_LINE";
        coSINGLE_LINE.Size = new Size(186, 31);
        coSINGLE_LINE.TabIndex = 1;
        coSINGLE_LINE.Text = "Single line";
        coSINGLE_LINE.UseVisualStyleBackColor = true;
        coSINGLE_LINE.CheckedChanged += CheckOption_CheckedChanged;
        // 
        // coLINE_BREAKS
        // 
        coLINE_BREAKS.Dock = DockStyle.Fill;
        coLINE_BREAKS.Location = new Point(195, 77);
        coLINE_BREAKS.Name = "coLINE_BREAKS";
        coLINE_BREAKS.Size = new Size(186, 31);
        coLINE_BREAKS.TabIndex = 6;
        coLINE_BREAKS.Text = "Line breaks";
        coLINE_BREAKS.UseVisualStyleBackColor = true;
        coLINE_BREAKS.CheckedChanged += CheckOption_CheckedChanged;
        // 
        // coMULTILINE
        // 
        coMULTILINE.Dock = DockStyle.Fill;
        coMULTILINE.Location = new Point(3, 77);
        coMULTILINE.Name = "coMULTILINE";
        coMULTILINE.Size = new Size(186, 31);
        coMULTILINE.TabIndex = 5;
        coMULTILINE.Text = "Multiline RegEx";
        coMULTILINE.UseVisualStyleBackColor = true;
        coMULTILINE.CheckedChanged += CheckOption_CheckedChanged;
        // 
        // coEXPLICIT
        // 
        coEXPLICIT.Dock = DockStyle.Fill;
        coEXPLICIT.Location = new Point(3, 40);
        coEXPLICIT.Name = "coEXPLICIT";
        coEXPLICIT.Size = new Size(186, 31);
        coEXPLICIT.TabIndex = 2;
        coEXPLICIT.Text = "Explicit groups";
        coEXPLICIT.UseVisualStyleBackColor = true;
        coEXPLICIT.CheckedChanged += CheckOption_CheckedChanged;
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
        _split_I_R.Panel2.Controls.Add(spcRESULT);
        _split_I_R.Panel2.Padding = new Padding(4, 0, 4, 0);
        _split_I_R.Size = new Size(1878, 718);
        _split_I_R.SplitterDistance = 382;
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
        gbINPUT.Size = new Size(1870, 382);
        gbINPUT.TabIndex = 3;
        gbINPUT.TabStop = false;
        gbINPUT.Text = "Input";
        // 
        // panel2
        // 
        panel2.Controls.Add(txDATA);
        panel2.Dock = DockStyle.Fill;
        panel2.Location = new Point(3, 29);
        panel2.Name = "panel2";
        panel2.Size = new Size(1864, 350);
        panel2.TabIndex = 0;
        // 
        // txDATA
        // 
        txDATA.BorderStyle = BorderStyle.None;
        txDATA.DetectUrls = false;
        txDATA.Dock = DockStyle.Fill;
        txDATA.Font = new Font("JetBrains Mono", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        txDATA.HideSelection = false;
        txDATA.Location = new Point(0, 0);
        txDATA.MaxLength = 32768;
        txDATA.Name = "txDATA";
        txDATA.Size = new Size(1864, 350);
        txDATA.TabIndex = 3;
        txDATA.Text = "hello denis balashov\nhello2 denis balashov 3\nhello4 denis balashov 4\nhello deniwffwefs balashovddddd";
        txDATA.WordWrap = false;
        txDATA.TextChanged += TextInput_TextChanged;
        txDATA.Enter += textInput_Enter;
        txDATA.Leave += textInput_Leave;
        // 
        // spcRESULT
        // 
        spcRESULT.Dock = DockStyle.Fill;
        spcRESULT.Location = new Point(4, 0);
        spcRESULT.Name = "spcRESULT";
        // 
        // spcRESULT.Panel1
        // 
        spcRESULT.Panel1.Controls.Add(groupBox3);
        // 
        // spcRESULT.Panel2
        // 
        spcRESULT.Panel2.Controls.Add(groupBox4);
        spcRESULT.Size = new Size(1870, 333);
        spcRESULT.SplitterDistance = 959;
        spcRESULT.TabIndex = 3;
        // 
        // groupBox3
        // 
        groupBox3.Controls.Add(panel3);
        groupBox3.Dock = DockStyle.Fill;
        groupBox3.Font = new Font("JetBrains Mono", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        groupBox3.Location = new Point(0, 0);
        groupBox3.Name = "groupBox3";
        groupBox3.Size = new Size(959, 333);
        groupBox3.TabIndex = 2;
        groupBox3.TabStop = false;
        groupBox3.Text = "Result";
        // 
        // panel3
        // 
        panel3.Controls.Add(btnCOLLAPSE);
        panel3.Controls.Add(txRESULT);
        panel3.Dock = DockStyle.Fill;
        panel3.Location = new Point(3, 29);
        panel3.Name = "panel3";
        panel3.Size = new Size(953, 301);
        panel3.TabIndex = 0;
        // 
        // btnCOLLAPSE
        // 
        btnCOLLAPSE.Anchor =  AnchorStyles.Bottom | AnchorStyles.Right;
        btnCOLLAPSE.Location = new Point(933, 278);
        btnCOLLAPSE.Name = "btnCOLLAPSE";
        btnCOLLAPSE.Size = new Size(21, 23);
        btnCOLLAPSE.TabIndex = 0;
        btnCOLLAPSE.UseVisualStyleBackColor = true;
        btnCOLLAPSE.Click += btnCOLLAPSE_Click;
        // 
        // txRESULT
        // 
        txRESULT.BorderStyle = BorderStyle.None;
        txRESULT.DetectUrls = false;
        txRESULT.Dock = DockStyle.Fill;
        txRESULT.Font = new Font("JetBrains Mono", 8.999999F, FontStyle.Regular, GraphicsUnit.Point);
        txRESULT.HideSelection = false;
        txRESULT.Location = new Point(0, 0);
        txRESULT.MaxLength = 32768;
        txRESULT.Name = "txRESULT";
        txRESULT.ReadOnly = true;
        txRESULT.Size = new Size(953, 301);
        txRESULT.TabIndex = 2;
        txRESULT.Text = "";
        txRESULT.WordWrap = false;
        // 
        // groupBox4
        // 
        groupBox4.Controls.Add(lvRESULT);
        groupBox4.Dock = DockStyle.Fill;
        groupBox4.Font = new Font("JetBrains Mono", 8.999999F, FontStyle.Regular, GraphicsUnit.Point);
        groupBox4.Location = new Point(0, 0);
        groupBox4.Name = "groupBox4";
        groupBox4.Size = new Size(907, 333);
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
        lvRESULT.Size = new Size(901, 303);
        lvRESULT.TabIndex = 0;
        lvRESULT.UseCompatibleStateImageBehavior = false;
        lvRESULT.View = View.Details;
        lvRESULT.ItemSelectionChanged += lvRESULT_ItemSelectionChanged;
        lvRESULT.KeyDown += lvRESULT_KeyDown;
        // 
        // _menuMain
        // 
        _menuMain.ImageScalingSize = new Size(24, 24);
        _menuMain.Items.AddRange(new ToolStripItem[] { _menuItemFile, _menuItemEdit, _menuItemTools });
        _menuMain.Location = new Point(0, 0);
        _menuMain.Name = "_menuMain";
        _menuMain.RenderMode = ToolStripRenderMode.System;
        _menuMain.Size = new Size(1878, 33);
        _menuMain.TabIndex = 0;
        // 
        // _menuItemFile
        // 
        _menuItemFile.DropDownItems.AddRange(new ToolStripItem[] { _menuItemFileNew, _menuItemFileOpen, _menuSeparatorFile1, _menuItemFileSave, _menuItemFileSaveAs, _menuSeparatorFile2, _menuItemFileExit });
        _menuItemFile.Name = "_menuItemFile";
        _menuItemFile.Size = new Size(54, 29);
        _menuItemFile.Text = "&File";
        // 
        // _menuItemFileNew
        // 
        _menuItemFileNew.ImageTransparentColor = Color.Magenta;
        _menuItemFileNew.Name = "_menuItemFileNew";
        _menuItemFileNew.ShortcutKeys =  Keys.Control | Keys.N;
        _menuItemFileNew.Size = new Size(241, 34);
        _menuItemFileNew.Text = "&New";
        _menuItemFileNew.ToolTipText = "Create new document.";
        _menuItemFileNew.Click += MenuItemFileNew_Click;
        // 
        // _menuItemFileOpen
        // 
        _menuItemFileOpen.ImageTransparentColor = Color.Magenta;
        _menuItemFileOpen.Name = "_menuItemFileOpen";
        _menuItemFileOpen.ShortcutKeys =  Keys.Control | Keys.O;
        _menuItemFileOpen.Size = new Size(241, 34);
        _menuItemFileOpen.Text = "&Open …";
        _menuItemFileOpen.ToolTipText = "Open existing document.";
        _menuItemFileOpen.Click += MenuItemFileOpen_Click;
        // 
        // _menuSeparatorFile1
        // 
        _menuSeparatorFile1.Name = "_menuSeparatorFile1";
        _menuSeparatorFile1.Size = new Size(238, 6);
        // 
        // _menuItemFileSave
        // 
        _menuItemFileSave.ImageTransparentColor = Color.Magenta;
        _menuItemFileSave.Name = "_menuItemFileSave";
        _menuItemFileSave.ShortcutKeys =  Keys.Control | Keys.S;
        _menuItemFileSave.Size = new Size(241, 34);
        _menuItemFileSave.Text = "&Save";
        _menuItemFileSave.ToolTipText = "Save current document.";
        _menuItemFileSave.Click += MenuItemFileSave_Click;
        // 
        // _menuItemFileSaveAs
        // 
        _menuItemFileSaveAs.Name = "_menuItemFileSaveAs";
        _menuItemFileSaveAs.Size = new Size(241, 34);
        _menuItemFileSaveAs.Text = "Save &As …";
        _menuItemFileSaveAs.ToolTipText = "Save current document under new name.";
        _menuItemFileSaveAs.Click += MenuItemFileSaveAs_Click;
        // 
        // _menuSeparatorFile2
        // 
        _menuSeparatorFile2.Name = "_menuSeparatorFile2";
        _menuSeparatorFile2.Size = new Size(238, 6);
        // 
        // _menuItemFileExit
        // 
        _menuItemFileExit.Name = "_menuItemFileExit";
        _menuItemFileExit.Size = new Size(241, 34);
        _menuItemFileExit.Text = "E&xit";
        _menuItemFileExit.ToolTipText = "Exit application.";
        _menuItemFileExit.Click += MenuItemFileExit_Click;
        // 
        // _menuItemEdit
        // 
        _menuItemEdit.DropDownItems.AddRange(new ToolStripItem[] { _menuItemEditUndo, _menuItemEditRedo, _menuSeparatorEdit1, _menuItemEditCut, _menuItemEditCopy, _menuItemEditCopyCSharpCode, _menuItemEditPaste, _menuSeparatorEdit2, _menuItemEditSelectAll });
        _menuItemEdit.Name = "_menuItemEdit";
        _menuItemEdit.Size = new Size(58, 29);
        _menuItemEdit.Text = "&Edit";
        // 
        // _menuItemEditUndo
        // 
        _menuItemEditUndo.Name = "_menuItemEditUndo";
        _menuItemEditUndo.ShortcutKeys =  Keys.Control | Keys.Z;
        _menuItemEditUndo.Size = new Size(230, 34);
        _menuItemEditUndo.Tag = "Undo {0}";
        _menuItemEditUndo.Text = "&Undo";
        _menuItemEditUndo.Click += MenuItemEditUndo_Click;
        // 
        // _menuItemEditRedo
        // 
        _menuItemEditRedo.Name = "_menuItemEditRedo";
        _menuItemEditRedo.ShortcutKeys =  Keys.Control | Keys.Y;
        _menuItemEditRedo.Size = new Size(230, 34);
        _menuItemEditRedo.Tag = "Redo {0}";
        _menuItemEditRedo.Text = "&Redo";
        _menuItemEditRedo.Click += MenuItemEditRedo_Click;
        // 
        // _menuSeparatorEdit1
        // 
        _menuSeparatorEdit1.Name = "_menuSeparatorEdit1";
        _menuSeparatorEdit1.Size = new Size(227, 6);
        // 
        // _menuItemEditCut
        // 
        _menuItemEditCut.ImageTransparentColor = Color.Magenta;
        _menuItemEditCut.Name = "_menuItemEditCut";
        _menuItemEditCut.ShortcutKeys =  Keys.Control | Keys.X;
        _menuItemEditCut.Size = new Size(230, 34);
        _menuItemEditCut.Text = "Cu&t";
        _menuItemEditCut.ToolTipText = "Cut selection to clipboard.";
        _menuItemEditCut.Click += MenuItemEditCut_Click;
        // 
        // _menuItemEditCopy
        // 
        _menuItemEditCopy.ImageTransparentColor = Color.Magenta;
        _menuItemEditCopy.Name = "_menuItemEditCopy";
        _menuItemEditCopy.ShortcutKeys =  Keys.Control | Keys.C;
        _menuItemEditCopy.Size = new Size(230, 34);
        _menuItemEditCopy.Text = "&Copy";
        _menuItemEditCopy.ToolTipText = "Copy selection to clipboard.";
        _menuItemEditCopy.Click += MenuItemEditCopy_Click;
        // 
        // _menuItemEditCopyCSharpCode
        // 
        _menuItemEditCopyCSharpCode.Name = "_menuItemEditCopyCSharpCode";
        _menuItemEditCopyCSharpCode.Size = new Size(230, 34);
        _menuItemEditCopyCSharpCode.Text = "Copy C# Code";
        _menuItemEditCopyCSharpCode.Click += MenuItemEditCopyCSharpCode_Click;
        // 
        // _menuItemEditPaste
        // 
        _menuItemEditPaste.ImageTransparentColor = Color.Magenta;
        _menuItemEditPaste.Name = "_menuItemEditPaste";
        _menuItemEditPaste.ShortcutKeys =  Keys.Control | Keys.V;
        _menuItemEditPaste.Size = new Size(230, 34);
        _menuItemEditPaste.Text = "&Paste";
        _menuItemEditPaste.ToolTipText = "Paste from clipboard.";
        _menuItemEditPaste.Click += MenuItemEditPaste_Click;
        // 
        // _menuSeparatorEdit2
        // 
        _menuSeparatorEdit2.Name = "_menuSeparatorEdit2";
        _menuSeparatorEdit2.Size = new Size(227, 6);
        // 
        // _menuItemEditSelectAll
        // 
        _menuItemEditSelectAll.Name = "_menuItemEditSelectAll";
        _menuItemEditSelectAll.Size = new Size(230, 34);
        _menuItemEditSelectAll.Text = "Select &All";
        _menuItemEditSelectAll.ToolTipText = "Select whole text.";
        _menuItemEditSelectAll.Click += MenuItemEditSelectAll_Click;
        // 
        // _menuItemTools
        // 
        _menuItemTools.DropDownItems.AddRange(new ToolStripItem[] { _menuItemToolsOptions });
        _menuItemTools.Name = "_menuItemTools";
        _menuItemTools.Size = new Size(69, 29);
        _menuItemTools.Text = "Tools";
        // 
        // _menuItemToolsOptions
        // 
        _menuItemToolsOptions.Name = "_menuItemToolsOptions";
        _menuItemToolsOptions.Size = new Size(196, 34);
        _menuItemToolsOptions.Text = "Options …";
        _menuItemToolsOptions.ToolTipText = "Change application parameters.";
        _menuItemToolsOptions.Click += MenuItemToolsOptions_Click;
        // 
        // _openFileDialog
        // 
        _openFileDialog.DefaultExt = "regex";
        _openFileDialog.FileName = "new";
        _openFileDialog.Filter = "RegEx files|*.regex|All files|*.*";
        _openFileDialog.RestoreDirectory = true;
        _openFileDialog.SupportMultiDottedExtensions = true;
        // 
        // _saveFileDialog
        // 
        _saveFileDialog.DefaultExt = "regex";
        _saveFileDialog.FileName = "new";
        _saveFileDialog.Filter = "RegEx files|*.regex|All files|*.*";
        _saveFileDialog.RestoreDirectory = true;
        _saveFileDialog.SupportMultiDottedExtensions = true;
        // 
        // Main
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1878, 944);
        Controls.Add(_split_Re_IR);
        Controls.Add(_menuMain);
        Icon = (Icon) resources.GetObject("$this.Icon");
        MainMenuStrip = _menuMain;
        Name = "Main";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "RegEx Tracer";
        FormClosing += FormMain_FormClosing;
        Load += FormMain_Load;
        _split_Re_IR.Panel1.ResumeLayout(false);
        _split_Re_IR.Panel2.ResumeLayout(false);
        ((ISupportInitialize) _split_Re_IR).EndInit();
        _split_Re_IR.ResumeLayout(false);
        splitContainer2.Panel1.ResumeLayout(false);
        splitContainer2.Panel2.ResumeLayout(false);
        ((ISupportInitialize) splitContainer2).EndInit();
        splitContainer2.ResumeLayout(false);
        gbREGEX.ResumeLayout(false);
        panel1.ResumeLayout(false);
        _tableLayoutOptions.ResumeLayout(false);
        _split_I_R.Panel1.ResumeLayout(false);
        _split_I_R.Panel2.ResumeLayout(false);
        ((ISupportInitialize) _split_I_R).EndInit();
        _split_I_R.ResumeLayout(false);
        gbINPUT.ResumeLayout(false);
        panel2.ResumeLayout(false);
        spcRESULT.Panel1.ResumeLayout(false);
        spcRESULT.Panel2.ResumeLayout(false);
        ((ISupportInitialize) spcRESULT).EndInit();
        spcRESULT.ResumeLayout(false);
        groupBox3.ResumeLayout(false);
        panel3.ResumeLayout(false);
        groupBox4.ResumeLayout(false);
        _menuMain.ResumeLayout(false);
        _menuMain.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
}