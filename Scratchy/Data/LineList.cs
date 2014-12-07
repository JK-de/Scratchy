using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Scratchy
{
    public class Line
    {
        public int Idx1;
        public int Idx2;
    };

    public class LineList : List<Line>
    {
        PointList _Points = null;

        public LineList(PointList Points)
        {
            _Points = Points;
        }

        public int GetIndex(Point3D P1, Point3D P2)
        {
            foreach (Line L in this)
            {
                if (P1 == _Points[L.Idx1] && P2 == _Points[L.Idx2])
                    return IndexOf(L);
                if (P1 == _Points[L.Idx2] && P2 == _Points[L.Idx1])
                    return IndexOf(L);
            }
            return -1;
        }

        public int GetIndex(int IdxP1, int IdxP2)
        {
            foreach (Line L in this)
            {
                if (IdxP1 == L.Idx1 && IdxP2 == L.Idx2)
                    return IndexOf(L);
                if (IdxP1 == L.Idx2 && IdxP2 == L.Idx1)
                    return IndexOf(L);
            }
            return -1;
        }

        public int AddGetIndex(Point3D P1, Point3D P2)
        {
            int i = GetIndex(P1, P2);
            if (i < 0)   // not found
            {
                Line L = new Line();
                L.Idx1 = _Points.AddGetIndex(P1);
                L.Idx2 = _Points.AddGetIndex(P2);
                i = this.Count();
                Add(L);
            }
            return i;
        }

        public int AddGetIndex(int IdxP1, int IdxP2)
        {
            int i = GetIndex(IdxP1, IdxP2);
            if (i < 0)   // not found
            {
                Line L = new Line();
                L.Idx1 = IdxP1;
                L.Idx2 = IdxP2;
                i = this.Count();
                Add(L);
            }
            return i;
        }
    }
}
