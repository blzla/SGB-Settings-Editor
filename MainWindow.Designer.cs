
namespace SGB_Palette_Editor
{
    internal class NoFocusTrackBar : System.Windows.Forms.TrackBar
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public extern static int SendMessage(System.IntPtr hWnd, uint msg, int wParam, int lParam);

        private static int MakeParam(int loWord, int hiWord)
        {
            return (hiWord << 16) | (loWord & 0xffff);
        }

        protected override void OnGotFocus(System.EventArgs e)
        {
            base.OnGotFocus(e);
            SendMessage(this.Handle, 0x0128, MakeParam(1, 0x1), 0);
        }
    }

    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.panelClipboard1 = new System.Windows.Forms.Panel();
            this.textboxRGB = new System.Windows.Forms.TextBox();
            this.textboxBGR15 = new System.Windows.Forms.TextBox();
            this.buttonColor1 = new System.Windows.Forms.Button();
            this.panelActiveColor = new System.Windows.Forms.Panel();
            this.comboBoxPaletteslot = new System.Windows.Forms.ComboBox();
            this.buttonColor2 = new System.Windows.Forms.Button();
            this.buttonColor4 = new System.Windows.Forms.Button();
            this.panelPalettebg = new System.Windows.Forms.Panel();
            this.panelColor1 = new System.Windows.Forms.Panel();
            this.panelColor2 = new System.Windows.Forms.Panel();
            this.panelColor3 = new System.Windows.Forms.Panel();
            this.panelColor4 = new System.Windows.Forms.Panel();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.panelClipboard2 = new System.Windows.Forms.Panel();
            this.panelClipboard3 = new System.Windows.Forms.Panel();
            this.panelClipboard4 = new System.Windows.Forms.Panel();
            this.panelClipboard5 = new System.Windows.Forms.Panel();
            this.panelClipboard6 = new System.Windows.Forms.Panel();
            this.panelClipboard7 = new System.Windows.Forms.Panel();
            this.panelClipboard8 = new System.Windows.Forms.Panel();
            this.buttonIps = new System.Windows.Forms.Button();
            this.labelGame = new System.Windows.Forms.Label();
            this.comboBoxGame = new System.Windows.Forms.ComboBox();
            this.labelClick = new System.Windows.Forms.Label();
            this.buttonStore1 = new System.Windows.Forms.Button();
            this.comboBoxVersion = new System.Windows.Forms.ComboBox();
            this.labelPalette = new System.Windows.Forms.Label();
            this.labelHexcolor = new System.Windows.Forms.Label();
            this.labelSnescolor = new System.Windows.Forms.Label();
            this.buttonStore2 = new System.Windows.Forms.Button();
            this.buttonLoad1 = new System.Windows.Forms.Button();
            this.buttonLoad2 = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonImport = new System.Windows.Forms.Button();
            this.buttonModify = new System.Windows.Forms.Button();
            this.screenshotPanel = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.textBoxRDec = new System.Windows.Forms.TextBox();
            this.textBoxRHex = new System.Windows.Forms.TextBox();
            this.textBoxGDec = new System.Windows.Forms.TextBox();
            this.textBoxGHex = new System.Windows.Forms.TextBox();
            this.textBoxBDec = new System.Windows.Forms.TextBox();
            this.textBoxBHex = new System.Windows.Forms.TextBox();
            this.labelDec = new System.Windows.Forms.Label();
            this.labelHex = new System.Windows.Forms.Label();
            this.labelRed = new System.Windows.Forms.Label();
            this.labelGreen = new System.Windows.Forms.Label();
            this.labelBlue = new System.Windows.Forms.Label();
            this.groupBoxEditColor = new System.Windows.Forms.GroupBox();
            this.tabControlColorformat = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.labelV = new System.Windows.Forms.Label();
            this.textBoxV = new System.Windows.Forms.TextBox();
            this.labelS = new System.Windows.Forms.Label();
            this.labelH = new System.Windows.Forms.Label();
            this.textBoxS = new System.Windows.Forms.TextBox();
            this.textBoxH = new System.Windows.Forms.TextBox();
            this.labelSet = new System.Windows.Forms.Label();
            this.buttonColor3 = new System.Windows.Forms.Button();
            this.panelColorbg = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.checkBoxControls = new System.Windows.Forms.CheckBox();
            this.groupBoxClipboard = new System.Windows.Forms.GroupBox();
            this.panelClipboard9 = new System.Windows.Forms.Panel();
            this.panelClipboard10 = new System.Windows.Forms.Panel();
            this.panelClipboard11 = new System.Windows.Forms.Panel();
            this.panelClipboard12 = new System.Windows.Forms.Panel();
            this.buttonToggle = new System.Windows.Forms.Button();
            this.buttonStore3 = new System.Windows.Forms.Button();
            this.buttonLoad3 = new System.Windows.Forms.Button();
            this.groupBoxPalette = new System.Windows.Forms.GroupBox();
            this.buttonResetPalette = new System.Windows.Forms.Button();
            this.labelStore = new System.Windows.Forms.Label();
            this.labelLoad = new System.Windows.Forms.Label();
            this.groupBoxPreview = new System.Windows.Forms.GroupBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonReadGB = new System.Windows.Forms.Button();
            this.groupBoxExport = new System.Windows.Forms.GroupBox();
            this.labelVersion = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paletteEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.presetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startupBorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlTypeAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.tabPresets = new System.Windows.Forms.TabPage();
            this.groupBoxPresets = new System.Windows.Forms.GroupBox();
            this.textBoxPreset1 = new System.Windows.Forms.TextBox();
            this.textBoxPreset2 = new System.Windows.Forms.TextBox();
            this.textBoxPreset3 = new System.Windows.Forms.TextBox();
            this.textBoxPreset4 = new System.Windows.Forms.TextBox();
            this.textBoxPreset5 = new System.Windows.Forms.TextBox();
            this.textBoxPreset6 = new System.Windows.Forms.TextBox();
            this.textBoxPreset7 = new System.Windows.Forms.TextBox();
            this.textBoxPreset8 = new System.Windows.Forms.TextBox();
            this.textBoxPreset9 = new System.Windows.Forms.TextBox();
            this.textBoxPreset10 = new System.Windows.Forms.TextBox();
            this.textBoxPreset11 = new System.Windows.Forms.TextBox();
            this.textBoxPreset12 = new System.Windows.Forms.TextBox();
            this.textBoxPreset13 = new System.Windows.Forms.TextBox();
            this.textBoxPreset14 = new System.Windows.Forms.TextBox();
            this.textBoxPreset15 = new System.Windows.Forms.TextBox();
            this.textBoxPreset16 = new System.Windows.Forms.TextBox();
            this.textBoxPreset17 = new System.Windows.Forms.TextBox();
            this.textBoxPreset18 = new System.Windows.Forms.TextBox();
            this.textBoxPreset19 = new System.Windows.Forms.TextBox();
            this.textBoxPreset20 = new System.Windows.Forms.TextBox();
            this.textBoxPreset21 = new System.Windows.Forms.TextBox();
            this.textBoxPreset22 = new System.Windows.Forms.TextBox();
            this.textBoxPreset23 = new System.Windows.Forms.TextBox();
            this.textBoxPreset24 = new System.Windows.Forms.TextBox();
            this.textBoxPreset25 = new System.Windows.Forms.TextBox();
            this.textBoxPreset26 = new System.Windows.Forms.TextBox();
            this.textBoxPreset27 = new System.Windows.Forms.TextBox();
            this.textBoxPreset28 = new System.Windows.Forms.TextBox();
            this.textBoxPreset29 = new System.Windows.Forms.TextBox();
            this.textBoxPreset30 = new System.Windows.Forms.TextBox();
            this.textBoxPreset31 = new System.Windows.Forms.TextBox();
            this.textBoxPreset32 = new System.Windows.Forms.TextBox();
            this.textBoxPreset33 = new System.Windows.Forms.TextBox();
            this.textBoxPreset34 = new System.Windows.Forms.TextBox();
            this.textBoxPreset35 = new System.Windows.Forms.TextBox();
            this.textBoxPreset36 = new System.Windows.Forms.TextBox();
            this.textBoxPreset37 = new System.Windows.Forms.TextBox();
            this.textBoxPreset38 = new System.Windows.Forms.TextBox();
            this.textBoxPreset39 = new System.Windows.Forms.TextBox();
            this.textBoxPreset40 = new System.Windows.Forms.TextBox();
            this.textBoxPreset41 = new System.Windows.Forms.TextBox();
            this.textBoxPreset42 = new System.Windows.Forms.TextBox();
            this.textBoxPreset43 = new System.Windows.Forms.TextBox();
            this.textBoxPreset44 = new System.Windows.Forms.TextBox();
            this.textBoxPreset45 = new System.Windows.Forms.TextBox();
            this.textBoxPreset46 = new System.Windows.Forms.TextBox();
            this.textBoxPreset47 = new System.Windows.Forms.TextBox();
            this.textBoxPreset48 = new System.Windows.Forms.TextBox();
            this.textBoxPreset49 = new System.Windows.Forms.TextBox();
            this.textBoxPreset50 = new System.Windows.Forms.TextBox();
            this.textBoxPreset51 = new System.Windows.Forms.TextBox();
            this.textBoxPreset52 = new System.Windows.Forms.TextBox();
            this.textBoxPreset53 = new System.Windows.Forms.TextBox();
            this.textBoxPreset54 = new System.Windows.Forms.TextBox();
            this.textBoxPreset55 = new System.Windows.Forms.TextBox();
            this.textBoxPreset56 = new System.Windows.Forms.TextBox();
            this.textBoxPreset57 = new System.Windows.Forms.TextBox();
            this.textBoxPreset58 = new System.Windows.Forms.TextBox();
            this.textBoxPreset59 = new System.Windows.Forms.TextBox();
            this.textBoxPreset60 = new System.Windows.Forms.TextBox();
            this.textBoxPreset61 = new System.Windows.Forms.TextBox();
            this.textBoxPreset62 = new System.Windows.Forms.TextBox();
            this.textBoxPreset63 = new System.Windows.Forms.TextBox();
            this.textBoxPreset64 = new System.Windows.Forms.TextBox();
            this.textBoxPreset65 = new System.Windows.Forms.TextBox();
            this.textBoxPreset66 = new System.Windows.Forms.TextBox();
            this.textBoxPreset67 = new System.Windows.Forms.TextBox();
            this.textBoxPreset68 = new System.Windows.Forms.TextBox();
            this.textBoxPreset69 = new System.Windows.Forms.TextBox();
            this.textBoxPreset70 = new System.Windows.Forms.TextBox();
            this.textBoxPreset71 = new System.Windows.Forms.TextBox();
            this.textBoxPreset72 = new System.Windows.Forms.TextBox();
            this.tabBorders = new System.Windows.Forms.TabPage();
            this.groupBoxBorder = new System.Windows.Forms.GroupBox();
            this.labelBordersInfo = new System.Windows.Forms.Label();
            this.buttonBoarderImportFile = new System.Windows.Forms.Button();
            this.pictureBoxGameinBorder = new System.Windows.Forms.PictureBox();
            this.comboBoxBorder = new System.Windows.Forms.ComboBox();
            this.pictureBoxBorder = new System.Windows.Forms.PictureBox();
            this.groupBoxBorderInfo = new System.Windows.Forms.GroupBox();
            this.trackBarRed = new SGB_Palette_Editor.NoFocusTrackBar();
            this.trackBarBlue = new SGB_Palette_Editor.NoFocusTrackBar();
            this.trackBarGreen = new SGB_Palette_Editor.NoFocusTrackBar();
            this.trackBarH = new SGB_Palette_Editor.NoFocusTrackBar();
            this.trackBarS = new SGB_Palette_Editor.NoFocusTrackBar();
            this.trackBarV = new SGB_Palette_Editor.NoFocusTrackBar();
            this.panelPalettebg.SuspendLayout();
            this.screenshotPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBoxEditColor.SuspendLayout();
            this.tabControlColorformat.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.groupBoxClipboard.SuspendLayout();
            this.groupBoxPalette.SuspendLayout();
            this.groupBoxPreview.SuspendLayout();
            this.groupBoxExport.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabPresets.SuspendLayout();
            this.groupBoxPresets.SuspendLayout();
            this.tabBorders.SuspendLayout();
            this.groupBoxBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGameinBorder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBorder)).BeginInit();
            this.groupBoxBorderInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarV)).BeginInit();
            this.SuspendLayout();
            // 
            // panelClipboard1
            // 
            this.panelClipboard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(206)))), ((int)(((byte)(24)))));
            this.panelClipboard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelClipboard1.Location = new System.Drawing.Point(12, 18);
            this.panelClipboard1.Name = "panelClipboard1";
            this.panelClipboard1.Size = new System.Drawing.Size(16, 16);
            this.panelClipboard1.TabIndex = 99;
            this.panelClipboard1.Click += new System.EventHandler(this.storagepanelClick);
            // 
            // textboxRGB
            // 
            this.textboxRGB.Location = new System.Drawing.Point(162, 204);
            this.textboxRGB.MaxLength = 7;
            this.textboxRGB.Name = "textboxRGB";
            this.textboxRGB.Size = new System.Drawing.Size(100, 20);
            this.textboxRGB.TabIndex = 1;
            this.textboxRGB.TextChanged += new System.EventHandler(this.rgb24value_Change);
            // 
            // textboxBGR15
            // 
            this.textboxBGR15.Location = new System.Drawing.Point(162, 230);
            this.textboxBGR15.MaxLength = 4;
            this.textboxBGR15.Name = "textboxBGR15";
            this.textboxBGR15.Size = new System.Drawing.Size(100, 20);
            this.textboxBGR15.TabIndex = 2;
            this.textboxBGR15.Text = "0f35";
            this.textboxBGR15.TextChanged += new System.EventHandler(this.bgr15value_Change);
            // 
            // buttonColor1
            // 
            this.buttonColor1.Location = new System.Drawing.Point(62, 265);
            this.buttonColor1.Name = "buttonColor1";
            this.buttonColor1.Size = new System.Drawing.Size(59, 23);
            this.buttonColor1.TabIndex = 7;
            this.buttonColor1.Text = "Color 1";
            this.toolTip.SetToolTip(this.buttonColor1, "Lightest");
            this.buttonColor1.UseVisualStyleBackColor = true;
            this.buttonColor1.Click += new System.EventHandler(this.buttonSetColor_Click);
            // 
            // panelActiveColor
            // 
            this.panelActiveColor.Location = new System.Drawing.Point(268, 204);
            this.panelActiveColor.Name = "panelActiveColor";
            this.panelActiveColor.Size = new System.Drawing.Size(46, 46);
            this.panelActiveColor.TabIndex = 99;
            this.toolTip.SetToolTip(this.panelActiveColor, "Preview of SNES safe color");
            this.panelActiveColor.Click += new System.EventHandler(this.panelActiveColor_Click);
            // 
            // comboBoxPaletteslot
            // 
            this.comboBoxPaletteslot.FormattingEnabled = true;
            this.comboBoxPaletteslot.Items.AddRange(new object[] {
            "1-A",
            "1-B",
            "1-C",
            "1-D",
            "1-E",
            "1-F",
            "1-G",
            "1-H",
            "2-A",
            "2-B",
            "2-C",
            "2-D",
            "2-E",
            "2-F",
            "2-G",
            "2-H",
            "3-A",
            "3-B",
            "3-C",
            "3-D",
            "3-E",
            "3-F",
            "3-G",
            "3-H",
            "4-A",
            "4-B",
            "4-C",
            "4-D",
            "4-E",
            "4-F",
            "4-G",
            "4-H"});
            this.comboBoxPaletteslot.Location = new System.Drawing.Point(106, 19);
            this.comboBoxPaletteslot.Name = "comboBoxPaletteslot";
            this.comboBoxPaletteslot.Size = new System.Drawing.Size(70, 21);
            this.comboBoxPaletteslot.TabIndex = 11;
            this.comboBoxPaletteslot.Text = "1-A";
            this.comboBoxPaletteslot.SelectedValueChanged += new System.EventHandler(this.comboBoxPaletteslot_SelectedValueChanged);
            // 
            // buttonColor2
            // 
            this.buttonColor2.Location = new System.Drawing.Point(127, 265);
            this.buttonColor2.Name = "buttonColor2";
            this.buttonColor2.Size = new System.Drawing.Size(59, 23);
            this.buttonColor2.TabIndex = 8;
            this.buttonColor2.Text = "Color 2";
            this.toolTip.SetToolTip(this.buttonColor2, "Light");
            this.buttonColor2.UseVisualStyleBackColor = true;
            this.buttonColor2.Click += new System.EventHandler(this.buttonSetColor_Click);
            // 
            // buttonColor4
            // 
            this.buttonColor4.Location = new System.Drawing.Point(257, 265);
            this.buttonColor4.Name = "buttonColor4";
            this.buttonColor4.Size = new System.Drawing.Size(59, 23);
            this.buttonColor4.TabIndex = 10;
            this.buttonColor4.Text = "Color 4";
            this.toolTip.SetToolTip(this.buttonColor4, "Darkest");
            this.buttonColor4.UseVisualStyleBackColor = true;
            this.buttonColor4.Click += new System.EventHandler(this.buttonSetColor_Click);
            // 
            // panelPalettebg
            // 
            this.panelPalettebg.BackColor = System.Drawing.Color.Black;
            this.panelPalettebg.Controls.Add(this.panelColor1);
            this.panelPalettebg.Controls.Add(this.panelColor2);
            this.panelPalettebg.Controls.Add(this.panelColor3);
            this.panelPalettebg.Controls.Add(this.panelColor4);
            this.panelPalettebg.Location = new System.Drawing.Point(15, 42);
            this.panelPalettebg.Name = "panelPalettebg";
            this.panelPalettebg.Size = new System.Drawing.Size(73, 61);
            this.panelPalettebg.TabIndex = 99;
            // 
            // panelColor1
            // 
            this.panelColor1.BackColor = System.Drawing.Color.White;
            this.panelColor1.Location = new System.Drawing.Point(1, 1);
            this.panelColor1.Name = "panelColor1";
            this.panelColor1.Size = new System.Drawing.Size(38, 26);
            this.panelColor1.TabIndex = 99;
            this.panelColor1.Click += new System.EventHandler(this.panelColor_Click);
            // 
            // panelColor2
            // 
            this.panelColor2.BackColor = System.Drawing.Color.LightGray;
            this.panelColor2.Location = new System.Drawing.Point(1, 28);
            this.panelColor2.Name = "panelColor2";
            this.panelColor2.Size = new System.Drawing.Size(38, 32);
            this.panelColor2.TabIndex = 99;
            this.toolTip.SetToolTip(this.panelColor2, "Test");
            this.panelColor2.Click += new System.EventHandler(this.panelColor_Click);
            // 
            // panelColor3
            // 
            this.panelColor3.BackColor = System.Drawing.Color.DarkGray;
            this.panelColor3.Location = new System.Drawing.Point(40, 28);
            this.panelColor3.Name = "panelColor3";
            this.panelColor3.Size = new System.Drawing.Size(32, 32);
            this.panelColor3.TabIndex = 99;
            this.panelColor3.Click += new System.EventHandler(this.panelColor_Click);
            // 
            // panelColor4
            // 
            this.panelColor4.BackColor = System.Drawing.Color.DimGray;
            this.panelColor4.Location = new System.Drawing.Point(40, 1);
            this.panelColor4.Name = "panelColor4";
            this.panelColor4.Size = new System.Drawing.Size(32, 26);
            this.panelColor4.TabIndex = 99;
            this.panelColor4.Click += new System.EventHandler(this.panelColor_Click);
            // 
            // panelClipboard2
            // 
            this.panelClipboard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(165)))), ((int)(((byte)(24)))));
            this.panelClipboard2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelClipboard2.Location = new System.Drawing.Point(34, 18);
            this.panelClipboard2.Name = "panelClipboard2";
            this.panelClipboard2.Size = new System.Drawing.Size(16, 16);
            this.panelClipboard2.TabIndex = 99;
            this.panelClipboard2.Click += new System.EventHandler(this.storagepanelClick);
            // 
            // panelClipboard3
            // 
            this.panelClipboard3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(115)))), ((int)(((byte)(66)))));
            this.panelClipboard3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelClipboard3.Location = new System.Drawing.Point(56, 18);
            this.panelClipboard3.Name = "panelClipboard3";
            this.panelClipboard3.Size = new System.Drawing.Size(16, 16);
            this.panelClipboard3.TabIndex = 99;
            this.panelClipboard3.Click += new System.EventHandler(this.storagepanelClick);
            // 
            // panelClipboard4
            // 
            this.panelClipboard4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(74)))), ((int)(((byte)(49)))));
            this.panelClipboard4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelClipboard4.Location = new System.Drawing.Point(78, 18);
            this.panelClipboard4.Name = "panelClipboard4";
            this.panelClipboard4.Size = new System.Drawing.Size(16, 16);
            this.panelClipboard4.TabIndex = 99;
            this.panelClipboard4.Click += new System.EventHandler(this.storagepanelClick);
            // 
            // panelClipboard5
            // 
            this.panelClipboard5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(214)))));
            this.panelClipboard5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelClipboard5.Location = new System.Drawing.Point(100, 18);
            this.panelClipboard5.Name = "panelClipboard5";
            this.panelClipboard5.Size = new System.Drawing.Size(16, 16);
            this.panelClipboard5.TabIndex = 99;
            this.panelClipboard5.Click += new System.EventHandler(this.storagepanelClick);
            // 
            // panelClipboard6
            // 
            this.panelClipboard6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(173)))), ((int)(((byte)(115)))));
            this.panelClipboard6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelClipboard6.Location = new System.Drawing.Point(122, 18);
            this.panelClipboard6.Name = "panelClipboard6";
            this.panelClipboard6.Size = new System.Drawing.Size(16, 16);
            this.panelClipboard6.TabIndex = 99;
            this.panelClipboard6.Click += new System.EventHandler(this.storagepanelClick);
            // 
            // panelClipboard7
            // 
            this.panelClipboard7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(123)))), ((int)(((byte)(99)))));
            this.panelClipboard7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelClipboard7.Location = new System.Drawing.Point(143, 18);
            this.panelClipboard7.Name = "panelClipboard7";
            this.panelClipboard7.Size = new System.Drawing.Size(16, 16);
            this.panelClipboard7.TabIndex = 99;
            this.panelClipboard7.Click += new System.EventHandler(this.storagepanelClick);
            // 
            // panelClipboard8
            // 
            this.panelClipboard8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(33)))), ((int)(((byte)(49)))));
            this.panelClipboard8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelClipboard8.Location = new System.Drawing.Point(165, 18);
            this.panelClipboard8.Name = "panelClipboard8";
            this.panelClipboard8.Size = new System.Drawing.Size(16, 16);
            this.panelClipboard8.TabIndex = 99;
            this.panelClipboard8.Click += new System.EventHandler(this.storagepanelClick);
            // 
            // buttonIps
            // 
            this.buttonIps.Location = new System.Drawing.Point(255, 87);
            this.buttonIps.Name = "buttonIps";
            this.buttonIps.Size = new System.Drawing.Size(125, 23);
            this.buttonIps.TabIndex = 25;
            this.buttonIps.Text = "Generate ips patch";
            this.toolTip.SetToolTip(this.buttonIps, "Generate an ips patch and share it!");
            this.buttonIps.UseVisualStyleBackColor = true;
            this.buttonIps.Click += new System.EventHandler(this.buttonIps_Click);
            // 
            // labelGame
            // 
            this.labelGame.AutoSize = true;
            this.labelGame.Location = new System.Drawing.Point(14, 22);
            this.labelGame.Name = "labelGame";
            this.labelGame.Size = new System.Drawing.Size(38, 13);
            this.labelGame.TabIndex = 99;
            this.labelGame.Text = "Game:";
            // 
            // comboBoxGame
            // 
            this.comboBoxGame.DisplayMember = "None found";
            this.comboBoxGame.FormattingEnabled = true;
            this.comboBoxGame.Location = new System.Drawing.Point(58, 19);
            this.comboBoxGame.Name = "comboBoxGame";
            this.comboBoxGame.Size = new System.Drawing.Size(119, 21);
            this.comboBoxGame.TabIndex = 20;
            this.comboBoxGame.SelectedValueChanged += new System.EventHandler(this.comboBoxGame_SelectedValueChanged);
            // 
            // labelClick
            // 
            this.labelClick.AutoSize = true;
            this.labelClick.Location = new System.Drawing.Point(21, 107);
            this.labelClick.Name = "labelClick";
            this.labelClick.Size = new System.Drawing.Size(62, 13);
            this.labelClick.TabIndex = 99;
            this.labelClick.Text = "Click to edit";
            // 
            // buttonStore1
            // 
            this.buttonStore1.Location = new System.Drawing.Point(24, 143);
            this.buttonStore1.Name = "buttonStore1";
            this.buttonStore1.Size = new System.Drawing.Size(44, 23);
            this.buttonStore1.TabIndex = 14;
            this.buttonStore1.Text = "Slot 1";
            this.buttonStore1.UseVisualStyleBackColor = true;
            this.buttonStore1.Click += new System.EventHandler(this.buttonStorePalette_Click);
            // 
            // comboBoxVersion
            // 
            this.comboBoxVersion.FormattingEnabled = true;
            this.comboBoxVersion.Items.AddRange(new object[] {
            "Super Game Boy 2 (Japan)",
            "Super Game Boy (World) (Rev 2)",
            "Super Game Boy (Japan, USA) (Rev 1)",
            "Super Game Boy (Japan)",
            "Super Game Boy (Japan, USA) (Beta)"});
            this.comboBoxVersion.Location = new System.Drawing.Point(188, 54);
            this.comboBoxVersion.Name = "comboBoxVersion";
            this.comboBoxVersion.Size = new System.Drawing.Size(192, 21);
            this.comboBoxVersion.TabIndex = 22;
            this.comboBoxVersion.Text = "Super Game Boy 2 (Japan)";
            this.toolTip.SetToolTip(this.comboBoxVersion, "Optional, only used for patch export.");
            this.comboBoxVersion.SelectedIndexChanged += new System.EventHandler(this.comboBoxVersion_SelectedIndexChanged);
            // 
            // labelPalette
            // 
            this.labelPalette.AutoSize = true;
            this.labelPalette.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPalette.Location = new System.Drawing.Point(14, 22);
            this.labelPalette.Name = "labelPalette";
            this.labelPalette.Size = new System.Drawing.Size(62, 13);
            this.labelPalette.TabIndex = 99;
            this.labelPalette.Text = "Palette slot:";
            // 
            // labelHexcolor
            // 
            this.labelHexcolor.AutoSize = true;
            this.labelHexcolor.Location = new System.Drawing.Point(17, 208);
            this.labelHexcolor.Name = "labelHexcolor";
            this.labelHexcolor.Size = new System.Drawing.Size(123, 13);
            this.labelHexcolor.TabIndex = 99;
            this.labelHexcolor.Text = "Hex color code (RGB24)";
            // 
            // labelSnescolor
            // 
            this.labelSnescolor.AutoSize = true;
            this.labelSnescolor.Location = new System.Drawing.Point(17, 233);
            this.labelSnescolor.Name = "labelSnescolor";
            this.labelSnescolor.Size = new System.Drawing.Size(133, 13);
            this.labelSnescolor.TabIndex = 99;
            this.labelSnescolor.Text = "SNES color code (BGR15)";
            // 
            // buttonStore2
            // 
            this.buttonStore2.Location = new System.Drawing.Point(74, 143);
            this.buttonStore2.Name = "buttonStore2";
            this.buttonStore2.Size = new System.Drawing.Size(44, 23);
            this.buttonStore2.TabIndex = 15;
            this.buttonStore2.Text = "Slot 2";
            this.buttonStore2.UseVisualStyleBackColor = true;
            this.buttonStore2.Click += new System.EventHandler(this.buttonStorePalette_Click);
            // 
            // buttonLoad1
            // 
            this.buttonLoad1.Location = new System.Drawing.Point(24, 189);
            this.buttonLoad1.Name = "buttonLoad1";
            this.buttonLoad1.Size = new System.Drawing.Size(44, 23);
            this.buttonLoad1.TabIndex = 17;
            this.buttonLoad1.Text = "Slot 1";
            this.buttonLoad1.UseVisualStyleBackColor = true;
            this.buttonLoad1.Click += new System.EventHandler(this.buttonLoadPalette_Click);
            // 
            // buttonLoad2
            // 
            this.buttonLoad2.Location = new System.Drawing.Point(74, 189);
            this.buttonLoad2.Name = "buttonLoad2";
            this.buttonLoad2.Size = new System.Drawing.Size(44, 23);
            this.buttonLoad2.TabIndex = 18;
            this.buttonLoad2.Text = "Slot 2";
            this.buttonLoad2.UseVisualStyleBackColor = true;
            this.buttonLoad2.Click += new System.EventHandler(this.buttonLoadPalette_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "SNES ROM files|*.sfc; *.bin|All files|*.*";
            this.openFileDialog.Title = "Select \"Super Game Boy 2 (Japan).sfc\"";
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(25, 87);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(100, 23);
            this.buttonImport.TabIndex = 23;
            this.buttonImport.Text = "Import from .sfc";
            this.toolTip.SetToolTip(this.buttonImport, "Import palettes from SGB rom file.");
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // buttonModify
            // 
            this.buttonModify.Location = new System.Drawing.Point(141, 87);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(100, 23);
            this.buttonModify.TabIndex = 24;
            this.buttonModify.Text = "Modify .sfc";
            this.toolTip.SetToolTip(this.buttonModify, "Modify SGB rom file with your custom palettes.");
            this.buttonModify.UseVisualStyleBackColor = true;
            this.buttonModify.Click += new System.EventHandler(this.buttonModify_Click);
            // 
            // screenshotPanel
            // 
            this.screenshotPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.screenshotPanel.Controls.Add(this.pictureBox);
            this.screenshotPanel.Location = new System.Drawing.Point(15, 54);
            this.screenshotPanel.Name = "screenshotPanel";
            this.screenshotPanel.Size = new System.Drawing.Size(162, 146);
            this.screenshotPanel.TabIndex = 99;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Black;
            this.pictureBox.InitialImage = null;
            this.pictureBox.Location = new System.Drawing.Point(1, 1);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(160, 144);
            this.pictureBox.TabIndex = 99;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            // 
            // textBoxRDec
            // 
            this.textBoxRDec.Location = new System.Drawing.Point(226, 25);
            this.textBoxRDec.MaxLength = 3;
            this.textBoxRDec.Name = "textBoxRDec";
            this.textBoxRDec.Size = new System.Drawing.Size(34, 20);
            this.textBoxRDec.TabIndex = 4;
            this.textBoxRDec.TextChanged += new System.EventHandler(this.rgbdecBox_TextChanged);
            // 
            // textBoxRHex
            // 
            this.textBoxRHex.Location = new System.Drawing.Point(268, 25);
            this.textBoxRHex.MaxLength = 2;
            this.textBoxRHex.Name = "textBoxRHex";
            this.textBoxRHex.Size = new System.Drawing.Size(34, 20);
            this.textBoxRHex.TabIndex = 99;
            this.textBoxRHex.TabStop = false;
            this.textBoxRHex.TextChanged += new System.EventHandler(this.rgbhexBox_TextChanged);
            // 
            // textBoxGDec
            // 
            this.textBoxGDec.Location = new System.Drawing.Point(226, 66);
            this.textBoxGDec.MaxLength = 3;
            this.textBoxGDec.Name = "textBoxGDec";
            this.textBoxGDec.Size = new System.Drawing.Size(34, 20);
            this.textBoxGDec.TabIndex = 5;
            this.textBoxGDec.TextChanged += new System.EventHandler(this.rgbdecBox_TextChanged);
            // 
            // textBoxGHex
            // 
            this.textBoxGHex.Location = new System.Drawing.Point(268, 66);
            this.textBoxGHex.MaxLength = 2;
            this.textBoxGHex.Name = "textBoxGHex";
            this.textBoxGHex.Size = new System.Drawing.Size(34, 20);
            this.textBoxGHex.TabIndex = 99;
            this.textBoxGHex.TabStop = false;
            this.textBoxGHex.TextChanged += new System.EventHandler(this.rgbhexBox_TextChanged);
            // 
            // textBoxBDec
            // 
            this.textBoxBDec.Location = new System.Drawing.Point(226, 106);
            this.textBoxBDec.MaxLength = 3;
            this.textBoxBDec.Name = "textBoxBDec";
            this.textBoxBDec.Size = new System.Drawing.Size(34, 20);
            this.textBoxBDec.TabIndex = 6;
            this.textBoxBDec.TextChanged += new System.EventHandler(this.rgbdecBox_TextChanged);
            // 
            // textBoxBHex
            // 
            this.textBoxBHex.Location = new System.Drawing.Point(268, 106);
            this.textBoxBHex.MaxLength = 2;
            this.textBoxBHex.Name = "textBoxBHex";
            this.textBoxBHex.Size = new System.Drawing.Size(34, 20);
            this.textBoxBHex.TabIndex = 99;
            this.textBoxBHex.TabStop = false;
            this.textBoxBHex.TextChanged += new System.EventHandler(this.rgbhexBox_TextChanged);
            // 
            // labelDec
            // 
            this.labelDec.AutoSize = true;
            this.labelDec.Location = new System.Drawing.Point(230, 7);
            this.labelDec.Name = "labelDec";
            this.labelDec.Size = new System.Drawing.Size(27, 13);
            this.labelDec.TabIndex = 99;
            this.labelDec.Text = "Dec";
            // 
            // labelHex
            // 
            this.labelHex.AutoSize = true;
            this.labelHex.Location = new System.Drawing.Point(272, 7);
            this.labelHex.Name = "labelHex";
            this.labelHex.Size = new System.Drawing.Size(26, 13);
            this.labelHex.TabIndex = 99;
            this.labelHex.Text = "Hex";
            // 
            // labelRed
            // 
            this.labelRed.AutoSize = true;
            this.labelRed.Location = new System.Drawing.Point(13, 27);
            this.labelRed.Name = "labelRed";
            this.labelRed.Size = new System.Drawing.Size(27, 13);
            this.labelRed.TabIndex = 99;
            this.labelRed.Text = "Red";
            // 
            // labelGreen
            // 
            this.labelGreen.AutoSize = true;
            this.labelGreen.Location = new System.Drawing.Point(13, 67);
            this.labelGreen.Name = "labelGreen";
            this.labelGreen.Size = new System.Drawing.Size(36, 13);
            this.labelGreen.TabIndex = 99;
            this.labelGreen.Text = "Green";
            // 
            // labelBlue
            // 
            this.labelBlue.AutoSize = true;
            this.labelBlue.Location = new System.Drawing.Point(13, 107);
            this.labelBlue.Name = "labelBlue";
            this.labelBlue.Size = new System.Drawing.Size(28, 13);
            this.labelBlue.TabIndex = 99;
            this.labelBlue.Text = "Blue";
            // 
            // groupBoxEditColor
            // 
            this.groupBoxEditColor.Controls.Add(this.panelActiveColor);
            this.groupBoxEditColor.Controls.Add(this.tabControlColorformat);
            this.groupBoxEditColor.Controls.Add(this.labelSet);
            this.groupBoxEditColor.Controls.Add(this.textboxRGB);
            this.groupBoxEditColor.Controls.Add(this.labelSnescolor);
            this.groupBoxEditColor.Controls.Add(this.labelHexcolor);
            this.groupBoxEditColor.Controls.Add(this.textboxBGR15);
            this.groupBoxEditColor.Controls.Add(this.buttonColor1);
            this.groupBoxEditColor.Controls.Add(this.buttonColor2);
            this.groupBoxEditColor.Controls.Add(this.buttonColor3);
            this.groupBoxEditColor.Controls.Add(this.buttonColor4);
            this.groupBoxEditColor.Controls.Add(this.panelColorbg);
            this.groupBoxEditColor.Location = new System.Drawing.Point(11, 64);
            this.groupBoxEditColor.Name = "groupBoxEditColor";
            this.groupBoxEditColor.Size = new System.Drawing.Size(335, 303);
            this.groupBoxEditColor.TabIndex = 99;
            this.groupBoxEditColor.TabStop = false;
            this.groupBoxEditColor.Text = "Edit color";
            // 
            // tabControlColorformat
            // 
            this.tabControlColorformat.Controls.Add(this.tabPage1);
            this.tabControlColorformat.Controls.Add(this.tabPage2);
            this.tabControlColorformat.Location = new System.Drawing.Point(7, 20);
            this.tabControlColorformat.Name = "tabControlColorformat";
            this.tabControlColorformat.SelectedIndex = 0;
            this.tabControlColorformat.Size = new System.Drawing.Size(323, 166);
            this.tabControlColorformat.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Menu;
            this.tabPage1.Controls.Add(this.trackBarRed);
            this.tabPage1.Controls.Add(this.labelBlue);
            this.tabPage1.Controls.Add(this.labelGreen);
            this.tabPage1.Controls.Add(this.textBoxBDec);
            this.tabPage1.Controls.Add(this.textBoxRHex);
            this.tabPage1.Controls.Add(this.trackBarBlue);
            this.tabPage1.Controls.Add(this.labelHex);
            this.tabPage1.Controls.Add(this.textBoxRDec);
            this.tabPage1.Controls.Add(this.trackBarGreen);
            this.tabPage1.Controls.Add(this.labelDec);
            this.tabPage1.Controls.Add(this.textBoxGHex);
            this.tabPage1.Controls.Add(this.labelRed);
            this.tabPage1.Controls.Add(this.textBoxGDec);
            this.tabPage1.Controls.Add(this.textBoxBHex);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(315, 140);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "RGB";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Menu;
            this.tabPage2.Controls.Add(this.labelV);
            this.tabPage2.Controls.Add(this.textBoxV);
            this.tabPage2.Controls.Add(this.labelS);
            this.tabPage2.Controls.Add(this.labelH);
            this.tabPage2.Controls.Add(this.textBoxS);
            this.tabPage2.Controls.Add(this.textBoxH);
            this.tabPage2.Controls.Add(this.trackBarH);
            this.tabPage2.Controls.Add(this.trackBarS);
            this.tabPage2.Controls.Add(this.trackBarV);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(315, 140);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "HSV";
            // 
            // labelV
            // 
            this.labelV.AutoSize = true;
            this.labelV.Location = new System.Drawing.Point(13, 107);
            this.labelV.Name = "labelV";
            this.labelV.Size = new System.Drawing.Size(56, 13);
            this.labelV.TabIndex = 99;
            this.labelV.Text = "Brightness";
            // 
            // textBoxV
            // 
            this.textBoxV.Location = new System.Drawing.Point(268, 106);
            this.textBoxV.MaxLength = 3;
            this.textBoxV.Name = "textBoxV";
            this.textBoxV.Size = new System.Drawing.Size(34, 20);
            this.textBoxV.TabIndex = 6;
            this.textBoxV.TextChanged += new System.EventHandler(this.textBoxHSV_TextChanged);
            // 
            // labelS
            // 
            this.labelS.AutoSize = true;
            this.labelS.Location = new System.Drawing.Point(13, 67);
            this.labelS.Name = "labelS";
            this.labelS.Size = new System.Drawing.Size(55, 13);
            this.labelS.TabIndex = 99;
            this.labelS.Text = "Saturation";
            // 
            // labelH
            // 
            this.labelH.AutoSize = true;
            this.labelH.Location = new System.Drawing.Point(13, 27);
            this.labelH.Name = "labelH";
            this.labelH.Size = new System.Drawing.Size(27, 13);
            this.labelH.TabIndex = 99;
            this.labelH.Text = "Hue";
            // 
            // textBoxS
            // 
            this.textBoxS.Location = new System.Drawing.Point(268, 66);
            this.textBoxS.MaxLength = 3;
            this.textBoxS.Name = "textBoxS";
            this.textBoxS.Size = new System.Drawing.Size(34, 20);
            this.textBoxS.TabIndex = 5;
            this.textBoxS.TextChanged += new System.EventHandler(this.textBoxHSV_TextChanged);
            // 
            // textBoxH
            // 
            this.textBoxH.Location = new System.Drawing.Point(268, 25);
            this.textBoxH.MaxLength = 3;
            this.textBoxH.Name = "textBoxH";
            this.textBoxH.Size = new System.Drawing.Size(34, 20);
            this.textBoxH.TabIndex = 4;
            this.textBoxH.TextChanged += new System.EventHandler(this.textBoxHSV_TextChanged);
            // 
            // labelSet
            // 
            this.labelSet.AutoSize = true;
            this.labelSet.Location = new System.Drawing.Point(17, 270);
            this.labelSet.Name = "labelSet";
            this.labelSet.Size = new System.Drawing.Size(40, 13);
            this.labelSet.TabIndex = 99;
            this.labelSet.Text = "Set as:";
            // 
            // buttonColor3
            // 
            this.buttonColor3.Location = new System.Drawing.Point(192, 265);
            this.buttonColor3.Name = "buttonColor3";
            this.buttonColor3.Size = new System.Drawing.Size(59, 23);
            this.buttonColor3.TabIndex = 9;
            this.buttonColor3.Text = "Color 3";
            this.toolTip.SetToolTip(this.buttonColor3, "Dark");
            this.buttonColor3.UseVisualStyleBackColor = true;
            this.buttonColor3.Click += new System.EventHandler(this.buttonSetColor_Click);
            // 
            // panelColorbg
            // 
            this.panelColorbg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.panelColorbg.Location = new System.Drawing.Point(267, 203);
            this.panelColorbg.Name = "panelColorbg";
            this.panelColorbg.Size = new System.Drawing.Size(48, 48);
            this.panelColorbg.TabIndex = 99;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 420);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(788, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 99;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // checkBoxControls
            // 
            this.checkBoxControls.AutoSize = true;
            this.checkBoxControls.Location = new System.Drawing.Point(26, 27);
            this.checkBoxControls.Name = "checkBoxControls";
            this.checkBoxControls.Size = new System.Drawing.Size(187, 17);
            this.checkBoxControls.TabIndex = 21;
            this.checkBoxControls.Text = "Change default controls to Type A";
            this.toolTip.SetToolTip(this.checkBoxControls, "Type A: SNES B button = Game Boy A button");
            this.checkBoxControls.UseVisualStyleBackColor = true;
            this.checkBoxControls.CheckedChanged += new System.EventHandler(this.checkBoxControls_CheckedChanged);
            // 
            // groupBoxClipboard
            // 
            this.groupBoxClipboard.Controls.Add(this.panelClipboard1);
            this.groupBoxClipboard.Controls.Add(this.panelClipboard2);
            this.groupBoxClipboard.Controls.Add(this.panelClipboard3);
            this.groupBoxClipboard.Controls.Add(this.panelClipboard4);
            this.groupBoxClipboard.Controls.Add(this.panelClipboard5);
            this.groupBoxClipboard.Controls.Add(this.panelClipboard6);
            this.groupBoxClipboard.Controls.Add(this.panelClipboard7);
            this.groupBoxClipboard.Controls.Add(this.panelClipboard8);
            this.groupBoxClipboard.Controls.Add(this.panelClipboard9);
            this.groupBoxClipboard.Controls.Add(this.panelClipboard10);
            this.groupBoxClipboard.Controls.Add(this.panelClipboard11);
            this.groupBoxClipboard.Controls.Add(this.panelClipboard12);
            this.groupBoxClipboard.Controls.Add(this.buttonToggle);
            this.groupBoxClipboard.Location = new System.Drawing.Point(11, 4);
            this.groupBoxClipboard.Name = "groupBoxClipboard";
            this.groupBoxClipboard.Size = new System.Drawing.Size(335, 47);
            this.groupBoxClipboard.TabIndex = 99;
            this.groupBoxClipboard.TabStop = false;
            this.groupBoxClipboard.Text = "Clipboard: Load";
            // 
            // panelClipboard9
            // 
            this.panelClipboard9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(189)))));
            this.panelClipboard9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelClipboard9.Location = new System.Drawing.Point(187, 18);
            this.panelClipboard9.Name = "panelClipboard9";
            this.panelClipboard9.Size = new System.Drawing.Size(16, 16);
            this.panelClipboard9.TabIndex = 99;
            this.panelClipboard9.Click += new System.EventHandler(this.storagepanelClick);
            // 
            // panelClipboard10
            // 
            this.panelClipboard10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(165)))), ((int)(((byte)(123)))));
            this.panelClipboard10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelClipboard10.Location = new System.Drawing.Point(209, 18);
            this.panelClipboard10.Name = "panelClipboard10";
            this.panelClipboard10.Size = new System.Drawing.Size(16, 16);
            this.panelClipboard10.TabIndex = 99;
            this.panelClipboard10.Click += new System.EventHandler(this.storagepanelClick);
            // 
            // panelClipboard11
            // 
            this.panelClipboard11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(82)))), ((int)(((byte)(115)))));
            this.panelClipboard11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelClipboard11.Location = new System.Drawing.Point(231, 18);
            this.panelClipboard11.Name = "panelClipboard11";
            this.panelClipboard11.Size = new System.Drawing.Size(16, 16);
            this.panelClipboard11.TabIndex = 99;
            this.panelClipboard11.Click += new System.EventHandler(this.storagepanelClick);
            // 
            // panelClipboard12
            // 
            this.panelClipboard12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(33)))), ((int)(((byte)(66)))));
            this.panelClipboard12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelClipboard12.Location = new System.Drawing.Point(253, 18);
            this.panelClipboard12.Name = "panelClipboard12";
            this.panelClipboard12.Size = new System.Drawing.Size(16, 16);
            this.panelClipboard12.TabIndex = 99;
            this.panelClipboard12.Click += new System.EventHandler(this.storagepanelClick);
            // 
            // buttonToggle
            // 
            this.buttonToggle.Location = new System.Drawing.Point(278, 15);
            this.buttonToggle.Name = "buttonToggle";
            this.buttonToggle.Size = new System.Drawing.Size(48, 23);
            this.buttonToggle.TabIndex = 99;
            this.buttonToggle.TabStop = false;
            this.buttonToggle.Text = "Toggle";
            this.toolTip.SetToolTip(this.buttonToggle, "Load / Store");
            this.buttonToggle.UseVisualStyleBackColor = true;
            this.buttonToggle.Click += new System.EventHandler(this.buttonToggle_Click);
            // 
            // buttonStore3
            // 
            this.buttonStore3.Location = new System.Drawing.Point(124, 143);
            this.buttonStore3.Name = "buttonStore3";
            this.buttonStore3.Size = new System.Drawing.Size(44, 23);
            this.buttonStore3.TabIndex = 16;
            this.buttonStore3.Text = "Slot 3";
            this.buttonStore3.UseVisualStyleBackColor = true;
            this.buttonStore3.Click += new System.EventHandler(this.buttonStorePalette_Click);
            // 
            // buttonLoad3
            // 
            this.buttonLoad3.Location = new System.Drawing.Point(124, 189);
            this.buttonLoad3.Name = "buttonLoad3";
            this.buttonLoad3.Size = new System.Drawing.Size(44, 23);
            this.buttonLoad3.TabIndex = 19;
            this.buttonLoad3.Text = "Slot 3";
            this.buttonLoad3.UseVisualStyleBackColor = true;
            this.buttonLoad3.Click += new System.EventHandler(this.buttonLoadPalette_Click);
            // 
            // groupBoxPalette
            // 
            this.groupBoxPalette.Controls.Add(this.buttonResetPalette);
            this.groupBoxPalette.Controls.Add(this.buttonStore3);
            this.groupBoxPalette.Controls.Add(this.labelStore);
            this.groupBoxPalette.Controls.Add(this.buttonStore1);
            this.groupBoxPalette.Controls.Add(this.buttonStore2);
            this.groupBoxPalette.Controls.Add(this.labelLoad);
            this.groupBoxPalette.Controls.Add(this.comboBoxPaletteslot);
            this.groupBoxPalette.Controls.Add(this.buttonLoad3);
            this.groupBoxPalette.Controls.Add(this.labelPalette);
            this.groupBoxPalette.Controls.Add(this.buttonLoad2);
            this.groupBoxPalette.Controls.Add(this.panelPalettebg);
            this.groupBoxPalette.Controls.Add(this.buttonLoad1);
            this.groupBoxPalette.Controls.Add(this.labelClick);
            this.groupBoxPalette.Location = new System.Drawing.Point(366, 4);
            this.groupBoxPalette.Name = "groupBoxPalette";
            this.groupBoxPalette.Size = new System.Drawing.Size(190, 225);
            this.groupBoxPalette.TabIndex = 99;
            this.groupBoxPalette.TabStop = false;
            this.groupBoxPalette.Text = "Palette";
            // 
            // buttonResetPalette
            // 
            this.buttonResetPalette.Enabled = false;
            this.buttonResetPalette.Location = new System.Drawing.Point(106, 54);
            this.buttonResetPalette.Name = "buttonResetPalette";
            this.buttonResetPalette.Size = new System.Drawing.Size(70, 23);
            this.buttonResetPalette.TabIndex = 13;
            this.buttonResetPalette.Text = "Reset";
            this.toolTip.SetToolTip(this.buttonResetPalette, "Reset current palette.");
            this.buttonResetPalette.UseVisualStyleBackColor = true;
            this.buttonResetPalette.Click += new System.EventHandler(this.buttonResetPalette_Click);
            // 
            // labelStore
            // 
            this.labelStore.AutoSize = true;
            this.labelStore.Location = new System.Drawing.Point(12, 126);
            this.labelStore.Name = "labelStore";
            this.labelStore.Size = new System.Drawing.Size(89, 13);
            this.labelStore.TabIndex = 99;
            this.labelStore.Text = "Store in clipboard";
            // 
            // labelLoad
            // 
            this.labelLoad.AutoSize = true;
            this.labelLoad.Location = new System.Drawing.Point(12, 172);
            this.labelLoad.Name = "labelLoad";
            this.labelLoad.Size = new System.Drawing.Size(100, 13);
            this.labelLoad.TabIndex = 99;
            this.labelLoad.Text = "Load from clipboard";
            // 
            // groupBoxPreview
            // 
            this.groupBoxPreview.Controls.Add(this.comboBoxGame);
            this.groupBoxPreview.Controls.Add(this.screenshotPanel);
            this.groupBoxPreview.Controls.Add(this.labelGame);
            this.groupBoxPreview.Location = new System.Drawing.Point(576, 4);
            this.groupBoxPreview.Name = "groupBoxPreview";
            this.groupBoxPreview.Size = new System.Drawing.Size(191, 225);
            this.groupBoxPreview.TabIndex = 99;
            this.groupBoxPreview.TabStop = false;
            this.groupBoxPreview.Text = "Preview";
            // 
            // buttonReadGB
            // 
            this.buttonReadGB.Location = new System.Drawing.Point(16, 341);
            this.buttonReadGB.Name = "buttonReadGB";
            this.buttonReadGB.Size = new System.Drawing.Size(192, 23);
            this.buttonReadGB.TabIndex = 111;
            this.buttonReadGB.Text = "Read game id from file";
            this.toolTip.SetToolTip(this.buttonReadGB, "Read game id from a Game Boy rom file.");
            this.buttonReadGB.UseVisualStyleBackColor = true;
            this.buttonReadGB.Click += new System.EventHandler(this.buttonReadGB_Click);
            // 
            // groupBoxExport
            // 
            this.groupBoxExport.Controls.Add(this.labelVersion);
            this.groupBoxExport.Controls.Add(this.buttonImport);
            this.groupBoxExport.Controls.Add(this.buttonModify);
            this.groupBoxExport.Controls.Add(this.buttonIps);
            this.groupBoxExport.Controls.Add(this.comboBoxVersion);
            this.groupBoxExport.Controls.Add(this.checkBoxControls);
            this.groupBoxExport.Location = new System.Drawing.Point(366, 242);
            this.groupBoxExport.Name = "groupBoxExport";
            this.groupBoxExport.Size = new System.Drawing.Size(401, 125);
            this.groupBoxExport.TabIndex = 99;
            this.groupBoxExport.TabStop = false;
            this.groupBoxExport.Text = "Import / Export";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(23, 57);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(163, 13);
            this.labelVersion.TabIndex = 99;
            this.labelVersion.Text = "Select SGB version for ips patch:";
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewsToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(788, 24);
            this.menuStrip.TabIndex = 100;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.modifyToolStripMenuItem,
            this.savePatchToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.importToolStripMenuItem.Text = "Load Data";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.buttonImport_Click);
            this.importToolStripMenuItem.MouseEnter += new System.EventHandler(this.importToolStripMenuItem_MouseEnter);
            this.importToolStripMenuItem.MouseLeave += new System.EventHandler(this.toolStripMenuItem_MouseLeave);
            // 
            // modifyToolStripMenuItem
            // 
            this.modifyToolStripMenuItem.Name = "modifyToolStripMenuItem";
            this.modifyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.modifyToolStripMenuItem.Text = "Modify Rom File";
            this.modifyToolStripMenuItem.Click += new System.EventHandler(this.buttonModify_Click);
            this.modifyToolStripMenuItem.MouseEnter += new System.EventHandler(this.modifyToolStripMenuItem_MouseEnter);
            this.modifyToolStripMenuItem.MouseLeave += new System.EventHandler(this.toolStripMenuItem_MouseLeave);
            // 
            // savePatchToolStripMenuItem
            // 
            this.savePatchToolStripMenuItem.Name = "savePatchToolStripMenuItem";
            this.savePatchToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.savePatchToolStripMenuItem.Text = "Save IPS Patch";
            this.savePatchToolStripMenuItem.Click += new System.EventHandler(this.buttonIps_Click);
            this.savePatchToolStripMenuItem.MouseEnter += new System.EventHandler(this.savePatchToolStripMenuItem_MouseEnter);
            this.savePatchToolStripMenuItem.MouseLeave += new System.EventHandler(this.toolStripMenuItem_MouseLeave);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewsToolStripMenuItem
            // 
            this.viewsToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.viewsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paletteEditorToolStripMenuItem,
            this.presetsToolStripMenuItem,
            this.startupBorderToolStripMenuItem});
            this.viewsToolStripMenuItem.Name = "viewsToolStripMenuItem";
            this.viewsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewsToolStripMenuItem.Text = "View";
            // 
            // paletteEditorToolStripMenuItem
            // 
            this.paletteEditorToolStripMenuItem.Checked = true;
            this.paletteEditorToolStripMenuItem.CheckOnClick = true;
            this.paletteEditorToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.paletteEditorToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.paletteEditorToolStripMenuItem.Name = "paletteEditorToolStripMenuItem";
            this.paletteEditorToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.paletteEditorToolStripMenuItem.Text = "Palette Editor";
            this.paletteEditorToolStripMenuItem.Click += new System.EventHandler(this.paletteEditorToolStripMenuItem_Click);
            // 
            // presetsToolStripMenuItem
            // 
            this.presetsToolStripMenuItem.CheckOnClick = true;
            this.presetsToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.presetsToolStripMenuItem.Name = "presetsToolStripMenuItem";
            this.presetsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.presetsToolStripMenuItem.Text = "Game Presets";
            this.presetsToolStripMenuItem.Click += new System.EventHandler(this.presetsToolStripMenuItem1_Click);
            // 
            // startupBorderToolStripMenuItem
            // 
            this.startupBorderToolStripMenuItem.CheckOnClick = true;
            this.startupBorderToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.startupBorderToolStripMenuItem.Name = "startupBorderToolStripMenuItem";
            this.startupBorderToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.startupBorderToolStripMenuItem.Text = "Startup Border";
            this.startupBorderToolStripMenuItem.Click += new System.EventHandler(this.startupBorderToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlTypeAToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // controlTypeAToolStripMenuItem
            // 
            this.controlTypeAToolStripMenuItem.CheckOnClick = true;
            this.controlTypeAToolStripMenuItem.Name = "controlTypeAToolStripMenuItem";
            this.controlTypeAToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.controlTypeAToolStripMenuItem.Text = "Control Type A";
            this.controlTypeAToolStripMenuItem.CheckedChanged += new System.EventHandler(this.controlTypeAToolStripMenuItem_CheckedChanged);
            this.controlTypeAToolStripMenuItem.MouseEnter += new System.EventHandler(this.controlTypeAToolStripMenuItem_MouseEnter);
            this.controlTypeAToolStripMenuItem.MouseLeave += new System.EventHandler(this.toolStripMenuItem_MouseLeave);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(24, 20);
            this.helpToolStripMenuItem.Text = "?";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControlMain.Controls.Add(this.tabMain);
            this.tabControlMain.Controls.Add(this.tabPresets);
            this.tabControlMain.Controls.Add(this.tabBorders);
            this.tabControlMain.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControlMain.Location = new System.Drawing.Point(0, 27);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(788, 390);
            this.tabControlMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlMain.TabIndex = 101;
            // 
            // tabMain
            // 
            this.tabMain.BackColor = System.Drawing.SystemColors.Control;
            this.tabMain.Controls.Add(this.groupBoxClipboard);
            this.tabMain.Controls.Add(this.groupBoxExport);
            this.tabMain.Controls.Add(this.groupBoxEditColor);
            this.tabMain.Controls.Add(this.groupBoxPreview);
            this.tabMain.Controls.Add(this.groupBoxPalette);
            this.tabMain.Location = new System.Drawing.Point(4, 5);
            this.tabMain.Margin = new System.Windows.Forms.Padding(0);
            this.tabMain.Name = "tabMain";
            this.tabMain.Size = new System.Drawing.Size(780, 381);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            // 
            // tabPresets
            // 
            this.tabPresets.BackColor = System.Drawing.SystemColors.Control;
            this.tabPresets.Controls.Add(this.groupBoxPresets);
            this.tabPresets.Location = new System.Drawing.Point(4, 5);
            this.tabPresets.Name = "tabPresets";
            this.tabPresets.Padding = new System.Windows.Forms.Padding(3);
            this.tabPresets.Size = new System.Drawing.Size(780, 381);
            this.tabPresets.TabIndex = 1;
            this.tabPresets.Text = "Presets";
            // 
            // groupBoxPresets
            // 
            this.groupBoxPresets.Controls.Add(this.textBoxPreset1);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset2);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset3);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset4);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset5);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset6);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset7);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset8);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset9);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset10);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset11);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset12);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset13);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset14);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset15);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset16);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset17);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset18);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset19);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset20);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset21);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset22);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset23);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset24);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset25);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset26);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset27);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset28);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset29);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset30);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset31);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset32);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset33);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset34);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset35);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset36);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset37);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset38);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset39);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset40);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset41);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset42);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset43);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset44);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset45);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset46);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset47);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset48);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset49);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset50);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset51);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset52);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset53);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset54);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset55);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset56);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset57);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset58);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset59);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset60);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset61);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset62);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset63);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset64);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset65);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset66);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset67);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset68);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset69);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset70);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset71);
            this.groupBoxPresets.Controls.Add(this.textBoxPreset72);
            this.groupBoxPresets.Controls.Add(this.buttonReadGB);
            this.groupBoxPresets.Location = new System.Drawing.Point(11, 4);
            this.groupBoxPresets.Name = "groupBoxPresets";
            this.groupBoxPresets.Size = new System.Drawing.Size(663, 373);
            this.groupBoxPresets.TabIndex = 112;
            this.groupBoxPresets.TabStop = false;
            this.groupBoxPresets.Text = "Game Presets";
            // 
            // textBoxPreset1
            // 
            this.textBoxPreset1.Location = new System.Drawing.Point(16, 23);
            this.textBoxPreset1.MaxLength = 16;
            this.textBoxPreset1.Name = "textBoxPreset1";
            this.textBoxPreset1.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset1.TabIndex = 3;
            this.textBoxPreset1.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset2
            // 
            this.textBoxPreset2.Location = new System.Drawing.Point(172, 23);
            this.textBoxPreset2.MaxLength = 3;
            this.textBoxPreset2.Name = "textBoxPreset2";
            this.textBoxPreset2.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset2.TabIndex = 4;
            this.textBoxPreset2.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset3
            // 
            this.textBoxPreset3.Location = new System.Drawing.Point(16, 49);
            this.textBoxPreset3.MaxLength = 16;
            this.textBoxPreset3.Name = "textBoxPreset3";
            this.textBoxPreset3.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset3.TabIndex = 6;
            this.textBoxPreset3.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset4
            // 
            this.textBoxPreset4.Location = new System.Drawing.Point(172, 49);
            this.textBoxPreset4.MaxLength = 3;
            this.textBoxPreset4.Name = "textBoxPreset4";
            this.textBoxPreset4.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset4.TabIndex = 7;
            this.textBoxPreset4.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset5
            // 
            this.textBoxPreset5.Location = new System.Drawing.Point(16, 75);
            this.textBoxPreset5.MaxLength = 16;
            this.textBoxPreset5.Name = "textBoxPreset5";
            this.textBoxPreset5.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset5.TabIndex = 9;
            this.textBoxPreset5.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset6
            // 
            this.textBoxPreset6.Location = new System.Drawing.Point(172, 75);
            this.textBoxPreset6.MaxLength = 3;
            this.textBoxPreset6.Name = "textBoxPreset6";
            this.textBoxPreset6.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset6.TabIndex = 10;
            this.textBoxPreset6.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset7
            // 
            this.textBoxPreset7.Location = new System.Drawing.Point(16, 101);
            this.textBoxPreset7.MaxLength = 16;
            this.textBoxPreset7.Name = "textBoxPreset7";
            this.textBoxPreset7.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset7.TabIndex = 12;
            this.textBoxPreset7.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset8
            // 
            this.textBoxPreset8.Location = new System.Drawing.Point(172, 101);
            this.textBoxPreset8.MaxLength = 3;
            this.textBoxPreset8.Name = "textBoxPreset8";
            this.textBoxPreset8.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset8.TabIndex = 13;
            this.textBoxPreset8.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset9
            // 
            this.textBoxPreset9.Location = new System.Drawing.Point(16, 127);
            this.textBoxPreset9.MaxLength = 16;
            this.textBoxPreset9.Name = "textBoxPreset9";
            this.textBoxPreset9.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset9.TabIndex = 15;
            this.textBoxPreset9.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset10
            // 
            this.textBoxPreset10.Location = new System.Drawing.Point(172, 127);
            this.textBoxPreset10.MaxLength = 3;
            this.textBoxPreset10.Name = "textBoxPreset10";
            this.textBoxPreset10.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset10.TabIndex = 16;
            this.textBoxPreset10.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset11
            // 
            this.textBoxPreset11.Location = new System.Drawing.Point(16, 153);
            this.textBoxPreset11.MaxLength = 16;
            this.textBoxPreset11.Name = "textBoxPreset11";
            this.textBoxPreset11.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset11.TabIndex = 18;
            this.textBoxPreset11.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset12
            // 
            this.textBoxPreset12.Location = new System.Drawing.Point(172, 153);
            this.textBoxPreset12.MaxLength = 3;
            this.textBoxPreset12.Name = "textBoxPreset12";
            this.textBoxPreset12.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset12.TabIndex = 19;
            this.textBoxPreset12.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset13
            // 
            this.textBoxPreset13.Location = new System.Drawing.Point(16, 179);
            this.textBoxPreset13.MaxLength = 16;
            this.textBoxPreset13.Name = "textBoxPreset13";
            this.textBoxPreset13.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset13.TabIndex = 21;
            this.textBoxPreset13.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset14
            // 
            this.textBoxPreset14.Location = new System.Drawing.Point(172, 179);
            this.textBoxPreset14.MaxLength = 3;
            this.textBoxPreset14.Name = "textBoxPreset14";
            this.textBoxPreset14.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset14.TabIndex = 22;
            this.textBoxPreset14.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset15
            // 
            this.textBoxPreset15.Location = new System.Drawing.Point(16, 205);
            this.textBoxPreset15.MaxLength = 16;
            this.textBoxPreset15.Name = "textBoxPreset15";
            this.textBoxPreset15.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset15.TabIndex = 24;
            this.textBoxPreset15.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset16
            // 
            this.textBoxPreset16.Location = new System.Drawing.Point(172, 205);
            this.textBoxPreset16.MaxLength = 3;
            this.textBoxPreset16.Name = "textBoxPreset16";
            this.textBoxPreset16.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset16.TabIndex = 25;
            this.textBoxPreset16.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset17
            // 
            this.textBoxPreset17.Location = new System.Drawing.Point(16, 231);
            this.textBoxPreset17.MaxLength = 16;
            this.textBoxPreset17.Name = "textBoxPreset17";
            this.textBoxPreset17.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset17.TabIndex = 27;
            this.textBoxPreset17.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset18
            // 
            this.textBoxPreset18.Location = new System.Drawing.Point(172, 231);
            this.textBoxPreset18.MaxLength = 3;
            this.textBoxPreset18.Name = "textBoxPreset18";
            this.textBoxPreset18.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset18.TabIndex = 28;
            this.textBoxPreset18.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset19
            // 
            this.textBoxPreset19.Location = new System.Drawing.Point(16, 257);
            this.textBoxPreset19.MaxLength = 16;
            this.textBoxPreset19.Name = "textBoxPreset19";
            this.textBoxPreset19.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset19.TabIndex = 30;
            this.textBoxPreset19.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset20
            // 
            this.textBoxPreset20.Location = new System.Drawing.Point(172, 257);
            this.textBoxPreset20.MaxLength = 3;
            this.textBoxPreset20.Name = "textBoxPreset20";
            this.textBoxPreset20.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset20.TabIndex = 31;
            this.textBoxPreset20.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset21
            // 
            this.textBoxPreset21.Location = new System.Drawing.Point(16, 283);
            this.textBoxPreset21.MaxLength = 16;
            this.textBoxPreset21.Name = "textBoxPreset21";
            this.textBoxPreset21.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset21.TabIndex = 33;
            this.textBoxPreset21.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset22
            // 
            this.textBoxPreset22.Location = new System.Drawing.Point(172, 283);
            this.textBoxPreset22.MaxLength = 3;
            this.textBoxPreset22.Name = "textBoxPreset22";
            this.textBoxPreset22.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset22.TabIndex = 34;
            this.textBoxPreset22.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset23
            // 
            this.textBoxPreset23.Location = new System.Drawing.Point(16, 309);
            this.textBoxPreset23.MaxLength = 16;
            this.textBoxPreset23.Name = "textBoxPreset23";
            this.textBoxPreset23.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset23.TabIndex = 36;
            this.textBoxPreset23.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset24
            // 
            this.textBoxPreset24.Location = new System.Drawing.Point(172, 309);
            this.textBoxPreset24.MaxLength = 3;
            this.textBoxPreset24.Name = "textBoxPreset24";
            this.textBoxPreset24.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset24.TabIndex = 37;
            this.textBoxPreset24.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset25
            // 
            this.textBoxPreset25.Location = new System.Drawing.Point(237, 23);
            this.textBoxPreset25.MaxLength = 16;
            this.textBoxPreset25.Name = "textBoxPreset25";
            this.textBoxPreset25.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset25.TabIndex = 39;
            this.textBoxPreset25.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset26
            // 
            this.textBoxPreset26.Location = new System.Drawing.Point(393, 23);
            this.textBoxPreset26.MaxLength = 3;
            this.textBoxPreset26.Name = "textBoxPreset26";
            this.textBoxPreset26.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset26.TabIndex = 40;
            this.textBoxPreset26.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset27
            // 
            this.textBoxPreset27.Location = new System.Drawing.Point(237, 49);
            this.textBoxPreset27.MaxLength = 16;
            this.textBoxPreset27.Name = "textBoxPreset27";
            this.textBoxPreset27.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset27.TabIndex = 42;
            this.textBoxPreset27.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset28
            // 
            this.textBoxPreset28.Location = new System.Drawing.Point(393, 49);
            this.textBoxPreset28.MaxLength = 3;
            this.textBoxPreset28.Name = "textBoxPreset28";
            this.textBoxPreset28.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset28.TabIndex = 43;
            this.textBoxPreset28.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset29
            // 
            this.textBoxPreset29.Location = new System.Drawing.Point(237, 75);
            this.textBoxPreset29.MaxLength = 16;
            this.textBoxPreset29.Name = "textBoxPreset29";
            this.textBoxPreset29.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset29.TabIndex = 45;
            this.textBoxPreset29.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset30
            // 
            this.textBoxPreset30.Location = new System.Drawing.Point(393, 75);
            this.textBoxPreset30.MaxLength = 3;
            this.textBoxPreset30.Name = "textBoxPreset30";
            this.textBoxPreset30.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset30.TabIndex = 46;
            this.textBoxPreset30.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset31
            // 
            this.textBoxPreset31.Location = new System.Drawing.Point(237, 101);
            this.textBoxPreset31.MaxLength = 16;
            this.textBoxPreset31.Name = "textBoxPreset31";
            this.textBoxPreset31.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset31.TabIndex = 48;
            this.textBoxPreset31.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset32
            // 
            this.textBoxPreset32.Location = new System.Drawing.Point(393, 101);
            this.textBoxPreset32.MaxLength = 3;
            this.textBoxPreset32.Name = "textBoxPreset32";
            this.textBoxPreset32.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset32.TabIndex = 49;
            this.textBoxPreset32.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset33
            // 
            this.textBoxPreset33.Location = new System.Drawing.Point(237, 127);
            this.textBoxPreset33.MaxLength = 16;
            this.textBoxPreset33.Name = "textBoxPreset33";
            this.textBoxPreset33.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset33.TabIndex = 51;
            this.textBoxPreset33.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset34
            // 
            this.textBoxPreset34.Location = new System.Drawing.Point(393, 127);
            this.textBoxPreset34.MaxLength = 3;
            this.textBoxPreset34.Name = "textBoxPreset34";
            this.textBoxPreset34.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset34.TabIndex = 52;
            this.textBoxPreset34.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset35
            // 
            this.textBoxPreset35.Location = new System.Drawing.Point(237, 153);
            this.textBoxPreset35.MaxLength = 16;
            this.textBoxPreset35.Name = "textBoxPreset35";
            this.textBoxPreset35.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset35.TabIndex = 54;
            this.textBoxPreset35.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset36
            // 
            this.textBoxPreset36.Location = new System.Drawing.Point(393, 153);
            this.textBoxPreset36.MaxLength = 3;
            this.textBoxPreset36.Name = "textBoxPreset36";
            this.textBoxPreset36.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset36.TabIndex = 55;
            this.textBoxPreset36.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset37
            // 
            this.textBoxPreset37.Location = new System.Drawing.Point(237, 179);
            this.textBoxPreset37.MaxLength = 16;
            this.textBoxPreset37.Name = "textBoxPreset37";
            this.textBoxPreset37.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset37.TabIndex = 57;
            this.textBoxPreset37.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset38
            // 
            this.textBoxPreset38.Location = new System.Drawing.Point(393, 179);
            this.textBoxPreset38.MaxLength = 3;
            this.textBoxPreset38.Name = "textBoxPreset38";
            this.textBoxPreset38.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset38.TabIndex = 58;
            this.textBoxPreset38.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset39
            // 
            this.textBoxPreset39.Location = new System.Drawing.Point(237, 205);
            this.textBoxPreset39.MaxLength = 16;
            this.textBoxPreset39.Name = "textBoxPreset39";
            this.textBoxPreset39.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset39.TabIndex = 60;
            this.textBoxPreset39.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset40
            // 
            this.textBoxPreset40.Location = new System.Drawing.Point(393, 205);
            this.textBoxPreset40.MaxLength = 3;
            this.textBoxPreset40.Name = "textBoxPreset40";
            this.textBoxPreset40.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset40.TabIndex = 61;
            this.textBoxPreset40.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset41
            // 
            this.textBoxPreset41.Location = new System.Drawing.Point(237, 231);
            this.textBoxPreset41.MaxLength = 16;
            this.textBoxPreset41.Name = "textBoxPreset41";
            this.textBoxPreset41.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset41.TabIndex = 63;
            this.textBoxPreset41.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset42
            // 
            this.textBoxPreset42.Location = new System.Drawing.Point(393, 231);
            this.textBoxPreset42.MaxLength = 3;
            this.textBoxPreset42.Name = "textBoxPreset42";
            this.textBoxPreset42.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset42.TabIndex = 64;
            this.textBoxPreset42.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset43
            // 
            this.textBoxPreset43.Location = new System.Drawing.Point(237, 257);
            this.textBoxPreset43.MaxLength = 16;
            this.textBoxPreset43.Name = "textBoxPreset43";
            this.textBoxPreset43.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset43.TabIndex = 66;
            this.textBoxPreset43.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset44
            // 
            this.textBoxPreset44.Location = new System.Drawing.Point(393, 257);
            this.textBoxPreset44.MaxLength = 3;
            this.textBoxPreset44.Name = "textBoxPreset44";
            this.textBoxPreset44.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset44.TabIndex = 67;
            this.textBoxPreset44.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset45
            // 
            this.textBoxPreset45.Location = new System.Drawing.Point(237, 283);
            this.textBoxPreset45.MaxLength = 16;
            this.textBoxPreset45.Name = "textBoxPreset45";
            this.textBoxPreset45.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset45.TabIndex = 69;
            this.textBoxPreset45.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset46
            // 
            this.textBoxPreset46.Location = new System.Drawing.Point(393, 283);
            this.textBoxPreset46.MaxLength = 3;
            this.textBoxPreset46.Name = "textBoxPreset46";
            this.textBoxPreset46.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset46.TabIndex = 70;
            this.textBoxPreset46.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset47
            // 
            this.textBoxPreset47.Location = new System.Drawing.Point(237, 309);
            this.textBoxPreset47.MaxLength = 16;
            this.textBoxPreset47.Name = "textBoxPreset47";
            this.textBoxPreset47.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset47.TabIndex = 72;
            this.textBoxPreset47.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset48
            // 
            this.textBoxPreset48.Location = new System.Drawing.Point(393, 309);
            this.textBoxPreset48.MaxLength = 3;
            this.textBoxPreset48.Name = "textBoxPreset48";
            this.textBoxPreset48.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset48.TabIndex = 73;
            this.textBoxPreset48.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset49
            // 
            this.textBoxPreset49.Location = new System.Drawing.Point(452, 23);
            this.textBoxPreset49.MaxLength = 16;
            this.textBoxPreset49.Name = "textBoxPreset49";
            this.textBoxPreset49.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset49.TabIndex = 75;
            this.textBoxPreset49.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset50
            // 
            this.textBoxPreset50.Location = new System.Drawing.Point(608, 23);
            this.textBoxPreset50.MaxLength = 3;
            this.textBoxPreset50.Name = "textBoxPreset50";
            this.textBoxPreset50.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset50.TabIndex = 76;
            this.textBoxPreset50.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset51
            // 
            this.textBoxPreset51.Location = new System.Drawing.Point(452, 49);
            this.textBoxPreset51.MaxLength = 16;
            this.textBoxPreset51.Name = "textBoxPreset51";
            this.textBoxPreset51.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset51.TabIndex = 78;
            this.textBoxPreset51.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset52
            // 
            this.textBoxPreset52.Location = new System.Drawing.Point(608, 49);
            this.textBoxPreset52.MaxLength = 3;
            this.textBoxPreset52.Name = "textBoxPreset52";
            this.textBoxPreset52.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset52.TabIndex = 79;
            this.textBoxPreset52.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset53
            // 
            this.textBoxPreset53.Location = new System.Drawing.Point(452, 75);
            this.textBoxPreset53.MaxLength = 16;
            this.textBoxPreset53.Name = "textBoxPreset53";
            this.textBoxPreset53.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset53.TabIndex = 81;
            this.textBoxPreset53.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset54
            // 
            this.textBoxPreset54.Location = new System.Drawing.Point(608, 75);
            this.textBoxPreset54.MaxLength = 3;
            this.textBoxPreset54.Name = "textBoxPreset54";
            this.textBoxPreset54.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset54.TabIndex = 82;
            this.textBoxPreset54.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset55
            // 
            this.textBoxPreset55.Location = new System.Drawing.Point(452, 101);
            this.textBoxPreset55.MaxLength = 16;
            this.textBoxPreset55.Name = "textBoxPreset55";
            this.textBoxPreset55.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset55.TabIndex = 84;
            this.textBoxPreset55.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset56
            // 
            this.textBoxPreset56.Location = new System.Drawing.Point(608, 101);
            this.textBoxPreset56.MaxLength = 3;
            this.textBoxPreset56.Name = "textBoxPreset56";
            this.textBoxPreset56.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset56.TabIndex = 85;
            this.textBoxPreset56.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset57
            // 
            this.textBoxPreset57.Location = new System.Drawing.Point(452, 127);
            this.textBoxPreset57.MaxLength = 16;
            this.textBoxPreset57.Name = "textBoxPreset57";
            this.textBoxPreset57.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset57.TabIndex = 87;
            this.textBoxPreset57.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset58
            // 
            this.textBoxPreset58.Location = new System.Drawing.Point(608, 127);
            this.textBoxPreset58.MaxLength = 3;
            this.textBoxPreset58.Name = "textBoxPreset58";
            this.textBoxPreset58.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset58.TabIndex = 88;
            this.textBoxPreset58.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset59
            // 
            this.textBoxPreset59.Location = new System.Drawing.Point(452, 153);
            this.textBoxPreset59.MaxLength = 16;
            this.textBoxPreset59.Name = "textBoxPreset59";
            this.textBoxPreset59.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset59.TabIndex = 90;
            this.textBoxPreset59.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset60
            // 
            this.textBoxPreset60.Location = new System.Drawing.Point(608, 153);
            this.textBoxPreset60.MaxLength = 3;
            this.textBoxPreset60.Name = "textBoxPreset60";
            this.textBoxPreset60.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset60.TabIndex = 91;
            this.textBoxPreset60.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset61
            // 
            this.textBoxPreset61.Location = new System.Drawing.Point(452, 179);
            this.textBoxPreset61.MaxLength = 16;
            this.textBoxPreset61.Name = "textBoxPreset61";
            this.textBoxPreset61.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset61.TabIndex = 93;
            this.textBoxPreset61.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset62
            // 
            this.textBoxPreset62.Location = new System.Drawing.Point(608, 179);
            this.textBoxPreset62.MaxLength = 3;
            this.textBoxPreset62.Name = "textBoxPreset62";
            this.textBoxPreset62.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset62.TabIndex = 94;
            this.textBoxPreset62.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset63
            // 
            this.textBoxPreset63.Location = new System.Drawing.Point(452, 205);
            this.textBoxPreset63.MaxLength = 16;
            this.textBoxPreset63.Name = "textBoxPreset63";
            this.textBoxPreset63.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset63.TabIndex = 96;
            this.textBoxPreset63.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset64
            // 
            this.textBoxPreset64.Location = new System.Drawing.Point(608, 205);
            this.textBoxPreset64.MaxLength = 3;
            this.textBoxPreset64.Name = "textBoxPreset64";
            this.textBoxPreset64.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset64.TabIndex = 97;
            this.textBoxPreset64.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset65
            // 
            this.textBoxPreset65.Location = new System.Drawing.Point(452, 231);
            this.textBoxPreset65.MaxLength = 16;
            this.textBoxPreset65.Name = "textBoxPreset65";
            this.textBoxPreset65.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset65.TabIndex = 99;
            this.textBoxPreset65.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset66
            // 
            this.textBoxPreset66.Location = new System.Drawing.Point(608, 231);
            this.textBoxPreset66.MaxLength = 3;
            this.textBoxPreset66.Name = "textBoxPreset66";
            this.textBoxPreset66.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset66.TabIndex = 100;
            this.textBoxPreset66.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset67
            // 
            this.textBoxPreset67.Location = new System.Drawing.Point(452, 257);
            this.textBoxPreset67.MaxLength = 16;
            this.textBoxPreset67.Name = "textBoxPreset67";
            this.textBoxPreset67.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset67.TabIndex = 102;
            this.textBoxPreset67.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset68
            // 
            this.textBoxPreset68.Location = new System.Drawing.Point(608, 257);
            this.textBoxPreset68.MaxLength = 3;
            this.textBoxPreset68.Name = "textBoxPreset68";
            this.textBoxPreset68.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset68.TabIndex = 103;
            this.textBoxPreset68.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset69
            // 
            this.textBoxPreset69.Location = new System.Drawing.Point(452, 283);
            this.textBoxPreset69.MaxLength = 16;
            this.textBoxPreset69.Name = "textBoxPreset69";
            this.textBoxPreset69.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset69.TabIndex = 105;
            this.textBoxPreset69.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset70
            // 
            this.textBoxPreset70.Location = new System.Drawing.Point(608, 283);
            this.textBoxPreset70.MaxLength = 3;
            this.textBoxPreset70.Name = "textBoxPreset70";
            this.textBoxPreset70.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset70.TabIndex = 106;
            this.textBoxPreset70.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // textBoxPreset71
            // 
            this.textBoxPreset71.Location = new System.Drawing.Point(452, 309);
            this.textBoxPreset71.MaxLength = 16;
            this.textBoxPreset71.Name = "textBoxPreset71";
            this.textBoxPreset71.Size = new System.Drawing.Size(150, 20);
            this.textBoxPreset71.TabIndex = 108;
            this.textBoxPreset71.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxPreset72
            // 
            this.textBoxPreset72.Location = new System.Drawing.Point(608, 309);
            this.textBoxPreset72.MaxLength = 3;
            this.textBoxPreset72.Name = "textBoxPreset72";
            this.textBoxPreset72.Size = new System.Drawing.Size(36, 20);
            this.textBoxPreset72.TabIndex = 109;
            this.textBoxPreset72.Leave += new System.EventHandler(this.textBoxPreset_Leave);
            // 
            // tabBorders
            // 
            this.tabBorders.BackColor = System.Drawing.SystemColors.Control;
            this.tabBorders.Controls.Add(this.groupBoxBorder);
            this.tabBorders.Location = new System.Drawing.Point(4, 5);
            this.tabBorders.Name = "tabBorders";
            this.tabBorders.Padding = new System.Windows.Forms.Padding(3);
            this.tabBorders.Size = new System.Drawing.Size(780, 381);
            this.tabBorders.TabIndex = 2;
            this.tabBorders.Text = "Borders";
            // 
            // groupBoxBorder
            // 
            this.groupBoxBorder.Controls.Add(this.groupBoxBorderInfo);
            this.groupBoxBorder.Controls.Add(this.buttonBoarderImportFile);
            this.groupBoxBorder.Controls.Add(this.pictureBoxGameinBorder);
            this.groupBoxBorder.Controls.Add(this.comboBoxBorder);
            this.groupBoxBorder.Controls.Add(this.pictureBoxBorder);
            this.groupBoxBorder.Location = new System.Drawing.Point(11, 4);
            this.groupBoxBorder.Name = "groupBoxBorder";
            this.groupBoxBorder.Size = new System.Drawing.Size(663, 372);
            this.groupBoxBorder.TabIndex = 2;
            this.groupBoxBorder.TabStop = false;
            this.groupBoxBorder.Text = "Startup Border";
            // 
            // labelBordersInfo
            // 
            this.labelBordersInfo.AutoSize = true;
            this.labelBordersInfo.Location = new System.Drawing.Point(6, 19);
            this.labelBordersInfo.Name = "labelBordersInfo";
            this.labelBordersInfo.Size = new System.Drawing.Size(217, 91);
            this.labelBordersInfo.TabIndex = 4;
            this.labelBordersInfo.Text = "Import data from your SGB rom file to see the\r\navailable borders. (optional)\r\n\r\nS" +
    "uper Game Boy 2 can have any border.\r\n\r\nSGB enhanced games will still show their" +
    "\r\noriginal special borders.";
            // 
            // buttonBoarderImportFile
            // 
            this.buttonBoarderImportFile.Location = new System.Drawing.Point(65, 282);
            this.buttonBoarderImportFile.Name = "buttonBoarderImportFile";
            this.buttonBoarderImportFile.Size = new System.Drawing.Size(160, 23);
            this.buttonBoarderImportFile.TabIndex = 3;
            this.buttonBoarderImportFile.Text = "Import border images from rom";
            this.buttonBoarderImportFile.UseVisualStyleBackColor = true;
            this.buttonBoarderImportFile.Click += new System.EventHandler(this.buttonImportImages_Click);
            // 
            // pictureBoxGameinBorder
            // 
            this.pictureBoxGameinBorder.Location = new System.Drawing.Point(65, 92);
            this.pictureBoxGameinBorder.Name = "pictureBoxGameinBorder";
            this.pictureBoxGameinBorder.Size = new System.Drawing.Size(160, 144);
            this.pictureBoxGameinBorder.TabIndex = 2;
            this.pictureBoxGameinBorder.TabStop = false;
            this.pictureBoxGameinBorder.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            // 
            // comboBoxBorder
            // 
            this.comboBoxBorder.FormattingEnabled = true;
            this.comboBoxBorder.Items.AddRange(new object[] {
            "GB (SGB2)",
            "GB (Pink)",
            "GB (Yellow)",
            "GB (Green)",
            "GB (Blue)",
            "GB (Red)",
            "GB (Black)",
            "Black (SGB2)",
            "Printed Circuit Board",
            "Palm Trees",
            "Stone Mosaic",
            "Gears",
            "Swamp",
            "Dolphins",
            "Chess Arena",
            "GB (SGB1)",
            "Black (SGB1)",
            "Windows (SGB1)",
            "Cork Board (SGB1)",
            "Log Cabin In The Countryside (SGB1)",
            "Movie Theater (SGB1)",
            "Cats (SGB1)",
            "Chequered Desk With Pencils (SGB1)",
            "Escher (SGB1)"});
            this.comboBoxBorder.Location = new System.Drawing.Point(17, 25);
            this.comboBoxBorder.Name = "comboBoxBorder";
            this.comboBoxBorder.Size = new System.Drawing.Size(256, 21);
            this.comboBoxBorder.TabIndex = 0;
            this.comboBoxBorder.Text = "GB (SGB2)";
            this.comboBoxBorder.SelectedIndexChanged += new System.EventHandler(this.comboBoxBorder_SelectedIndexChanged);
            // 
            // pictureBoxBorder
            // 
            this.pictureBoxBorder.BackColor = System.Drawing.Color.Black;
            this.pictureBoxBorder.InitialImage = null;
            this.pictureBoxBorder.Location = new System.Drawing.Point(17, 52);
            this.pictureBoxBorder.Name = "pictureBoxBorder";
            this.pictureBoxBorder.Size = new System.Drawing.Size(256, 224);
            this.pictureBoxBorder.TabIndex = 1;
            this.pictureBoxBorder.TabStop = false;
            // 
            // groupBoxBorderInfo
            // 
            this.groupBoxBorderInfo.Controls.Add(this.labelBordersInfo);
            this.groupBoxBorderInfo.Location = new System.Drawing.Point(291, 25);
            this.groupBoxBorderInfo.Name = "groupBoxBorderInfo";
            this.groupBoxBorderInfo.Size = new System.Drawing.Size(229, 121);
            this.groupBoxBorderInfo.TabIndex = 5;
            this.groupBoxBorderInfo.TabStop = false;
            this.groupBoxBorderInfo.Text = "Info";
            // 
            // trackBarRed
            // 
            this.trackBarRed.Location = new System.Drawing.Point(46, 22);
            this.trackBarRed.Maximum = 255;
            this.trackBarRed.Name = "trackBarRed";
            this.trackBarRed.Size = new System.Drawing.Size(173, 45);
            this.trackBarRed.TabIndex = 99;
            this.trackBarRed.TabStop = false;
            this.trackBarRed.TickFrequency = 16;
            this.trackBarRed.ValueChanged += new System.EventHandler(this.rgbsliderChange);
            // 
            // trackBarBlue
            // 
            this.trackBarBlue.Location = new System.Drawing.Point(46, 102);
            this.trackBarBlue.Maximum = 255;
            this.trackBarBlue.Name = "trackBarBlue";
            this.trackBarBlue.Size = new System.Drawing.Size(173, 45);
            this.trackBarBlue.TabIndex = 99;
            this.trackBarBlue.TabStop = false;
            this.trackBarBlue.TickFrequency = 16;
            this.trackBarBlue.ValueChanged += new System.EventHandler(this.rgbsliderChange);
            // 
            // trackBarGreen
            // 
            this.trackBarGreen.Location = new System.Drawing.Point(46, 62);
            this.trackBarGreen.Maximum = 255;
            this.trackBarGreen.Name = "trackBarGreen";
            this.trackBarGreen.Size = new System.Drawing.Size(173, 45);
            this.trackBarGreen.TabIndex = 99;
            this.trackBarGreen.TabStop = false;
            this.trackBarGreen.TickFrequency = 16;
            this.trackBarGreen.ValueChanged += new System.EventHandler(this.rgbsliderChange);
            // 
            // trackBarH
            // 
            this.trackBarH.LargeChange = 10;
            this.trackBarH.Location = new System.Drawing.Point(67, 22);
            this.trackBarH.Maximum = 360;
            this.trackBarH.Name = "trackBarH";
            this.trackBarH.Size = new System.Drawing.Size(184, 45);
            this.trackBarH.TabIndex = 99;
            this.trackBarH.TabStop = false;
            this.trackBarH.TickFrequency = 20;
            this.trackBarH.ValueChanged += new System.EventHandler(this.trackBarHSV_ValueChanged);
            // 
            // trackBarS
            // 
            this.trackBarS.Location = new System.Drawing.Point(67, 62);
            this.trackBarS.Maximum = 100;
            this.trackBarS.Name = "trackBarS";
            this.trackBarS.Size = new System.Drawing.Size(184, 45);
            this.trackBarS.TabIndex = 99;
            this.trackBarS.TabStop = false;
            this.trackBarS.TickFrequency = 5;
            this.trackBarS.ValueChanged += new System.EventHandler(this.trackBarHSV_ValueChanged);
            // 
            // trackBarV
            // 
            this.trackBarV.Location = new System.Drawing.Point(67, 102);
            this.trackBarV.Maximum = 100;
            this.trackBarV.Name = "trackBarV";
            this.trackBarV.Size = new System.Drawing.Size(184, 45);
            this.trackBarV.TabIndex = 99;
            this.trackBarV.TabStop = false;
            this.trackBarV.TickFrequency = 5;
            this.trackBarV.ValueChanged += new System.EventHandler(this.trackBarHSV_ValueChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 442);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximumSize = new System.Drawing.Size(804, 481);
            this.MinimumSize = new System.Drawing.Size(160, 144);
            this.Name = "MainWindow";
            this.Text = "SGB Settings Editor";
            this.Load += new System.EventHandler(this.Form_Load);
            this.panelPalettebg.ResumeLayout(false);
            this.screenshotPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBoxEditColor.ResumeLayout(false);
            this.groupBoxEditColor.PerformLayout();
            this.tabControlColorformat.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBoxClipboard.ResumeLayout(false);
            this.groupBoxPalette.ResumeLayout(false);
            this.groupBoxPalette.PerformLayout();
            this.groupBoxPreview.ResumeLayout(false);
            this.groupBoxPreview.PerformLayout();
            this.groupBoxExport.ResumeLayout(false);
            this.groupBoxExport.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabPresets.ResumeLayout(false);
            this.groupBoxPresets.ResumeLayout(false);
            this.groupBoxPresets.PerformLayout();
            this.tabBorders.ResumeLayout(false);
            this.groupBoxBorder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGameinBorder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBorder)).EndInit();
            this.groupBoxBorderInfo.ResumeLayout(false);
            this.groupBoxBorderInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelClipboard1;
        private System.Windows.Forms.TextBox textboxRGB;
        private System.Windows.Forms.TextBox textboxBGR15;
        private System.Windows.Forms.Button buttonColor1;
        private System.Windows.Forms.Panel panelActiveColor;
        private System.Windows.Forms.ComboBox comboBoxPaletteslot;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button buttonColor2;
        private System.Windows.Forms.Button buttonColor4;
        private System.Windows.Forms.Panel panelPalettebg;
        private System.Windows.Forms.Panel panelColor3;
        private System.Windows.Forms.Panel panelColor4;
        private System.Windows.Forms.Panel panelColor2;
        private System.Windows.Forms.Panel panelColor1;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Panel panelClipboard2;
        private System.Windows.Forms.Panel panelClipboard3;
        private System.Windows.Forms.Panel panelClipboard4;
        private System.Windows.Forms.Panel panelClipboard5;
        private System.Windows.Forms.Panel panelClipboard6;
        private System.Windows.Forms.Panel panelClipboard7;
        private System.Windows.Forms.Panel panelClipboard8;
        private System.Windows.Forms.Button buttonIps;
        private System.Windows.Forms.Label labelGame;
        private System.Windows.Forms.ComboBox comboBoxGame;
        private System.Windows.Forms.Label labelClick;
        private System.Windows.Forms.Button buttonStore1;
        private System.Windows.Forms.Label labelPalette;
        private System.Windows.Forms.Label labelHexcolor;
        private System.Windows.Forms.Label labelSnescolor;
        private NoFocusTrackBar trackBarRed;
        private NoFocusTrackBar trackBarGreen;
        private NoFocusTrackBar trackBarBlue;
        private System.Windows.Forms.Button buttonStore2;
        private System.Windows.Forms.Button buttonLoad1;
        private System.Windows.Forms.Button buttonLoad2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Button buttonModify;
        private System.Windows.Forms.Panel screenshotPanel;
        private System.Windows.Forms.TextBox textBoxRDec;
        private System.Windows.Forms.TextBox textBoxRHex;
        private System.Windows.Forms.TextBox textBoxGDec;
        private System.Windows.Forms.TextBox textBoxGHex;
        private System.Windows.Forms.TextBox textBoxBDec;
        private System.Windows.Forms.TextBox textBoxBHex;
        private System.Windows.Forms.Label labelDec;
        private System.Windows.Forms.Label labelHex;
        private System.Windows.Forms.Label labelRed;
        private System.Windows.Forms.Label labelGreen;
        private System.Windows.Forms.Label labelBlue;
        private System.Windows.Forms.GroupBox groupBoxEditColor;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Button buttonColor3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.CheckBox checkBoxControls;
        private System.Windows.Forms.GroupBox groupBoxClipboard;
        private System.Windows.Forms.Panel panelClipboard12;
        private System.Windows.Forms.Panel panelClipboard11;
        private System.Windows.Forms.Panel panelClipboard10;
        private System.Windows.Forms.Panel panelClipboard9;
        private System.Windows.Forms.Button buttonToggle;
        private System.Windows.Forms.Label labelSet;
        private System.Windows.Forms.Button buttonStore3;
        private System.Windows.Forms.Button buttonLoad3;
        private System.Windows.Forms.GroupBox groupBoxPalette;
        private System.Windows.Forms.GroupBox groupBoxPreview;
        private System.Windows.Forms.Label labelStore;
        private System.Windows.Forms.Label labelLoad;
        private System.Windows.Forms.Button buttonResetPalette;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox groupBoxExport;
        private NoFocusTrackBar trackBarH;
        private NoFocusTrackBar trackBarS;
        private NoFocusTrackBar trackBarV;
        private System.Windows.Forms.TextBox textBoxH;
        private System.Windows.Forms.TextBox textBoxS;
        private System.Windows.Forms.TextBox textBoxV;
        private System.Windows.Forms.TabControl tabControlColorformat;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label labelV;
        private System.Windows.Forms.Label labelS;
        private System.Windows.Forms.Label labelH;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Panel panelColorbg;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem viewsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem presetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabPresets;
        private System.Windows.Forms.TabPage tabBorders;
        private System.Windows.Forms.TextBox textBoxPreset1;
        private System.Windows.Forms.TextBox textBoxPreset2;
        private System.Windows.Forms.TextBox textBoxPreset25;
        private System.Windows.Forms.TextBox textBoxPreset26;
        private System.Windows.Forms.TextBox textBoxPreset23;
        private System.Windows.Forms.TextBox textBoxPreset24;
        private System.Windows.Forms.TextBox textBoxPreset21;
        private System.Windows.Forms.TextBox textBoxPreset22;
        private System.Windows.Forms.TextBox textBoxPreset19;
        private System.Windows.Forms.TextBox textBoxPreset20;
        private System.Windows.Forms.TextBox textBoxPreset17;
        private System.Windows.Forms.TextBox textBoxPreset18;
        private System.Windows.Forms.TextBox textBoxPreset15;
        private System.Windows.Forms.TextBox textBoxPreset16;
        private System.Windows.Forms.TextBox textBoxPreset13;
        private System.Windows.Forms.TextBox textBoxPreset14;
        private System.Windows.Forms.TextBox textBoxPreset11;
        private System.Windows.Forms.TextBox textBoxPreset12;
        private System.Windows.Forms.TextBox textBoxPreset9;
        private System.Windows.Forms.TextBox textBoxPreset10;
        private System.Windows.Forms.TextBox textBoxPreset7;
        private System.Windows.Forms.TextBox textBoxPreset8;
        private System.Windows.Forms.TextBox textBoxPreset5;
        private System.Windows.Forms.TextBox textBoxPreset6;
        private System.Windows.Forms.TextBox textBoxPreset3;
        private System.Windows.Forms.TextBox textBoxPreset4;
        private System.Windows.Forms.TextBox textBoxPreset71;
        private System.Windows.Forms.TextBox textBoxPreset72;
        private System.Windows.Forms.TextBox textBoxPreset69;
        private System.Windows.Forms.TextBox textBoxPreset70;
        private System.Windows.Forms.TextBox textBoxPreset67;
        private System.Windows.Forms.TextBox textBoxPreset68;
        private System.Windows.Forms.TextBox textBoxPreset65;
        private System.Windows.Forms.TextBox textBoxPreset66;
        private System.Windows.Forms.TextBox textBoxPreset63;
        private System.Windows.Forms.TextBox textBoxPreset64;
        private System.Windows.Forms.TextBox textBoxPreset61;
        private System.Windows.Forms.TextBox textBoxPreset62;
        private System.Windows.Forms.TextBox textBoxPreset59;
        private System.Windows.Forms.TextBox textBoxPreset60;
        private System.Windows.Forms.TextBox textBoxPreset57;
        private System.Windows.Forms.TextBox textBoxPreset58;
        private System.Windows.Forms.TextBox textBoxPreset55;
        private System.Windows.Forms.TextBox textBoxPreset56;
        private System.Windows.Forms.TextBox textBoxPreset53;
        private System.Windows.Forms.TextBox textBoxPreset54;
        private System.Windows.Forms.TextBox textBoxPreset51;
        private System.Windows.Forms.TextBox textBoxPreset52;
        private System.Windows.Forms.TextBox textBoxPreset49;
        private System.Windows.Forms.TextBox textBoxPreset50;
        private System.Windows.Forms.TextBox textBoxPreset47;
        private System.Windows.Forms.TextBox textBoxPreset48;
        private System.Windows.Forms.TextBox textBoxPreset45;
        private System.Windows.Forms.TextBox textBoxPreset46;
        private System.Windows.Forms.TextBox textBoxPreset43;
        private System.Windows.Forms.TextBox textBoxPreset44;
        private System.Windows.Forms.TextBox textBoxPreset41;
        private System.Windows.Forms.TextBox textBoxPreset42;
        private System.Windows.Forms.TextBox textBoxPreset39;
        private System.Windows.Forms.TextBox textBoxPreset40;
        private System.Windows.Forms.TextBox textBoxPreset37;
        private System.Windows.Forms.TextBox textBoxPreset38;
        private System.Windows.Forms.TextBox textBoxPreset35;
        private System.Windows.Forms.TextBox textBoxPreset36;
        private System.Windows.Forms.TextBox textBoxPreset33;
        private System.Windows.Forms.TextBox textBoxPreset34;
        private System.Windows.Forms.TextBox textBoxPreset31;
        private System.Windows.Forms.TextBox textBoxPreset32;
        private System.Windows.Forms.TextBox textBoxPreset29;
        private System.Windows.Forms.TextBox textBoxPreset30;
        private System.Windows.Forms.TextBox textBoxPreset27;
        private System.Windows.Forms.TextBox textBoxPreset28;
        private System.Windows.Forms.Button buttonReadGB;
        private System.Windows.Forms.ToolStripMenuItem paletteEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startupBorderToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxPresets;
        private System.Windows.Forms.ComboBox comboBoxBorder;
        private System.Windows.Forms.PictureBox pictureBoxBorder;
        private System.Windows.Forms.GroupBox groupBoxBorder;
        private System.Windows.Forms.PictureBox pictureBoxGameinBorder;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button buttonBoarderImportFile;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savePatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label labelBordersInfo;
        private System.Windows.Forms.ComboBox comboBoxVersion;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlTypeAToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxBorderInfo;
    }
}

