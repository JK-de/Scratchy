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
            ScratchArcs.Clear();

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

            Optimize();

            foreach (ScratchArc A in ScratchArcs)
            {
                NC_ArcDirect(A.ArcType, A.X1, A.Y1, A.X2, A.Y2, A.R);
            }

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
            PointsX.Sort(new Point3DComparer(0.01, 1, Math.Cos((double)Set.Default.Common_MovingAngle / 180 * Math.PI)));

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

        public class ScratchArc
        {
            public int ArcType;
            public double X1;
            public double Y1;
            public double X2;
            public double Y2;
            public double R;
            public int SortIndex;
            public bool Reverse;
            public int OptimizeSortIndex;
            public bool OptimizeReverse;

            public ScratchArc()
            {
                SortIndex = -1;
                OptimizeSortIndex = -1;
                Reverse = false;
                OptimizeReverse = false;
            }

            public ScratchArc(int nArcType, double dX1, double dY1, double dX2, double dY2, double dR)
                : this()
            {
                ArcType = nArcType;
                X1 = dX1;
                Y1 = dY1;
                X2 = dX2;
                Y2 = dY2;
                R = dR;
            }

            public double GetDist1(double dX, double dY)
            {
                double x = dX - X1;
                double y = dY - Y1;
                return Math.Sqrt(x * x + y * y);
            }
            public double GetDist2(double dX, double dY)
            {
                double x = dX - X2;
                double y = dY - Y2;
                return Math.Sqrt(x * x + y * y);
            }
            //public double GetNearest(double dX, double dY)
        }

        List<ScratchArc> ScratchArcs = new List<ScratchArc>();
        double dDistMin = 999999999;

        public List<int> GetNearestScratchArcs(double dX, double dY)
        {
            Dictionary<int, double> Dic = new Dictionary<int, double>();
            List<int> L = new List<int>();

            for (int i = 0; i < ScratchArcs.Count; i++)
                if (ScratchArcs[i].SortIndex < 0)
                {
                    double d = Math.Min(ScratchArcs[i].GetDist1(dX, dY), ScratchArcs[i].GetDist2(dX, dY));
                    Dic.Add(i, d);
                }

            double dNearest = -1;
            var query = Dic.OrderBy(e => e.Value);
            foreach (var I in query)
            {
                if (dNearest < 0)
                    dNearest = I.Value;
                else
                    if (I.Value > (dNearest + 25))
                        break;
                //if ( L.Find(I.Key)<0)
                //if (!L.Exists(i => i == I.Key))
                L.Add(I.Key);
                if (L.Count >= 3 || dNearest==0)
                    break;
            }

            return L;
        }

        public class ScratchArcComparer : IComparer<ScratchArc>
        {
            public int Compare(ScratchArc a, ScratchArc b)
            {
                if (a.OptimizeSortIndex > b.OptimizeSortIndex)
                    return 1;
                else if (a.OptimizeSortIndex < b.OptimizeSortIndex)
                    return -1;
                else
                    return 0;
            }
        }

        public void Optimize()
        {
            if (ScratchArcs.Count == 0)
                return;

            progress.Maximum = 3 * 3 * 3;
            progress.Value = 0;
            progress.UseWaitCursor = true;



            dDistMin = 999999999;
            OptimizeRecursive(0, 0, 0, 0);

            ScratchArcComparer sac = new ScratchArcComparer();

            ScratchArcs.Sort(sac);

            foreach (ScratchArc A in ScratchArcs)
            {
                if (A.OptimizeReverse)
                {
                    A.OptimizeReverse = !A.OptimizeReverse;
                    Swap(ref A.X1, ref A.X2);
                    Swap(ref A.Y1, ref A.Y2);
                    if (A.ArcType == 2)
                        A.ArcType = 3;
                    else if (A.ArcType == 3)
                        A.ArcType = 2;
                }
                A.Reverse = A.OptimizeReverse;
                A.SortIndex = A.OptimizeSortIndex;
            }

            progress.Value = 0;
            progress.UseWaitCursor = false;
        }

        void OptimizeRecursive(int nRec, double dActX, double dActY, double dDistSum)
        {
            if (dDistSum >= dDistMin)
                return;

            if (nRec >= ScratchArcs.Count)
            {
                if (true)
                {
                    for (int i = 0; i < ScratchArcs.Count; i++)
                    {
                        ScratchArcs[i].OptimizeReverse = ScratchArcs[i].Reverse;
                        ScratchArcs[i].OptimizeSortIndex = ScratchArcs[i].SortIndex;
                    }
                    dDistMin = dDistSum;
                }
                return;
            }

            List<int> L = GetNearestScratchArcs(dActX, dActY);

            foreach (int i in L)
            {
                //}
                //for (int i = 0; i < ScratchArcs.Count; i++)
                //    if (ScratchArcs[i].SortIndex < 0)
                //    {
                double d;

                if (nRec == 2)
                {
                    //Progress bar
                    progress.PerformStep();
                }

                d = ScratchArcs[i].GetDist1(dActX, dActY);
                if (d < 500)
                {
                    ScratchArcs[i].Reverse = false;
                    ScratchArcs[i].SortIndex = nRec;
                    OptimizeRecursive(nRec + 1, ScratchArcs[i].X2, ScratchArcs[i].Y2, dDistSum + d);
                    ScratchArcs[i].SortIndex = -1;
                }

                d = ScratchArcs[i].GetDist2(dActX, dActY);
                if (d < 500)
                {
                    ScratchArcs[i].Reverse = true;
                    ScratchArcs[i].SortIndex = nRec;
                    OptimizeRecursive(nRec + 1, ScratchArcs[i].X1, ScratchArcs[i].Y1, dDistSum + d);
                    ScratchArcs[i].SortIndex = -1;
                }

            }
        }
    }
}
