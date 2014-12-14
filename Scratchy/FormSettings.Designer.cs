namespace Scratchy
{
    partial class FormSettings
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
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.tabPageCommon = new System.Windows.Forms.TabPage();
            this.picAngles = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.numScanningStepAngle = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.numLightingAngle = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.numViewingAngle = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numMovingAngle = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numToolAngle = new System.Windows.Forms.NumericUpDown();
            this.tabPageExportNC = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBoxProlog = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxEpilog = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkCompensateRadius = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numScratchingDepthAtHeight = new System.Windows.Forms.NumericUpDown();
            this.numScratchingDepthZero = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numScratchingDepthMax = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numTravelHeight = new System.Windows.Forms.NumericUpDown();
            this.checkForceG1onNegZ = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.numWorkingAreaX = new System.Windows.Forms.NumericUpDown();
            this.numWorkingAreaY = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.tabCtrl.SuspendLayout();
            this.tabPageCommon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAngles)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScanningStepAngle)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLightingAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numViewingAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMovingAngle)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numToolAngle)).BeginInit();
            this.tabPageExportNC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScratchingDepthAtHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScratchingDepthZero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScratchingDepthMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTravelHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWorkingAreaX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWorkingAreaY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCtrl
            // 
            this.tabCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCtrl.Controls.Add(this.tabPageCommon);
            this.tabCtrl.Controls.Add(this.tabPageExportNC);
            this.tabCtrl.Location = new System.Drawing.Point(0, 0);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(735, 486);
            this.tabCtrl.TabIndex = 0;
            // 
            // tabPageCommon
            // 
            this.tabPageCommon.Controls.Add(this.picAngles);
            this.tabPageCommon.Controls.Add(this.groupBox4);
            this.tabPageCommon.Controls.Add(this.groupBox2);
            this.tabPageCommon.Controls.Add(this.groupBox1);
            this.tabPageCommon.Location = new System.Drawing.Point(4, 25);
            this.tabPageCommon.Name = "tabPageCommon";
            this.tabPageCommon.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCommon.Size = new System.Drawing.Size(727, 457);
            this.tabPageCommon.TabIndex = 0;
            this.tabPageCommon.Text = "Common";
            this.tabPageCommon.UseVisualStyleBackColor = true;
            // 
            // picAngles
            // 
            this.picAngles.Image = global::Scratchy.Properties.Resources.Scratch11;
            this.picAngles.InitialImage = null;
            this.picAngles.Location = new System.Drawing.Point(421, 7);
            this.picAngles.Name = "picAngles";
            this.picAngles.Size = new System.Drawing.Size(298, 214);
            this.picAngles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAngles.TabIndex = 11;
            this.picAngles.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBox2);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.checkBox1);
            this.groupBox4.Controls.Add(this.numericUpDown1);
            this.groupBox4.Controls.Add(this.numWorkingAreaY);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.numWorkingAreaX);
            this.groupBox4.Controls.Add(this.comboType);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.numScanningStepAngle);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Location = new System.Drawing.Point(7, 191);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(408, 253);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Rendering";
            // 
            // comboType
            // 
            this.comboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboType.FormattingEnabled = true;
            this.comboType.Items.AddRange(new object[] {
            "TTD-WC Table-Top-Display Wireframe-Circle (as above, so below (Z-0-Mirror))",
            "TTD-WA Table-Top-Display Wireframe-Arc",
            "TTD-SA Table-Top-Display Solid-Arc (with hidden Lines, slow)",
            "WMD-xx Wall-Mounted-Display ???"});
            this.comboType.Location = new System.Drawing.Point(5, 39);
            this.comboType.Name = "comboType";
            this.comboType.Size = new System.Drawing.Size(397, 24);
            this.comboType.TabIndex = 10;
            this.comboType.SelectedIndexChanged += new System.EventHandler(this.comboType_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(290, 17);
            this.label10.TabIndex = 9;
            this.label10.Text = "Scanning Step Angle (only for solid types) [°]";
            // 
            // numScanningStepAngle
            // 
            this.numScanningStepAngle.DecimalPlaces = 2;
            this.numScanningStepAngle.Location = new System.Drawing.Point(1, 144);
            this.numScanningStepAngle.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numScanningStepAngle.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numScanningStepAngle.Name = "numScanningStepAngle";
            this.numScanningStepAngle.Size = new System.Drawing.Size(120, 22);
            this.numScanningStepAngle.TabIndex = 8;
            this.numScanningStepAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numScanningStepAngle.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 17);
            this.label9.TabIndex = 7;
            this.label9.Text = "Display Type";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.numLightingAngle);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.numViewingAngle);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.numMovingAngle);
            this.groupBox2.Location = new System.Drawing.Point(214, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 179);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Observer";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 118);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(147, 17);
            this.label12.TabIndex = 11;
            this.label12.Text = "Lighting Angle (LA) [°]";
            // 
            // numLightingAngle
            // 
            this.numLightingAngle.DecimalPlaces = 1;
            this.numLightingAngle.Enabled = false;
            this.numLightingAngle.Location = new System.Drawing.Point(6, 138);
            this.numLightingAngle.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numLightingAngle.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numLightingAngle.Name = "numLightingAngle";
            this.numLightingAngle.Size = new System.Drawing.Size(120, 22);
            this.numLightingAngle.TabIndex = 10;
            this.numLightingAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numLightingAngle.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(146, 17);
            this.label11.TabIndex = 9;
            this.label11.Text = "Viewing Angle (VA) [°]";
            // 
            // numViewingAngle
            // 
            this.numViewingAngle.DecimalPlaces = 1;
            this.numViewingAngle.Enabled = false;
            this.numViewingAngle.Location = new System.Drawing.Point(6, 88);
            this.numViewingAngle.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.numViewingAngle.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numViewingAngle.Name = "numViewingAngle";
            this.numViewingAngle.Size = new System.Drawing.Size(120, 22);
            this.numViewingAngle.TabIndex = 8;
            this.numViewingAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numViewingAngle.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Moving Angle (MA) [±°]";
            // 
            // numMovingAngle
            // 
            this.numMovingAngle.DecimalPlaces = 1;
            this.numMovingAngle.Location = new System.Drawing.Point(6, 38);
            this.numMovingAngle.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numMovingAngle.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numMovingAngle.Name = "numMovingAngle";
            this.numMovingAngle.Size = new System.Drawing.Size(120, 22);
            this.numMovingAngle.TabIndex = 6;
            this.numMovingAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numMovingAngle.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numToolAngle);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 179);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scratch Tool";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tool Angle [°]";
            // 
            // numToolAngle
            // 
            this.numToolAngle.DecimalPlaces = 1;
            this.numToolAngle.Location = new System.Drawing.Point(6, 38);
            this.numToolAngle.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numToolAngle.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numToolAngle.Name = "numToolAngle";
            this.numToolAngle.Size = new System.Drawing.Size(120, 22);
            this.numToolAngle.TabIndex = 4;
            this.numToolAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numToolAngle.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numToolAngle.ValueChanged += new System.EventHandler(this.numToolAngle_ValueChanged);
            this.numToolAngle.Validating += new System.ComponentModel.CancelEventHandler(this.numToolAngle_Validating);
            // 
            // tabPageExportNC
            // 
            this.tabPageExportNC.Controls.Add(this.splitContainer1);
            this.tabPageExportNC.Controls.Add(this.groupBox3);
            this.tabPageExportNC.Location = new System.Drawing.Point(4, 25);
            this.tabPageExportNC.Name = "tabPageExportNC";
            this.tabPageExportNC.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageExportNC.Size = new System.Drawing.Size(727, 457);
            this.tabPageExportNC.TabIndex = 1;
            this.tabPageExportNC.Text = "Export NC";
            this.tabPageExportNC.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 6);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBoxProlog);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBoxEpilog);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Size = new System.Drawing.Size(727, 228);
            this.splitContainer1.SplitterDistance = 357;
            this.splitContainer1.TabIndex = 10;
            // 
            // textBoxProlog
            // 
            this.textBoxProlog.AcceptsReturn = true;
            this.textBoxProlog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProlog.Location = new System.Drawing.Point(6, 20);
            this.textBoxProlog.Multiline = true;
            this.textBoxProlog.Name = "textBoxProlog";
            this.textBoxProlog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxProlog.Size = new System.Drawing.Size(348, 205);
            this.textBoxProlog.TabIndex = 0;
            this.textBoxProlog.Text = "G21 G90\r\nG1 F400";
            this.textBoxProlog.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "G-Code Prolog";
            // 
            // textBoxEpilog
            // 
            this.textBoxEpilog.AcceptsReturn = true;
            this.textBoxEpilog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEpilog.Location = new System.Drawing.Point(6, 20);
            this.textBoxEpilog.Multiline = true;
            this.textBoxEpilog.Name = "textBoxEpilog";
            this.textBoxEpilog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxEpilog.Size = new System.Drawing.Size(352, 205);
            this.textBoxEpilog.TabIndex = 7;
            this.textBoxEpilog.Text = "M2";
            this.textBoxEpilog.WordWrap = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "G-Code Epilog";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkCompensateRadius);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.numScratchingDepthZero);
            this.groupBox3.Controls.Add(this.numScratchingDepthMax);
            this.groupBox3.Controls.Add(this.numScratchingDepthAtHeight);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.numTravelHeight);
            this.groupBox3.Controls.Add(this.checkForceG1onNegZ);
            this.groupBox3.Location = new System.Drawing.Point(6, 240);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(356, 197);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Z-Movement";
            // 
            // checkCompensateRadius
            // 
            this.checkCompensateRadius.AutoSize = true;
            this.checkCompensateRadius.Location = new System.Drawing.Point(6, 167);
            this.checkCompensateRadius.Name = "checkCompensateRadius";
            this.checkCompensateRadius.Size = new System.Drawing.Size(157, 21);
            this.checkCompensateRadius.TabIndex = 14;
            this.checkCompensateRadius.Text = "Compensate Radius";
            this.checkCompensateRadius.UseVisualStyleBackColor = true;
            this.checkCompensateRadius.CheckedChanged += new System.EventHandler(this.checkCompensateRadius_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(132, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "at Object Z of ZERO";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(132, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "at Object Z of";
            // 
            // numScratchingDepthAtHeight
            // 
            this.numScratchingDepthAtHeight.DecimalPlaces = 1;
            this.numScratchingDepthAtHeight.Location = new System.Drawing.Point(230, 139);
            this.numScratchingDepthAtHeight.Name = "numScratchingDepthAtHeight";
            this.numScratchingDepthAtHeight.Size = new System.Drawing.Size(120, 22);
            this.numScratchingDepthAtHeight.TabIndex = 11;
            this.numScratchingDepthAtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numScratchingDepthAtHeight.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // numScratchingDepthZero
            // 
            this.numScratchingDepthZero.DecimalPlaces = 1;
            this.numScratchingDepthZero.Location = new System.Drawing.Point(6, 111);
            this.numScratchingDepthZero.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            -2147418112});
            this.numScratchingDepthZero.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.numScratchingDepthZero.Name = "numScratchingDepthZero";
            this.numScratchingDepthZero.Size = new System.Drawing.Size(120, 22);
            this.numScratchingDepthZero.TabIndex = 10;
            this.numScratchingDepthZero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numScratchingDepthZero.Value = new decimal(new int[] {
            2,
            0,
            0,
            -2147483648});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Scratching Depth [mm]";
            // 
            // numScratchingDepthMax
            // 
            this.numScratchingDepthMax.DecimalPlaces = 1;
            this.numScratchingDepthMax.Location = new System.Drawing.Point(6, 139);
            this.numScratchingDepthMax.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            -2147418112});
            this.numScratchingDepthMax.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.numScratchingDepthMax.Name = "numScratchingDepthMax";
            this.numScratchingDepthMax.Size = new System.Drawing.Size(120, 22);
            this.numScratchingDepthMax.TabIndex = 8;
            this.numScratchingDepthMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numScratchingDepthMax.Value = new decimal(new int[] {
            2,
            0,
            0,
            -2147483648});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Travel Height [mm]";
            // 
            // numTravelHeight
            // 
            this.numTravelHeight.DecimalPlaces = 1;
            this.numTravelHeight.Location = new System.Drawing.Point(6, 66);
            this.numTravelHeight.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numTravelHeight.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numTravelHeight.Name = "numTravelHeight";
            this.numTravelHeight.Size = new System.Drawing.Size(120, 22);
            this.numTravelHeight.TabIndex = 6;
            this.numTravelHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTravelHeight.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // checkForceG1onNegZ
            // 
            this.checkForceG1onNegZ.AutoSize = true;
            this.checkForceG1onNegZ.Location = new System.Drawing.Point(7, 22);
            this.checkForceG1onNegZ.Name = "checkForceG1onNegZ";
            this.checkForceG1onNegZ.Size = new System.Drawing.Size(180, 21);
            this.checkForceG1onNegZ.TabIndex = 0;
            this.checkForceG1onNegZ.Text = "Force G1 on negative Z";
            this.checkForceG1onNegZ.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(518, 492);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 104;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Image = global::Scratchy.Properties.Resources.Check_32x32;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(623, 492);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 103;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1, 71);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(154, 17);
            this.label13.TabIndex = 7;
            this.label13.Text = "Working Area X/Y [mm]";
            // 
            // numWorkingAreaX
            // 
            this.numWorkingAreaX.DecimalPlaces = 1;
            this.numWorkingAreaX.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numWorkingAreaX.Location = new System.Drawing.Point(1, 91);
            this.numWorkingAreaX.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numWorkingAreaX.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numWorkingAreaX.Name = "numWorkingAreaX";
            this.numWorkingAreaX.Size = new System.Drawing.Size(120, 22);
            this.numWorkingAreaX.TabIndex = 6;
            this.numWorkingAreaX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numWorkingAreaX.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // numWorkingAreaY
            // 
            this.numWorkingAreaY.DecimalPlaces = 1;
            this.numWorkingAreaY.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numWorkingAreaY.Location = new System.Drawing.Point(127, 91);
            this.numWorkingAreaY.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numWorkingAreaY.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numWorkingAreaY.Name = "numWorkingAreaY";
            this.numWorkingAreaY.Size = new System.Drawing.Size(120, 22);
            this.numWorkingAreaY.TabIndex = 11;
            this.numWorkingAreaY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numWorkingAreaY.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(2, 201);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(250, 21);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "Compensate Observer Perspective";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 1;
            this.numericUpDown1.Location = new System.Drawing.Point(282, 223);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown1.TabIndex = 15;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown1.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(22, 225);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(149, 17);
            this.label14.TabIndex = 17;
            this.label14.Text = "Observer Distance [m]";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(1, 174);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(264, 21);
            this.checkBox2.TabIndex = 18;
            this.checkBox2.Text = "Compensate Observer Viewing Angle";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(735, 536);
            this.ControlBox = false;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabCtrl);
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.tabCtrl.ResumeLayout(false);
            this.tabPageCommon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAngles)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScanningStepAngle)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLightingAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numViewingAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMovingAngle)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numToolAngle)).EndInit();
            this.tabPageExportNC.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScratchingDepthAtHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScratchingDepthZero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScratchingDepthMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTravelHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWorkingAreaX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWorkingAreaY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.TabPage tabPageCommon;
        private System.Windows.Forms.TabPage tabPageExportNC;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numToolAngle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numMovingAngle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxEpilog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxProlog;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numScanningStepAngle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkCompensateRadius;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numScratchingDepthAtHeight;
        private System.Windows.Forms.NumericUpDown numScratchingDepthZero;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numScratchingDepthMax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numTravelHeight;
        private System.Windows.Forms.CheckBox checkForceG1onNegZ;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numViewingAngle;
        private System.Windows.Forms.PictureBox picAngles;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numLightingAngle;
        private System.Windows.Forms.NumericUpDown numWorkingAreaY;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numWorkingAreaX;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}