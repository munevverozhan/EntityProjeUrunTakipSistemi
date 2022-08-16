using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityProjeUrunTakipSistemi.Forms;

namespace EntityProjeUrunTakipSistemi
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmKategori frm = new frmKategori();
            frm.Show();
            this.Hide();
        }
   
        private void button2_Click(object sender, EventArgs e)
        {
            frmUrun urun = new frmUrun();
            urun.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmIstatistik frm = new frmIstatistik();
            frm.Show();
            this.Hide();
        }
    }
}
