using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
 
namespace Cherv
{
    class Program
    {
        static void Main()
        {
            Dictionary<int, List<int>> a_t = new Dictionary<int, List<int>>(); // путь до ябока по веткам
            Dictionary<int, string> tree = new Dictionary<int, string>(); // номер_ветки - откуда - длина
            Dictionary<int, string> apples = new Dictionary<int, string>(); // номер_яблока - номер_ветки - спелость
            List<int> length = new();
            bool b;
            int r, way = 0;
            List<int> w_worm = new(); // путь от червчка доя корня
            StreamReader sr = new StreamReader("input_s1_02.txt");
            StreamReader sr2 = new StreamReader("output_s1_02.txt");
            int k = Convert.ToInt32(sr2.ReadLine());
            string s = sr.ReadLine();
            int n = Convert.ToInt32(s.Split(' ')[0]); // сколько ветвей
            int m = Convert.ToInt32(s.Split(' ')[1]); // сколько яблок
            for (int i = 1; i <= n; i++)
            {
                s = sr.ReadLine();
                tree.Add(i, s); // номер_ветки - откуда - длина
            }
            for (int i = 1; i <= m; i++)
            {
                s = sr.ReadLine();
                apples.Add(i, s); // номер_яблока - номер_ветки - спелость
            }
            s = sr.ReadLine();
            int x = Convert.ToInt32(s.Split(' ')[0]);
            int X = x; // на конце какой ветки червяк
            int z = Convert.ToInt32(s.Split(' ')[1]); // минимальный уровень спелости
            int x_c = x;
            
            while (x_c != 0)
            {
                w_worm.Add(x_c);
                int w = Convert.ToInt32(tree[x_c].Split(' ')[1]);
                int wh = Convert.ToInt32(tree[x_c].Split(' ')[0]);
                way += w;
                x_c = wh;
            }
            w_worm.Reverse(); // путь от корня до червяка
            foreach (var apple in apples)
            {
                if ((Convert.ToInt32(apple.Value.Split(' ')[1]) < z) | (x == Convert.ToInt32(apple.Value.Split(' ')[0])))
                {
                    apples.Remove(apple.Key);
                    tree.Remove(Convert.ToInt32(apple.Value.Split(' ')[0])); // если не нравится червяку или он прям с яблоком, удаляем яблоко и ветку
                }
            }
 
            
            foreach (var apple in apples)
            {
                List<int> ver = new List<int>(); // путь от червяка до яблока
                b = true;
                r = 0;
                int n_v = Convert.ToInt32(apple.Value.Split(' ')[0]); // на какой ветке яблоко
                int w_v;
                int l_v;
                ver.Clear();
                while (b)
                {
                    ver.Add(n_v);
                    w_v = Convert.ToInt32(tree[n_v].Split(' ')[0]); // откуда эта ветка
                    l_v = Convert.ToInt32(tree[n_v].Split(' ')[1]); // длина ветки
                    r += l_v;
                    if (x == w_v) { length.Add(r); b = false; }
                    else if (w_v == 0) 
                    { 
                        length.Add(r + way);  
                        b = false; 
                        foreach (int ww in w_worm)
                        {
                            ver.Add(ww);
                        }
                    }
                    n_v = w_v;
                }
                ver.Reverse();
                a_t.Add(apple.Key, ver);
            }
            r = 0;
 
            foreach (var vet in a_t)
            {
                Console.Write("{0}:", vet.Key);
                foreach (var kun in vet.Value)
                {
                    Console.Write(" {0}", kun);
                }
                Console.WriteLine();
            }
            
            Dictionary<int, List<int>> dict = new(); // ответвление - ветки по которым пройти
            SortedList<int, int> ves_vet = new(); // общий_вес_ответвления - ответвление
            List<int> used = new(); // список пройденных яблок
 
            int kaka = 0;
            while (true)
            {
                kaka++;
                foreach (var vet in a_t)
                {
                    foreach (var net in a_t)
                    {
                        if ((!used.Contains(net.Key)) & (vet.Key != net.Key) & (vet.Value[0] == net.Value[0]))
                        {
                            if (dict.ContainsKey(vet.Value[0]))
                            {
                                List<int> obsh = new();
                                foreach (int ob in dict[vet.Value[0]].Union(net.Value))
                                {
                                    obsh.Add(ob);
                                }
                                dict[vet.Value[0]] = obsh;
                            }
                            else 
                            {
                                
                                List<int> obsh = new();
                                foreach (int ob in vet.Value.Union(net.Value))
                                {
                                    obsh.Add(ob);
                                }
                                dict.Add(vet.Value[0], obsh);
                                
                            }
                            used.Add(net.Key);
                        }
                    }
                }
 
                used.Clear();
                if (dict.Count == 0)
                { 
                    if (r == 0)
                    {
                        r = rast(length);
                        vivod(r, k);
                        Environment.Exit(0);
                    }
                    vivod(r, k);
                    break;
                }
 
                foreach (var ss in dict)
                {
                    int ves = 0;
                    foreach (int put in ss.Value)
                    {
                        ves += 2 * Convert.ToInt32(tree[put].Split(' ')[1]);
                    }
                    ves_vet.Add(ves, ss.Key);
 
                }
                dict.Clear();
 
                for (int c = 0; c < ves_vet.Count(); c++) // общее расстояние наименее затратных ответвлений
                {
                    r += ves_vet.Keys[c];
                }
                Console.WriteLine(r);
                foreach (var ap in a_t)
                {
                    for (int j = 0; j < ves_vet.Count - 1; j++)
                    {
                                    Console.WriteLine("\nkek");
                        if (ap.Value[0] != ves_vet.Values[j])
                        {
                            a_t.Remove(ap.Key);
                        }
                        else
                        {
                            ap.Value.RemoveAt(0);
                        }
                    }
                }
                ves_vet.Clear();
                if (kaka > 30) break;
            }
            
 
        }   
        static int rast (List<int> l)
        {
            int itog = l[0];
            int i_1;
            for (int i = 1; i < l.Count; i++)
            {
                itog += 2 * l[i];
            }
            for (int i = 1; i < l.Count; i++)
            {
                i_1 = l[i];
                for (int j = 0; j < l.Count; j++)
                {
                    if (j != i) i_1 += 2*l[j];
                }
                itog = Math.Min(itog, i_1);
            }
            return itog;
        }
        static void vivod(int r, int k)
        {
 
            if (r == k) Console.WriteLine("Путь червяка - {0}", r);
            else
            {
                Console.WriteLine("Ошибка\n{0} != {1}\n", r, k);
                //Console.WriteLine(n + " " + m + " " + X + " " + z + " " + way + "\n");
                //foreach (var apple in apples)
                //{
                //    Console.WriteLine("{0} - {1}", apple.Key, apple.Value);
                //}
                //Console.WriteLine();
                //foreach (var tr in tree)
                //{
                //    Console.WriteLine("{0} - {1}", tr.Key, tr.Value);
                //}
                //foreach (var c in length)
                //{
                //    Console.WriteLine(c);
                //}
            }
        }
    }
}
