using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace Scratchy
{
    public partial class ScratchData
    {
        public PointList Points;
        public LineList Lines;
        public PolygonList Polygons;

        /// <summary>
        /// Constructor
        /// </summary>
        public ScratchData()
        {
            Points = new PointList();
            Lines = new LineList(Points);
            Polygons = new PolygonList(Points);
        }


        public void Clear()
        {
            Points.Clear();
            Lines.Clear();
            Polygons.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nAxis"></param>
        /// <param name="dAngle"></param>
        public void Rotate(int nAxis, double dAngle)
        {
            //Matrix3D m = new Matrix3D();
            Vector3D v;

            if (nAxis == 0)
                v = new Vector3D(1, 0, 0);
            else if (nAxis == 1)
                v = new Vector3D(0, 1, 0);
            else if (nAxis == 2)
                v = new Vector3D(0, 0, 1);
            else
                v = new Vector3D(0, -1, 1);   // around viewing ray

            RotateTransform3D rt = new RotateTransform3D(new AxisAngleRotation3D(v, dAngle));

            Points.ApplyMatrix(rt.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Xoffset"></param>
        /// <param name="Yoffset"></param>
        /// <param name="Zoffset"></param>
        public void Translate(double Xoffset, double Yoffset, double Zoffset)
        {
            TranslateTransform3D tt = new TranslateTransform3D(Xoffset, Yoffset, Zoffset);

            Points.ApplyMatrix(tt.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="BoxSize"></param>
        public void FitInBoundingBox(double BoxSize)
        {
            double Xmin, Xmax, Ymin, Ymax, Zmin, Zmax;

            Points.GetObjectMinMax(out Xmin, out Xmax, out Ymin, out Ymax, out Zmin, out Zmax);

            double Xsize = Xmax - Xmin;
            double Ysize = Ymax - Ymin;
            double Zsize = Zmax - Zmin;
            double Asize = Math.Max(Xsize, Ysize);
            Asize = Math.Max(Asize, Zsize);

            double scale = BoxSize / Asize;

            double Xoffset = (Xmin + (Xmax - Xmin) * 0.5) * scale;
            double Yoffset = (Ymin + (Ymax - Ymin) * 0.5) * scale;
            double Zoffset = (Zmin + (Zmax - Zmin) * 0.5) * scale;

            Matrix3D m = new Matrix3D(
                scale, 0, 0, 0,
                0, scale, 0, 0,
                0, 0, scale, 0,
                -Xoffset, -Yoffset, -Zoffset, 1);
            Points.ApplyMatrix(m);

            //Matrix3D m2 = new Matrix3D();
        }

        /// <summary>
        /// 
        /// </summary>
        public void LevelZ()
        {
            double AngleRange = 90;
            int Steps = 30;
            double LevelZ = 99999, LevelAngleX=0, LevelAngleY=0;
            double OffsetAngleX = 0, OffsetAngleY = 0;
            double Xmin, Xmax, Ymin, Ymax, Zmin, Zmax;
            Vector3D VectorX = new Vector3D(1, 0, 0);
            Vector3D VectorY = new Vector3D(0, 1, 0);
            RotateTransform3D rt;

            for (int i = 0; i < 5; i++ )
            {
                for (double AngleY=-AngleRange; AngleY<=AngleRange; AngleY+=(AngleRange/Steps))
                for (double AngleX=-AngleRange; AngleX<=AngleRange; AngleX+=(AngleRange/Steps))
                {
                    PointList L = new PointList(Points);

                    rt = new RotateTransform3D(new AxisAngleRotation3D(VectorY, AngleY + OffsetAngleY));
                    L.ApplyMatrix(rt.Value);
                    rt = new RotateTransform3D(new AxisAngleRotation3D(VectorX, AngleX+OffsetAngleX));
                    L.ApplyMatrix(rt.Value);

                    L.GetObjectMinMax(out Xmin, out Xmax, out Ymin, out Ymax, out Zmin, out Zmax);
                    double Z = Zmax - Zmin;

                    if ( Z<LevelZ)
                    {
                        LevelZ = Z;
                        LevelAngleX = AngleX + OffsetAngleX;
                        LevelAngleY = AngleY + OffsetAngleY;
                    }
                }

                OffsetAngleX = LevelAngleX;
                OffsetAngleY = LevelAngleY;
                AngleRange /= Steps;
            }

            rt = new RotateTransform3D(new AxisAngleRotation3D(VectorY, LevelAngleY));
            Points.ApplyMatrix(rt.Value);
            rt = new RotateTransform3D(new AxisAngleRotation3D(VectorX, LevelAngleX));
            Points.ApplyMatrix(rt.Value);
        }

        /// <summary>
        /// Recreates the list of lines out of the list of polygons
        /// </summary>
        public void LinesFromPolygons()
        {
            Lines.Clear();

            foreach (Polygon I in Polygons)
            {
                for (int i = 1; i < I.Count; i++)
                    Lines.AddGetIndex(I[i - 1], I[i]);

                // Add closing line
                if (I.Count > 2)
                    Lines.AddGetIndex(I[I.Count - 1], I[0]);
            }
        }
    }
}
