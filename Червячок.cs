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
            string No = "13";
            Dictionary<int, List<int>> a_t = new Dictionary<int, List<int>>(); // путь до ябока по веткам
            Dictionary<int, string> tree = new Dictionary<int, string>(); // номер_ветки - откуда - длина
            Dictionary<int, string> apples = new Dictionary<int, string>(); // номер_яблока - номер_ветки - спелость
            List<int> length = new();
            bool b;
            int r, way = 0;
            List<int> w_worm = new();
            List<int> ww_c = new();// путь от червчка до корня
            StreamReader sr = new StreamReader("input_s1_" + No + ".txt");
            StreamReader sr2 = new StreamReader("output_s1_" + No + ".txt");
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
            
            foreach (var apple in apples)
            {
                if ((Convert.ToInt32(apple.Value.Split(' ')[1]) < z) | (x == Convert.ToInt32(apple.Value.Split(' ')[0])))
                {
                    apples.Remove(apple.Key);
                    if (x != Convert.ToInt32(apple.Value.Split(' ')[0]))
                    tree.Remove(Convert.ToInt32(apple.Value.Split(' ')[0])); // если не нравится червяку или он прям с яблоком, удаляем яблоко и ветку
                }
            }

            //Floyd(n+1, tree, apples, x, k);

            while (x_c != 0)
            {
                w_worm.Add(x_c);
                ww_c.Add(x_c);
                int w = Convert.ToInt32(tree[x_c].Split(' ')[1]);
                int wh = Convert.ToInt32(tree[x_c].Split(' ')[0]);
                way += w;
                x_c = wh;
            }
            w_worm.Reverse(); // путь от корня до червяка
            ww_c.Reverse();

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
                    else if (w_worm.Contains(w_v))
                    {
                        if (w_worm.IndexOf(w_v) != 0)
                        {
                            ww_c.RemoveRange(0, w_worm.IndexOf(w_v) + 1);
                            length.Add(r + way);
                            b = false;
                            foreach (int ww in ww_c)
                            {
                                ver.Add(ww);
                            }
                            ww_c.Reverse();
                            for (int q = w_worm.IndexOf(w_v); q >= 0; q--)
                            {
                                ww_c.Add(w_worm[q]);
                            }
                            ww_c.Reverse();
                        }
                        else
                        {
                            b = false;
                            length.Add(r + way);
                            foreach (int ww in w_worm)
                            {
                                ver.Add(ww);
                            }
                        }
                    }
                    n_v = w_v;
                }
                ver.Reverse();
                a_t.Add(apple.Key, ver);
            }
            r = 0;
            int nomer = Convert.ToInt32(No);

            Dictionary<int, List<int>> dict = new(); // ответвление - ветки по которым пройти
            SortedList<int, int> ves_vet = new(); // общий_вес_ответвления - ответвление
            SortedList<int, int> vv_c = new();
            List<int> used = new(); // список пройденных яблок
            List<string> sowp = new List<string>(); // совпадения

            while (true)
            {
                if (a_t.Count() > 1)
                {
                    foreach (var vet in a_t)
                    {
                        foreach (var net in a_t)
                        {
                            if (!used.Contains(net.Key))
                            {
                                if ((vet.Key != net.Key) & (vet.Value[0] == net.Value[0]))
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
                                    sowp.Add("Совпадение");
                                }
                                else if (vet.Key == net.Key)
                                {
                                    if (!dict.ContainsKey(vet.Value[0]))
                                    {
                                        List<int> obsh = new();
                                        foreach (int ob in vet.Value)
                                        {
                                            obsh.Add(ob);
                                        }
                                        dict.Add(vet.Value[0], obsh);
                                    }
                                    used.Add(net.Key);
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (int kek in length)
                    {
                        r += kek;
                    }
                    vivod(r, k);
                    Environment.Exit(0);
                }

                used.Clear();
                r = vesvet(dict, r, ref vv_c, ref ves_vet, tree, a_t);
                if (dict.Count == 2)
                {
                    if (r == 0)
                    {
                        r = rast(length);
                        vivod(r, k);
                        Environment.Exit(0);
                    }
                    else
                    {
                        length.Clear();
                        if (vv_c.Count != 0)
                        {
                            int l = vv_c.Keys[vv_c.IndexOfValue(ves_vet.Keys[0])];
                            foreach (int kuku in dict[l])
                            {
                                length.Add(Convert.ToInt32(tree[kuku].Split(' ')[1]));
                            }
                            int cop = rast(length);
                            length.Clear();
                            foreach (var kok in dict[ves_vet.Values[0]])
                            {
                                length.Add(Convert.ToInt32(tree[kok].Split(' ')[1]));
                            }
                            int lok = rast(length);
                            length.Clear();
                            length.Add(cop);
                            length.Add(lok);
                            r += rast(length);
                            vivod(r, k);
                            break;
                        }
                        else
                        {
                            foreach (var kok in dict[ves_vet.Values[0]])
                            {
                                length.Add(Convert.ToInt32(tree[kok].Split(' ')[1]));
                            }
                            r += length[0];
                            length.RemoveAt(0);
                            if (length.Count != 0) r += rast(length);
                            vivod(r, k);
                            break;
                        }
                        
                    }
                }
                if (dict.Count == 1)
                {
                    foreach (var duc in dict)
                    {
                        r += Convert.ToInt32(tree[duc.Key].Split(' ')[1]);
                    }
                    foreach (var ap in a_t)
                    {
                        if (ap.Value[0] == ves_vet.Values[0])
                        {
                            ap.Value.RemoveAt(0);
                        }
                    }
                }
                else if (sowp.Count != 0)
                {
                    if (a_t.Count == 1)
                    { 
                        length.Clear();
                        foreach (var ap in a_t) 
                        {
                            foreach (int kon in ap.Value)
                            {
                                length.Add(Convert.ToInt32(tree[kon].Split(' ')[1]));
                            }
                        }
                        r += rast(length);
                        vivod(r, k);
                        Environment.Exit(0);
                    }
                    foreach (var ap in a_t)
                    {
                        if (ap.Value[0] == ves_vet.Values[0])
                        {
                            ap.Value.RemoveAt(0);
                        }
                    }
                }
                else
                {
                    r = rast(length);
                    vivod(r, k);
                    Environment.Exit(0);
                }
                dict.Clear();
                ves_vet.Clear();
                vv_c.Clear();
                used.Clear();
            }
        }
        static void cr_v(Dictionary<int, List<int>> d, ref SortedList<int, int> vc, ref SortedList<int, int> v, Dictionary<int, string> t)
        {
            foreach (var ss in d)
            {
                int ves = 0;
                foreach (int put in ss.Value)
                {
                    ves += 2 * Convert.ToInt32(t[put].Split(' ')[1]);
                }
                if (!v.ContainsKey(ves)) { v.Add(ves, ss.Key); }
                else
                {
                    vc.Add(ss.Key, ves);
                }
            }
        }
        static int vesvet(Dictionary<int, List<int>> d, int r, ref SortedList<int, int> vc, ref SortedList<int, int> v, Dictionary<int, string> t, Dictionary<int, List<int>> a_t)
        {
            List<int> used = new List<int>();
            cr_v(d, ref vc, ref v, t);
            for (int c = 0; c < v.Count() - 1; c++)
            {
                r += v.Keys[c];
                foreach (var ap in a_t)
                {
                    if (ap.Value[0] == v.Values[c]) a_t.Remove(ap.Key);
                }
                used.Add(v.Keys[c]);
            }
            foreach (int ik in used)
            {
                v.Remove(ik);
            }
            if (v.Count < 1)
            {
                return r += 0;
            }
            else
            {
                create(d[v.Values[0]], r, t);
                return r;
            }
        }
        static int create(List<int> l, int r, Dictionary<int, string> t)
        {
            List<int> v = new List<int>();
            foreach (int y in l)
            {
                v.Add(Convert.ToInt32(t[y].Split(' ')[1]));
            }
            r += rast(v);
            return r;
        }

        static int rast (List<int> l)
        {
            if (l.Count < 1) return 0;
            else
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
        }
        static void vivod(int r, int k)
        {
            if (r == k) Console.WriteLine("Путь червяка - {0}", r);
            else Console.WriteLine("Ошибка\n{0} != {1}\n", r, k);
        }
    }
}
