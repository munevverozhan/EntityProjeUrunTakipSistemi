using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProjeUrunTakipSistemi
{
    public partial class frmUrun : Form
    {
        DBEntityUrunEntities db = new DBEntityUrunEntities();

        public frmUrun()
        {
            InitializeComponent();
        }
        private void frmUrun_Load(object sender, EventArgs e)
        {
            //COMBOBOX İÇİNE VERİ ÇEKME İŞLEMİ
            // bu yapı for-each döngüsü yapısına benziyor
            
            var kategoriler = (from x in db.tblKategoris //x isimli bir değişken oluşturuldu.Bu değişken değerlerini tblKategoris tablosundan alacak.
                               select new // tablodan alınacak alanlar
                               {
                                   x.categoryID,
                                   x.categoryAd
                               }
                               ).ToList(); // alınan alanları listeler.
            cmbKategori.ValueMember = "categoryID";
            cmbKategori.DisplayMember = "categoryAd";
            cmbKategori.DataSource = kategoriler;
                                
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.tblUrunlers
                                        select new
                                        {
                                            x.urunID,
                                            x.urunAd,
                                            x.urunMarka,
                                            x.urunStok,
                                            x.urunFiyat,
                                            x.urunDurum,
                                            x.tblKategori.categoryAd
                                        }
                                        ).ToList();
                                        

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(txtUrunID.Text);
            var sil = db.tblUrunlers.Find(id);
            db.tblUrunlers.Remove(sil);
            db.SaveChanges();
            MessageBox.Show("ürün silindi..");

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            tblUrunler urun = new tblUrunler();
            urun.urunAd = txtUrunAd.Text;
            urun.urunMarka = txtUrunMarka.Text;
            urun.urunStok = Convert.ToInt16(txtUrunStok.Text);
            urun.urunFiyat = Convert.ToInt16(txtUrunFiyat.Text);
            urun.urunDurum = true;
            urun.kategori = Convert.ToInt16(cmbKategori.SelectedValue.ToString());
            db.tblUrunlers.Add(urun);
            db.SaveChanges();
            MessageBox.Show("ürün sisteme kaydedildi.");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtUrunID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtUrunAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtUrunMarka.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtUrunStok.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtUrunFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtUrunDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                cmbKategori.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

            }
            catch (Exception)
            {
               // MessageBox.Show("lütfen geçerli bir alan seçiniz...");
            }
           
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtUrunID.Text);
            var deger = db.tblUrunlers.Find(id);
            deger.urunAd = txtUrunAd.Text;
            deger.urunMarka = txtUrunMarka.Text;
            deger.urunStok = short.Parse(txtUrunStok.Text);
            deger.urunFiyat = Convert.ToDecimal(txtUrunFiyat.Text);
            deger.urunDurum = false;
            deger.kategori = Convert.ToInt32(cmbKategori.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("ürün güncellendi..");


        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtUrunAd.Text = "";
            txtUrunDurum.Text = "";
            txtUrunFiyat.Text = "";
            txtUrunID.Text = "";
            txtUrunMarka.Text = "";
            txtUrunStok.Text = "";
            cmbKategori.Text = "";

        }
    }
}
