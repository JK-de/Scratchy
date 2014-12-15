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
                _file.WriteLine(Set.Default.NC_Prolog);
            }

            RenderInit();

            RenderTableArcHidden();
            //RenderTableArc();
            //            RenderTableCircle();

            RenderExit();

            if (_file != null)
            {
                _file.WriteLine(Set.Default.NC_Epilog);
                _file.Close();
            }

            _file = null;
        }

        /// <summary>
        /// 
        /// </summary>
        void RenderInit()
        {

            NC_MoveUp();

            G = Graphics.FromImage(_image);


            G.PageUnit = GraphicsUnit.Pixel;
            G.FillRectangle(Brushes.White, 0, 0, _image.Size.Width, _image.Size.Height);

            G.PageUnit = GraphicsUnit.Millimeter;
            G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            float fRangeX = (float)Set.Default.Common_WorkingAreaX / 2;
            float fRangeY = (float)Set.Default.Common_WorkingAreaY / 2;
            float fRangeM = Math.Max(fRangeX, fRangeY);

            //G.ScaleTransform((float)(1024 / (range * 2.0)), (float)(1024 / (range * -2.0)));
            //G.TranslateTransform(512, 512, MatrixOrder.Append);
            
            G.ScaleTransform(1.0f, -1.0f);//  * 0.7f

            //G.RotateTransform(30, MatrixOrder.Append);
            G.TranslateTransform(fRangeX, fRangeY, MatrixOrder.Append);

            Color colorScratch = Color.FromArgb(12, 0, 0, 0);
            penScratch = new Pen(colorScratch, 0.3f);
            Color colorReflexR = Color.FromArgb(64, 255, 0, 0);
            brushReflexR = new SolidBrush(colorReflexR);
            Color colorReflexC = Color.FromArgb(96, 0, 255, 255);
            brushReflexC = new SolidBrush(colorReflexC);
            
            
            if ( Set.Default.View_ShowGrid )
            {
                Color c = Color.FromArgb(48, 128, 255, 0);
                Pen pen = new Pen(c, 0.1f);

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
            NC_MoveUp();

            G.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        void RenderTableArc()
        {
            PointList L = new PointList(_data.Points);

            //L.Sort(new Point3DComparer());

            foreach (Point3D P in L)
            {
                Arc(P.X, P.Y, P.Z);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        void RenderTableCircle()
        {
            foreach (Point3D P in _data.Points)
            {
                if (P.Z >= 0)
                    Circle(P.X, P.Y, P.Z);
            }
        }






        /// <summary>
        /// Render image and NC for table-type-scratch with hidden-point-calculation
        /// </summary>
        /// <returns></returns>
        public bool RenderTableArcHidden()
        {
            double ViewingAngle = 80;
            int Steps = (int)(ViewingAngle / 10 + 0.5);

//            if (Settings.Default.ViewScraches != CheckState.Checked)
                if (!Set.Default.View_ShowScratches)
                    Steps = 0;

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

            foreach (Point3D P in _data.Points)
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
                    if (P.X > 20 - 1 && P.X < 20 + 1 && P.Y < 1 && P.Y > -1 && P.Z > 10 - 1 && P.Z < 10 + 1 && AngleZ < 0.01 && AngleZ > -0.01)
                    { }

                    // Calc viewing ray
                    P1 = new Point3D(P.X + x * 0.01, P.Y + y * 0.01, P.Z + z * 0.01);
                    P2 = new Point3D(P.X + x * 500, P.Y + y * 500, P.Z + z * 500);

                    // collition of ray with any polygon?
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
            Render();
            _image.Save(FileName);
        }

    }
}
