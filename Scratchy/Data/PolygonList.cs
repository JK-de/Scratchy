using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Scratchy
{
    public class Polygon : List<int>
    {
        //public List<int> Idxs;

        public Polygon()
        { }

        public Polygon(int A,int B, int C)
        {
            Add(A);
            Add(B);
            Add(C);
        }
       
    };

    public class PolygonList : List<Polygon>
    {
        PointList _Points = null;

        public PolygonList(PointList Points)
        {
            _Points = Points;
        }


    }
}
