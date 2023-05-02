using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication17
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число дуг");
            int m = Convert.ToInt32(Console.ReadLine());
            int[] v1 = new int[m];
            int[] v2 = new int[m];
            int[] len = new int[m];
            Console.WriteLine("Введите число вершин");
            int n = Convert.ToInt32(Console.ReadLine());
            int min = 99999;
            int otvet = 0;
            int v_1 = 0;
            int v_2 = 0;
            for (var i = 0; i < m; i++)
            {
                Console.WriteLine("Введите первую вершину");
                v1[i] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите вторую вершину");
                v2[i] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите вес ребра");
                len[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Введите исток");
            int istok = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите сток");
            int stok = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            List<List<int>> puti = new List<List<int>>();
            List<List<int>> lenputi = new List<List<int>>();
            List<int> pusto =  new List<int>();
            puti.Add(pusto);
            puti[0].Add(istok);
            for (var i = 0; i < n - 1; i++)
            {
                for (var j = 0; j < puti.Count; j++)
                {
                    if (puti[j].Count == i + 1)
                    {
                        for (var k = 0; k < m; k++)
                        {
                            if ((v1[k] == puti[j][puti[j].Count - 1]) && (puti[j].Contains(v2[k]) == false))
                            {
                                List<int> newput = new List<int>();
                                for (var l = 0; l < puti[j].Count; l++)
                                {
                                    newput.Add(puti[j][l]);
                                }
                                newput.Add(v2[k]);
                                puti.Add(newput);
                            }
                        }
                    }
                }
            }
            for (var i = 0; i < puti.Count; i++)
            {
                if (puti[i][puti[i].Count - 1] != stok)
                {
                    puti.Remove(puti[i]);
                    i--;
                }
            }
            for (var i = 0; i < puti.Count; i++)
            {
                for (var j = 0; j < puti[i].Count; j++)
                {
                    Console.Write(puti[i][j] + " ");
                }
                Console.WriteLine();
            }
            int p = 0;
            for (var i = 0; i < puti.Count; i++)
            {
                for(var j=0; j<puti[i].Count-1; j++)
                {
                    for (var k = 0; k < m; k++)
                    {
                        if ((v1[k] == puti[i][j]) && (v2[k] == puti[i][j + 1]))
                        {
                            if (len[k] == 0) p = 1;
                            if (len[k] < min) min = len[k];
                        }
                    }

                }
                for (var j = 0; j < puti[i].Count - 1; j++)
                {
                    for (var k = 0; k < m; k++)
                    {
                        if (p == 1) break;
                        if ((v1[k] == puti[i][j]) && (v2[k] == puti[i][j + 1]))
                        {
                            len[k] = len[k] - min;
                        }
                    }

                }
                p = 0;
                otvet += min;
                min = 99999;
            }
            Console.WriteLine(otvet);
            Console.ReadLine();
        }
    }
}
