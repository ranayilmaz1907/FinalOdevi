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
    public partial class FormUrun : Form
    {
        public FormUrun()
        {
            InitializeComponent();
        }
        public Tedarikci Tedarikci { get; set; }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void butonİptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        public Urun Urun { get; set; }
        public bool Güncelleme { get; set; } = false;

        private void butonTamam_Click(object sender, EventArgs e)
        {
            
            
            if (!ErrorControl(numericFiyat)) return;
            if (!ErrorControl(Kategori)) return;
            if (!ErrorControl(numericStok)) return;
            if (!ErrorControl(textUrunID)) return;
            if(!ErrorControl(textUrunAd)) return;

            Urun.Ad = textUrunAd.Text;
            Urun.ID = textUrunID.Text;
            Urun.Fiyat = (double)numericFiyat.Value;
            Urun.Stok = (double)numericStok.Value;
            Urun.Kategori = Kategori.Text;


            DialogResult = DialogResult.OK;
        }
        private bool ErrorControl(Control c)
        {
            if (c is TextBox )
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
            if (c is NumericUpDown)
            {
                if (((NumericUpDown)c).Value==0)
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

        private void FormUrun_Load(object sender, EventArgs e)
        {
            textUrunID.Text = Urun.ID.ToString();
            if (Güncelleme)
            {
                textUrunAd.Text = Urun.Ad;
                Kategori.Text = Urun.Kategori;
                numericFiyat.Value = (decimal)Urun.Fiyat;
                numericStok.Value = (decimal)Urun.Stok;
            }
        }
    }
}
