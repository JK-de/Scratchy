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

namespace Scratchy
{
    public partial class FormMain : Form
    {
        Scratch S = new Scratch();

        private void tESTToolStripMenuItem1_Click_1(object sender, EventArgs e)
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

        private void xmasTreeRandomToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            S.GenerateXmasTreeRandom();
            S.UpdateImage();
            pictureBox.Refresh();
            UseWaitCursor = false;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            SizeF s = new SizeF(0.025f, 0.025f);

            if (e.Button == MouseButtons.Right)
            {
                pictureBox.Scale(s);
            }

            //pictureBox.

        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            loadToolStripMenuItem1_Click(sender, e);
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

        private void scaleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void levelToMinHeightToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void smashLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteUnreferencedPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {

        }


        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox_MouseMove_1(object sender, MouseEventArgs e)
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
                p.ToString();

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


    }
}
