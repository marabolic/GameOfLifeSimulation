using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_of_life___nasleđivanje_2
{
    abstract public class Polje
    {
        int x;
        int y;
        public Polje(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int X
        {
            get { return x; }
            set { x  = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        abstract public int Boja
        {
            get;
            set;
        }
        public bool moze(int n, int m, int i, int j)
        {
            if (i >= 0 && i < n && j >= 0 && j < m)
                return true;
            return false;
        }
        public int brojSuseda(List<Polje> a, int n, int m, int i, int j)
        {
            int br = 0;
            if (moze(n, m, i - 1, j - 1) && a[i- 1].X == 1 && a[j - 1 ].Y == 1) br++;
            if (moze(n, m, i + 1, j - 1) && a[i + 1].X == 1 && a[j - 1].Y == 1) br++;
            if (moze(n, m, i - 1, j + 1) && a[i - 1].X == 1 && a[j + 1].Y == 1) br++;
            if (moze(n, m, i + 1, j + 1) && a[i + 1].X == 1 && a[j + 1].Y == 1) br++;
            if (moze(n, m, i, j + 1) && a[i].X == 1 && a[j + 1].Y == 1) br++;
            if (moze(n, m, i, j - 1) && a[i].X == 1 && a[j - 1].Y == 1) br++;
            if (moze(n, m, i - 1, j) && a[i - 1].X == 1 && a[j].Y == 1) br++;
            if (moze(n, m, i + 1, j) && a[i + 1].X == 1 && a[j].Y == 1) br++;
            return br;
        }
        public abstract void provera(List<Polje> a, List<Polje> b, int n, int i, int j);
    }
}
