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
    /// <summary>
    /// Settings dialog for object translation (move)
    /// </summary>
    public partial class FormObjectTranslate : Form
    {
        static DataObjectTranslate _data = new DataObjectTranslate();
        public DataObjectTranslate Data { get { return _data; } }

        public FormObjectTranslate()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _data.X = (double)numX.Value;
            _data.Y = (double)numY.Value;
            _data.Z = (double)numZ.Value;
        }

        private void FormObjectTranslate_Load(object sender, EventArgs e)
        {
            numX.Value = (decimal)_data.X;
            numY.Value = (decimal)_data.Y;
            numZ.Value = (decimal)_data.Z;
        }
    }

    public class DataObjectTranslate
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public DataObjectTranslate()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }
    }

}
