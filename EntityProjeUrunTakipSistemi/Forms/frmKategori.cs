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
    public partial class frmKategori : Form
    {
        DBEntityUrunEntities db = new DBEntityUrunEntities();
        public frmKategori()
        {
            InitializeComponent();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            //ToList() metodu ile kategorileri veritabanından dataGridView1'de listeleme kodu.
            dataGridView1.DataSource = (from x in db.tblKategoris
                                        select new
                                        {
                                            x.categoryID,
                                            x.categoryAd
                                        }).ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            //Add() metodu ile kategoriler için ekleme işlemi.
            tblKategori t = new tblKategori();
            t.categoryAd = txtCatAd.Text;
            db.tblKategoris.Add(t);
            db.SaveChanges();
            MessageBox.Show("kategori eklendi");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            //Remove() metodu ile kategori silme işlemi.
            int id = Convert.ToInt32(txtCatID.Text);
            var deger = db.tblKategoris.Find(id);
            db.tblKategoris.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("kategori silindi");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtCatID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtCatAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (Exception)
            {
            }
           
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            //İD DEĞERİNE GÖRE GÜNCELLEME İŞLEMİ YAPILDI.
            int id = Convert.ToInt32(txtCatID.Text);
            var deger = db.tblKategoris.Find(id);
            deger.categoryAd = txtCatAd.Text;
            db.SaveChanges();
            MessageBox.Show("güncelleme yapıldı.");
        }
    }

}
