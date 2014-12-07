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
    public partial class FormObjectRotate : Form
    {
        public int Axis { get; set; }
        public double Angle { get; set; }

        public FormObjectRotate()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void FormObjectRotate_Load(object sender, EventArgs e)
        {
           // DataBindings.Add(formObjectRotateBindingSource);

        }
    }
}
