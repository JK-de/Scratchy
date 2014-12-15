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
        Bitmap _image = null;
        Graphics G = null;
        Pen penScratch;
        Brush brushReflexR, brushReflexC;
        float fDPI = 300;
        public float fAxisMax = 82;

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="r"></param>
        void Circle(double x, double y, double r)
        {

            if (r < 0.1 && r >= 0)
                r = 0.1;

            if (r > 0)
            {
                G.DrawEllipse(penScratch, (float)(x - r), (float)(y - r), (float)(2.0 * r), (float)(2.0 * r));
                DrawReflex(x, y + r, r);
                DrawReflex(x, y - r, -r);

                NC_Arc(x - r, y, x + r, y, r, true);
                NC_Arc(x + r, y, x - r, y, r, true);
            }
            else
            {
                // do nothing
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

            if (r < 0.1 && r >= 0)
                r = 0.1;
            if (r > -0.1 && r <= 0)
                r = -0.1;

            if (r > 0)
            {
                G.DrawArc(penScratch, (float)(x - r), (float)(y - r), (float)(2.0 * r), (float)(2.0 * r), (float)(90 - ViewingAngle / 2), (float)ViewingAngle);
                DrawReflex(x, y + r, r);

                dx = Math.Sin((ViewingAngle / 360) * Math.PI) * r;
                dy = Math.Cos((ViewingAngle / 360) * Math.PI) * r;

                NC_Arc(x - dx, y + dy, x + dx, y + dy, r, true);
            }
            else if (r < 0)
            {
                r = -r;

                G.DrawArc(penScratch, (float)(x - r), (float)(y - r), (float)(2.0 * r), (float)(2.0 * r), (float)(-90 - ViewingAngle / 2), (float)ViewingAngle);
                DrawReflex(x, y - r, -r);

                dx = Math.Sin((ViewingAngle / 360) * Math.PI) * r;
                dy = Math.Cos((ViewingAngle / 360) * Math.PI) * r;

                NC_Arc(x - dx, y - dy, x + dx, y - dy, r, false);
            }
            else
            {
            //    NC_MoveTo(x - 0.1, y);

            //    NC_MoveDown();

            //    LineTo(x + 0.1, y);

            //    DrawReflex(x, y, 0);

            //    xAct = x + 0.1; yAct = y;
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

            if (r < 0.1 && r >= 0)
                r = 0.1;
            if (r > -0.1 && r <= 0)
                r = -0.1;

            if (r > 0)
            {
                G.DrawArc(penScratch, (float)(x - r), (float)(y - r), (float)(2.0 * r), (float)(2.0 * r), (float)(90 + AngleBegin), (float)(AngleEnd - AngleBegin));

                dxBegin = Math.Sin((AngleBegin / 180) * Math.PI) * r;
                dyBegin = Math.Cos((AngleBegin / 180) * Math.PI) * r;
                dxEnd = Math.Sin((AngleEnd / 180) * Math.PI) * r;
                dyEnd = Math.Cos((AngleEnd / 180) * Math.PI) * r;

                NC_Arc(x - dxEnd, y + dyEnd,x - dxBegin, y + dyBegin, r, true);
            }
            else if (r < 0)
            {
                r = -r;
                G.DrawArc(penScratch, (float)(x - r), (float)(y - r), (float)(2.0 * r), (float)(2.0 * r), (float)(-90 + AngleBegin), (float)(AngleEnd - AngleBegin));

                dxBegin = Math.Sin((AngleBegin / 180) * Math.PI) * r;
                dyBegin = Math.Cos((AngleBegin / 180) * Math.PI) * r;
                dxEnd = Math.Sin((AngleEnd / 180) * Math.PI) * r;
                dyEnd = Math.Cos((AngleEnd / 180) * Math.PI) * r;

                NC_Arc(x + dxBegin, y - dyBegin, x + dxEnd, y - dyEnd, r, false);
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