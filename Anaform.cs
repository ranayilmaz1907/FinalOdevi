using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalOdevi.BL;
using FinalOdevi.UI;

namespace FinalOdevi
{
    public partial class Anaform : Form
    {
        public Anaform()
        {
            InitializeComponent();
        }

        Musteriler mf = new Musteriler();
        Urunler uf = new Urunler();
        private void butonMusteriler_Click(object sender, EventArgs e)
        {
            mf.ShowDialog();
        }

        private void butonUrunler_Click(object sender, EventArgs e)
        {
            uf.ShowDialog();
        }

        private void butonSatis_Click(object sender, EventArgs e)
        {
            FormSatis form = new FormSatis()
            {
                Text = "Satış Yap",
                Satis = new Satis()
                {
                    ID = Guid.NewGuid()
                }
            };
            
            tekrar:
                var sonuc = form.ShowDialog();
                if (sonuc == DialogResult.OK)
                {
                    bool b = BLogic.SatisEkle(form.Satis);
                    if (b)
                    {
                        DataSet ds = BLogic.SatisDetay();
                       if (ds != null)
                           dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                       goto tekrar;
                }
            
        }

        private void Anaform_Load(object sender, EventArgs e)
        {
            DataSet ds1 = BLogic.SatisDetay();
            if (ds1 != null)
                dataGridView1.DataSource = ds1.Tables[0];
            DataSet ds2 = BLogic.OdemeDetay();
            if (ds2 != null)
                dataGridView2.DataSource = ds2.Tables[0];

        }

        private void butonSatisdüzenle_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            FormSatis formSatis = new FormSatis()
            {
                Text = "Satış Güncelle",
                Güncelleme = true,
                Satis = new Satis()
                {
                    ID = Guid.Parse(row.Cells[0].Value.ToString()),
                    MusteriID = Guid.Parse(row.Cells[1].Value.ToString()),
                    UrunID = Guid.Parse(row.Cells[2].Value.ToString()),
                    CaliasnID = Guid.Parse(row.Cells[3].Value.ToString()),
                    Fiyat = double.Parse(row.Cells[4].Value.ToString()),
                    Tarih = DateTime.Parse(row.Cells[5].Value.ToString()),
                },
            };
            var sonuc = formSatis.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.SatisGuncelle(formSatis.Satis);
                if (b)
                {
                    row.Cells[1].Value = formSatis.Satis.MusteriID;
                    row.Cells[2].Value = formSatis.Satis.UrunID;
                    row.Cells[7].Value = formSatis.Satis.CalisanID;
                    row.Cells[8].Value = formSatis.Satis.Fiyat;
                    row.Cells[9].Value = formSatis.Satis.Tarih;
                }

            }
        }

        private void butonSatisSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            var ID = Guid.Parse(row.Cells[0].Value.ToString());


            var sonuc = MessageBox.Show("Seçili satış silinsin mi ?", "Silmeyi onayla", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.SatisSil(ID);
                if (b)
                {
                    DataSet ds = BLogic.SatisDetay();
                    if (ds != null)
                        dataGridView1.DataSource = ds.Tables[0];
                }

            }
        }

        private void butonOdeme_Click(object sender, EventArgs e)
        {
            FormOdeme form = new FormOdeme()
            {
                Text = "Ödeme Yap",
                Satis = new Satis()
                {
                    ID = Guid.NewGuid()
                }
            };

        tekrar:
            var sonuc = form.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.OdemeEkle(form.Odeme);
                if (b)
                {
                    DataSet ds2 = BLogic.OdemeDetay();
                    if (ds2 != null)
                        dataGridView2.DataSource = ds2.Tables[0];
                }
                else
                    goto tekrar;
            }
        }

        private void butonOdemeDuzenle_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            FormOdeme formOdeme = new FormOdeme()
            {
                Text = "Ödeme Güncelle",
                Güncelleme = true,
                Odeme = new Odeme()
                {
                    ID = Guid.Parse(row.Cells[0].Value.ToString()),
                    MusteriID = Guid.Parse(row.Cells[1].Value.ToString()),
                    Tutar = double.Parse(row.Cells[4].Value.ToString()),
                    Tur = row.Parse(row.Cells[5].Value.ToString()),
                },
            };
            var sonuc = formOdeme.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.OdemeGuncelle(formOdeme.Odeme);
                if (b)
                {
                    row.Cells[1].Value = formOdeme.Odeme.MusteriID;

                    row.Cells[2].Value = formOdeme.Odeme.Tutar;
                    row.Cells[3].Value = formOdeme.Odeme.Tur;
                }

            }
        }

        private void butonOdemeSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.SelectedRows[0];
            var ID = Guid.Parse(row.Cells[0].Value.ToString());


            var sonuc = MessageBox.Show("Seçili ödeme silinsin mi ?", "Silmeyi onayla", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.OdemeSil(ID);
                if (b)
                {
                    DataSet ds = BLogic.OdemeDetay();
                    if (ds != null)
                        dataGridView2.DataSource = ds.Tables[0];
                }

            }
        }

        
    }
}
