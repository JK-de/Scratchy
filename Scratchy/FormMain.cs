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
            S._render.progress = (ProgressBar)toolStripProgressBar.ProgressBar;
        }

        private void tESTToolStripMenuItem1_Click(object sender, EventArgs e)
        {

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

        private void tESTToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            //xmasTreeRandomToolStripMenuItem1_Click(sender, e);
            //S.Load(@"C:\Trefoil_knot\trefoil_JK.off");
            S._data.JoinPolygons();
            
            S._data.LinesFromPolygons();


            S._data.SmashLines(2.5);
            //S._data.LevelZ();
            S.UpdateImage();
            pictureBox.Refresh();
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


    }
}
