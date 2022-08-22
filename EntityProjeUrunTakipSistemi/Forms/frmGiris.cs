using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EntityProjeUrunTakipSistemi
{
    
    public partial class frmGiris : Form
    {
        
        public frmGiris()
        {
            InitializeComponent();
        }
        DBEntityUrunEntities db = new DBEntityUrunEntities();
        private void btnGiris_Click(object sender, EventArgs e)
        {
            var sorgu = from x in db.tblAdmin where x.adminAdSoyad == txtAdminAd.Text && x.adminSifre == txtAdminSifre.Text select x;
            if (sorgu.Any())//eger sorgu değişkeninden herhangi bir sonuç dönerse(true) yapılacaklar. 
            {
                AnaForm frm = new AnaForm();
                frm.Show();
                this.Hide();
            }
            else //(false)
            {
                MessageBox.Show("Kullanıcı adı yada şifre hatalı...");
            }

        }
    }
}
