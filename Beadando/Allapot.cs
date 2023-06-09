using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    class Allapot : ICloneable
    {
        public char[,] JatekTer = new char[8, 9]
        {
            { '#', '#', '#', '#', '#', '#', '#', '#', '#'},
            { '#', '-', '-', '-', '-', '-', '-', '-', '#'},
            { '#', '-', '-', '-', '-', '-', '-', '-', '#'},
            { '#', 'J', '-', '-', '-', '-', '-', '-', '#'},
            { '#', '-', '-', '-', '-', '-', '-', 'G', '#'},
            { '#', '-', '-', '-', '-', '-', '-', '-', '#'},
            { '#', '-', '-', '-', '-', '-', '-', '-', '#'},
            { '#', '#', '#', '#', '#', '#', '#', '#', '#'}
        };

        public char AktJatekos = 'J';
        public char ToroltMezo = 'x';

        public void JatekosValtas()
        {
            if (AktJatekos == 'J')
            {
                AktJatekos = 'G';
            }
            else
            {
                AktJatekos = 'J';
            }
        }

        public bool JatekTerenBelul(int sor, int oszlop)
        {
            return sor >= 1 && sor < 7 && oszlop >= 1 && oszlop < 8;
        }

        public char AllapotLekerdezes()
        {
            List<(int x, int y)> lehetsegesElmozdulasok = new List<(int x, int y)>()
            {
                (-1, -1), (-1, 0), (-1, 1),
                (0, -1), (0,0), (0, 1),
                (1, -1), (1, 0), (1, 1)
            };

            for (int sor = 1; sor < 7; sor++)
            {
                for (int oszlop = 1; oszlop < 8; oszlop++)
                {
                    if (JatekTer[sor, oszlop] == 'J' || JatekTer[sor, oszlop] == 'G')
                    {
                        bool mozoghat = lehetsegesElmozdulasok.Any(lehetsegesElmozdulas =>
                        {
                            int szomszedSor = sor + lehetsegesElmozdulas.x;
                            int szomszedOszlop = oszlop + lehetsegesElmozdulas.y;

                            return JatekTerenBelul(szomszedSor, szomszedOszlop) &&
                                   JatekTer[szomszedSor, szomszedOszlop] == '-';
                        });

                        if (mozoghat)
                        {
                            continue;
                        }
                        else
                        {
                            return JatekTer[sor, oszlop] == 'J' ? 'G' : 'J';
                        }
                    }
                }
            }

            return '-';
        }

        public int[] JatekosPozicioja()
        {
            int[] koordinata = new int[2];

            for (int sor = 1; sor < 7; sor++)
            {
                for (int oszlop = 1; oszlop < 8; oszlop++)
                {
                    if (JatekTer[sor, oszlop] == 'J')
                    {
                        koordinata[0] = sor;
                        koordinata[1] = oszlop;
                        return koordinata;
                    }
                }
            }

            koordinata[0] = -1;
            koordinata[1] = -1;

            return koordinata;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;

            #region Mozgási irányok kiírása
            sb.AppendLine("Üdv a játékban!");
            sb.AppendLine();
            sb.AppendLine("Mozgás:");
            sb.AppendLine("\t↑ (Num 8)  ↖ (Num 7)");
            sb.AppendLine("\t↓ (Num 2)  ↙ (Num 1)");
            sb.AppendLine("\t← (Num 4)  ↗ (Num 9)");
            sb.AppendLine("\t→ (Num 6)  ↘ (Num 3)");
            sb.AppendLine();
            sb.AppendLine("Ha az ellenfél (G) nem tud már lépni, GYŐZTÉL.");
            sb.AppendLine();
            #endregion

            for (int sor = 0; sor < 8; sor++)
            {
                for (int oszlop = 0; oszlop < 9; oszlop++)
                {
                    sb.Append(JatekTer[sor, oszlop] + "  ");
                }
                sb.AppendLine();
            }

            sb.AppendLine();
            sb.AppendLine("Aktuális játékos: " + AktJatekos);

            return sb.ToString();
        }

        public object Clone()
        {
            Allapot ujAllapot = new Allapot();
            ujAllapot.JatekTer = (char[,])JatekTer.Clone();
            ujAllapot.AktJatekos = AktJatekos;
            return ujAllapot;
        }

        public override bool Equals(object obj)
        {
            Allapot masik = obj as Allapot;

            if (masik.AktJatekos != AktJatekos)
            {
                return false;
            }

            for (int sor = 1; sor < 7; sor++)
            {
                for (int oszlop = 1; oszlop < 8; oszlop++)
                {
                    if (masik.JatekTer[sor, oszlop] != JatekTer[sor, oszlop])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
