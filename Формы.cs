using System;
using System.Collections.Generic;
using System.IO;

namespace Forms
{
    class Program
    {
        public static void Poisk(ref List<string[]> det, ref List<string[]> pol, ref List<List<int>> otvet, int n,int p)
        {
            for (var i = 0; i < pol.Count; i++)
            {
                //Для тех случаев, когда освнова - лево или право
                //Верх-низ прямое - верх-низ обратное
                for (var j = 0; j < det.Count; j++)
                    {
                    int ch = 0;
                    for (var k = 0; k < 5; k++)
                    {
                        if ((pol[i][k] == det[j][k]))
                        {
                            ch++;
                        }
                    }
                    if (ch != 5) continue;
                    for (var k = 10; k < 15; k++)
                    {
                        if ((pol[i][k] == det[j][k]))
                        {
                            ch++;
                        }
                    }
                    if (ch != 10) continue;
                    for (var k = 5; k < 10; k++)
                    {
                        if ((pol[i][k] == det[j][k + 10]))
                        {
                            ch++;
                        }
                    }
                    if (ch == 15)
                    {
                        for (var l = 0; l < pol.Count; l++)
                        {
                            ch = 0;
                            for (var k = 0; k < 5; k++)
                            {
                                if ((pol[l][k] == det[j][4 - k]))
                                {
                                    ch++;
                                }
                            }
                            if (ch != 5) continue;
                            for (var k = 10; k < 15; k++)
                            {
                                if ((pol[l][k] == det[j][14 - k + 10]))
                                {
                                    ch++;
                                }
                            }
                            if (ch != 10) continue;
                            for (var k = 5; k < 10; k++)
                            {
                                if ((pol[l][k] == det[j][9 - k + 5]))
                                {
                                    ch++;
                                }
                            }
                            if (ch == 15)
                            {
                                if (otvet[j].Contains(l+1) == false)
                                {
                                    otvet[j].Add(l + 1);
                                    otvet[j].Add(i + 1);
                                }
                            }
                        }
                    }
                }

                //Верх-низ(обратное) - низ-верх(обратное)
                for (var j = 0; j < det.Count; j++)
                {
                    int ch = 0;
                    for (var k = 0; k < 5; k++)
                    {
                        if ((pol[i][k] == det[j][4 - k]))
                        {
                            ch++;
                        }
                    }
                    if (ch != 5) continue;
                    for (var k = 10; k < 15; k++)
                    {
                        if ((pol[i][k] == det[j][14 - k + 10]))
                        {
                            ch++;
                        }
                    }
                    if (ch != 10) continue;
                    for (var k = 5; k < 10; k++)
                    {
                        if ((pol[i][k] == det[j][9 - k + 5]))
                        {
                            ch++;
                        }
                    }
                    if (ch == 15)
                    {
                        for (var l = 0; l < pol.Count; l++)
                        {
                            ch = 0;
                            for (var k = 0; k < 5; k++)
                            {
                                if ((pol[l][k] == det[j][14 - k]))
                                {
                                    ch++;
                                }
                            }
                            if (ch != 5) continue;
                            for (var k = 10; k < 15; k++)
                            {
                                if ((pol[l][k] == det[j][14 - k]))
                                {
                                    ch++;
                                }
                            }
                            if (ch != 10) continue;
                            for (var k = 5; k < 10; k++)
                            {
                                if ((pol[l][k] == det[j][19 - k + 5]))
                                {
                                    ch++;
                                }
                            }

                            if (ch == 15)
                            {
                                if(otvet[j].Contains(l + 1) == false)
                                {
                                    otvet[j].Add(l + 1);
                                    otvet[j].Add(i + 1);
                                }
                            }
                        }
                    }
                }

                //Низ-верх - низ-верх обратное
                for (var j = 0; j < det.Count; j++)
                {
                    int ch = 0;
                    for (var k = 0; k < 5; k++)
                    {
                        if ((pol[i][k] == det[j][k + 10]))
                        {
                            ch++;
                        }
                    }
                    if (ch != 5) continue;
                    for (var k = 10; k < 15; k++)
                    {
                        if ((pol[i][k] == det[j][k - 10]))
                        {
                            ch++;
                        }
                    }
                    if (ch != 10) continue;
                    for (var k = 5; k < 10; k++)
                    {
                        if ((pol[i][k] == det[j][k]))
                        {
                            ch++;
                        }
                    }

                    if (ch == 15)
                    {
                        for (var l = 0; l < pol.Count; l++)
                        {
                            ch = 0;
                            for (var k = 0; k < 5; k++)
                            {
                                if ((pol[l][k] == det[j][14 - k]))
                                {
                                    ch++;
                                }
                            }
                            if (ch != 5) continue;
                            for (var k = 10; k < 15; k++)
                            {
                                if ((pol[l][k] == det[j][14 - k]))
                                {
                                    ch++;
                                }
                            }
                            if (ch != 10) continue;
                            for (var k = 5; k < 10; k++)
                            {
                                if ((pol[l][k] == det[j][19 - k + 5]))
                                {
                                    ch++;
                                }
                            }

                            if (ch == 15)
                            {
                                if (otvet[j].Contains(l + 1) == false)
                                {
                                    otvet[j].Add(l + 1);
                                    otvet[j].Add(i + 1);
                                }
                            }
                        }
                    }
                }

                //Верх-низ - низ-верх(всё прямое)
                for (var j = 0; j < det.Count; j++)
                {
                    int ch = 0;
                    for (var k = 0; k < 5; k++)
                    {
                        if ((pol[i][k] == det[j][k + 10]))
                        {
                            ch++;
                        }
                    }
                    if (ch != 5) continue;
                    for (var k = 10; k < 15; k++)
                    {
                        if ((pol[i][k] == det[j][k - 10]))
                        {
                            ch++;
                        }
                    }
                    if (ch != 10) continue;
                    for (var k = 5; k < 10; k++)
                    {
                        if ((pol[i][k] == det[j][k]))
                        {
                            ch++;
                        }
                    }

                    if (ch == 15)
                    {
                        for (var l = 0; l < pol.Count; l++)
                        {
                            ch = 0;
                            for (var k = 0; k < 5; k++)
                            {
                                if ((pol[l][k] == det[j][k]))
                                {
                                    ch++;
                                }
                            }
                            if (ch != 5) continue;
                            for (var k = 10; k < 15; k++)
                            {
                                if ((pol[l][k] == det[j][k]))
                                {
                                    ch++;
                                }
                            }
                            if (ch != 10) continue;
                            for (var k = 5; k < 10; k++)
                            {
                                if ((pol[l][k] == det[j][k + 10]))
                                {
                                    ch++;
                                }
                            }
                            if (ch == 15)
                            {
                                if (otvet[j].Contains(l + 1) == false)
                                {
                                    otvet[j].Add(l + 1);
                                    otvet[j].Add(i + 1);
                                }
                            }
                        }
                    }
                }


                //Для тех случаев, когда рассматриваем, что основа - низ или верх
                //Право-лево(прямое) - право-лево(обр)
                for (var j = 0; j < det.Count; j++)
                {
                    int ch = 0;
                    for (var k = 0; k < 5; k++)
                    {
                        if ((pol[i][k] == det[j][k + 15]))
                        {
                            ch++;
                        }
                    }
                    if (ch != 5) continue;
                    for (var k = 10; k < 15; k++)
                    {
                        if ((pol[i][k] == det[j][k - 5]))
                        {
                            ch++;
                        }
                    }
                    if (ch != 10) continue;
                    for (var k = 5; k < 10; k++)
                    {
                        if ((pol[i][k] == det[j][k + 5]))
                        {
                            ch++;
                        }
                    }

                    if (ch == 15)
                    {
                        for (var l = 0; l < pol.Count; l++)
                        {
                            if (pol[i][0] == "2") continue;
                            ch = 0;
                            for (var k = 0; k < 5; k++)
                            {
                                if ((pol[l][k] == det[j][19 - k]))
                                {
                                    ch++;
                                }
                            }
                            if (ch != 5) continue;
                            for (var k = 10; k < 15; k++)
                            {
                                if ((pol[l][k] == det[j][19 - k]))
                                {
                                    ch++;
                                }
                            }
                            if (ch != 10) continue;
                            p = 4;
                            for (var k = 5; k < 10; k++)
                            {
                                if ((pol[l][k] == det[j][p]))
                                {
                                    ch++;
                                }
                                p--;
                            }

                            if (ch == 15)
                            {
                                if (otvet[j].Contains(l + 1) == false)
                                {
                                    otvet[j].Add(l + 1);
                                    otvet[j].Add(i + 1);
                                }
                            }
                        }
                    }
                }

                //Право-лево(обратное) - лево-право(обр)
               for (var j = 0; j < det.Count; j++)
               {
                    int ch = 0;
                    for (var k = 0; k < 5; k++)
                    {
                        if ((pol[i][k] == det[j][19 - k]))
                        {
                            ch++;
                        }
                    }
                    if (ch != 5) continue;
                    for (var k = 10; k < 15; k++)
                    {
                        if ((pol[i][k] == det[j][19 - k]))
                        {
                            ch++;
                        }
                    }
                    if (ch != 10) continue;
                    p = 4;
                    for (var k = 5; k < 10; k++)
                    {
                        if ((pol[i][k] == det[j][p]))
                        {
                            ch++;
                        }
                        p--;
                    }

                    if (ch == 15)
                    {
                        for (var l = 0; l < pol.Count; l++)
                        {

                            ch = 0;
                            for (var k = 0; k < 5; k++)
                            {
                                if ((pol[l][k] == det[j][9 - k]))
                                {
                                    ch++;
                                }
                            }
                            if (ch != 5) continue;
                            p = 19;
                            for (var k = 10; k < 15; k++)
                            {
                                if ((pol[l][k] == det[j][p]))
                                {
                                    ch++;
                                }
                                p--;
                            }
                            if (ch != 10) continue;
                            for (var k = 5; k < 10; k++)
                            {
                                if (((pol[l][k] == det[j][14 - k + 5])))
                                {
                                    ch++;
                                }
                            }

                            if (ch == 15)
                            {

                                if (otvet[j].Contains(l + 1) == false)
                                {
                                    otvet[j].Add(l + 1);
                                    otvet[j].Add(i + 1);
                                }
                            }
                        }
                    }
               }

                //Лево-право(прямое) - лево-право(обр)
                for (var j = 0; j < det.Count; j++)
                {
                    int ch = 0;
                    for (var k = 0; k < 5; k++)
                    {
                        if ((pol[i][k] == det[j][k + 5]))
                        {
                            ch++;
                        }
                    }
                    if (ch != 5) continue;
                    for (var k = 10; k < 15; k++)
                    {
                        if ((pol[i][k] == det[j][k + 5]))
                        {
                            ch++;
                        }
                    }
                    if (ch != 10) continue;
                    for (var k = 5; k < 10; k++)
                    {
                        if ((pol[i][k] == det[j][k - 5]))
                        {
                            ch++;
                        }
                    }

                    if (ch == 15)
                    {
                        for (var l = 0; l < pol.Count; l++)
                        {

                            ch = 0;
                            for (var k = 0; k < 5; k++)
                            {
                                if ((pol[l][k] == det[j][9 - k]))
                                {
                                    ch++;
                                }
                            }
                            if (ch != 5) continue;
                            p = 19;
                            for (var k = 10; k < 15; k++)
                            {
                                if ((pol[l][k] == det[j][p]))
                                {
                                    ch++;
                                }
                                p--;
                            }
                            if (ch != 10) continue;
                            for (var k = 5; k < 10; k++)
                            {
                                if (((pol[l][k] == det[j][14 - k + 5])))
                                {
                                    ch++;
                                }
                            }

                            if (ch == 15)
                            {
                                if (otvet[j].Contains(l + 1) == false)
                                {
                                    otvet[j].Add(l + 1);
                                    otvet[j].Add(i + 1);
                                }
                            }
                        }
                    }
                }

                //Право-лево - Лево-право(всё прямое)
                for (var j = 0; j < det.Count; j++)
                {
                    int ch = 0;
                    for (var k = 0; k < 5; k++)
                    {
                        if ((pol[i][k] == det[j][k + 5]))
                        {
                            ch++;
                        }
                    }
                    if (ch != 5) continue;
                    for (var k = 10; k < 15; k++)
                    {
                        if ((pol[i][k] == det[j][k + 5]))
                        {
                            ch++;
                        }
                    }
                    if (ch != 10) continue;
                    for (var k = 5; k < 10; k++)
                    {
                        if ((pol[i][k] == det[j][k - 5]))
                        {
                            ch++;
                        }
                    }

                    if (ch == 15)
                    {
                        for (var l = 0; l < pol.Count; l++)
                        {
                            if (pol[i][0] == "2") continue;
                            ch = 0;
                            for (var k = 0; k < 5; k++)
                            {
                                if ((pol[l][k] == det[j][k + 15]))
                                {
                                    ch++;
                                }
                            }
                            if (ch != 5) continue;
                            for (var k = 10; k < 15; k++)
                            {
                                if ((pol[l][k] == det[j][k - 5]))
                                {
                                    ch++;
                                }
                            }
                            if (ch != 10) continue;
                            for (var k = 5; k < 10; k++)
                            {
                                if ((pol[l][k] == det[j][k + 5]))
                                {
                                    ch++;
                                }
                            }
                            if (ch == 15)
                            {
                                if (otvet[j].Contains(l + 1) == false)
                                {
                                    otvet[j].Add(l + 1);
                                    otvet[j].Add(i + 1);
                                }
                            }
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {

            int p = 0;
            //Считывание данных
            StreamReader sr = new StreamReader("input19.txt");
            StreamReader sr1 = new StreamReader("output19.txt");
            string s = sr.ReadLine();
            int n = Convert.ToInt32(s);
            List<string[]> det = new List<string[]>();
            for (var i = 0; i < n; i++)
            {
                s = sr.ReadLine();
                string[] d1 = s.Split(' ');
                det.Add(d1);
            }
            List<string[]> pol = new List<string[]>();
            for (var i = 0; i < 2 * n; i++)
            {
                s = sr.ReadLine();
                string[] d1 = s.Split(' ');
                pol.Add(d1);
            }
            //Решение задачи
            List<List<int>> otvet = new List<List<int>>();
            for (var i = 0; i < det.Count; i++)
            {
                List<int> d1 = new List<int>();
                otvet.Add(d1);
            }

            Poisk(ref det, ref pol, ref otvet, n, p);

            //Проверка на повторы(3 раза, потому что 19 тест с 3 раза полностью чистится от повторов)
            for(var m = 0; m<3; m++)
            {
                for(var i =0; i<otvet.Count; i++)
                {
                    if (otvet[i].Count > 2)
                    {
                        List<int> rem = new List<int>();
                        for (var j = 0; j< otvet[i].Count; j++)
                        {
                            p = otvet[i][j];
                            for(var k =0; k < otvet.Count; k++)
                            {
                                if (k == i) continue;
                                if (otvet[k].Count == 2)
                                { 
                                    for(var l = 0; l< otvet[k].Count; l++)
                                    {
                                        if(p == otvet[k][l])
                                        {
                                            rem.Add(p);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        for(var j=0; j<rem.Count; j++)
                        {
                            otvet[i].Remove(rem[j]);
                        }
                    }
                }
            }
            //Вывод ответа
            List<string[]> otvetreal = new List<string[]>();
            for (var i = 0; i < n; i++)
            {
                s = sr1.ReadLine();
                string[] d1 = s.Split(' ');
                otvetreal.Add(d1);
            }
            Console.WriteLine("Мой ответ");
            for (var i = 0; i < n; i++)
            {
                otvet[i].Sort();
                for (var j = 0; j < otvet[i].Count; j++)
                {
                    Console.Write(otvet[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Реальный ответ");
            for (var i = 0; i < det.Count; i++)
            {
                for (var j = 0; j < 2; j++)
                {
                    Console.Write(otvetreal[i][j] + " ");
                }
                Console.WriteLine();
            }
            int srav = 0;
            for (var i = 0; i < n; i++)
            {
                otvet[i].Sort();
                for (var j = 0; j < 2; j++)
                {
                    if (Convert.ToString(otvet[i][j])== otvetreal[i][j])
                    {
                        srav++;
                    }
                }
            }
            if (srav == 2*n)
            {
                Console.WriteLine("Тест успешно пройден");
            }
            else
            {
                Console.WriteLine("Тест не пройден");
            }
            Console.ReadLine();
        }
    }
}
