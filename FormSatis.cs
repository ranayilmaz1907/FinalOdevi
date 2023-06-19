using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalOdevi.UI
{
    public partial class FormSatis : Form
    {
        public FormSatis()
        {
            InitializeComponent();
        }

        public Satis Satis { get; set; }
        public bool Güncelleme { get; set; } = false;
        private void butonİptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public Musteri Musteri { get; set; }

        public Urun Urun { get; set; }

        public Satis Satis { get; set; }
        private void butonTamam_Click(object sender, EventArgs e)
        {
            
            if(numericSatisFiyat.Value==0)
            {
                errorProvider1.SetError(numericSatisFiyat, "Lütfen fiyat giriniz!");
                numericSatisFiyat.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(numericSatisFiyat, "");
            }

           
            Satis.Musteri = Musteri.ID;
            Satis.Urun = Urun.ID;
            Satis.Calisan = Calisan.ID;
            Satis.Tarih = dateTimeSatis.Value;
            Satis.Fiyat = (double)numericSatisFiyat.Value;




            DialogResult = DialogResult.OK;
        }

        private void FormSatis_Load(object sender, EventArgs e)
        {
            textSatisID = Satis.ID.ToString();
            if (Güncelleme)
            {
                textSatisMusteri.Text = Satis.MusteriID.ToString();
                textSatisUrun.Text = Satis.UrunID.ToString();
                numericSatisFiyat.Value = Satis.Fiyat;
                dateTimeSatis.Value = Satis.Tarih;
            }
           
        }

        private void butonMusteriSec_Click(object sender, EventArgs e)
        {
            Musteriler form = new Musteriler();
            if(form.ShowDialog() == DialogResult.OK)
            {
                Musteri = form.Musteri;
               textSatisMusteri.Text = Musteri.ToString();
            }
        }

        private void butonUrunSec_Click(object sender, EventArgs e)
        {
            Urunler form = new Urunler();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Urun = form.Urun;
                textSatisUrun.Text = Urun.ToString();
            }
        }
    }
}
