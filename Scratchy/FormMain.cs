using Ciloci.Flee;
using Ciloci.Flee.CalcEngine;
using Cyotek.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Settings = Scratchy.Properties.Settings;

namespace Scratchy
{

    /// <summary>
    /// Main Form with menu and status bar
    /// </summary>
    public partial class FormMain : Form
    {
        Scratch S = new Scratch();

        void Update()
        {
            UseWaitCursor = true;
            S.UpdateImage();
            pictureBox.Refresh();
            UseWaitCursor = false;
        }

        private void MenuTEST_Click(object sender, EventArgs e)
        {
            CalculationEngine engine = new CalculationEngine();
            ExpressionContext context = new ExpressionContext();
            VariableCollection variables = context.Variables;

            // Add some variables
            variables.Add("x", 100.0);
            variables.Add("y", 200.0);

            // Add an expression to the calculation engine as "a"
            engine.Add("a", "x * 2 ", context);

            // Add an expression to the engine as "b"
            engine.Add("b", "y + 100.0 ", context);

            // Add an expression at "c" that uses the results of "a" and "b"
            engine.Add("c", "a + b", context);

            // Get the value of "c"
            var result = engine.GetResult<double>("c");

            // Update a variable on the "a" expression            
            variables["x"] = 200.0;

            // Recalculate it
            engine.Recalculate("a");

            // Get the updated result
            result = engine.GetResult<double>("c");

            context.Imports.AddType(typeof(Math));

            IDynamicExpression de = context.CompileDynamic("cos(a)*sqrt(2)");
            result = (double)de.Evaluate();


            //xmasTreeRandomToolStripMenuItem1_Click(sender, e);
            //S.Load(@"C:\Trefoil_knot\trefoil_JK.off");
            S._data.JoinPolygons();

            S._data.LinesFromPolygons();


            S._data.SmashLines(2.86);
            //S._data.LevelZ();
            S.UpdateImage();
            pictureBox.Refresh();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
        }


        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            pictureBox.Image = S.GetImage();
            pictureBox.Focus();
            S._render.progress = (ProgressBar)statusProgress.ProgressBar;
        }

        private void MenuObjectGenerateXmasTreeRandom_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            S.GenerateXmasTreeRandom();
            S.UpdateImage();
            pictureBox.Refresh();
            UseWaitCursor = false;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            MenuOpen_Click(sender, e);
        }


        private void FormMain_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            bool bRender = false;

            if (e.Alt && !e.Control)
            {
                double dAngle = 7.5;
                if (e.Shift)
                    dAngle = 45;

                switch (e.KeyCode)
                {
                    case Keys.Right:
                        S._data.Rotate(1, dAngle); bRender = true;
                        break;
                    case Keys.Left:
                        S._data.Rotate(1, -dAngle); bRender = true;
                        break;
                    case Keys.Down:
                        S._data.Rotate(0, dAngle); bRender = true;
                        break;
                    case Keys.Up:
                        S._data.Rotate(0, -dAngle); bRender = true;
                        break;
                    case Keys.PageUp:
                        S._data.Rotate(2, dAngle); bRender = true;
                        break;
                    case Keys.PageDown:
                        S._data.Rotate(2, -dAngle); bRender = true;
                        break;
                    case Keys.Home:
                        S._data.Rotate(3, dAngle); bRender = true;
                        break;
                    case Keys.End:
                        S._data.Rotate(3, -dAngle); bRender = true;
                        break;

                }
                e.Handled = true;
            }

            if (e.Alt && e.Control)
            {
                double dOffset = 1;
                if (e.Shift)
                    dOffset = 10;

                switch (e.KeyCode)
                {
                    case Keys.Right:
                        S._data.Translate(dOffset, 0, 0); bRender = true;
                        break;
                    case Keys.Left:
                        S._data.Translate(-dOffset, 0, 0); bRender = true;
                        break;
                    case Keys.Up:
                        S._data.Translate(0, dOffset, 0); bRender = true;
                        break;
                    case Keys.Down:
                        S._data.Translate(0, -dOffset, 0); bRender = true;
                        break;
                    case Keys.PageUp:
                        S._data.Translate(0, 0, dOffset); bRender = true;
                        break;
                    case Keys.PageDown:
                        S._data.Translate(0, 0, -dOffset); bRender = true;
                        break;
                    case Keys.Home:
                        break;
                    case Keys.End:
                        break;

                }
                e.Handled = true;
            }

            if (bRender)
            {
                UseWaitCursor = true;

                S.UpdateImage();
                pictureBox.Refresh();
                UseWaitCursor = false;
            }
        }


        private void FormMain_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.Location.X, e.Location.Y);
            string sX, sY;

            if (((ImageBox)sender).IsPointInImage(p) == true)
            {
                //((ImageBox)sender).PointToClient(p);
                p = ((ImageBox)sender).PointToImage(p);

                double x = (double)p.X / ((ImageBox)sender).Image.Size.Width * S._render.fAxisMax * 2 - S._render.fAxisMax;
                double y = (double)p.Y / ((ImageBox)sender).Image.Size.Height * S._render.fAxisMax * -2 + S._render.fAxisMax;

                //((ImageBox)sender).Text = p.ToString();
                //p.ToString();

                sX = string.Format("{0:0.0}", x);
                sY = string.Format("{0:0.0}", y);
            }
            else
            {
                sX = "";
                sY = "";
            }

            ((FormMain)((ImageBox)sender).Parent.Parent).statusCoordX.Text = sX;
            ((FormMain)((ImageBox)sender).Parent.Parent).statusCoordY.Text = sY;
        }

        private void MenuOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadFileDialog = new OpenFileDialog();

            //loadFileDialog.FileName = Properties.Settings.Default.ExportImageName;
            loadFileDialog.Title = "Load 3D-Object";
            //saveFileDialog.InitialDirectory = "c:\\";
            loadFileDialog.Filter = "Scratchable files|*.STL;*.M;*.OFF;*.SSX|STL files (*.STL)|*.STL|OFF files (*.OFF)|*.OFF|M files (*.M)|*.M|Scratch-Script files (*.SSC)|*.SCS|All files (*.*)|*.*";
            loadFileDialog.FilterIndex = 1;
            loadFileDialog.DefaultExt = "STL";
            loadFileDialog.AddExtension = true;
            loadFileDialog.CheckPathExists = true;
            loadFileDialog.CheckFileExists = true;
            loadFileDialog.RestoreDirectory = true;
            loadFileDialog.ValidateNames = true;

            if (loadFileDialog.ShowDialog() == DialogResult.OK)
            {
                S._data.Clear();

                //Properties.Settings.Default.ExportImageName = loadFileDialog.FileName;
                //S.loadFileDialog.FileName(loadFileDialog.FileName);
                S.Load(loadFileDialog.FileName);
                //S.SmashLines(5);
                Update();
            }
        }


        private void MenuSave_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.FileName = Settings.Default.RenderExportImage_Name;
            saveFileDialog.Title = "Save as OFF";
            //saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "OFF files (*.OFF)|*.OFF|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.DefaultExt = "OFF";
            saveFileDialog.AddExtension = true;
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.ValidateNames = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                UseWaitCursor = true;

                Settings.Default.RenderExportImage_Name = saveFileDialog.FileName;
                S.Save(saveFileDialog.FileName);

                UseWaitCursor = false;
            }
        }

        private void MenuSettings_Click(object sender, EventArgs e)
        {
            FormSettings dlg = new FormSettings();

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //S._data.Translate(dlg.Data.X, dlg.Data.Y, dlg.Data.Z);
                Update();
            }
        }

        private void MenuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MenuRenderExportNC_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.FileName = Settings.Default.RenderExportNC_Name;
            saveFileDialog.Title = "Export NC File (G-Code)";
            //saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "NC files (*.NC)|*.NC;*.CNC|TXT files (*.TXT)|*.TXT|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.DefaultExt = "NC";
            saveFileDialog.AddExtension = true;
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.ValidateNames = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                UseWaitCursor = true;

                Settings.Default.RenderExportNC_Name = saveFileDialog.FileName;
                S._render.Render(saveFileDialog.FileName);
                pictureBox.Refresh();

                UseWaitCursor = false;
            }
        }

        private void MenuRenderExportImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.FileName = Settings.Default.RenderExportImage_Name;
            saveFileDialog.Title = "Export Image";
            //saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "PNG files (*.PNG)|*.PNG|JPG files (*.JPG)|*.JPG|Bitmap files (*.BMP)|*.BMP|Tiff files (*.TIF)|*.TIF|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.DefaultExt = "PNG";
            saveFileDialog.AddExtension = true;
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.ValidateNames = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                UseWaitCursor = true;

                Settings.Default.RenderExportImage_Name = saveFileDialog.FileName;
                S._render.ExportImage(saveFileDialog.FileName);

                UseWaitCursor = false;
            }
        }

        private void MenuAbout_Click(object sender, EventArgs e)
        {

        }

        private void MenuObjectScale_Click(object sender, EventArgs e)
        {

        }

        private void MenuObjectRotate_Click(object sender, EventArgs e)
        {
            FormObjectRotate dlg = new FormObjectRotate();

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                S._data.Rotate(dlg.Data.Axis, dlg.Data.Angle);
                Update();
            }
        }

        private void MenuObjectTranslate_Click(object sender, EventArgs e)
        {
            FormObjectTranslate dlg = new FormObjectTranslate();

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                S._data.Translate(dlg.Data.X, dlg.Data.Y, dlg.Data.Z);
                Update();
            }
        }

        private void MenuObjectFit_Click(object sender, EventArgs e)
        {
            FormObjectFit dlg = new FormObjectFit();

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //(double)Settings.Default.ObjectFit_Size
                S._data.Fit(dlg.Data.Size);
                Update();
            }
        }

        private void MenuObjectLevelToMinHeight_Click(object sender, EventArgs e)
        {

        }

        private void MenuObjectSmashLines_Click(object sender, EventArgs e)
        {

        }

        private void MenuObjectDeleteUnreferencedPoints_Click(object sender, EventArgs e)
        {

        }

        private void MenuObjectGenerateXasTreeRandom_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MenuSave_Click(sender, e);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            MenuRenderExportNC_Click(sender, e);
        }

        private void MenuViewScratches_CheckStateChanged(object sender, EventArgs e)
        {
            Settings.Default.View_ShowScratches = ((ToolStripMenuItem)sender).Checked;
            Update();
        }

        private void menuObjectInformation_Click(object sender, EventArgs e)
        {

        }

        private void menuJoinPolygons_Click(object sender, EventArgs e)
        {

        }
    }
}
