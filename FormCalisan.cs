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
    public partial class FormCalisan : Form
    {
        public FormCalisan()
        {
            InitializeComponent();
        }

        private void butonİptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public Calisan Calisan { get; set; }
        private void butonTamam_Click(object sender, EventArgs e)
        {
            if (!ErrorControl(textCalisanAd)) return;
            if (!ErrorControl(textCalisanID)) return;
            if (!ErrorControl(textCalisanTel)) return;
            if (!ErrorControl(textCalisanAdres)) return;
            if (!ErrorControl(CalisanPozisyon)) return;

            Calisan.Ad = textCalisanAd.Text;
            Calisan.Soyad = textCalisanSoyad.Text;
            Calisan.Telefon = textCalisanTel.Text;
            Calisan.Adres = textCalisanAdres.Text;
            Calisan.Pozisyon = CalisanPozisyon.Text;




            DialogResult = DialogResult.OK;
        }

        
        private bool ErrorControl(Control c)
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
            if (c is ComboBox)
            {
                if (ComboBox.ComboBox)
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
    }
}
