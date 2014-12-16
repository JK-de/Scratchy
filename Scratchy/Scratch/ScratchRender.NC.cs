using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using Set = Scratchy.Properties.Settings;

namespace Scratchy
{
    public partial class ScratchRender
    {
        StreamWriter _file = null;
        double xAct = -9999;
        double yAct = -9999;
        bool bUp = false;

        void NC_Init()
        {
            xAct = -9999;
            yAct = -9999;
            bUp = false;
            NC_MoveUp();
        }

        void NC_Exit()
        {
            NC_MoveUp();
        }

        bool NC_IsFinal()
        {
            return (_file != null);
        }

        /// <summary>
        /// 
        /// </summary>
        void NC_MoveUp()
        {
            if (_file == null)
                return;

            if (bUp)
                return;

            double z = (double)Set.Default.NC_TravelHeight;

            _file.WriteLine("G0 Z{0:0.####}", z);

            bUp = true;
        }

        /// <summary>
        /// 
        /// </summary>
        void NC_MoveDown(double r)
        {
            if (_file == null)
                return;

            if (!bUp)
                return;

            if (r < 0)
                r = -r;

            double z0 = (double)Set.Default.NC_ScratchingDepthZero;
            double z1 = (double)Set.Default.NC_ScratchingDepthMax;
            double z;

            if (Set.Default.NC_CompensateRadius && (double)Set.Default.NC_ScratchingDepthAtHeight > 0)
            {
                if (r > (double)Set.Default.NC_ScratchingDepthAtHeight)
                    r = (double)Set.Default.NC_ScratchingDepthAtHeight;
                r /= (double)Set.Default.NC_ScratchingDepthAtHeight;

                z = z0 + (z1 - z0) * r;
            }
            else
            {
                z = z0;
            }

            if (Set.Default.NC_ForceG1onNegZ)
            {
                _file.WriteLine("G0 Z0.1");
                _file.WriteLine("G1 Z{0:0.####}", z);
            }
            else
            {
                _file.WriteLine("G0 Z{0:0.####}", z);
            }

            bUp = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void NC_MoveTo(double x, double y)
        {
            if (_file == null)
                return;

            if (x == xAct && y == yAct)
                return;

            NC_MoveUp();

            _file.WriteLine("G0 X{0:0.####} Y{1:0.####}", x, y);

            xAct = x; yAct = y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void NC_LineTo(double x, double y)
        {
            if (_file == null)
                return;

            if (x == xAct && y == yAct)
                return;

            NC_MoveDown(0);

            _file.WriteLine("G1 X{0:0.####} Y{1:0.####}", x, y);

            xAct = x; yAct = y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="r"></param>
        /// <param name="bClockwise"></param>
        void NC_Arc(double x1, double y1, double x2, double y2, double r, bool bClockwise)
        {
            if (_file == null)
                return;

            if (Math.Abs(x1 - x2) < 0.001 && Math.Abs(y1 - y2) < 0.001)
                return;

            if (NC_GetDistanceToAct(x1, y1) > NC_GetDistanceToAct(x2, y2))
            {
                Swap(ref x1, ref x2);
                Swap(ref y1, ref y2);
                bClockwise = !bClockwise;
            }

            NC_MoveTo(x1, y1);

            NC_MoveDown(r);

            //JK
            if (false)
                _file.WriteLine("G1 X{0:0.####} Y{1:0.####}", x1, y1);

            _file.WriteLine("G{3} X{0:0.####} Y{1:0.####} R{2:0.####}", x2, y2, r, bClockwise ? 2 : 3);

            xAct = x2; yAct = y2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        double NC_GetDistanceToAct(double x, double y)
        {
            double X = xAct - x;
            double Y = yAct - y;

            return Math.Sqrt(X * X + Y * Y);
        }

        void Swap(ref double a, ref double b)
        {
            double t;

            t = a;
            a = b;
            b = t;
        }

    }
}