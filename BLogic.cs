using FinalOdevi.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalOdevi.BL
{
    public static class BLogic
    {
        public static bool MusteriEkle(Musteri m)
        {
            try
            {
                int res = DataLayer.MusteriEkle(m);
                return (res > 0);
            }
            catch(Exception ex)
            {
                MessageBox.Show("hata oluştu :" + ex.Message);
                return false;
            }

        }

        internal static DataSet Musterigetir(string filtre)
        {
            try
            {
                DataSet ds = DataLayer.MusteriEkle(filtre);
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata oluştu :" + ex.Message);
                return null;
            }
        }

        internal static bool Musteriguncelle(Musteri m)
        {
            try
            {
                int res = DataLayer.Musteriguncelle(m);
                return (res > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata oluştu :" + ex.Message);
                return false;
            }
        }

        internal static bool Musterisil(string id)
        {
            try
            {
                int res = DataLayer.Musterisil(id);
                return (res > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata oluştu :" + ex.Message);
                return false;
            }
        }

        internal static bool UrunEkle(Urun urun)
        {
            try
            {
                int res = DataLayer.UrunEkle(u);
                return (res > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata oluştu :" + ex.Message);
                return false;
            }
        }

        internal static DataSet Urungetir(string filtre)
        {
            try
            {
                DataSet ds2 = DataLayer.UrunEkle(filtre);
                return ds2;
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata oluştu :" + ex.Message);
                return null;
            }
        }

        internal static bool Urunguncelle(Urun u)
        {
            try
            {
                int res = DataLayer.Urunguncelle(u);
                return (res > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata oluştu :" + ex.Message);
                return false;
            }
        }

        internal static bool UrunSil(string id)
        {
            try
            {
                int res = DataLayer.UrunSil(id);
                return (res > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata oluştu :" + ex.Message);
                return false;
            }
        }
        public static bool SatisEkle(Satis s)
        {
            try
            {
                int res = DataLayer.SatisEkle(s);
                return (res > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata oluştu :" + ex.Message);
                return false;
            }

        }

        internal static DataSet SatisDetay()
        {
            try
            {
                DataSet ds1 = DataLayer.SatisDetay();
                return ds1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata oluştu :" + ex.Message);
                return null;
            }
        }

        internal static bool SatisGuncelle(Satis s)
        {
            try
            {
                int res = DataLayer.SatisGuncelle(s);
                return (res > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata oluştu :" + ex.Message);
                return false;
            }
        }

        internal static bool SatisSil(string id)
        {
            try
            {
                int res = DataLayer.SatisSil(id);
                return (res > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata oluştu :" + ex.Message);
                return false;
            }
        }

        public static bool OdemeEkle(Odeme o)
        {
            try
            {
                int res = DataLayer.OdemeEkle(o);
                return (res > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata oluştu :" + ex.Message);
                return false;
            }

        }

        internal static DataSet OdemeDetay()
        {
            try
            {
                DataSet ds1 = DataLayer.OdemeDetay();
                return ds1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata oluştu :" + ex.Message);
                return null;
            }
        }
        internal static bool OdemeGuncelle(Odeme odeme)
        {
            try
            {
                int res = DataLayer.OdemeGuncelle(odeme);
                return (res > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata oluştu :" + ex.Message);
                return false;
            }
        }

        internal static bool OdemeSil(string o)
        {
            try
            {
                int res = DataLayer.OdemeSil(o);
                return (res > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata oluştu :" + ex.Message);
                return false;
            }
        }
    }
}
