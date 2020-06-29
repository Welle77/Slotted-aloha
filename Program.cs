using System;

namespace Slotted_aloha
{
    class Program
    {
        static void Main(string[] args)
        {
            const int stations = 100;
            const double lambda = 0.0005;
            const int slots = 100000;

            Random random = new Random();

            int[] array = new int[slots];

            for (double k = lambda; k <= 0.03; k += lambda)
            {

                for (int i = 0; i < slots; i++)
                {
                    for (int j = 0; j < stations; j++)
                    {
                        if (random.NextDouble() <= lambda)
                        {
                            array[i] += 1;
                        }
                    }
                }

                int succes = 0;
                int collisions = 0;
                int silent = 0;

                Array.ForEach(array, num =>
                {
                    if (num == 0)
                        silent++;
                    else if (num == 1)
                        succes++;
                    else
                        collisions++;
                });

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("Data birth rate: " + k.ToString("0.0000"));
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\t" + "Throughput: "
                    + ((double)(succes) / 100000 * 100).ToString("0.000") + "%");
            }
        }
    }
}
