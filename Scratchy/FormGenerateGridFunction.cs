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
    public partial class FormGenerateGridFunction : Form
    {
        static DataGenerateGridFunction _data = new DataGenerateGridFunction();
        public DataGenerateGridFunction Data { get { return _data; } }

        public FormGenerateGridFunction()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _data.strA = textA.Text;
            _data.strB = textB.Text;
            _data.strC = textC.Text;
            _data.strZ = textZ.Text;
            _data.nPoints = (int)numPoints.Value;

        }

        private void FormGenerateGridFunction_Load(object sender, EventArgs e)
        {
            textA.Text = _data.strA;
            textB.Text = _data.strB;
            textC.Text = _data.strC;
            textZ.Text = _data.strZ;
            numPoints.Value = _data.nPoints;
        }
    }

    public class DataGenerateGridFunction
    {
        public string strA { get; set; }
        public string strB { get; set; }
        public string strC { get; set; }
        public string strZ { get; set; }
        public int nPoints { get; set; }

        public DataGenerateGridFunction()
        {
            strA = "0";
            strB = "0";
            strC = "0";
            strZ = "0";
            nPoints = 40;
        }
    }

}
