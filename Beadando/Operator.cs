using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    class Operator
    {
        public int Sor;
        public int Oszlop;

        public Operator(int sor, int oszlop)
        {
            Sor = sor;
            Oszlop = oszlop;
        }

        public bool AlkalmazhatoE(Allapot allapot)
        {
            List<(int x, int y)> lehetsegesElmozdulasok = new List<(int x, int y)>()
            {
                (-1, -1), (-1, 0), (-1, 1),
                (0, -1), (0,0), (0, 1),
                (1, -1), (1, 0), (1, 1)
            };

            if (allapot.JatekTer[Sor, Oszlop] != '-')
            {
                return false;
            }

            foreach ((int x, int y) lehetsegesElmozdulas in lehetsegesElmozdulasok)
            {
                int szomszedSor = Sor + lehetsegesElmozdulas.x;
                int szomszedOszlop = Oszlop + lehetsegesElmozdulas.y;

                if (szomszedSor >= 1 && szomszedSor < 7 && szomszedOszlop >= 1 && szomszedOszlop < 8 &&
                    allapot.JatekTer[szomszedSor, szomszedOszlop] == allapot.AktJatekos)
                {
                    allapot.JatekTer[szomszedSor, szomszedOszlop] = 'x';
                    return true;
                }
            }
            return false;
        }

        public Allapot Alkalmaz(Allapot allapot)
        {
            Allapot ujAllapot = (Allapot)allapot.Clone();
            ujAllapot.JatekTer[Sor, Oszlop] = allapot.AktJatekos;
            ujAllapot.JatekosValtas();
            return ujAllapot;
        }
    }
}
