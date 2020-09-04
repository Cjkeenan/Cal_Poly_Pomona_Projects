using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinKeenanECE256Midterm
{
    class Problem_2
    {
        public void Run()
        {
            double[] results = new double[20];
            int games = 1000;
            Craps Game = new Craps();
            int[] gameLengths = new int[games];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < games; j++)
                {
                    results[i] += Game.Run();
                }
                results[i+1] = 1000 - results[i];
            }

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("S{3}: In {0} games, the player won {1} times resulting in a probability of winning at {2:F2}%.", games, results[i], (results[i] / (results[i] + results[i+1]) * 100), i);
                Console.WriteLine("In {0} games, the player lost {1} times resulting in a probability of losing at {2:F2}%.\n", games, results[i + 1], (results[i + 1] / (results[i] + results[i + 1]) * 100));
            }

            double[] results10k = new double[2];
            for (int i = 0; i < 10000; i++)
            {
                results10k[0] += Game.Run();
            }
            results[2] = 10000 - results[1];

            Console.WriteLine("In {0} games, the player won {1} times resulting in a probability of winning at {2}%.", 10000, results10k[0], (results10k[0] / (results10k[0] + results10k[1]) * 100));
            Console.WriteLine("In {0} games, the player lost {1} times resulting in a probability of losing at {2}%.", 10000, results10k[1], (results10k[1] / (results10k[0] + results10k[1]) * 100));

        }
    }
}
