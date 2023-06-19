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
    public partial class FormMusteri : Form
    {
        public FormMusteri()
        {
            InitializeComponent();
        }

        private void butonİptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        public Musteri Musteri { get; set; }
        public bool Güncelleme { get; set; } = false;
        private void butonTamam_Click(object sender, EventArgs e)
        {
           if ( !ErrorControl(textAd)) return;
            if (!ErrorControl(textSoyad)) return;
            if (!ErrorControl(textTel)) return;
            if (!ErrorControl(textAdres)) return;
            if (!ErrorControl(textMail)) return;
            if (!ErrorControl(textID)) return;

            Musteri.Ad = textAd.Text;
            Musteri.Soyad = textSoyad.Text;
            Musteri.Telefon = textTel.Text;
            Musteri.Adres = textAdres.Text;
            Musteri.Mail = textMail.Text;
         


            DialogResult = DialogResult.OK;
           
        }
        private bool ErrorControl (Control c)
        {
            if (c is TextBox)
            {
                if (c.Text == "")
                {
                    errorProvider1.SetError(c, "Eksik veya hatalı bilgi");
                    c.Focus();
                    return false;
                }
                else
                {
                    errorProvider1.SetError(c, "");
                    return true;
                }
            }
            if (c is MaskedTextBox)
            {
                if (((MaskedTextBox)c).MaskFull)
                {
                    errorProvider1.SetError(c, "Eksik veya hatalı bilgi");
                    c.Focus();
                    return false;
                }
                else
                {
                    errorProvider1.SetError(c, "");
                    return true;
                }
            }
            return true;




        }
        private void FormMusteri_Load(object sender, EventArgs e)
        {
            textID.Text = Musteri.ID.ToString();
            if (Güncelleme)
            {
                 textAd.Text= Musteri.Ad;
                textSoyad.Text = Musteri.Soyad;
                textTel.Text = Musteri.Telefon;
                textAdres.Text = Musteri.Adres;
                textMail.Text = Musteri.Mail;
            }
            else
            {

            }
        }


    }
}
