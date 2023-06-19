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
    public partial class FormTedarikci : Form
    {
        public FormTedarikci()
        {
            InitializeComponent();
        }

        private void butonİptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        public Tedarikci Tedarikci { get; set; }
        private void butonTamam_Click(object sender, EventArgs e)
        {
            if (c is TextBox and)
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


            Tedarikci.Ad = textTedarikciAd.Text;
            Tedarikci.ID = textTedarikciID.Text;
            Tedarikci.Adres = textTedarikciAdres.Text;

            DialogResult = DialogResult.OK;
        }

        
       
    }
}
