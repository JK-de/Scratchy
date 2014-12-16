using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using Set = Scratchy.Properties.Settings;

namespace Scratchy
{
    public partial class ScratchRender
    {
        public string FileName;
        public ProgressBar progress;
        PointList PointsX;

        ScratchData _data;

        public ScratchRender(ScratchData data)
        {
            _data = data;
            CreateImage();
        }

        public Bitmap CreateImage()
        {
            _image = null;

            int nImageX = (int)((fDPI / 25.4) * (double)Set.Default.Common_WorkingAreaX);
            int nImageY = (int)((fDPI / 25.4) * (double)Set.Default.Common_WorkingAreaY);
            _image = new Bitmap(nImageX, nImageY, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            _image.SetResolution(fDPI, fDPI);

            Render();

            return _image;
        }

        public Bitmap GetImage()
        {
            return _image;
        }

        /// <summary>Render image and NC</summary>
        /// <param name="FileName"> optional file-name for NC export</param>
        public void Render(string FileName = null)
        {
            if (FileName != null && FileName.Length > 0)
                _file = File.CreateText(FileName);
            else
                _file = null;

            if (_file != null)
            {
                _file.WriteLine(";(SCRATCHY V0.1)");
                _file.WriteLine(Set.Default.NC_Prolog);
            }

            PointsX = new PointList(_data.Points);

            RenderInit();

            switch (Set.Default.Common_Type)
            {
                case 0:
                    RenderTableTopCircle();
                    break;
                case 1:
                default:
                    RenderTableTopArc();
                    break;
                case 2:
                    RenderTableTopArcSolid();
                    break;
            }

            RenderExit();

            if (_file != null)
            {
                _file.WriteLine(Set.Default.NC_Epilog);
            }

            if (_file != null)
            {
                _file.Close();
                _file = null;
            }

            PointsX = null;
        }

        /// <summary>
        /// 
        /// </summary>
        void RenderInit()
        {
            NC_Init();

            G = Graphics.FromImage(_image);


            G.PageUnit = GraphicsUnit.Pixel;
            G.FillRectangle(Brushes.White, 0, 0, _image.Size.Width, _image.Size.Height);

            G.PageUnit = GraphicsUnit.Millimeter;
            G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            double dStrechY = 1.0;
            if (Set.Default.View_ShowCompressY)
                dStrechY = 1.4;

            float fRangeX = (float)Set.Default.Common_WorkingAreaX / 2;
            float fRangeY = (float)Set.Default.Common_WorkingAreaY / 2;

            //G.ScaleTransform((float)(1024 / (range * 2.0)), (float)(1024 / (range * -2.0)));
            //G.TranslateTransform(512, 512, MatrixOrder.Append);

            G.ScaleTransform(1.0f, -1.0f / (float)dStrechY);//  * 0.7f

            //G.RotateTransform(30, MatrixOrder.Append);
            G.TranslateTransform(fRangeX, fRangeY, MatrixOrder.Append);

            Color colorScratch = Color.FromArgb(12, 0, 0, 0);
            penScratch = new Pen(colorScratch, 0.3f);
            Color colorReflexR = Color.FromArgb(64, 255, 0, 0);
            brushReflexR = new SolidBrush(colorReflexR);
            Color colorReflexC = Color.FromArgb(96, 0, 255, 255);
            brushReflexC = new SolidBrush(colorReflexC);


            if (Set.Default.View_ShowGrid)
            {
                Color c = Color.FromArgb(48, 128, 255, 0);
                Pen pen = new Pen(c, 0.1f);

                fRangeY *= (float)dStrechY;
                float fRangeM = Math.Max(fRangeX, fRangeY);

                for (float fStep = 0; fStep < fRangeM; fStep += 1.0f)
                {
                    G.DrawLine(pen, fStep, -fRangeY, fStep, fRangeY);
                    G.DrawLine(pen, -fStep, -fRangeY, -fStep, fRangeY);
                    G.DrawLine(pen, -fRangeX, fStep, fRangeX, fStep);
                    G.DrawLine(pen, -fRangeX, -fStep, fRangeX, -fStep);
                }
                for (float fStep = 0; fStep < fRangeM; fStep += 10.0f)
                {
                    G.DrawLine(pen, fStep, -fRangeY, fStep, fRangeY);
                    G.DrawLine(pen, -fStep, -fRangeY, -fStep, fRangeY);
                    G.DrawLine(pen, -fRangeX, fStep, fRangeX, fStep);
                    G.DrawLine(pen, -fRangeX, -fStep, fRangeX, -fStep);
                }
                for (float fStep = 0; fStep < fRangeM; fStep += 50.0f)
                {
                    G.DrawLine(pen, fStep, -fRangeY, fStep, fRangeY);
                    G.DrawLine(pen, -fStep, -fRangeY, -fStep, fRangeY);
                    G.DrawLine(pen, -fRangeX, fStep, fRangeX, fStep);
                    G.DrawLine(pen, -fRangeX, -fStep, fRangeX, -fStep);
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        void RenderExit()
        {
            G.Dispose();
            NC_Exit();
        }

        /// <summary>
        /// 
        /// </summary>
        void RenderTableTopArc()
        {
            PointsX.Sort(new Point3DComparer(0.01, 1, Math.Cos((double)Set.Default.Common_MovingAngle / 180 * Math.PI) ));

            foreach (Point3D P in PointsX)
            {
                Arc(P.X, P.Y, P.Z);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        void RenderTableTopCircle()
        {
            PointsX.Sort(new Point3DComparer(0.01, 0.001, 1));

            foreach (Point3D P in PointsX)
            {
                if (P.Z >= 0)
                    Circle(P.X, P.Y, P.Z);
            }
        }






        /// <summary>
        /// Render image and NC for table-type-scratch with hidden-point-calculation
        /// </summary>
        /// <returns></returns>
        public bool RenderTableTopArcSolid()
        {
            double ViewingAngle = (double)Set.Default.Common_MovingAngle;
            int Steps = (int)(ViewingAngle / (double)Set.Default.Common_ScanningStepAngle + 0.5);

            if (!NC_IsFinal())
                Steps /= 10;

            //            if (Settings.Default.ViewScraches != CheckState.Checked)
            if (_file == null)
                if (!Set.Default.View_ShowScratches)
                    Steps = 0;

            PointsX.Sort(new Point3DComparer(0.01, 1, Math.Cos((double)Set.Default.Common_MovingAngle / 180 * Math.PI)));

            Point3D P1, P2;
            double x, y, z;
            double BeginAngle = 0, EndAngle = 0;
            double AngleZ;
            bool bIntersect = false;
            bool bArcActive = false;

            if (_data.Points.Count == 0)
                return false;

            progress.Maximum = _data.Points.Count;
            progress.Value = 0;
            //progress.Step = 1;
            progress.UseWaitCursor = true;

            foreach (Point3D P in PointsX)
            {
                progress.PerformStep();

                bArcActive = false;

                for (int i = -Steps; i <= Steps; i++)
                //                for (double AngleZ = -(ViewingAngle / 2); AngleZ <= (ViewingAngle / 2); AngleZ += (ViewingAngle / Steps))
                {
                    if (Steps == 0)
                        AngleZ = 0;
                    else
                        AngleZ = ViewingAngle * (double)i / Steps;
                    x = Math.Sin(AngleZ / (180 / Math.PI));
                    y = -Math.Cos(AngleZ / (180 / Math.PI));
                    z = 1;

                    //JK debug
                    //if (P.X > 20 - 1 && P.X < 20 + 1 && P.Y < 1 && P.Y > -1 && P.Z > 10 - 1 && P.Z < 10 + 1 && AngleZ < 0.01 && AngleZ > -0.01)
                    //{ }

                    // Calc viewing ray
                    P1 = new Point3D(P.X + x * 0.01, P.Y + y * 0.01, P.Z + z * 0.01);
                    P2 = new Point3D(P.X + x * 500, P.Y + y * 500, P.Z + z * 500);

                    // collision of ray with any polygon?
                    bIntersect = _data.LinePolygonsIntersection(P1, P2);


                    if (!bIntersect && !bArcActive)
                    {
                        BeginAngle = AngleZ;
                        bArcActive = true;
                    }
                    else if (bIntersect && bArcActive)
                    {
                        //Draw Arc
                        Arc(P.X, P.Y, P.Z, BeginAngle, EndAngle);

                        bArcActive = false;
                    }
                    EndAngle = AngleZ;

                    //                    if (AngleZ < 0.01 && AngleZ > -0.01 && !bIntersect)
                    if (i == 0 && !bIntersect)
                    {
                        // Draw Point
                        DrawReflex(P.X, P.Y + P.Z, P.Z);
                    }
                }

                if (bArcActive)
                {
                    //Draw Arc
                    Arc(P.X, P.Y, P.Z, BeginAngle, EndAngle);

                }
            }

            progress.Value = 0;
            progress.UseWaitCursor = false;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileName"></param>
        public void ExportImage(string FileName)
        {
            //Render();
            _image.Save(FileName);
        }

    }
}
