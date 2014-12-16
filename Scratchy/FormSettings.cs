using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Set = Scratchy.Properties.Settings;

namespace Scratchy
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        private void numToolAngle_ValueChanged(object sender, EventArgs e)
        {
            double v = (double)numToolAngle.Value;

            v = v - 90;
            if (v < 0) v = 0;

            numViewingAngle.Value = (decimal)v;
            //Set.Default.Common_ViewingAngle = (decimal)v;
        }

        private void comboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Set.Default.Common_Type = comboType.SelectedIndex;
        }

        private void checkCompensateRadius_CheckedChanged(object sender, EventArgs e)
        {
            bool on = checkCompensateRadius.Checked;

            numScratchingDepthMax.Enabled = on;
            numScratchingDepthAtHeight.Enabled = on;

            if (!on)
                numScratchingDepthMax.Value = numScratchingDepthZero.Value;
        }

        private void numToolAngle_Validating(object sender, CancelEventArgs e)
        {
            double v = (double)numToolAngle.Value;

            v = v - 90;
            if (v < 0) v = 0;

            numViewingAngle.Value = (decimal)v;
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            // tab common
            numToolAngle.Value = Set.Default.Common_ToolAngle;
            numMovingAngle.Value = Set.Default.Common_MovingAngle;
            numViewingAngle.Value = Set.Default.Common_ViewingAngle;
            numLightingAngle.Value = Set.Default.Common_LightingAngle;
            comboType.SelectedIndex = Set.Default.Common_Type;
            numScanningStepAngle.Value = Set.Default.Common_ScanningStepAngle;
            numWorkingAreaX.Value=Set.Default.Common_WorkingAreaX;
            numWorkingAreaY.Value=Set.Default.Common_WorkingAreaY;

            numToolAngle_ValueChanged(sender, e);

            // tabCtrl NC
            textBoxProlog.Text = Set.Default.NC_Prolog;
            textBoxEpilog.Text = Set.Default.NC_Epilog;
            checkForceG1onNegZ.Checked = Set.Default.NC_ForceG1onNegZ;
            numTravelHeight.Value = Set.Default.NC_TravelHeight;
            numScratchingDepthMax.Value = Set.Default.NC_ScratchingDepthMax;
            numScratchingDepthZero.Value = Set.Default.NC_ScratchingDepthZero;
            numScratchingDepthAtHeight.Value = Set.Default.NC_ScratchingDepthAtHeight;
            checkCompensateRadius.Checked = Set.Default.NC_CompensateRadius;

            checkCompensateRadius_CheckedChanged(sender, e);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // tab common
            Set.Default.Common_ToolAngle = numToolAngle.Value;
            Set.Default.Common_MovingAngle = numMovingAngle.Value;
            Set.Default.Common_ViewingAngle = numViewingAngle.Value;
            Set.Default.Common_LightingAngle = numLightingAngle.Value;
            Set.Default.Common_Type = comboType.SelectedIndex;
            Set.Default.Common_WorkingAreaX = numWorkingAreaX.Value;
            Set.Default.Common_WorkingAreaY = numWorkingAreaY.Value;
            Set.Default.Common_ScanningStepAngle = numScanningStepAngle.Value;
            

            // tabCtrl NC
            Set.Default.NC_Prolog = textBoxProlog.Text;
            Set.Default.NC_Epilog = textBoxEpilog.Text;
            Set.Default.NC_ForceG1onNegZ = checkForceG1onNegZ.Checked;
            Set.Default.NC_TravelHeight = numTravelHeight.Value;
            Set.Default.NC_ScratchingDepthMax = numScratchingDepthMax.Value;
            Set.Default.NC_ScratchingDepthZero = numScratchingDepthZero.Value;
            Set.Default.NC_ScratchingDepthAtHeight = numScratchingDepthAtHeight.Value;
            Set.Default.NC_CompensateRadius = checkCompensateRadius.Checked;

        }

    }
}
