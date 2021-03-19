using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopireIceberg
{
    class Program
    {
        static int[,] matrix;
        static int[,] secondary;
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            int n = 10;
            int m = 10;
            matrix = new int[n, m];
            secondary = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = rnd.Next(2);
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            bool ok;
            do
            {
                ok = true;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i, j] == 1)
                        {
                            int[] nr = new int[] { 0, 0 };

                            if (i - 1 >= 0 && j - 1 >= 0)
                                nr[matrix[i - 1, j - 1]]++;
                            if (i - 1 >= 0) nr[matrix[i - 1, j]]++;
                            if (i - 1 >= 0 && j + 1 < m)
                                nr[matrix[i - 1, j + 1]]++;
                            if (j + 1 < m)
                                nr[matrix[i, j + 1]]++;
                            if (j - 1 >= 0)
                                nr[matrix[i, j - 1]]++;
                            if (i + 1 < n && j - 1 >= 0)
                                nr[matrix[i + 1, j - 1]]++;
                            if (i + 1 < n)
                                nr[matrix[i + 1, j]]++;
                            if (i + 1 < n && j + 1 < m)
                                nr[matrix[i + 1, j + 1]]++;

                            if (nr[0] >= nr[1])
                                secondary[i, j] = 0;
                            else
                            {
                                secondary[i, j] = 1;
                                ok = false;
                            }
                        }

                    }

                }
                for(int i=0;i<n;i++)
                {
                    for(int j=0;j<m;j++)
                    {
                        matrix[i, j] = secondary[i, j];
                        Console.Write($"{matrix[i,j]} ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();

            } while (ok!=true);

        }
    }
}
