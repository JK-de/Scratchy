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
    /// Settings dialog for object rotation
    /// </summary>
    public partial class FormObjectRotate : Form
    {
        static DataObjectRotate _data = new DataObjectRotate();
        public DataObjectRotate Data { get { return _data; } }


        public FormObjectRotate()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _data.Axis = comboAxis.SelectedIndex;
            _data.Angle = (double)numSize.Value;
        }

        private void FormObjectRotate_Load(object sender, EventArgs e)
        {
            // DataBindings.Add(formObjectRotateBindingSource);
            comboAxis.SelectedIndex = _data.Axis;
            numSize.Value = (decimal)_data.Angle;
        }
    }

    public class DataObjectRotate
    {
        public int Axis { get; set; }
        public double Angle { get; set; }

        public DataObjectRotate()
        {
            Axis = 2;
            Angle = 0;
        }
    }

}
