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
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void rotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormObjectRotate dlg = new FormObjectRotate();

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UseWaitCursor = true;
                S._data.Rotate(dlg.Axis, dlg.Angle);
                S.UpdateImage();
                pictureBox.Refresh();
                UseWaitCursor = false;

            }
        }


        private void translateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormObjectTranslate dlg = new FormObjectTranslate();

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UseWaitCursor = true;
                S._data.Translate(0, 0, -10);
                S.UpdateImage();
                pictureBox.Refresh();
                UseWaitCursor = false;
            }
        }


        private void fitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormObjectFit f = new FormObjectFit();

            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UseWaitCursor = true;
                S._data.Fit((double)Properties.Settings.Default.ObjectFit_Size);
                S.UpdateImage();
                pictureBox.Refresh();
                UseWaitCursor = false;

            }
        }



        private void loadToolStripMenuItem1_Click(object sender, EventArgs e)
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
                UseWaitCursor = true;

                S._data.Clear();

                //Properties.Settings.Default.ExportImageName = loadFileDialog.FileName;
                //S.loadFileDialog.FileName(loadFileDialog.FileName);
                S.Load(loadFileDialog.FileName);
                //S.SmashLines(5);
                S.UpdateImage();
                pictureBox.Refresh();

                UseWaitCursor = false;
            }
        }



        private void exportCNCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.FileName = Properties.Settings.Default.ExportImageName;
            saveFileDialog.Title = "Export CNC File (G-Code)";
            //saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "NC files (*.NC)|*.NC|TXT files (*.TXT)|*.TXT|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.DefaultExt = "NC";
            saveFileDialog.AddExtension = true;
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.ValidateNames = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                UseWaitCursor = true;

                Properties.Settings.Default.ExportImageName = saveFileDialog.FileName;
                S._render.Render(saveFileDialog.FileName);

                UseWaitCursor = false;
            }
        }

        private void exportImagePNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.FileName = Properties.Settings.Default.ExportImageName;
            saveFileDialog.Title = "Export Image PNG";
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

                Properties.Settings.Default.ExportImageName = saveFileDialog.FileName;
                S._render.ExportImage(saveFileDialog.FileName);

                UseWaitCursor = false;
            }
        }


    }
}