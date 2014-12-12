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
    public partial class FormObjectSmashLines : Form
    {
        static DataObjectSmashLines _data = new DataObjectSmashLines();
        public DataObjectSmashLines Data { get { return _data; } }

        public FormObjectSmashLines()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _data.Dist = (double)numDist.Value;
        }

        private void FormObjectSmashLines_Load(object sender, EventArgs e)
        {
            numDist.Value = (decimal)_data.Dist;
        }
    }

    public class DataObjectSmashLines
    {
        public double Dist { get; set; }

        public DataObjectSmashLines()
        {
            Dist = 2.5;
        }
    }

}
