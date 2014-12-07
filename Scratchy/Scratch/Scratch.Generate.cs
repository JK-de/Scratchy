using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Media.Media3D;

namespace Scratchy
{
    public partial class Scratch
    {
        public void GenerateXmasTreeRandom()
        {
            double h, a, r, x, y, z, d;
            Point3D P;
            int nCandles = 1;
            int xxx = 0;

            x = 0;
            y = 0;
            z = 0.75;
            P = new Point3D(x, y, z);
            //JK P.Scale(80.0);
            _data.Points.Add(P);

            for (int i = 0; i < 10000; i++)
            {
                h = Random01();
                h = h * h;
                r = (1.0 - h) * 0.5;
                r += RandomG() * (r + 0.5) * 0.05;   // Jitter radius by 5%
                r *= 0.7;
                a = Random01() * 2 * Math.PI;
                x = Math.Sin(a) * r;
                y = Math.Cos(a) * r;
                z = h;

                //// Jitter
                //x += RandomG()*(r+0.5)*0.03;
                //y += RandomG()*(r+0.5)*0.03;

                if (z > 0.5) xxx++;

                z -= 0.25;
                P = new Point3D(x, y, z);
                //JK P.Scale(80.0);

                d = _data.Points.GetNearestDistance(P);

                if (d > 0.05 * 80.0)
                {
                    _data.Points.Add(P);

                    nCandles++;
                }

                if (nCandles > 200)
                    break;
            }

        }
    }
}