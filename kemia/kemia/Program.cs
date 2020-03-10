using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace kemia
{
    class Program
    {
        static List<Kemia> KemiaList;
        static List<int> Evek;
        static List<int> Kulonbseg;
        static Dictionary<int, int> Statisztika;
        static void Main(string[] args)
        {
            Console.WriteLine("\n-------------------------\n");
            Feladat2Beolvasas();
            Console.WriteLine("\n-------------------------\n");
            Feladat3ElemekSzama();
            Console.WriteLine("\n-------------------------\n");
            Feladat4OkoriFelfedezesekSzama();
            Console.WriteLine("\n-------------------------\n");
            Feladat5VegyjelBekeres();
            Console.WriteLine("\n-------------------------\n");
            Feladat7IdoKulonbseg();
            Console.WriteLine("\n-------------------------\n");
            Feladat8Statisztika();
            Console.WriteLine("\n-------------------------\n");
            Console.ReadKey();
        }

        private static void Feladat8Statisztika()
        {
            Console.WriteLine("\n8.Feladat: Statisztika hány elemet találtak egy adott évben");
            
            string ev = " ";
            Statisztika = new Dictionary<int, int>();
            foreach (var e in Evek)
            {
                int db = 0;
                ev = e.ToString();
                foreach (var k in KemiaList)
                {
                    if(ev == k.Ev )
                    {
                        db++;
                    }
                   
                }
                //Console.WriteLine("\t{0} : {1} db", e, db);
                Statisztika.Add(e, db);                
            }
            foreach (var s in Statisztika)
            {
                Console.WriteLine("\t{0} : {1} db", s.Key, s.Value);
            }
        }

        private static void Feladat7IdoKulonbseg()
        {
            Console.WriteLine("\n7.Feladat: Leghosszabb időszak két elem felfedezése között");
            Evek = new List<int>();
            foreach (var k in KemiaList)
            {
                if(k.Ev!="Ókor")
                {
                    if(!Evek.Contains(int.Parse(k.Ev)))
                    {
                        Evek.Add(int.Parse(k.Ev));
                    }
                }
            }
            foreach (var e in Evek)
            {
               // Console.WriteLine("\t{0}",e);
            }
            Kulonbseg = new List<int>();
            int differencial = 0;
            for (int i = 1; i < Evek.Count; i++)
            {
                differencial = Evek[i] - Evek[i - 1];
                if (!Kulonbseg.Contains(differencial))
                {
                    Kulonbseg.Add(differencial);
                }

            }
            int Max = int.MinValue;
            foreach (var k in Kulonbseg)
            {
                if(Max<k)
                {
                    Max = k;
                }
            }
            Console.WriteLine("\tMaximálisan eltelt idő  két kémiaia elem felfedezése között: {0} év", Max);
           
        }

        private static void Feladat5VegyjelBekeres()
        {
            Console.WriteLine("\n5.Feladat:Vegyjel bekérése");
            bool ok=false;
            string KeresettVegyjel;
            string Betukeszlet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int db = 0;
            do
            {
                Console.Write("\tKérem adjon meg egy vegyjelet az angol abc betüivel: ");
                KeresettVegyjel = Console.ReadLine();
                KeresettVegyjel = KeresettVegyjel.ToUpper();
                if (KeresettVegyjel.Length == 1 || KeresettVegyjel.Length == 2)
                {
                    for (int i = 0; i < KeresettVegyjel.Length; i++)
                    {
                        if(Betukeszlet.Contains(KeresettVegyjel[i]))
                        {
                            db++;
                        }
                        if (db == KeresettVegyjel.Length) ok = true;
                    }

                   
                }
            }
            while (!ok);

             int szamlalo = 0;
             while (szamlalo < KemiaList.Count && KeresettVegyjel.ToUpper() != KemiaList[szamlalo].Vegyjel.ToUpper())
             {
                 szamlalo++;
             }
             if (szamlalo == KemiaList.Count)
             {
                 Console.WriteLine("\n6.Feladat:Nincs ilyen elem a listában");
             }
             else
             {
                 Console.WriteLine("\n6.FeladatKeresés \n\tAz elem vegyjele: {0}\n\tAz elem neve: {1} \n\tRendszáma: {2}\n\tFelfedezés éve: {3}\n\tFelfedező: {4}", KemiaList[szamlalo].Vegyjel, KemiaList[szamlalo].Elem, KemiaList[szamlalo].Rendszam, KemiaList[szamlalo].Ev, KemiaList[szamlalo].Felfedezo);
             }
           
           

        }

        private static void Feladat4OkoriFelfedezesekSzama()
        {
            Console.WriteLine("\n4.Feladat: Ókori felfedezések száma");
            int db = 0;
            foreach (var k in KemiaList)
            {
                if(k.Ev=="Ókor")
                {
                    db++;
                }
            }
            Console.WriteLine("\tÓkori felfedezések száma: {0}",db);
        }

        private static void Feladat3ElemekSzama()
        {
            Console.WriteLine("\n3.Feladat: Elemek száma");
            Console.WriteLine("\tBeolvasott elemek száma: {0}", KemiaList.Count);
        }

        private static void Feladat2Beolvasas()
        {
            Console.WriteLine("2.Feladat:Adatok beolvasása");
            int db = 0;
            KemiaList = new List<Kemia>();
            var sr = new StreamReader(@"felfedezesek.csv", Encoding.UTF8);
            while(!sr.EndOfStream)
            {
                KemiaList.Add(new Kemia(sr.ReadLine()));
                db++;
            }
            sr.Close();
            if(db>0)
            {
                Console.WriteLine("\tSikeres beolvasás, beolvasostt adatok száma: {0}", db);
            }
            else
            {
                Console.WriteLine("\tSikertelen beolvasás");
            }
        }
    }
}
