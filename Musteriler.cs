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
    public partial class Musteriler : Form
    {
        public Musteriler()
        {
            InitializeComponent();
        }

        private void butonMusteriEkle_Click(object sender, EventArgs e)
        {
            FormMusteri formMusteri = new FormMusteri()
            {
                Text = "Müşteri Ekle",
                Musteri = new Musteri() { ID = Guid.NewGuid() },
            };
        tekrar:
            var sonuc = formMusteri.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.MusteriEkle(formMusteri.Musteri);
                if (b)
                {
                    DataSet ds = BLogic.Musterigetir("");
                    if (ds != null)
                        dataGridView1.DataSource = ds.Tables[0];
                }
                else
                    goto tekrar;
            }

        }

        private void butonMusteriD_Clicdüzenle(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            FormMusteri formMusteri = new FormMusteri()
            {
                Text = "Müşteri Güncelle",
                Güncelleme = true,
                Musteri = new Musteri()
                {
                    ID = Guid.Parse(row.Cells[0].Value.ToString()),
                    Ad = row.Cells[1].Value.ToString(),
                    Soyad = row.Cells[1].Value.ToString(),
                    Adres = row.Cells[1].Value.ToString(),
                    Telefon = row.Cells[1].Value.ToString(),
                    Mail = row.Cells[1].Value.ToString(),
                },
            };
            var sonuc = formMusteri.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.Musteriguncelle(formMusteri.Musteri);
                if (b)
                {
                    row.Cells[1].Value = formMusteri.Musteri.Ad;
                    row.Cells[1].Value = formMusteri.Musteri.Soyad;
                    row.Cells[1].Value = formMusteri.Musteri.Telefon;
                    row.Cells[1].Value = formMusteri.Musteri.Mail;
                    row.Cells[1].Value = formMusteri.Musteri.Adres;
                }

            }
        }

        private void ButonMusteriBul_Click(object sender, EventArgs e)
        {
            DataSet ds = BLogic.Musterigetir(toolStripTextBox1.Text);
            if (ds != null)
                dataGridView1.DataSource = ds.Tables[0];
        }



        private void butonMusteriSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            var ID = Guid.Parse(row.Cells[0].Value.ToString());


            var sonuc = MessageBox.Show("Seçili kayıt silinsin mi ?", "Silmeyi onayla", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.Musterisil(ID);
                if (b)
                {
                    DataSet ds = BLogic.Musterigetir("");
                    if (ds != null)
                        dataGridView1.DataSource = ds.Tables[0];
                }

            }
        }

        private void Musteriler_Load(object sender, EventArgs e)
        {
            DataSet ds = BLogic.Musterigetir("");
            if (ds != null)
                dataGridView1.DataSource = ds.Tables[0];

           
        }

       public Musteri Musteri { get; set; }
        private void butonTamam_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            
                Text = "Müşteri Güncelle",
                Güncelleme = true,
                Musteri = new Musteri()
                {
                    ID = Guid.Parse(row.Cells[0].Value.ToString()),
                    Ad = row.Cells[1].Value.ToString(),
                    Soyad = row.Cells[1].Value.ToString(),
                    Adres = row.Cells[1].Value.ToString(),
                    Telefon = row.Cells[1].Value.ToString(),
                    Mail = row.Cells[1].Value.ToString(),
               
                 };
            DialogResult = DialogResult.OK;
        }

        private void butonİptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
