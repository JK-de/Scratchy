using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Scratchy
{
    //public class Point
    ////: Point3D
    //{
    //    public double X;
    //    public double Y;
    //    public double Z;

    //    public Point()
    //    {
    //    }

    //    public Point(double x, double y, double z)
    //    {
    //        X = x;
    //        Y = y;
    //        Z = z;

    //    }

    //    public void Scale(double s)
    //    {
    //        X *= s;
    //        Y *= s;
    //        Z *= s;
    //    }

    //    public void Rotate(int nAxis, double dAngle)
    //    {
    //        dAngle *= Math.PI / 180;

    //        double x = X * Math.Cos(dAngle) + Y * Math.Sin(dAngle);
    //        double y = -X * Math.Sin(dAngle) + Y * Math.Cos(dAngle);

    //        X = x;
    //        Y = y;
    //    }

    //public double GetDistance(Point P)
    //{
    //    double x = P.X - X;
    //    double y = P.Y - Y;
    //    double z = P.Z - Z;
    //    return Math.Sqrt(x * x + y * y + z * z);
    //}

    //}

    public class Point3DComparer : IComparer<Point3D>
    {
        public int Compare(Point3D P1, Point3D P2)
        {
            double V1 = P1.Y + P1.Z + P1.X * 0.01;
            double V2 = P2.Y + P2.Z + P2.X * 0.01;

            if (V1 > V2)
                return 1;
            if (V1 < V2)
                return -1;

            return 0;
        }
    }

    public class PointList : List<Point3D>
    {
//        public PointList(
//    IEnumerable<Point3D> collection
//)
//        {
//            //base(collection);
//            //((List<Point3D>)this)(collection);
//        }

        public PointList()
        {

        }

        public PointList(PointList L) : base(L)
        {
            
        }

        public Point3D[] GetArray()
        {
            Point3D[] a = new Point3D[Count];

            CopyTo(a);
            return a;
        }

        public int GetIndex(Point3D P)
        {
            foreach (Point3D I in this)
            {
                double d;

                d = P.X - I.X;
                if (d > 0.0001 || d < -0.0001)
                    continue;
                d = P.Y - I.Y;
                if (d > 0.0001 || d < -0.0001)
                    continue;
                d = P.Z - I.Z;
                if (d > 0.0001 || d < -0.0001)
                    continue;

                return IndexOf(I);
            }
            return -1;
        }

        public int AddGetIndex(Point3D P)
        {
            int i = GetIndex(P);
            if (i < 0)   // not found
            {
                i = this.Count();
                Add(P);
            }
            return i;
        }

        public double GetNearestDistance(Point3D P)
        {
            double dMin = 99999, dAct;

            foreach (Point3D I in this)
            {
                dAct = ScratchData.GetDistance(P, I);
                if (dAct < dMin)
                    dMin = dAct;
            }
            return dMin;
        }

        public void GetObjectMinMax(out double Xmin, out double Xmax, out double Ymin, out double Ymax, out double Zmin, out double Zmax)
        {
            Xmin = 99999;
            Xmax = -99999;
            Ymin = 99999;
            Ymax = -99999;
            Zmin = 99999;
            Zmax = -99999;

            foreach (Point3D I in this)
            {
                if (I.X < Xmin) Xmin = I.X;
                if (I.X > Xmax) Xmax = I.X;

                if (I.Y < Ymin) Ymin = I.Y;
                if (I.Y > Ymax) Ymax = I.Y;

                if (I.Z < Zmin) Zmin = I.Z;
                if (I.Z > Zmax) Zmax = I.Z;

            }
        }



        public void ApplyMatrix(Matrix3D m)
        {
            //foreach (Point3D I in this)
            //{
            //    m.Transform(I);
            //}
            for (int i=0; i<Count;i++)
            {
                this[i] = m.Transform(this[i]);
            }

        }

    }
}
