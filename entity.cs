using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalOdevi
{
    public class Musteri
    {
        public Guid ID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }
        public string Adres{ get; set; }

        public override string ToString()
        {
            return $"{ Ad} { Soyad}";
        }
    }

    public class Urun
    {
        public Guid ID { get; set; }
        public Tedarikci Tedarikci { get; set; }
        public string Ad { get; set; }
        public string Kategori  { get; set; }
        public double Fiyat { get; set; }
        public double Stok { get; set; }

        public override string ToString()
        {
            return $"{Ad} {Kategori}";
        }
    }

    public class Satis
    {
        public Guid ID { get; set; }
        public Musteri Musteri { get; set; }
        public Urun Urun { get; set; }
        public Calisan Calisan { get; set; }

        public DateTime Tarih { get; set; }
        public double Fiyat { get; set; }
       
    }
    public class Calisan
    {
        public Guid ID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string Pozisyon { get; set; }

        public override string ToString()
        {
            return $"{ Ad} { Soyad}";
        }


    }
    public class Tedarikci
    {
        public Guid ID { get; set; }
        public string Ad { get; set; }
        public string Adres { get; set; }
        
    }
    public class Odeme
    {
        public Guid ID { get; set; }
        public Musteri Musteri { get; set; }
        public double Tutar { get; set; }
        public string Tur { get; set; }
    }






}
