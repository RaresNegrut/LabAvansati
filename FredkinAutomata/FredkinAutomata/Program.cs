using System;
using System.IO;
using System.Text;

namespace FredkinAutomata
{

    class Program
    {
        static char[,] matrix;
        static char[,] secondary;
        static char full_block = '\u2588';
        static char light_shade = '\u2591';
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            int n = 15;
            int m = 15;
            matrix = new char[n, m];
            secondary = new char[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    secondary[i, j] = light_shade;
            }

            using (var input = new StreamReader(@"..\..\Input.txt"))
            {
                for (int i = 0; i < n; i++)
                {
                    string line = input.ReadLine();
                    string[] split = line.Split(new Char[] { ' ' });
                    for (int j = 0; j < m; j++)
                    {
                        matrix[i, j] = Char.Parse(split[j]);
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            bool ok;
            do
            {
                ok = true;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {

                        int nr = 0;


                        if (i - 1 >= 0 && matrix[i - 1, j] == full_block)
                            nr++;

                        if (j + 1 < m && matrix[i, j + 1] == full_block)
                            nr++;
                        if (j - 1 >= 0 && matrix[i, j - 1] == full_block)
                            nr++;

                        if (i + 1 < n && matrix[i + 1, j] == full_block)
                            nr++;

                        if (nr % 2 == 0)
                            secondary[i, j] = light_shade;
                        else
                        {
                            secondary[i, j] = full_block;
                            ok = false;
                        }
                    }

                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        matrix[i, j] = secondary[i, j];
                        Console.Write($"{matrix[i, j]} ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            } while (ok != true);
            Console.ReadKey();
        }

    }
}
