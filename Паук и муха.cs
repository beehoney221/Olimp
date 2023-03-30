using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

namespace Pauk_Muha
{
    class Program
    {
        static void Main()
        {
            double r = 0, g = 0;
            StreamReader sr = new StreamReader("input_s1_20.txt");
            StreamReader sr2 = new StreamReader("output_s1_20.txt");
            string s = sr.ReadLine();
            string[] s1 = s.Split(' ');
            double a = Convert.ToDouble(s1[0]);
            double b = Convert.ToDouble(s1[1]);
            double c = Convert.ToDouble(s1[2]);
            s = sr.ReadLine();
            s1 = s.Split(' ');
            double sx = Convert.ToDouble(s1[0]);
            double sy = Convert.ToDouble(s1[1]);
            double sz = Convert.ToDouble(s1[2]);
            s = sr.ReadLine();
            s1 = s.Split(' ');
            double fx = Convert.ToDouble(s1[0]);
            double fy = Convert.ToDouble(s1[1]);
            double fz = Convert.ToDouble(s1[2]);

            // на одной плоскости
            if ((sx == 0 & fx == 0) | (sx == a & fx == a)) r = one_pl(sy, fy, sz, fz);
            else if ((sy == 0 & fy == 0) | (sy == b & fy == b)) r = one_pl(sx, fx, sz, fz);
            else if ((sz == 0 & fz == 0) | (sz == c & fz == c)) r = one_pl(sy, fy, sx, fx);

            // на параллельных плоскостях
            else if (Math.Abs(sx - fx) == a) r = Math.Min(Math.Min(short_put3(sy, a, fy, sz, fz), short_put3(b - sy, a, b - fy, sz, fz)), Math.Min(short_put3(sz, a, fz, sy, fy), short_put3(c - sz, a, c - fz, sy, fy)));
            else if (Math.Abs(sy - fy) == b) r = Math.Min(Math.Min(short_put3(sx, b, fx, sz, fz), short_put3(a - sx, b, a - fx, sz, fz)), Math.Min(short_put3(sz, b, fz, sx, fx), short_put3(c - sz, b, c - fz, sx, fx)));
            else if (Math.Abs(sz - fz) == c) r = Math.Min(Math.Min(short_put3(sx, c, fx, sy, fy), short_put3(a - sx, c, a - fx, sy, fy)), Math.Min(short_put3(sy, c, fy, sx, fx), short_put3(b - sy, c, b - fy, sx, fx)));

            // на смежных плоскостях
            else if (sx == 0)
            {
                if (fz == c) r = short_put2(c - sz, fx, sy, fy);
                if (fz == 0) r = short_put2(sz, fx, sy, fy);
                if (fy == b) r = short_put2(b - sy, fx, sz, fz);
                if (fy == 0) r = short_put2(sy, fx, sz, fz);
            }
            else if (sx == a)
            {
                if (fz == c) r = short_put2(c - sz, a - fx, sy, fy);
                if (fz == 0) r = short_put2(sz, a - fx, sy, fy);
                if (fy == b) r = short_put2(b - sy, a - fx, sz, fz);
                if (fy == 0) r = short_put2(sy, a - fx, sz, fz);
            }

            else if (sy == 0)
            {
                if (fz == c) r = short_put2(c - sz, fy, sx, fx);
                if (fz == 0) r = short_put2(sz, fy, sx, fx);
                if (fx == a) r = short_put2(a - sx, fy, sz, fz);
                if (fx == 0) r = short_put2(sx, fy, sz, fz);
            }
            else if (sy == b)
            {
                if (fz == c) r = short_put2(c - sz, b - fy, sx, fx);
                if (fz == 0) r = short_put2(sz, b - fy, sx, fx);
                if (fx == a) r = short_put2(a - sx, b - fy, sz, fz);
                if (fx == 0) r = short_put2(sx, b - fy, sz, fz);
            }

            else if (sz == 0)
            {
                if (fx == a) r = short_put2(a - sx, fz, sy, fy);
                if (fx == 0) r = short_put2(sx, fz, sy, fy);
                if (fy == b) r = short_put2(b - sy, fz, sx, fx);
                if (fy == 0) r = short_put2(sy, fz, sx, fx);
            }
            else if (sz == c)
            {
                if (fx == a) r = short_put2(a - sx, c - fz, sy, fy);
                if (fx == 0) r = short_put2(sx, c - fz, sy, fy);
                if (fy == b) r = short_put2(b - sy, c - fz, sx, fx);
                if (fy == 0) r = short_put2(sy, c - fz, sx, fx);
            }
            s = sr2.ReadLine();
            s = s.Replace('.', ',');
            if (Math.Round(r, 3) == Convert.ToDouble(s)) Console.WriteLine("Расстояние " + $"{r:0.000}");
        }
        static double one_pl(double s_1, double f_1, double s_2, double f_2)
        {
            return Math.Sqrt(Math.Pow(s_1 - f_1, 2) + Math.Pow(s_2 - f_2, 2));
        }
        static double short_put2(double b1, double b2, double a1, double a2)
        {
            return Math.Sqrt(Math.Pow(b1 + b2, 2) + Math.Pow(a1 - a2, 2));
        }
        static double short_put3(double a1, double a2, double a3, double b1, double b2)
        {
            return Math.Sqrt(Math.Pow(a1 + a2 + a3, 2) + Math.Pow(b1 - b2, 2));
        }
    }
}
