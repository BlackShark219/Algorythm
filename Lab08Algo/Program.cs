using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritm_8
{
    class Program
    {
        const int n = 7;
        static int infinity = 100000;
        static int[,] ves = new int[n, n];

        static int[] x = new int[n];
        static int[] dlina = new int[n];
        static int[] predvertex = new int[n];
        static int v;

        static void ReadArr()
        {
            string[] s;

            for (int i = 0; i < 7; i++)
            {
                s = Console.ReadLine().Split(' ');
                for (int j = 0; j < 7; j++)
                {
                    ves[i, j] = int.Parse(s[j]);
                }
            }

        }

        static void Main()
        {
            Console.WriteLine("Введіть матрицю ваги графа:");
            ReadArr();
            int start;
            int end;
            do
            {
                Console.WriteLine("Введіть початкову вершину:");
                start = int.Parse(Console.ReadLine());
            } while (start < 0 || start > 8);
            for (int i = 0; i < n; i++)
            {
                end = i;
                if (end == start)
                    continue;
                else
                {
                    int u;                                // Калькулятор вершин
                    for (u = 0; u < n; u++)
                    {
                        dlina[u] = infinity;
                        //Спочатку всі найкоротші шляхи з s в і == 00  
                        x[u] = 0;                            //і нема найкоротшого шляху ні для одной вершини
                    }
                    predvertex[start] = 0;                     // s - початок шляху, тому для вершини нема попередніх значень
                    dlina[start] = 0;                      // найкоротший шлях з s в s = 0
                    x[start] = 1;                              // Для вершини s знайден найкоротший шлях
                    v = start;                                 // робимо  s поточною вершиною

                    while (true)
                    {
                        // Перебираємо всі вершини, суміжні з V, і шукаємо для них найкоротший шлях
                        for (u = 0; u < n; u++)
                        {
                            if (ves[v, u] == 0) continue;      // Вершини u і v несуміжні
                            if (x[u] == 0 && dlina[u] > dlina[v] + ves[v, u]) //якщо для вершины 'u' не знайдено найкороший шлях 
                                                                              // і новий шлях в 'u' коротший за старий то
                            {
                                dlina[u] = dlina[v] + ves[v, u];            //записуємо більш коротку довжину шляху в
                                                                            //массив t[и]
                                predvertex[u] = v;                     //запасуємо, що v->u частина найкоротшого шляху з s->u
                            }
                        }// Шукаємо з всіх довжин самий короткий
                        int w = infinity;                   // Для пошуку самого короткого шляху
                        v = -1;                             // В кінці пошуку v - вершина, в яку буде 
                                                            // знайдено новий найкоротший шлях. Вона стане поточною вершиною 
                        for (u = 0; u < n; u++)                  // Перебираємо всі вершини.
                        {
                            if (x[u] == 0 && dlina[u] < w)           // якщо для вершини не знайдено найкоротший шлях і якщо довжина шляху в вершину "u"  меньше
                                                                     // уже знайденої, то
                            {
                                v = u;                         // поточною вершиною стає 'u'-я вершина
                                w = dlina[u];
                            }
                        }
                        if (v == -1)
                        {
                            Console.WriteLine($"Нема шляху до вершини {start + 1}  в вершину {end + 1} ");

                            break;
                        }
                        if (v == end)                            // Найдено найкоротший шлях і виведемо його
                        {

                            Console.WriteLine($"Найкоротший шлях з вершини {start + 1} в вершину {end + 1} :");

                            u = end;
                            string input = "";
                            while (u != start)
                            {

                                input += u + 1 + " ";
                                // Console.Write( $"  {u+1}  ");

                                u = predvertex[u];
                            }
                            input += start + 1 + " ";

                            string output = new string(input.Reverse().ToArray());

                            Console.WriteLine($"  {output} . Довжина шляху - {dlina[end]}");


                            break;
                        }
                        x[v] = 1;

                    }
                }
            }
            Console.ReadKey();
        }

    }
}

/*
 * Variant 9
0 2 7 0 6 0 0
0 0 6 3 0 0 0
0 0 0 0 0 11 0
0 0 0 0 0 0 4
0 0 0 0 0 0 3
0 0 0 0 0 0 1
0 0 0 0 0 0 0
 */
