using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProjeUrunTakipSistemi.Forms
{
    public partial class frmIstatistik : Form
    {
        public frmIstatistik()
        {
            InitializeComponent();
        }

        DBEntityUrunEntities db = new DBEntityUrunEntities();
        private void frmIstatistik_Load(object sender, EventArgs e)
        {
            lblToplamKategori.Text = db.tblKategoris.Count().ToString();
            lblToplamUrun.Text = db.tblUrunlers.Count().ToString();
            lblAktifMusteri.Text = db.tblMusterilers.Count(x => x.durum == true).ToString(); // => lambda ifadesidir. x öyle ki anlamındadır.
            lblPasifMusteri.Text = db.tblMusterilers.Count(x => x.durum == false).ToString();
            lblBeyazEsya.Text = db.tblUrunlers.Count(x => x.kategori == 1).ToString();
            lblStok.Text = db.tblUrunlers.Sum(y => y.urunStok).ToString();
            lblMaxFiyatliUrun.Text = (from x in db.tblUrunlers
                                      orderby x.urunFiyat descending
                                      select x.urunAd).FirstOrDefault(); //FirstOrDefault() metodu en üstteki değeri çeker. sadece 1 kaydı getirir. tek bir durumun olduğu durumlarda kullanılır.
            lblMinFiyatlıUrun.Text = (from x in db.tblUrunlers
                                      orderby x.urunFiyat ascending
                                      select x.urunAd).FirstOrDefault();
            
            lblKasa.Text = db.tblSatislars.Sum(x => x.fiyat).ToString() + "TL";
            lblSehir.Text = (from x in db.tblMusterilers
                             select x.musteriSehir).Distinct().Count().ToString();
            lblToplamBuzdolabı.Text = db.tblUrunlers.Count(x => x.urunAd == "Buzdolabı").ToString();
            lblMaxUrunluMarka.Text = db.MarkaGetir().FirstOrDefault();
        }

    }
}
