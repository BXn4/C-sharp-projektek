using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//NEM JÓ MÉG!!!

namespace Fuggvenyabrazolas
{
    class Program
    {
        static void Main(string[] args)
        {
            eleje:
            Console.Write("Kérem a maximális magasságot: ");
            string maxmagassag = Console.ReadLine();
            int y = Convert.ToInt32(maxmagassag);
            Console.Write("Kérem a maximális távolságot: ");
            string maxtavolsag = Console.ReadLine();
            int x = Convert.ToInt32(maxtavolsag);
            Console.Clear();
            var xcord = new List<string> { " " };
            if(y == 0 || x == 0)
            {
                //Console.Clear();
                goto eleje;
            }
            for (int i = 0; i < y; i++)
            {
                for (int e = 0; e < x * 2; e++)
                {
                    Console.Write(" ");
                }
                if(i == 0)
                {
                    Console.Write("↑");
                    Console.Write($"{y}");
                }
                if(i == y / 2)
                {
                    /* for (int ik = 0; ik < x * 2; ik++)
                     {
                         xcord.Add("_");
                     }
                     xcord.Add("┴");
                     for (int ik = 0; ik < x * 2; ik++)
                     {
                         xcord.Add("_");
                     }
                     Console.WriteLine(" ");
                     for (int iaa = 0; iaa < x * 2; iaa++)
                     {
                         Console.Write($"{xcord[iaa]}");
                     }*/
                    Console.Write("┴");
                }
                if (i == y - 1)
                {
                    Console.Write($"-{y}");
                    Console.Write("↓");
                }
                Console.WriteLine("│");
                if(i == y - 1)
                {
                    for (int e = 0; e < x; e++)
                    {
                        Console.Write(" ");
                    }
                }
                
            }
            for (int i = 0; i < x; i++)
            {
                for (int e = 0; e < 1; e++)
                {

                }
            }
            Console.ReadKey();
        }
    }
}

