using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game_of_life___nasleđivanje_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int n = 100;
        int iteracije = 10;
        DataGridView dgv;
        List<Polje> a = new List<Polje>();
        List<Polje> b = new List<Polje>();
        void postaviGrid(DataGridView dgv)
        {
            dgv.RowHeadersVisible = false;
            dgv.ColumnHeadersVisible = false;
            dgv.RowCount = n;
            dgv.ColumnCount = n;
            for (int i = 0; i < n; i++)
            {
                dgv.Rows[i].Height = 15;
            }
            for (int j = 0; j < n; j++)
            {
                dgv.Columns[j].Width = 15;
            }
            dgv.Width = n * 15 + 3;
            dgv.Height = n * 15 + 3;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    dgv[j, i].Style.BackColor = Color.White;
                }
        }
        void prepisiUGrid(List<Polje> p)      
        {
            for (int i = 0; i < a.Count; i++)
                for (int j = 0; j < a.Count; j++)
                {
                    dgv[j, i].Style.BackColor = Color.White;
                    if (p[i].Boja == 0)
                        dataGridView1[j, i].Style.BackColor = Color.White;
                    else dataGridView1[j, i].Style.BackColor = Color.Black;
                }
        }
        // prepis liste a u listu b
        void prepisi()
        {
            for (int i = 0; i < a.Count; i++)
                    b[i] = a[i];
        }
        void gol(Polje p)
        {
            for (int it = 0; it < iteracije; it++)
            {
                for (int i = 1; i < a.Count - 1; i++)
                    for (int j = 1; j < a.Count - 1; j++)
                    {
                        p.provera(a, b, n, i, j);
                    }
                prepisi();
                prepisiUGrid(a);
                for (int i = 0; i < a.Count; i++)
                    for (int j = 0; j < a.Count; j++)
                    {
                        if (it % 2 == 0)
                            p.provera(a, b, a.Count, i, j);
                        else
                            p.provera(b, a, a.Count, i, j);
                    }
                if (it % 2 == 0)
                    prepisiUGrid(b);
                else
                    prepisiUGrid(a);
            }
        }
        //radi
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
        private void Form1_Load_2(object sender, EventArgs e)
        {
            dgv = dataGridView1;
            postaviGrid(dgv);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            int j = e.ColumnIndex;
                if (dataGridView1[j, i].Style.BackColor == Color.White)
                {
                    dataGridView1[j, i].Style.BackColor = Color.Black;
                }
                else
                {
                    dataGridView1[j, i].Style.BackColor = Color.White;
                }
            
        }
        private void btStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void btStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            for (int i = 0; i < n; i++)
            {
                gol(a[i]);
            }
        }
    }
}
