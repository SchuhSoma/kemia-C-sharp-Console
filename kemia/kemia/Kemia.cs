using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kemia
{
    class Kemia
    {
        //Év;Elem;Vegyjel;Rendszám;Felfedező
        public string Ev;
        public string Elem;
        public string Vegyjel;
        public double Rendszam;
        public string Felfedezo;

        public Kemia (string sor)
        {
            var dbok = sor.Split(';');
            this.Ev = dbok[0];
            this.Elem = dbok[1];
            this.Vegyjel = dbok[2];
            this.Rendszam = double.Parse(dbok[3]);
            this.Felfedezo = dbok[4];
        }
    }
}
