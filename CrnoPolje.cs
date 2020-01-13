using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_of_life___nasleđivanje_2
{
    public class CrnoPolje : Polje
    {
        int boja;
        public CrnoPolje(int b, int x, int y) : base(x, y)
        {
            boja = b;
        }
        public override int Boja
        {
            get { return 1; }
            set { boja = value; }
        }
        public override void provera(List<Polje> a, List<Polje> b, int n, int i, int j)
        {
            int br = brojSuseda(a, n, n, i, j);
            if (br == 0 || br == 1 || br >= 4)
                boja = 0;
            if (br == 2 || br == 3)
                boja = 1;
        }
    }
}
