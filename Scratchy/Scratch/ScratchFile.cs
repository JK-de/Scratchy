using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.Windows.Media.Media3D;

namespace Scratchy
{
    public partial class Scratch
    {
        public void Load(string Name)
        {
            StreamReader file = null;
            string AllLines;

            //             file = File.OpenText(@"c:\test\trefoil_JK.stl");
            file = File.OpenText(Name);

            if (file != null)
            {
                AllLines = file.ReadToEnd();
                file.Close();

                if (AllLines.StartsWith("Graphics3D"))
                {
                    LoadM(AllLines);
                    //_data.SetMaxSize(70);
                    //SmashLines(5);
                }
                else if (AllLines.StartsWith("solid"))
                {
                    LoadSTL(AllLines);
                }
                else if (AllLines.StartsWith("OFF"))
                {
                    LoadOFF(AllLines);
                }
                else if (AllLines.StartsWith("SSX1"))
                {
                    LoadSSX(AllLines);
                }

                //_data.Points.SetMaxSize(70);
            }

        }


        public void LoadOFF(string AllLines)
        {
            //string Line;
            //string sX, sY, sZ;
            double dX, dY, dZ;
            int nVertexes, nPolygons;
            char[] aSerarators = { ' ', '\t' };



            AllLines = AllLines.Replace("\r\n", "\n");
            string[] Lines = AllLines.Split('\n');
            if (Lines.Count() < 10)
                return;

            string[] Tags = Lines[1].Split(aSerarators, StringSplitOptions.RemoveEmptyEntries);
            nVertexes = int.Parse(Tags[0]);
            nPolygons = int.Parse(Tags[1]);

            for (int i = 0; i < nVertexes; i++)
            {
                string[] Nums = Lines[i + 3].Split(aSerarators, StringSplitOptions.RemoveEmptyEntries);

                if (double.TryParse(Nums[0], out dX) && double.TryParse(Nums[2], out dY) && double.TryParse(Nums[1], out dZ))
                {
                    // Add point
                    Point3D P = new Point3D(dX, dY, dZ);
                    //P.Scale(50);
                    _data.Points.Add(P);
                }
            }
            //foreach (string L in _data.Lines)
            //{
            //}

            for (int i = 0; i < nPolygons; i++)
            {
                Polygon py = new Polygon();

                string[] Nums = Lines[i + 3 + nVertexes].Split(aSerarators, StringSplitOptions.RemoveEmptyEntries);
                int nIdxs = int.Parse(Nums[0]);

                for (int ii = 0; ii < nIdxs; ii++)
                {
                    py.Add(int.Parse(Nums[ii + 1]));
                }
                _data.Polygons.Add(py);

            }

            _data.LinesFromPolygons();
        }




        public void LoadM(string AllLines)
        {
            string sX, sY, sZ;
            double dX, dY, dZ;
            //            string sRegExNumberG = @"([-+]?[0-9]*\.?[0-9]+)";

            AllLines = AllLines.Replace("*^", "E");

            Regex rexObject = new Regex(@"(Polygon|Line)\[\{([0-9\-\.eE\t,\s\{\}]+?)\}\]", RegexOptions.Singleline | RegexOptions.Compiled);   // something between "Polygon[{" and "}]"

            //string sRegExNumberG = @"([-+]?[0-9\.eE\-]*)";
            string sRegExNumberG = @"([-+]?[0-9\.]+([eE]\-?[0-9]+)?)";
            string sRegEx = "";
            sRegEx += @"\{";
            sRegEx += sRegExNumberG;
            sRegEx += @",\s*";
            sRegEx += sRegExNumberG;
            sRegEx += @",\s*";
            sRegEx += sRegExNumberG;
            sRegEx += @"\}";
            Regex rexVertex = new Regex(sRegEx, RegexOptions.Singleline | RegexOptions.Compiled);

            Match matchObject = rexObject.Match(AllLines);
            while (matchObject.Success)
            {
                string sFacet = matchObject.Groups[2].Value;
                int nIdx;
                Polygon py = new Polygon();

                Match matchVertex = rexVertex.Match(sFacet);
                while (matchVertex.Success)
                {
                    sX = matchVertex.Groups[1].Value;
                    sY = matchVertex.Groups[3].Value;
                    sZ = matchVertex.Groups[5].Value;

                    if (double.TryParse(sX, out dX) && double.TryParse(sY, out dY) && double.TryParse(sZ, out dZ))
                    {
                        // Add point
                        Point3D P = new Point3D(dX, dY, dZ);
                        //P.Scale(50);
                        nIdx = _data.Points.AddGetIndex(P);
                        py.Add(nIdx);
                    }
                    else
                    {

                    }

                    matchVertex = matchVertex.NextMatch();
                }


                _data.Polygons.Add(py);

                matchObject = matchObject.NextMatch();
            }

            _data.LinesFromPolygons();
        }





        public void LoadSTL(string AllLines)
        {
            string sX, sY, sZ;
            double dX, dY, dZ;

            AllLines = AllLines.Replace("*^", "E");

            Regex rexFacet = new Regex(@"facet([A-Za-z0-9\-\.\r\n\t, ]+?)endfacet", RegexOptions.Multiline | RegexOptions.Compiled);

            string sRegExNumberG = @"([-+]?[0-9\.eE]+)";
            string sRegEx = "";
            sRegEx += @"vertex ";
            sRegEx += sRegExNumberG;
            sRegEx += @"\s*";
            sRegEx += sRegExNumberG;
            sRegEx += @"\s*";
            sRegEx += sRegExNumberG;
            sRegEx += @"";
            Regex rexVertex = new Regex(sRegEx, RegexOptions.Multiline | RegexOptions.Compiled);

            Match matchFacet = rexFacet.Match(AllLines);
            while (matchFacet.Success)
            {
                string sFacet = matchFacet.Groups[1].Value;
                int nIdx;
                Polygon py = new Polygon();

                Match matchVertex = rexVertex.Match(sFacet);
                while (matchVertex.Success)
                {
                    sX = matchVertex.Groups[1].Value;
                    sY = matchVertex.Groups[2].Value;
                    sZ = matchVertex.Groups[3].Value;

                    if (double.TryParse(sX, out dX) && double.TryParse(sY, out dY) && double.TryParse(sZ, out dZ))
                    {
                        // Add point
                        Point3D P = new Point3D(dX, dY, dZ);
                        //P.Scale(50);
                        nIdx = _data.Points.AddGetIndex(P);
                        py.Add(nIdx);
                    }

                    matchVertex = matchVertex.NextMatch();
                }

                _data.Polygons.Add(py);

                matchFacet = matchFacet.NextMatch();
            }



        }


        public void LoadSSX(string AllFile)
        {
            string sX, sY, sZ;
            double dActX = 0, dActY = 0, dActZ = 0, dActN = 1;
            double dLastX = 0, dLastY = 0, dLastZ = 0;

            int nVertexes, nLines, nPolygons;

            Point3D ActP = new Point3D(dActX, dActY, dActZ);
            Point3D LastP = new Point3D(dActX, dActY, dActZ);

            AllFile = AllFile.Replace("*^", "E");

            string sRegExValue = @"([-+]?[0-9\.eE]+)";
            string sRegExValueXYZ = @"([xXyYzZbBeErR]?\s*" + sRegExValue + @"\s*)";
            string sRegEx = @"(;.*$)|([MLSRPFC])\s*(" + sRegExValueXYZ + @"+)";

            Regex rexCommand = new Regex(sRegEx, RegexOptions.Multiline | RegexOptions.Compiled);

            AllFile = AllFile.Replace("\r\n", "\n");
            string[] AllLines = AllFile.Split('\n');

            foreach (string Line in AllLines)
            {
                Match matchCommand = rexCommand.Match(Line);
                if (matchCommand.Success)
                {
                    if (matchCommand.Groups[1].Value.StartsWith(";"))
                        continue;

                    string sCommand = matchCommand.Groups[2].Value.ToUpper();
                    string sValues = matchCommand.Groups[3].Value.ToUpper();

                    int nPoint;
                    List<int> lIdx = new List<int>();


                    if (sCommand == "M")
                    {
                        LoadSSXValues(sValues, ref dActX, ref dActY, ref dActZ, ref dActN);

                        ActP = new Point3D(dActX, dActY, dActZ);
                    }
                    if (sCommand == "L")
                    {
                        LoadSSXValues(sValues, ref dActX, ref dActY, ref dActZ, ref dActN);

                        // Add point
                        ActP = new Point3D(dActX, dActY, dActZ);
                        _data.Lines.AddGetIndex(LastP, ActP);
                        //P.Scale(50);
                    }
                    if (sCommand == "R")
                    {
                        double dAngleX = 0, dAngleY = 0, dAngleZ = 0;
                        LoadSSXValues(sValues, ref dAngleX, ref dAngleY, ref dAngleZ, ref dActN);

                        if (dAngleX != 0)
                            _data.Rotate(0, dAngleX);
                        if (dAngleY != 0)
                            _data.Rotate(1, dAngleY);
                        if (dAngleZ != 0)
                            _data.Rotate(2, dAngleZ);

                        //JK          I.Rotate(2, -dAngleZ);

                    }
                    if (sCommand == "F")
                    {
                        double dDummy = 0, dDist = 5;
                        LoadSSXValues(sValues, ref dDummy, ref dDummy, ref dDummy, ref dDist);

                        _data.SmashLines(dDist);
                    }
                    if (sCommand == "S")
                    {
                        double dDummy = 0, dFactor = 1;
                        LoadSSXValues(sValues, ref dDummy, ref dDummy, ref dDummy, ref dFactor);

                        _data.SetMaxSize(dFactor);
                    }
                    if (sCommand == "C")
                    {
                        double dRadiusX = 0, dRadiusY = 0, dRadiusZ = 0, dPoints = 24;
                        LoadSSXValues(sValues, ref dRadiusX, ref dRadiusY, ref dRadiusZ, ref dPoints);

                        double x;
                        double y;
                        double z;

                        for (int i = 0; i < (int)(dPoints + 0.5); i++)
                        {
                            double dAngle = (i * 2 * Math.PI) / dPoints;

                            x = y = z = 0;

                            if (dRadiusX != 0)
                            {
                                z += dRadiusX * Math.Cos(dAngle);
                                y += dRadiusX * Math.Sin(dAngle);
                            }
                            if (dRadiusY != 0)
                            {
                                z += dRadiusY * Math.Cos(dAngle);
                                x += dRadiusY * Math.Sin(dAngle);
                            }
                            if (dRadiusZ != 0)
                            {
                                y += dRadiusZ * Math.Cos(dAngle);
                                y += dRadiusZ * Math.Sin(dAngle);
                            }

                            Point3D P = new Point3D(dActX + x, dActY + y, dActZ + z);
                            _data.Points.AddGetIndex(P);
                        }

                    }


                    LastP = ActP;
                    dLastX = dActX;
                    dLastY = dActY;
                    dLastZ = dActZ;

                    //matchCommand = matchCommand.NextMatch();
                }
            }

        }

        public void LoadSSXValues(string AllValues, ref double X, ref double Y, ref double Z, ref double N)
        {
            //X = X;
            //Y = Y;
            //Z = Z;
            //N = N;

            double dV = 0;

            string sRegExValue = @"([-+]?[0-9\.eE]+)";
            string sRegExValueXYZ = @"([xyzXYZ]?)\s*" + sRegExValue + @"";

            string sRegEx = @"\s*" + sRegExValueXYZ + @"";
            Regex rexValue = new Regex(sRegEx, RegexOptions.Singleline | RegexOptions.Compiled);

            Match matchValue = rexValue.Match(AllValues);
            while (matchValue.Success)
            {
                string sAxis = matchValue.Groups[1].Value;
                string sValue = matchValue.Groups[2].Value;

                if (sAxis.StartsWith(";"))
                {
                    break;
                }
                else if (sAxis == "X" | sAxis == "x")
                {
                    double.TryParse(sValue, out X);
                }
                else if (sAxis == "Y" | sAxis == "y")
                {
                    double.TryParse(sValue, out Y);
                }
                else if (sAxis == "Z" | sAxis == "z")
                {
                    double.TryParse(sValue, out Z);
                }
                else
                {
                    double.TryParse(sValue, out N);
                }

                matchValue = matchValue.NextMatch();
            }
        }

    }
}
