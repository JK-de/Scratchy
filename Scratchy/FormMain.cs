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
using Set = Scratchy.Properties.Settings;

namespace Scratchy
{

    /// <summary>
    /// Main Form with menu and status bar
    /// </summary>
    public partial class FormMain : Form
    {
        Scratch S = new Scratch();

        private void MenuTEST_Click(object sender, EventArgs e)
        {
            GridCalcSinc calc = new GridCalcSinc();


            //xmasTreeRandomToolStripMenuItem1_Click(sender, e);
            //S.Load(@"C:\Trefoil_knot\trefoil_JK.off");
            S._data.JoinPolygons();

            S._data.LinesFromPolygons();


            S._data.SmashLines(2.86);
            //S._data.LevelZ();
            S.UpdateImage();
            pictureBox.Refresh();
        }

        void DoRender()
        {
            UseWaitCursor = true;
            S.UpdateImage();
            pictureBox.Refresh();
            UseWaitCursor = false;
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

        private void MenuObjectGenerateXmasTreeRandom_Click(object sender, EventArgs e)
        {
            S.GenerateXmasTreeRandom();
            DoRender();
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

                double SizeX = (double)Set.Default.Common_WorkingAreaX;
                double SizeY = (double)Set.Default.Common_WorkingAreaY;

                if (Set.Default.View_ShowCompressY)
                    SizeY *= 1.4;

                double x = (double)p.X / ((ImageBox)sender).Image.Size.Width * SizeX - SizeX/2;
                double y = (double)p.Y / ((ImageBox)sender).Image.Size.Height * -SizeY + SizeY/2;

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
                DoRender();
            }
        }


        private void MenuSave_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.FileName = Set.Default.RenderExportImage_Name;
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

                Set.Default.RenderExportImage_Name = saveFileDialog.FileName;
                S.Save(saveFileDialog.FileName);

                UseWaitCursor = false;
            }
        }

        private void MenuSettings_Click(object sender, EventArgs e)
        {
            FormSettings dlg = new FormSettings();

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                S.SettingsChanged();
                pictureBox.Image = S.GetImage();
                S._render.progress = (ProgressBar)statusProgress.ProgressBar;

                DoRender();
            }
        }

        private void MenuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MenuRenderExportNC_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.FileName = Set.Default.RenderExportNC_Name;
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

                Set.Default.RenderExportNC_Name = saveFileDialog.FileName;
                S._render.Render(saveFileDialog.FileName);
                pictureBox.Refresh();

                UseWaitCursor = false;
            }
        }

        private void MenuRenderExportImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.FileName = Set.Default.RenderExportImage_Name;
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

                Set.Default.RenderExportImage_Name = saveFileDialog.FileName;
                S._render.ExportImage(saveFileDialog.FileName);

                UseWaitCursor = false;
            }
        }

        private void MenuAbout_Click(object sender, EventArgs e)
        {
            FormAbout dlg = new FormAbout();

            dlg.ShowDialog();
        }

        private void MenuObjectScale_Click(object sender, EventArgs e)
        {
            FormObjectScale dlg = new FormObjectScale();

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                S._data.Scale(dlg.Data.X, dlg.Data.Y, dlg.Data.Z);
                DoRender();
            }
        }

        private void MenuObjectRotate_Click(object sender, EventArgs e)
        {
            FormObjectRotate dlg = new FormObjectRotate();

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                S._data.Rotate(dlg.Data.Axis, dlg.Data.Angle);
                DoRender();
            }
        }

        private void MenuObjectTranslate_Click(object sender, EventArgs e)
        {
            FormObjectTranslate dlg = new FormObjectTranslate();

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                S._data.Translate(dlg.Data.X, dlg.Data.Y, dlg.Data.Z);
                DoRender();
            }
        }

        private void MenuObjectFit_Click(object sender, EventArgs e)
        {
            FormObjectFit dlg = new FormObjectFit();

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                S._data.Fit(dlg.Data.Size);
                DoRender();
            }
        }

        private void MenuObjectLevelToMinHeight_Click(object sender, EventArgs e)
        {
            S._data.LevelZ();
            DoRender();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuObjectSmashLines_Click(object sender, EventArgs e)
        {
            FormObjectSmashLines dlg = new FormObjectSmashLines();

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                S._data.SmashLines(dlg.Data.Dist);
                DoRender();
            }
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


        private void menuObjectInformation_Click(object sender, EventArgs e)
        {

        }

        private void menuJoinPolygons_Click(object sender, EventArgs e)
        {
            S._data.JoinPolygons();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        class GridCalcSinc : ScratchData.IGridCalc
        {
            public bool CalcZ(int nX, int nY, ref double dX, ref double dY, ref double dZ)
            {
                double r = Math.Sqrt(dX * dX + dY * dY);
                double v = r * 3.14 * 2.5;

                if (v != 0)
                    dZ = Math.Sin(v) / v;
                else
                    dZ = 1;
                dZ *= 0.75;

                return true;
            }
        }

        private void menuGenerateGridSinc40_Click(object sender, EventArgs e)
        {
            GridCalcSinc calc = new GridCalcSinc();

            S._data.GenerateGrid(40, 40, calc);
            S._data.Points.Scale(40);
            DoRender();
        }

        class GridCalcSinX2Y2 : ScratchData.IGridCalc
        {
            public bool CalcZ(int nX, int nY, ref double dX, ref double dY, ref double dZ)
            {
                dZ = Math.Sin(10 * (dX * dX + dY * dY)) / 10;

                return true;
            }
        }

        private void menuGenerateGridSincX2Y2_40_Click(object sender, EventArgs e)
        {
            GridCalcSinX2Y2 calc = new GridCalcSinX2Y2();

            S._data.GenerateGrid(40, 40, calc);
            S._data.Points.Scale(40);
            DoRender();
        }

        class GridCalcFunction : ScratchData.IGridCalc
        {
            CalculationEngine engine;
            ExpressionContext context;
            VariableCollection variables;
            string strError = "";

            public GridCalcFunction(string strA, string strB, string strC, string strZ)
            {
                engine = new CalculationEngine();
                context = new ExpressionContext();
                variables = context.Variables;
                context.Imports.AddType(typeof(Math));

                try
                {
                    // Add some variables
                    variables.Add("x", 0.0);
                    variables.Add("y", 0.0);
                    variables.Add("r", 0.0);

                    // Add an expression to the calculation engine as "a"
                    engine.Add("a", strA, context);
                    engine.Add("b", strB, context);
                    engine.Add("c", strC, context);
                    engine.Add("z", strZ, context);

                    engine.Recalculate("a");
                }
                catch (Exception e)
                {
                    
                    //throw;
                }

                // Get the value of "c"
                //var result = engine.GetResult<double>("c");

                // Update a variable on the "a" expression            
                //variables["x"] = 200.0;

                // Recalculate it

                // Get the updated result
                //result = engine.GetResult<double>("c");

                //IDynamicExpression de = context.CompileDynamic("cos(a)*sqrt(2)");
                //result = (double)de.Evaluate();


            }

            public bool CalcZ(int nX, int nY, ref double dX, ref double dY, ref double dZ)
            {
                try
                {
                    variables["x"] = dX;
                    variables["y"] = dY;
                    variables["r"] = Math.Sqrt(dX * dX + dY * dY);

                    engine.Recalculate("a");
                    engine.Recalculate("b");
                    engine.Recalculate("c");
                    engine.Recalculate("z");

                    // Get the updated result
//                    dZ = engine.GetResult<double>();
                    var result = engine.GetResult("z");
                    //var t = result.GetType();
                    dZ = Convert.ToDouble(result);
                }
                catch (Exception e)
                {
                    strError = e.ToString();
                    dZ = 0;                    
                    //throw;
                }

                return true;
            }
        }

        private void menuGenerateGridFunction_Click(object sender, EventArgs e)
        {
            FormGenerateGridFunction dlg = new FormGenerateGridFunction();

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
//                GridCalcFunction calc = new GridCalcFunction("0", "0", "0", "Sin(x*5)*Cos(y*5)-sin(0)");
                GridCalcFunction calc = new GridCalcFunction(dlg.Data.strA, dlg.Data.strB, dlg.Data.strC, dlg.Data.strZ);

                S._data.GenerateGrid(dlg.Data.nPoints, dlg.Data.nPoints, calc);
                S._data.Points.Scale(dlg.Data.nPoints);
                DoRender();

                //JK S._data.Fit(dlg.Data.Size);
            }
        }

        private void menuObjectAlignCenterZ_Click(object sender, EventArgs e)
        {

        }

        private void menuObjectAlignDropZ_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            pictureBox.Image = S.GetImage();
            pictureBox.Focus();
            S._render.progress = (ProgressBar)statusProgress.ProgressBar;

            menuViewGrid.Checked = Set.Default.View_ShowGrid;
            menuViewScratches.Checked = Set.Default.View_ShowScratches;
            menuViewReflex.Checked = Set.Default.View_ShowReflex;
            menuViewCompressY.Checked = Set.Default.View_ShowCompressY;
        }

        private void MenuViewScratches_CheckStateChanged(object sender, EventArgs e)
        {
            Set.Default.View_ShowScratches = ((ToolStripMenuItem)sender).Checked;
            DoRender();
        }

        private void menuViewGrid_Click(object sender, EventArgs e)
        {
            Set.Default.View_ShowGrid = ((ToolStripMenuItem)sender).Checked;
            DoRender();
        }

        private void menuViewReflex_Click(object sender, EventArgs e)
        {
            Set.Default.View_ShowReflex = ((ToolStripMenuItem)sender).Checked;
            DoRender();
        }

        private void compressYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Set.Default.View_ShowCompressY = ((ToolStripMenuItem)sender).Checked;
            DoRender();
        }

        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            S._data.Clear();

            S.Load((string)e.Data.GetData(System.Windows.DataFormats.StringFormat));

            DoRender();
        }

        private void FormMain_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            
        }

        private void FormMain_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {

        }

        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {

        }
    }
}
