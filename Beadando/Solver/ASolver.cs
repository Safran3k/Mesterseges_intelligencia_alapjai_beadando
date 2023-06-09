using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    abstract class ASolver
    {
        public List<Operator> Operatorok = new List<Operator>();

        public ASolver()
        {
            OperatorGeneralas();
        }

        private void OperatorGeneralas()
        {
            for (int i = 1; i < 7; i++)
            {
                for (int j = 1; j < 8; j++)
                {
                    Operatorok.Add(new Operator(i, j));
                }
            }
        }

        public abstract Allapot KovetkezoLepes(Allapot aktAllapot);
    }
}
