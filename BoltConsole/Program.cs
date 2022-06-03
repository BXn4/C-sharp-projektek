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
                "Alma","Eper","Görögdinnye","Uborka","Saláta","Répa","Tök","Meggy","Hagyma","Paradicsom"
            };
            var mennyiseg = new List<int>
            {
                10,20,2,1,4,5,1,10,2,2
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
            if (parancs == "egyenleg")
            {
                Console.WriteLine($"Egyenleged: {egyenleg} Ft");
            }
            if (parancs == "cuccok")
            {
                for (int i = 0; i < cuccok.Count; i++)
                {
                    Console.WriteLine($"\t{cuccok[i]}, {mennyiseg[i]}db");
                }
            }
            try
            {

                //Ez így fog maradni, nem szeretnék már vele foglalkozni

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
                               /* Dictionary<string, int> szotar = new Dictionary<string, int>();
                                if(szotar.ContainsKey(termekneve))
                                {
                                    szotar[termekneve]++;
                                }*/
                                if (!cuccok.Contains(termekneve))
                                {
                                    cuccok.Add($"{termekneve}");
                                    mennyiseg.Add(db);
                                }
                                else
                                {
                                    try
                                    {
                                        mennyiseg[i] += db;
                                    }
                                    catch
                                    {
                                        cuccok.Add($"{termekneve}");
                                        mennyiseg.Add(db);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Nincs elég pénzed!");
                            }
                        }
                    }
                }
                if (bevitel == "elad")
                {
                    for (int i = 0; i < cuccok.Count; i++)
                    {
                        if(termekneve == cuccok[i])
                        {
                            if(db > mennyiseg[i])
                            {
                                Console.WriteLine($"Neked csak {mennyiseg[i]} {termekneve}-d van!");
                            }
                            else
                            {
                                mennyiseg[i] -= db;
                                Console.WriteLine($"Sikeresen eladtál {db}db {termekneve}-t!");
                                egyenleg += termekekara[i] * db;
                                Console.Title = $"Egyenleged: {egyenleg} Ft";
                            }
                            if(mennyiseg[i] == 0)
                            {
                                cuccok.Remove($"{cuccok[i]}");
                                mennyiseg.Remove(mennyiseg[i]);
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
