using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCon
{
    class Program
    {
        static void Main(string[] args)
        {
            var termekek = new List<string>
            {
                "Alma","Eper","Görögdinnye","Uborka","Saláta","Répa","Tök","Meggy","Hagyma","Paradicsom"
            };
            var termekekara = new List<int>
            {
                100,150,200,300,350,370,400,420,440,500
            };
            var cuccok = new List<string>
            {
                "Alma","Eper"
            };
            var mennyiseg = new List<int>
            {
                10,20
            };
            int egyenleg = 8000;
            int egyenlegcheck = 0;
            Console.Title = $"Egyenleged: {egyenleg} Ft";
            Console.WriteLine("Termékek kilistázása: termekek\nSaját cuccok: cuccok\nVétel: vesz {termeknev} {db}\nEladás: elad {termeknev} {db}\nÚj termék hozzáadása: hozzaad {termeknev} {ar}\nEgyenleg: egyenleg");
            bevitel:
            Console.Write("\n>>: ");
            string parancs = Console.ReadLine();
            if(parancs == "termekek")
            {
                for (int i = 0; i < termekek.Count; i++)
                {
                    Console.WriteLine($"\t{termekek[i]}, ár: {termekekara[i]} Ft/db");
                }
            }
            if(parancs == "cuccok")
            {
                for (int i = 0; i < cuccok.Count; i++)
                {
                    Console.WriteLine($"\t{cuccok[i]}, {mennyiseg[i]}db");
                }
            }
            try
            {
                //string termekneve = parancs;
                //int veteldb = Convert.ToInt32(parancs);
                string[] tomb = parancs.Split(' ');
                string bevitel = tomb[0];
                string termekneve = tomb[1];
                int db = Convert.ToInt32(tomb[2]);
                if (bevitel == "vesz")
                {
                    for (int i = 0; i < termekek.Count; i++)
                    {
                        if (termekneve == termekek[i])
                        {
                            egyenlegcheck = egyenleg - (termekekara[i] * db);
                            if (egyenlegcheck > -1)
                            {
                                egyenleg = egyenleg - (termekekara[i] * db);
                                Console.WriteLine($"Sikeresen vettél {db}db {termekneve}-t!");
                                Console.Title = $"Egyenleged: {egyenleg} Ft";
                                if (!cuccok.Contains(termekneve))
                                {
                                    cuccok.Add($"{termekneve}");
                                    mennyiseg.Add(db);
                                }
                                else
                                {
                                    mennyiseg[i] += db;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Nincs elég pénzed!");
                            }
                        }
                    }
                }
                //javitas hamarosan (nincs kesz teljesen)
                if (bevitel == "elad")
                {
                    for (int i = 0; i < cuccok.Count; i++)
                    {
                        if (termekneve == cuccok[i])
                        {
                            if (db <= mennyiseg[i])
                            {
                                mennyiseg.Remove(mennyiseg[i]);
                            }
                            if(mennyiseg[i] == 0)
                            {
                                cuccok.Remove($"{cuccok[i]}");
                            }
                        }
                    }
                }
                if(bevitel == "hozzaad")
                {
                    termekek.Add(termekneve);
                    termekekara.Add(db);
                    Console.WriteLine($"Sikeresen bővítetted a listát a(z) {termekneve} termékkel.\nÁra: {db}Ft/db ");
                }
            }
            catch
            {

            }
            goto bevitel;
        }
    }
}
