using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication15_об_
{
    class Program
    {
        static void Main(string[] args)
        {
            //Считывание данных
            StreamReader sr = new StreamReader("input11.txt");
            StreamReader sr2 = new StreamReader("output11.txt");
            string s = sr.ReadLine();
            string[] s1 = s.Split(' ');
            double[] isxod = new double[Convert.ToInt32(s1[0]) - 1];
            for (var i = 0; i < isxod.Length; i++)
            {
                isxod[i] = Convert.ToInt32(s1[i + 1]);
            }
            s = sr.ReadLine();
            s1 = s.Split(' ');
            double[] isxodnes = new double[Convert.ToInt32(s1[0])];
            for (var i = 0; i < isxodnes.Length; i++)
            {
                isxodnes[i] = Convert.ToInt32(s1[i + 1]);
            }
            s = sr.ReadLine();
            s1 = s.Split(' ');
            double[] poluch = new double[Convert.ToInt32(s1[0]) - 1];
            for (var i = 0; i < poluch.Length; i++)
            {
                poluch[i] = Convert.ToInt32(s1[i + 1]);
            }
            s = sr.ReadLine();
            s1 = s.Split(' ');
            double[] poluchnes = new double[Convert.ToInt32(s1[0])];
            for (var i = 0; i < poluchnes.Length; i++)
            {
                poluchnes[i] = Convert.ToInt32(s1[i + 1]);
            }
            s = sr.ReadLine();
            s1 = s.Split(' ');
            double[] dan = new double[isxod.Length + 1];
            for (var i = 0; i < dan.Length; i++)
            {
                dan[i] = Convert.ToInt32(s1[i]);
            }


            //Перевод изначальной валюты в её меньший из размеров(условно рубли в копейки)
            double[] otvet = new double[poluch.Length + 1];
            double[] realotvet = new double[poluch.Length + 1];
            double kop = 0;
            for (var i = 0; i < dan.Length; i++)
            {
                double real = dan[i];
                for (var j = 0; j < isxodnes.Length; j++)
                {
                    if (isxodnes[j] < dan[i])
                    {
                        real = real - 1;
                    }
                }
                if (i == dan.Length - 1)
                {
                    kop = kop + real;
                }
                else
                {
                    kop = kop + real;
                    kop = kop * isxod[i];
                }
            }


            //Получение реального числа денег в новой валюте
            int ch = poluch.Length-1;
            for (var i = otvet.Length - 1; i >= 0; i--)
            {
                double unreal = kop;
                double min = 0;
                if ((ch >= 0) && (poluch[ch]!=0))
                {
                    while (unreal % poluch[ch] > 0)
                    {
                        unreal--;
                        min++;
                    }
                    otvet[i] = min;
                    kop = unreal / poluch[ch];
                    ch--;
                }
                else
                {
                    otvet[i] = unreal;
                }
            }


            //Перевод почти готового ответа в ответ с несчастливыми числами
            Array.Sort(poluchnes);
            for (var i = 0; i < otvet.Length; i++)
            {
                for (var j = 0; j < poluchnes.Length; j++)
                {
                    if (poluchnes[j] <= otvet[i])
                    {
                        otvet[i] += 1;
                    }
                }
            }


            //Вывод ответа
            for (var i = 0; i < otvet.Length; i++)
            {
                Console.Write(otvet[i] + " ");
            }
            Console.WriteLine("");
            s = sr2.ReadLine();
            s1 = s.Split(" ");
            ch = 0;
            int[] prav_otvet = new int[s1.Length];
            for (var i = 0; i < s1.Length; i++)
            {
                Console.Write(s1[i] + " ");
                prav_otvet[i] = Convert.ToInt32(s1[i]);
                if(otvet[i] == prav_otvet[i])
                {
                    ch++;
                }
            }
            if(ch == prav_otvet.Length)
            {
                Console.WriteLine("\nПрограмма прошла этот тест");
            }
            Console.ReadLine();
        }
    }
}
