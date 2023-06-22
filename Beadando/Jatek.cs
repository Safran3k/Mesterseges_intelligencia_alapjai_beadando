using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    class Jatek
    {
        private ASolver solver;

        public Jatek(ASolver solver)
        {
            this.solver = solver;
        }

        public void Start()
        {
            Allapot aktAllapot = new Allapot();
            bool jatekosKore = true;

            while (aktAllapot.AllapotLekerdezes() == '-')
            {
                Console.WriteLine(aktAllapot);
                aktAllapot = jatekosKore ? JatekosMozgas(aktAllapot) : AIMozgas(aktAllapot);
                jatekosKore = !jatekosKore;
            }
            Console.WriteLine(aktAllapot);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Győztes: " + aktAllapot.AllapotLekerdezes());
            Console.ForegroundColor = ConsoleColor.White;
        }

        private Allapot JatekosMozgas(Allapot aktAllapot)
        {
            Operator op = null;
            
            while (op == null || !op.AlkalmazhatoE(aktAllapot))
            {
                int sor = aktAllapot.JatekosPozicioja()[0];
                int oszlop = aktAllapot.JatekosPozicioja()[1];
                int ujSor = sor;
                int ujOszlop = oszlop;
                
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();
                switch (key.KeyChar)
                {
                    case '1':
                        ujSor++;
                        ujOszlop--;
                        break;
                    case '2':
                        ujSor++;
                        break;
                    case '3':
                        ujSor++;
                        ujOszlop++;
                        break;
                    case '4':
                        ujOszlop--;
                        break;
                    case '6':
                        ujOszlop++;
                        break;
                    case '7':
                        ujSor--;
                        ujOszlop--;
                        break;
                    case '8':
                        ujSor--;
                        break;
                    case '9':
                        ujSor--;
                        ujOszlop++;
                        break;
                    default:
                        Console.WriteLine("Nem definiált billentyű!");
                        break;
                }

                if (aktAllapot.JatekTerenBelul(ujSor, ujOszlop))
                {
                    op = new Operator(ujSor, ujOszlop);
                }
                else
                {
                    Console.WriteLine("Érvénytelen lépés.");
                }
            }

            return op.Alkalmaz(aktAllapot);
        }

        private Allapot AIMozgas(Allapot aktAllapot)
        {
            Allapot kovetkezoAllapot = solver.KovetkezoLepes(aktAllapot);

            if (kovetkezoAllapot == null)
            {
                throw new Exception("Következő lépés nem lehetséges");
            }

            return kovetkezoAllapot;
        }
    }
}
