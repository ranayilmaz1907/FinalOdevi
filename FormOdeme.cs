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
    public partial class FormOdeme : Form
    {
        public FormOdeme()
        {
            InitializeComponent();
        }

        
        public Odeme Odeme { get; set; }
        public Musteri Musteri { get; set; }
        public Güncelleme { get; set; } = false;
            
            private void butonOdemeMusteri_Click(object sender, EventArgs e)
        {
        Musteriler form = new Musteriler();
        if (form.ShowDialog() == DialogResult.OK)
        {
            
            textOdemeMusteri.Text = Musteri.ToString();
        }
    }
    



    private void butonİptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public Odeme Odeme { get; set; }
        private void butonTamam_Click(object sender, EventArgs e)
        {
           
            
            if (numericOdemeFiyat.Value == 0)
            {
                errorProvider1.SetError(numericOdemeFiyat, "Lütfen tutar giriniz!");
                numericOdemeFiyat.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(numericOdemeFiyat, "");
            }
            if (OdemeTur.SelectedItem == null)
            {
                errorProvider1.SetError(OdemeTur, "Ödeme türü seçiniz!");
                OdemeTur.Focus();
                return;
            }
            
            else
                {
                    errorProvider1.SetError(OdemeTur, "");
               
                }


            
            Odeme.Tur = OdemeTur.SelectedItem.ToString();
            Odeme.Tutar = (double)numericOdemeFiyat.Value;
            Odeme.Musteri = textOdemeMusteri.Text;


            DialogResult = DialogResult.OK;
        }

        private void FormSatis_Load(object sender, EventArgs e)
        {
            textOdemeMusteri.Text = Musteri.ToString();
        }
    private void FormOdeme_Load(object sender, EventArgs e)
    {
        textOdemeID = Odeme.ID.ToString();
        if (Güncelleme)
        {
            textOdemeMusteri.Text = Odeme.MusteriID.ToString();
            numericOdemeFiyat.Value = Odeme.Tutar;
            OdemeTur.SelectedItem = Odeme.Tur;
        }

    }

}
    }

