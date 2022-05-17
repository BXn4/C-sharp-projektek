using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListabolfeltoltesGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int penzcsekkolas = 0;
        private void megnevezes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ar.SelectedIndex = megnevezes.SelectedIndex;
        }

        private void ar_SelectedIndexChanged(object sender, EventArgs e)
        {
            megnevezes.SelectedIndex = ar.SelectedIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int penz = Convert.ToInt32(egyenleg.Text);
            int ertek = 0;
            int kivalasztva = 0;
            if (penz <= 0)
            {
                MessageBox.Show("Nincs elég pénzed!");
            }
            else
            {
                try
                {
                    kivalasztva = megnevezes.SelectedIndex;
                    ertek = Convert.ToInt32(ar.Items[kivalasztva]);
                    penzcsekkolas = penz - (ertek * Convert.ToInt32(hanyDB.Value));
                    if (penzcsekkolas > -1)
                    {
                        egyenleg.Text = $"{penz - (ertek * Convert.ToInt32(hanyDB.Value))}";
                        eladasnev.Items.Add(Convert.ToString(megnevezes.Items[kivalasztva]));
                        eladasar.Items.Add(Convert.ToInt32(ar.Items[kivalasztva]));
                        mennyiseg.Items.Add(hanyDB.Value);
                    }
                    else
                    {
                        MessageBox.Show("Nincs elég pénzed!");
                    }
               }
               catch
                {

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int kivalasztva = 0;
            int ertek = 0;
            try
            {
                kivalasztva = eladasnev.SelectedIndex;
                ertek = Convert.ToInt32(eladasar.Items[kivalasztva]);
                int penz = Convert.ToInt32(egyenleg.Text);
                egyenleg.Text = $"{penz + (ertek * Convert.ToInt32(mennyiseg.Items[kivalasztva]))}";
                eladasnev.Items.RemoveAt(kivalasztva);
                eladasar.Items.RemoveAt(kivalasztva);
                mennyiseg.Items.RemoveAt(kivalasztva); 
            }
            catch
            {
                eladasnev.SelectedIndex = eladasnev.Items.Count - 1;
            }
        }

        private void eladasnev_SelectedIndexChanged(object sender, EventArgs e)
        {
            eladasar.SelectedIndex = eladasnev.SelectedIndex;
            mennyiseg.SelectedIndex = eladasnev.SelectedIndex;
        }

        private void eladasar_SelectedIndexChanged(object sender, EventArgs e)
        {
            eladasnev.SelectedIndex = eladasar.SelectedIndex;
            mennyiseg.SelectedIndex = eladasar.SelectedIndex;
        }

        private void mennyiseg_SelectedIndexChanged(object sender, EventArgs e)
        {
            eladasnev.SelectedIndex = mennyiseg.SelectedIndex;
            eladasar.SelectedIndex = mennyiseg.SelectedIndex;
        }
    }
}
