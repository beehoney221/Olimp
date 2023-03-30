using System;
using System.IO;
namespace Кубик_Рубика
{
    class Program
    {
        public static int[,] Povorot(int[,] st, int n)
        {
            int[,] stp = new int[n, n];
            for(var i=0; i<n; i++)
            {
                for(var j=0; j<n; j++)
                {
                    stp[j, n-1-i] = st[i, j];
                }
            }
            return stp;
        }
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input_s1_10.txt");
            StreamReader sr2 = new StreamReader("output_s1_10.txt");
            string so = sr2.ReadLine();
            string s = sr.ReadLine();
            string[] s1 = s.Split(" ");
            int N = Convert.ToInt32(s1[0]);
            int M = Convert.ToInt32(s1[1]);
            s = sr.ReadLine();
            s1 = s.Split(" ");
            int X = Convert.ToInt32(s1[0]);
            int Y = Convert.ToInt32(s1[1]);
            int Z = Convert.ToInt32(s1[2]);
            int K = 0, p = 0;
            for (var i = 0; i < M; i++)
            {
                s = sr.ReadLine();
                s1 = s.Split(" ");
                K = Convert.ToInt32(s1[1]);
                p = Convert.ToInt32(s1[2]);
                if ((s1[0] == "X") & (X == K))
                {
                    int[,] st = new int[N, N];
                    st[Y - 1, Z - 1] = 1;
                    if (p == 1)
                    {
                        st = Povorot(st, N);
                    }
                    else if (p == -1)
                    {
                        st = Povorot(Povorot(Povorot(st, N), N), N);
                    }
                    for (var k = 0; k < N; k++)
                    {
                        for (var j = 0; j < N; j++)
                        {
                            if (st[k, j] == 1)
                            {
                                Y = k + 1;
                                Z = j + 1;
                            }
                        }
                    }
                }
                if ((s1[0] == "Y") & (Y == K))
                {
                    int[,] st = new int[N, N];
                    st[X - 1, Z - 1] = 1;
                    if (p == 1)
                    {
                        st = Povorot(st, N);
                    }
                    else if (p == -1)
                    {
                        st = Povorot(Povorot(Povorot(st, N), N), N);
                    }
                    for (var k = 0; k < N; k++)
                    {
                        for (var j = 0; j < N; j++)
                        {
                            if (st[k, j] == 1)
                            {
                                X = k + 1;
                                Z = j + 1;
                            }
                        }
                    }
                }

                if ((s1[0] == "Z") & (Z == K))
                {
                    int[,] st = new int[N, N];
                    st[X - 1, Y - 1] = 1;
                    if (p == 1)
                    {
                        st = Povorot(st, N);
                    }
                    else if (p == -1)
                    {
                        st = Povorot(Povorot(Povorot(st, N), N), N);
                    }
                    for (var k = 0; k < N; k++)
                    {
                        for (var j = 0; j < N; j++)
                        {
                            if (st[k, j] == 1)
                            {
                                X = k + 1;
                                Y = j + 1;
                            }
                        }
                    }

                }
                
            }
            Console.WriteLine("Мой ответ: " + X + " " + Y + " " + Z);
            Console.WriteLine("Правильный ответ: " + so);
        }
    }
}
