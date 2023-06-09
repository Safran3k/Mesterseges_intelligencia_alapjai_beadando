using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * A 10.  ́abrán egy olyan 6 × 8 mezőből  ́alló játéktábla látható, amelyre az egyik
             * játékosnak egy világos, a másiknak egy sötét király sakkfigurát helyeztünk.
             * A játékosok felváltva következnek lépni. egy lépésben a figurát valamelyik
             * nyolcszomszédos  ̈ures mezőre kell elmozdítani, majd pedig el kell távolítani
             * a tábla valamelyik üres mezőjét ( ́ertelemszerűen a továbbiakban nem lehet
             * eltávolított mezőre lépni). Az a játékos nyer, aki utóljára tud lépni.
             */

            Jatek jatek = new Jatek(new TrialAndError());
            jatek.Start();

            Console.ReadKey();
        }
    }
}
