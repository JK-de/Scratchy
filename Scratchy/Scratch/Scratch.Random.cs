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
    public partial class Scratch
    {
        Random _rnd = new Random();

        public double Random01()
        {
            return _rnd.NextDouble();
        }

        public double Random101()
        {
            return (_rnd.NextDouble() * 2.0 - 1.0);
        }

        public double RandomG()
        {
            double v;
            v = _rnd.NextDouble();
            //            v = (1 - 0 - cos(v * 2.0 * Pi())) / 2.0;
            v = v * 2.0 - 1.0;
            if (v >= 0)
                v = v * v;
            else
                v = -v * v;

            return v;
        }

    }
}