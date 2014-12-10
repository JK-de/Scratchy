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
    /// Settings dialog for object fit in bounding box
    /// </summary>
    public partial class FormObjectFit : Form
    {
        static DataObjectFit _data = new DataObjectFit();
        public DataObjectFit Data { get { return _data; } }

        public FormObjectFit()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _data.Size = (double)numSize.Value;
        }

        private void FormObjectFit_Load(object sender, EventArgs e)
        {
            numSize.Value = (decimal)_data.Size;
        }
    }

    public class DataObjectFit
    {
        public double Size { get; set; }

        public DataObjectFit()
        {
            Size = 60;
        }
    }


}
