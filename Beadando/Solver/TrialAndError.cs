using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    class TrialAndError : ASolver
    {
        private Random rnd = new Random();

        private Operator OperatorKivalasztas(Allapot aktAllapot)
        {
            List<Operator> alkalmazhatoOperatorok = Operatorok.Where(op => op.AlkalmazhatoE(aktAllapot)).ToList();

            if (alkalmazhatoOperatorok.Count == 0)
            {
                return null;
            }

            int randomIndex = rnd.Next(0, alkalmazhatoOperatorok.Count);
            return alkalmazhatoOperatorok[randomIndex];
        }

        public override Allapot KovetkezoLepes(Allapot aktAllapot)
        {
            Operator op = OperatorKivalasztas(aktAllapot);

            if (op == null)
            {
                return null;
            }
            return op.Alkalmaz(aktAllapot);
        }
    }
}
