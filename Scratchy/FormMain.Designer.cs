namespace Scratchy
{
    partial class FormMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.pictureBox = new Cyotek.Windows.Forms.ImageBox();
            this.objectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSTLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renderingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportCNCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusCoordX = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusCoordY = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.statusInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.xmasTreeRandomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.objectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xmasTreeRandomToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuObjectScale = new System.Windows.Forms.ToolStripMenuItem();
            this.menuObjectRotate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuObjectTranslate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.menuObjectFit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuObjectLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuObjectSmashLines = new System.Windows.Forms.ToolStripMenuItem();
            this.menuObjectDeleteUnreferencedPoints = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRenderExportNC = new System.Windows.Forms.ToolStripMenuItem();
            this.exportCNCToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRenderExportImage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.menuTEST = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanelButton = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            this.flowLayoutPanelButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.AllowClickZoom = true;
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.pictureBox.Zoom = 25;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove_1);
            // 
            // objectToolStripMenuItem
            // 
            this.objectToolStripMenuItem.Name = "objectToolStripMenuItem";
            resources.ApplyResources(this.objectToolStripMenuItem, "objectToolStripMenuItem");
            // 
            // loadSTLToolStripMenuItem
            // 
            this.loadSTLToolStripMenuItem.Name = "loadSTLToolStripMenuItem";
            resources.ApplyResources(this.loadSTLToolStripMenuItem, "loadSTLToolStripMenuItem");
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            // 
            // renderingToolStripMenuItem
            // 
            this.renderingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.savePNGToolStripMenuItem,
            this.toolStripSeparator2,
            this.exportCNCToolStripMenuItem});
            this.renderingToolStripMenuItem.Name = "renderingToolStripMenuItem";
            resources.ApplyResources(this.renderingToolStripMenuItem, "renderingToolStripMenuItem");
            // 
            // savePNGToolStripMenuItem
            // 
            this.savePNGToolStripMenuItem.Name = "savePNGToolStripMenuItem";
            resources.ApplyResources(this.savePNGToolStripMenuItem, "savePNGToolStripMenuItem");
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // exportCNCToolStripMenuItem
            // 
            this.exportCNCToolStripMenuItem.Name = "exportCNCToolStripMenuItem";
            resources.ApplyResources(this.exportCNCToolStripMenuItem, "exportCNCToolStripMenuItem");
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            resources.ApplyResources(this.testToolStripMenuItem, "testToolStripMenuItem");
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusCoordX,
            this.statusCoordY,
            this.statusProgress,
            this.statusInfo});
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            // 
            // statusCoordX
            // 
            resources.ApplyResources(this.statusCoordX, "statusCoordX");
            this.statusCoordX.Name = "statusCoordX";
            // 
            // statusCoordY
            // 
            resources.ApplyResources(this.statusCoordY, "statusCoordY");
            this.statusCoordY.Name = "statusCoordY";
            this.statusCoordY.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // statusProgress
            // 
            this.statusProgress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.statusProgress.MarqueeAnimationSpeed = 500;
            this.statusProgress.Name = "statusProgress";
            resources.ApplyResources(this.statusProgress, "statusProgress");
            this.statusProgress.Step = 1;
            this.statusProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // statusInfo
            // 
            this.statusInfo.Name = "statusInfo";
            resources.ApplyResources(this.statusInfo, "statusInfo");
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.xmasTreeRandomToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // xmasTreeRandomToolStripMenuItem
            // 
            this.xmasTreeRandomToolStripMenuItem.Name = "xmasTreeRandomToolStripMenuItem";
            resources.ApplyResources(this.xmasTreeRandomToolStripMenuItem, "xmasTreeRandomToolStripMenuItem");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.objectToolStripMenuItem1,
            this.menuRenderExportNC,
            this.menuTEST,
            this.helpToolStripMenuItem1});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLoad,
            this.menuSave,
            this.toolStripSeparator5,
            this.menuSettings,
            this.toolStripSeparator8,
            this.menuExit});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            // 
            // menuLoad
            // 
            this.menuLoad.Image = global::Scratchy.Properties.Resources.Open_32x32;
            this.menuLoad.Name = "menuLoad";
            resources.ApplyResources(this.menuLoad, "menuLoad");
            this.menuLoad.Click += new System.EventHandler(this.loadToolStripMenuItem1_Click);
            // 
            // menuSave
            // 
            this.menuSave.Name = "menuSave";
            resources.ApplyResources(this.menuSave, "menuSave");
            this.menuSave.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // menuSettings
            // 
            this.menuSettings.Name = "menuSettings";
            resources.ApplyResources(this.menuSettings, "menuSettings");
            this.menuSettings.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            resources.ApplyResources(this.menuExit, "menuExit");
            this.menuExit.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
            // 
            // objectToolStripMenuItem1
            // 
            this.objectToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateToolStripMenuItem,
            this.toolStripSeparator3,
            this.menuObjectScale,
            this.menuObjectRotate,
            this.menuObjectTranslate,
            this.toolStripSeparator6,
            this.menuObjectFit,
            this.menuObjectLevel,
            this.toolStripSeparator4,
            this.menuObjectSmashLines,
            this.menuObjectDeleteUnreferencedPoints});
            this.objectToolStripMenuItem1.Name = "objectToolStripMenuItem1";
            resources.ApplyResources(this.objectToolStripMenuItem1, "objectToolStripMenuItem1");
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xmasTreeRandomToolStripMenuItem1});
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            resources.ApplyResources(this.generateToolStripMenuItem, "generateToolStripMenuItem");
            // 
            // xmasTreeRandomToolStripMenuItem1
            // 
            this.xmasTreeRandomToolStripMenuItem1.Name = "xmasTreeRandomToolStripMenuItem1";
            resources.ApplyResources(this.xmasTreeRandomToolStripMenuItem1, "xmasTreeRandomToolStripMenuItem1");
            this.xmasTreeRandomToolStripMenuItem1.Click += new System.EventHandler(this.xmasTreeRandomToolStripMenuItem1_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // menuObjectScale
            // 
            this.menuObjectScale.Name = "menuObjectScale";
            resources.ApplyResources(this.menuObjectScale, "menuObjectScale");
            this.menuObjectScale.Click += new System.EventHandler(this.scaleToolStripMenuItem_Click);
            // 
            // menuObjectRotate
            // 
            this.menuObjectRotate.Name = "menuObjectRotate";
            resources.ApplyResources(this.menuObjectRotate, "menuObjectRotate");
            this.menuObjectRotate.Click += new System.EventHandler(this.rotateToolStripMenuItem_Click);
            // 
            // menuObjectTranslate
            // 
            this.menuObjectTranslate.Name = "menuObjectTranslate";
            resources.ApplyResources(this.menuObjectTranslate, "menuObjectTranslate");
            this.menuObjectTranslate.Click += new System.EventHandler(this.translateToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // menuObjectFit
            // 
            this.menuObjectFit.Name = "menuObjectFit";
            resources.ApplyResources(this.menuObjectFit, "menuObjectFit");
            this.menuObjectFit.Click += new System.EventHandler(this.fitToolStripMenuItem_Click);
            // 
            // menuObjectLevel
            // 
            this.menuObjectLevel.Name = "menuObjectLevel";
            resources.ApplyResources(this.menuObjectLevel, "menuObjectLevel");
            this.menuObjectLevel.Click += new System.EventHandler(this.levelToMinHeightToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // menuObjectSmashLines
            // 
            this.menuObjectSmashLines.Name = "menuObjectSmashLines";
            resources.ApplyResources(this.menuObjectSmashLines, "menuObjectSmashLines");
            this.menuObjectSmashLines.Click += new System.EventHandler(this.smashLinesToolStripMenuItem_Click);
            // 
            // menuObjectDeleteUnreferencedPoints
            // 
            this.menuObjectDeleteUnreferencedPoints.Name = "menuObjectDeleteUnreferencedPoints";
            resources.ApplyResources(this.menuObjectDeleteUnreferencedPoints, "menuObjectDeleteUnreferencedPoints");
            this.menuObjectDeleteUnreferencedPoints.Click += new System.EventHandler(this.deleteUnreferencedPointsToolStripMenuItem_Click);
            // 
            // menuRenderExportNC
            // 
            this.menuRenderExportNC.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportCNCToolStripMenuItem1,
            this.menuRenderExportImage,
            this.toolStripSeparator7});
            this.menuRenderExportNC.Name = "menuRenderExportNC";
            resources.ApplyResources(this.menuRenderExportNC, "menuRenderExportNC");
            // 
            // exportCNCToolStripMenuItem1
            // 
            this.exportCNCToolStripMenuItem1.Name = "exportCNCToolStripMenuItem1";
            resources.ApplyResources(this.exportCNCToolStripMenuItem1, "exportCNCToolStripMenuItem1");
            this.exportCNCToolStripMenuItem1.Click += new System.EventHandler(this.exportCNCToolStripMenuItem1_Click);
            // 
            // menuRenderExportImage
            // 
            this.menuRenderExportImage.Name = "menuRenderExportImage";
            resources.ApplyResources(this.menuRenderExportImage, "menuRenderExportImage");
            this.menuRenderExportImage.Click += new System.EventHandler(this.exportImagePNGToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            // 
            // menuTEST
            // 
            this.menuTEST.Name = "menuTEST";
            resources.ApplyResources(this.menuTEST, "menuTEST");
            this.menuTEST.Click += new System.EventHandler(this.tESTToolStripMenuItem1_Click_1);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAbout});
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            resources.ApplyResources(this.helpToolStripMenuItem1, "helpToolStripMenuItem1");
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            resources.ApplyResources(this.menuAbout, "menuAbout");
            this.menuAbout.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // tableLayoutPanelMain
            // 
            resources.ApplyResources(this.tableLayoutPanelMain, "tableLayoutPanelMain");
            this.tableLayoutPanelMain.Controls.Add(this.pictureBox, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.flowLayoutPanelButton, 0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            // 
            // flowLayoutPanelButton
            // 
            resources.ApplyResources(this.flowLayoutPanelButton, "flowLayoutPanelButton");
            this.flowLayoutPanelButton.Controls.Add(this.btnLoad);
            this.flowLayoutPanelButton.Controls.Add(this.btnSave);
            this.flowLayoutPanelButton.Controls.Add(this.btnExport);
            this.flowLayoutPanelButton.Name = "flowLayoutPanelButton";
            // 
            // btnLoad
            // 
            resources.ApplyResources(this.btnLoad, "btnLoad");
            this.btnLoad.Image = global::Scratchy.Properties.Resources.Open_32x32;
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Image = global::Scratchy.Properties.Resources.Save_32x32;
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            resources.ApplyResources(this.btnExport, "btnExport");
            this.btnExport.Image = global::Scratchy.Properties.Resources.Stock_Index_Up_32x32;
            this.btnExport.Name = "btnExport";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormMain_KeyPress);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.FormMain_PreviewKeyDown);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.flowLayoutPanelButton.ResumeLayout(false);
            this.flowLayoutPanelButton.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        //        private PA.Picture.ZoomPictureBox pictureBox;
//        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolStripMenuItem objectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renderingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusCoordY;
        private System.Windows.Forms.ToolStripMenuItem loadSTLToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savePNGToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exportCNCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar statusProgress;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem xmasTreeRandomToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem objectToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuRenderExportNC;
        private System.Windows.Forms.ToolStripMenuItem menuTEST;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xmasTreeRandomToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exportCNCToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuRenderExportImage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        public Cyotek.Windows.Forms.ImageBox pictureBox;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem menuLoad;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButton;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ToolStripMenuItem menuObjectScale;
        private System.Windows.Forms.ToolStripMenuItem menuObjectRotate;
        private System.Windows.Forms.ToolStripMenuItem menuObjectTranslate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem menuObjectFit;
        private System.Windows.Forms.ToolStripMenuItem menuObjectLevel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem menuObjectSmashLines;
        private System.Windows.Forms.ToolStripMenuItem menuObjectDeleteUnreferencedPoints;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem menuSave;
        private System.Windows.Forms.ToolStripMenuItem menuSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripStatusLabel statusInfo;
        private System.Windows.Forms.ToolStripStatusLabel statusCoordX;
    }
}

