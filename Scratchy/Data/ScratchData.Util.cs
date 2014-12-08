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
    public partial class ScratchData
    {
        //public double GetDistance(Point3D P1, Point3D P2)
        //{
        //    double x = P1.X - P2.X;
        //    double y = P1.Y - P2.Y;
        //    double z = P1.Z - P2.Z;
        //    return Math.Sqrt(x * x + y * y + z * z);
        //}

        public void Fit(double dSize)
        {
            FitInBoundingBox(dSize);
        }

        public static Point3D LERP(double dFrac, Point3D P1, Point3D P2)
        {
            Point3D P = new Point3D();

            P.X = P1.X + dFrac * (P2.X - P1.X);
            P.Y = P1.Y + dFrac * (P2.Y - P1.Y);
            P.Z = P1.Z + dFrac * (P2.Z - P1.Z);

            return P;
        }

        public void SmashLine(Line L, int nParts)
        {
            Point3D P1 = Points[L.Idx1];
            Point3D P2 = Points[L.Idx2];

            for (int i = 1; i < (nParts); i++)
            {
                Point3D P = LERP((double)i / (double)nParts, P1, P2);
                Points.AddGetIndex(P);
            }

        }

        public void SmashLine(Line L, double dDist)
        {
            int nParts;
            Point3D P1 = Points[L.Idx1];
            Point3D P2 = Points[L.Idx2];

            double dLength = GetDistance(P1, P2);

            // if (dLength > 11)
            //     return; //JKJKJK

            nParts = (int)(dLength / dDist + 0.5);
            if (nParts < 2)
                return;

            SmashLine(L, nParts);
        }

        public void SmashLines(double dDist)
        {
            foreach (Line L in Lines)
            {
                SmashLine(L, dDist);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="P1"></param>
        /// <param name="P2"></param>
        /// <returns></returns>
        public static double GetDistance(Point3D P1, Point3D P2)
        {
            double x = P2.X - P1.X;
            double y = P2.Y - P1.Y;
            double z = P2.Z - P1.Z;
            return Math.Sqrt(x * x + y * y + z * z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public Vector3D GetFaceNormal(Polygon polygon)
        {
            if (polygon.Count < 3)
                return new Vector3D(0, 0, 0);

            Point3D[] P = new Point3D[3];

            P[0] = Points[polygon[0]];
            P[1] = Points[polygon[1]];
            P[2] = Points[polygon.Last()];

            return GetFaceNormal(P);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="P"></param>
        /// <returns></returns>
        public static Vector3D GetFaceNormal(Point3D[] P)
        {
            Vector3D normal = new Vector3D();
            Vector3D v1 = new Vector3D();			// Vector 1 (x,y,z) & Vector 2 (x,y,z)
            Vector3D v2 = new Vector3D();			// Vector 1 (x,y,z) & Vector 2 (x,y,z)

            // Finds The Vector Between 2 Points By Subtracting
            // The x,y,z Coordinates From One Point To Another.

            // Calculate The Vector From Point 1 To Point 0
            v1.X = P[0].X - P[1].X;					// Vector 1.x=Vertex[0].x-Vertex[1].x
            v1.Y = P[0].Y - P[1].Y;					// Vector 1.y=Vertex[0].y-Vertex[1].y
            v1.Z = P[0].Z - P[1].Z;					// Vector 1.z=Vertex[0].y-Vertex[1].z
            // Calculate The Vector From Point 2 To Point 1
            v2.X = P[1].X - P[2].X;					// Vector 2.x=Vertex[0].x-Vertex[1].x
            v2.Y = P[1].Y - P[2].Y;					// Vector 2.y=Vertex[0].y-Vertex[1].y
            v2.Z = P[1].Z - P[2].Z;					// Vector 2.z=Vertex[0].z-Vertex[1].z
            // Compute The Cross Product To Give Us A Surface Normal
            normal.X = v1.Y * v2.Z - v1.Z * v2.Y;	// Cross Product For Y - Z
            normal.Y = v1.Z * v2.X - v1.X * v2.Z;	// Cross Product For X - Z
            normal.Z = v1.X * v2.Y - v1.Y * v2.X;	// Cross Product For X - Y

            Normalise(ref normal);					// Normalize The Vectors

            return normal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        public static void Normalise(ref Vector3D vector)           // Reduces A Normal Vector (3 Coordinates)
        {                                            // To A Unit Normal Vector With A Length Of One.
            double length;                           // Holds Unit Length
            // Calculates The Length Of The Vector
            length = Math.Sqrt((vector.X * vector.X) + (vector.Y * vector.Y) + (vector.Z * vector.Z));

            if (length == 0.0)                      // Prevents Divide By 0 Error By Providing
                return;                       // An Acceptable Value For Vectors To Close To 0.

            vector.X /= length;                      // Dividing Each Element By
            vector.Y /= length;                      // The Length Results In A
            vector.Z /= length;                      // Unit Normal Vector.
        }



        /*
   Determine whether or not the line segment p1,p2
   Intersects the 3 vertex facet bounded by pa,pb,pc
   Return true/false and the intersection point p

   The equation of the line is p = p1 + mu (p2 - p1)
   The equation of the plane is a x + b y + c z + d = 0
                                n.x x + n.y y + n.z z + d = 0
*/

        /// <summary>
        /// Checks if the line intersects with a triangle
        /// </summary>
        /// <param name="P1">Point 1 of the line</param>
        /// <param name="P2">Point 2 of the line</param>
        /// <param name="PA">Point A of the triangle</param>
        /// <param name="PB">Point B of the triangle</param>
        /// <param name="PC">Point C of the triangle</param>
        /// <param name="Pi">Point of intersection</param>
        /// <returns>true if line intersects with the triangle</returns>
        public static bool LineTriangleIntersection(Point3D P1, Point3D P2, Point3D PA, Point3D PB, Point3D PC, ref Point3D Pi)
        {
            double EPS = 0.000000001;
            double D;
            double A1, A2, A3;
            double TOTAL, DENOM, MU;
            Vector3D N = new Vector3D(), PA1 = new Vector3D(), PA2 = new Vector3D(), PA3 = new Vector3D();

            /* Calculate the parameters for the plane */
            N.X = (PB.Y - PA.Y) * (PC.Z - PA.Z) - (PB.Z - PA.Z) * (PC.Y - PA.Y);
            N.Y = (PB.Z - PA.Z) * (PC.X - PA.X) - (PB.X - PA.X) * (PC.Z - PA.Z);
            N.Z = (PB.X - PA.X) * (PC.Y - PA.Y) - (PB.Y - PA.Y) * (PC.X - PA.X);
            Normalise(ref N);
            D = -N.X * PA.X - N.Y * PA.Y - N.Z * PA.Z;

            /* Calculate the position on the line that intersects the plane */
            DENOM = N.X * (P2.X - P1.X) + N.Y * (P2.Y - P1.Y) + N.Z * (P2.Z - P1.Z);
            if (Math.Abs(DENOM) < EPS)         /* Line and plane don't intersect */
                return false;

            MU = -(D + N.X * P1.X + N.Y * P1.Y + N.Z * P1.Z) / DENOM;
            Pi.X = P1.X + MU * (P2.X - P1.X);
            Pi.Y = P1.Y + MU * (P2.Y - P1.Y);
            Pi.Z = P1.Z + MU * (P2.Z - P1.Z);
            if (MU < 0 || MU > 1)   /* Intersection not along line segment */
                return false;

            /* Determine whether or not the intersection point is bounded by pa,pb,pc */
            PA1.X = PA.X - Pi.X;
            PA1.Y = PA.Y - Pi.Y;
            PA1.Z = PA.Z - Pi.Z;
            Normalise(ref PA1);
            PA2.X = PB.X - Pi.X;
            PA2.Y = PB.Y - Pi.Y;
            PA2.Z = PB.Z - Pi.Z;
            Normalise(ref PA2);
            PA3.X = PC.X - Pi.X;
            PA3.Y = PC.Y - Pi.Y;
            PA3.Z = PC.Z - Pi.Z;
            Normalise(ref PA3);
            A1 = PA1.X * PA2.X + PA1.Y * PA2.Y + PA1.Z * PA2.Z;
            if (A1 > 1) A1 = 1;
            A2 = PA2.X * PA3.X + PA2.Y * PA3.Y + PA2.Z * PA3.Z;
            if (A2 > 1) A2 = 1;
            A3 = PA3.X * PA1.X + PA3.Y * PA1.Y + PA3.Z * PA1.Z;
            if (A3 > 1) A3 = 1;
            TOTAL = (Math.Acos(A1) + Math.Acos(A2) + Math.Acos(A3)) * (180 / Math.PI);
//            if (TOTAL < (360-0.00001))
//                if (Math.Abs(TOTAL - 360) > EPS)
                    if ((360-TOTAL) > EPS)
                        return false;

            return true;
        }

        /// <summary>
        /// Checks if the line intersects with a poligon
        /// </summary>
        /// <param name="P1">Point 1 of the line</param>
        /// <param name="P2">Point 2 of the line</param>
        /// <param name="Y">Polygon</param>
        /// <param name="Pi">Point of intersection</param>
        /// <returns>true if line intersects with the polygon</returns>
        public bool LinePolygonIntersection(Point3D P1, Point3D P2, Polygon Y, ref Point3D Pi)
        {
            int n = Y.Count;
            bool bIntersect = false;
            Point3D PA, PB, PC;

            if (n < 3)
                return false;

            PA = Points[Y[0]];

            for (int i = 1; i < (n - 1); i++)
            {
                PB = Points[Y[i]];
                PC = Points[Y[i + 1]];

                if (LineTriangleIntersection(P1, P2, PA, PB, PC, ref  Pi))
                {
                    bIntersect = !bIntersect;
                }
            }

            return bIntersect;
        }

        /// <summary>
        /// Checks if the line intersects with a any poligon of list of polygons
        /// </summary>
        /// <param name="P1">Point 1 of the line</param>
        /// <param name="P2">Point 2 of the line</param>
        /// <returns>true if line intersects with the any poligon</returns>
        public bool LinePolygonsIntersection(Point3D P1, Point3D P2)
        {
            Point3D Pi = new Point3D();

            foreach (Polygon Y in Polygons)
            {
                if (LinePolygonIntersection(P1, P2, Y, ref  Pi))
                    return true;
            }

            return false;
        }


        /// <summary>
        /// Searches polygons (or triangles) with common lines and joins them. The first polygon grows by the points of secong polygon. The second polygon is removed 
        /// </summary>
        public void JoinPolygons()
        {
            int nPols = Polygons.Count;
            double EPS = 0.001;

            for (int a = 0; a < nPols; a++)
                for (int b = 0; b < nPols; b++)
                    if (a != b)
                    {
                        Vector3D vA, vB;
                        Polygon pA, pB;
                        int nPointsA, nPointsB;

                        pA = Polygons[a];
                        pB = Polygons[b];
                        nPointsA = pA.Count;
                        nPointsB = pB.Count;
                        if (nPointsA < 3 || nPointsB < 3)
                            continue;
                        vA = GetFaceNormal(pA);
                        vB = GetFaceNormal(pB);

                        if (Math.Abs(vA.X - vB.X) < EPS && Math.Abs(vA.Y - vB.Y) < EPS && Math.Abs(vA.Z - vB.Z) < EPS)
                        {
                            for (int aa1 = 0; aa1 < nPointsA; aa1++)
                                for (int bb1 = 0; bb1 < nPointsB; bb1++)
                                {
                                    int aa2 = aa1 + 1; if (aa2 >= nPointsA) aa2 = 0;
                                    int bb2 = bb1 + 1; if (bb2 >= nPointsB) bb2 = 0;

                                    if (pA[aa1] == pB[bb2] && pA[aa2] == pB[bb1])   // same point pairs in both polygons?
                                    {
                                        int bb3w = bb2 + 1;
                                        for (int i = 0; i < (nPointsB - 2); i++)
                                        {
                                            if (bb3w >= nPointsB) bb3w -= nPointsB;   // wrap
                                            pA.Insert(aa2, pB[bb3w]);
                                            bb3w++;
                                        }
                                        pB.Clear();
                                        nPointsA = 0;   // hack to continue over 2 for loops
                                        nPointsB = 0;
                                        goto FinishJoining;
                                    }
                                }
                        }
                    FinishJoining:
                        nPointsB = 0;
                    }

            // remove empty polygons
            for (int a = nPols - 1; a >= 0; a--)
            {
                if (Polygons[a].Count == 0)
                    Polygons.RemoveAt(a);
            }

        }

        /*
   Return whether a polygon in 2D is concave or convex
   return 0 for incomputables eg: colinear points
          CONVEX == 1
          CONCAVE == -1
   It is assumed that the polygon is simple
   (does not intersect itself or have holes)
*/
        /*
        int IsConvex(XY* p, int n)
        {
            int i, j, k;
            int flag = 0;
            double z;

            if (n < 3)
                return (0);

            for (i = 0; i < n; i++)
            {
                j = (i + 1) % n;
                k = (i + 2) % n;
                z = (p[j].x - p[i].x) * (p[k].y - p[j].y);
                z -= (p[j].y - p[i].y) * (p[k].x - p[j].x);
                if (z < 0)
                    flag |= 1;
                else if (z > 0)
                    flag |= 2;
                if (flag == 3)
                    return (CONCAVE);
            }
            if (flag != 0)
                return (CONVEX);
            else
                return (0);
        }*/


    }
}