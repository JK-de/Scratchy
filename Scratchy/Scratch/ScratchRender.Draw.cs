using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Scratchy
{
    public partial class ScratchRender
    {
        double xAct = -9999;
        double yAct = -9999;
        bool bUp = false;
        StreamWriter _file = null;
        Bitmap _image = null;
        Graphics G = null;
        Pen penScratch;
        Brush brushReflexR, brushReflexC;
        float fDPI = 300;
        float fAxisMax = 82;

        /// <summary>
        /// 
        /// </summary>
        void MoveUp()
        {
            if (bUp)
                return;

            if (_file != null)
                _file.WriteLine("G0 Z3");

            bUp = true;
        }

        /// <summary>
        /// 
        /// </summary>
        void MoveDown()
        {
            if (!bUp)
                return;

            if (_file != null)
                _file.WriteLine("G1 Z-2");

            bUp = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void MoveTo(double x, double y)
        {
            if (x == xAct && y == yAct)
                return;

            MoveUp();

            if (_file != null)
                _file.WriteLine("G0 X{0:0.####} Y{1:0.####}", x, y);

            xAct = x; yAct = y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void LineTo(double x, double y)
        {
            if (x == xAct && y == yAct)
                return;

            if (_file != null)
            {
                //C _file.WriteLine("// Line {0}, {1} - {2}, {3}", xAct, yAct, x, y);
            }

            MoveDown();

            if (_file != null)
            {
                _file.WriteLine("G1 X{0:0.####} Y{1:0.####}", x, y);
            }

            xAct = x; yAct = y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="r"></param>
        void Circle(double x, double y, double r)
        {
            if (_file != null)
            {
                //C _file.WriteLine("// Circle {0}, {1} r={2}", x, y, r);
            }

            if (r < 0.1 && r >= 0)
                r = 0.1;

            if (r > 0)
            {
                MoveTo(x - r, y);

                MoveDown();

                if (_file != null)
                {
                    //                file.WriteLine("G2 X{0} Y{1} R{2}", x, y+r, r);
                    _file.WriteLine("G2 X{0:0.####} Y{1:0.####} R{2:0.####}", x + r, y, r);
                    //                file.WriteLine("G2 X{0} Y{1} R{2}", x, y - r, r);
                    _file.WriteLine("G2 X{0:0.####} Y{1:0.####} R{2:0.####}", x - r, y, r);
                }

                G.DrawEllipse(penScratch, (float)(x - r), (float)(y - r), (float)(2.0 * r), (float)(2.0 * r));
                DrawReflex(x, y + r, r);
                DrawReflex(x, y - r, -r);

                xAct = x - r; yAct = y;
            }
            else if (r < -0.1)
            {
                // do nothing
            }
            else
            {
                MoveTo(x - 0.1, y);

                MoveDown();

                LineTo(x + 0.1, y);

                DrawReflex(x, y, 0);


                xAct = x + 0.1; yAct = y;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="r"></param>
        void Arc(double x, double y, double r)
        {
            double ViewingAngle = 160;
            double dx, dy;

            if (_file != null)
            {
                //C _file.WriteLine("// Arc {0}, {1} r={2}", x, y, r);
            }

            if (r < 0.1 && r >= 0)
                r = 0.1;
            if (r > -0.1 && r <= 0)
                r = -0.1;

            if (r > 0)
            {
                dx = Math.Sin((ViewingAngle / 360) * Math.PI) * r;
                dy = Math.Cos((ViewingAngle / 360) * Math.PI) * r;

                MoveTo(x - dx, y + dy);

                MoveDown();

                if (_file != null)
                {
                    _file.WriteLine("G2 X{0:0.####} Y{1:0.####} R{2:0.####}", x + dx, y + dy, r);
                }

                G.DrawArc(penScratch, (float)(x - r), (float)(y - r), (float)(2.0 * r), (float)(2.0 * r), (float)(90 - ViewingAngle / 2), (float)ViewingAngle);
                DrawReflex(x, y + r, r);

                xAct = x + dx; yAct = y + dy;

            }
            else if (r < 0)
            {
                r = -r;
                dx = Math.Sin((ViewingAngle / 360) * Math.PI) * r;
                dy = Math.Cos((ViewingAngle / 360) * Math.PI) * r;

                MoveTo(x - dx, y - dy);

                MoveDown();

                if (_file != null)
                {
                    _file.WriteLine("G3 X{0:0.####} Y{1:0.####} R{2:0.####}", x + dx, y - dy, r);
                }

                //G.DrawEllipse(penScratch, (float)(x - r), (float)(y - r), (float)(2.0 * r), (float)(2.0 * r));
                G.DrawArc(penScratch, (float)(x - r), (float)(y - r), (float)(2.0 * r), (float)(2.0 * r), (float)(-90 - ViewingAngle / 2), (float)ViewingAngle);
                DrawReflex(x, y - r, -r);

                xAct = x + dx; yAct = y + dy;
            }
            else
            {
                MoveTo(x - 0.1, y);

                MoveDown();

                LineTo(x + 0.1, y);

                DrawReflex(x, y, 0);

                xAct = x + 0.1; yAct = y;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="r"></param>
        /// <param name="AngleBegin"></param>
        /// <param name="AngleEnd"></param>
        void Arc(double x, double y, double r, double AngleBegin, double AngleEnd)
        {
            double dxBegin, dyBegin;
            double dxEnd, dyEnd;

            if (AngleBegin == AngleEnd)
                return;

            if (_file != null)
            {
                //C _file.WriteLine("// Arc {0}, {1} r={2}", x, y, r);
            }

            if (r < 0.1 && r >= 0)
                r = 0.1;
            if (r > -0.1 && r <= 0)
                r = -0.1;

            if (r > 0)
            {
                dxBegin = Math.Sin((AngleBegin / 180) * Math.PI) * r;
                dyBegin = Math.Cos((AngleBegin / 180) * Math.PI) * r;
                dxEnd = Math.Sin((AngleEnd / 180) * Math.PI) * r;
                dyEnd = Math.Cos((AngleEnd / 180) * Math.PI) * r;

                MoveTo(x - dxEnd, y + dyEnd);

                MoveDown();

                if (_file != null)
                {
                    _file.WriteLine("G2 X{0:0.####} Y{1:0.####} R{2:0.####}", x - dxBegin, y + dyBegin, r);
                }

                if (r >= 25)
                { }
                G.DrawArc(penScratch, (float)(x - r), (float)(y - r), (float)(2.0 * r), (float)(2.0 * r), (float)(90 + AngleBegin), (float)(AngleEnd - AngleBegin));

                xAct = x + dxEnd; yAct = y + dyEnd;

            }
            else if (r < 0)
            {
                r = -r;
                dxBegin = Math.Sin((AngleBegin / 180) * Math.PI) * r;
                dyBegin = Math.Cos((AngleBegin / 180) * Math.PI) * r;
                dxEnd = Math.Sin((AngleEnd / 180) * Math.PI) * r;
                dyEnd = Math.Cos((AngleEnd / 180) * Math.PI) * r;

                MoveTo(x + dxBegin, y - dyBegin);

                MoveDown();

                if (_file != null)
                {
                    _file.WriteLine("G3 X{0:0.####} Y{1:0.####} R{2:0.####}", x + dxEnd, y - dyEnd, r);
                }

                G.DrawArc(penScratch, (float)(x - r), (float)(y - r), (float)(2.0 * r), (float)(2.0 * r), (float)(-90 + AngleBegin), (float)(AngleEnd - AngleBegin));

                xAct = x + dxEnd; yAct = y + dyEnd;
            }
            else
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="h"></param>
        void DrawReflex(double x, double y, double h)
        {
            h *= 0.02;
            G.FillEllipse(brushReflexR, (float)(x - h - 1), (float)(y - 1), (float)(2), (float)(2));
            G.FillEllipse(brushReflexC, (float)(x + h - 1), (float)(y - 1), (float)(2), (float)(2));
        }
    }
}