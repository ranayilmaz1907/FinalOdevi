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
    public partial class Urunler : Form
    {
        public Urunler()
        {
            InitializeComponent();
        }

        private void butonUrunEK_Click(object sender, EventArgs e)
        {
            FormUrun frm = new FormUrun()
            {
                Text = "Ürün Ekle",
                Urun = new Urun() { ID = Guid.NewGuid() },
            };
        tekrar:
            var sonuc = frm.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.UrunEkle(frm.Urun);
                if (b)
                {
                    DataSet ds = BLogic.Urungetir("");
                    if (ds != null)
                        dataGridView1.DataSource = ds.Tables[0];
                }
                else
                    goto tekrar;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            DataSet ds2 = BLogic.Urungetir(toolStripTextBox2.Text);
            if (ds2 != null)
                dataGridView2.DataSource = ds2.Tables[0];
        }

        private void ButonUrunDuzenle_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.SelectedRows[0];
            FormUrun formUrun = new FormUrun()
            {
                Text = "Ürün Güncelle",
                Güncelleme = true,
                Urun = new Urun()
                {
                    ID = Guid.Parse(row.Cells[0].Value.ToString()),
                    Ad = row.Cells[1].Value.ToString(),
                    Kategori = row.Cells[2].Value.ToString(),
                    Fiyat = double.Parse(row.Cells[3].Value.ToString()),
                    Stok = double.Parse(row.Cells[4].Value.ToString()),

                },
            };
            var sonuc = formUrun.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.Urunguncelle(formUrun.Urun);
                if (b)
                {
                    row.Cells[1].Value = formUrun.Urun.Ad;
                    row.Cells[1].Value = formUrun.Urun.Kategori;
                    row.Cells[1].Value = formUrun.Urun.Stok;
                    row.Cells[1].Value = formUrun.Urun.Fiyat;
                }

            }
        }

        private void butonUrunSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.SelectedRows[0];
            var id = Guid.Parse(row.Cells[0].Value.ToString());


            var sonuc = MessageBox.Show("Seçili ürünü silinsin mi ?", "Silmeyi onayla", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.Urunisil(id);
                if (b)
                {
                    DataSet ds2 = BLogic.Musterigetir("");
                    if (ds2 != null)
                        dataGridView2.DataSource = ds2.Tables[0];
                }

            }
        }

        public Urun Urun { get; set; }
        private void butonTamam_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.SelectedRows[0];
            Urun = new Urun()
            {
                ID = Guid.Parse(row.Cells[0].Value.ToString()),
                Ad = row.Cells[1].Value.ToString(),
                Kategori = row.Cells[2].Value.ToString(),
                Fiyat = double.Parse(row.Cells[3].Value.ToString()),
                Stok = double.Parse(row.Cells[4].Value.ToString()),


            };
            DialogResult = DialogResult.OK;
        }

        private void butonİptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
