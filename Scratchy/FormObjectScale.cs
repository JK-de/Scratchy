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
    public partial class FormObjectScale : Form
    {
        static DataObjectScale _data = new DataObjectScale();
        public DataObjectScale Data { get { return _data; } }

        public FormObjectScale()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numX.Value = 1;
            numY.Value = 1;
            numZ.Value = 1;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _data.X = (double)numX.Value;
            _data.Y = (double)numY.Value;
            _data.Z = (double)numZ.Value;
        }

        private void FormObjectScale_Load(object sender, EventArgs e)
        {
            numX.Value = (decimal)_data.X;
            numY.Value = (decimal)_data.Y;
            numZ.Value = (decimal)_data.Z;
        }
    }

    public class DataObjectScale
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public DataObjectScale()
        {
            X = 1;
            Y = 1;
            Z = 1;
        }
    }

}
