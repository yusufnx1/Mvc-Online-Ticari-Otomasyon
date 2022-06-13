using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineOtomasyon.Models.Sınıflar
{
    public class SatisHareket
    {
        [Key]
        public int SatisHareketId { get; set; }
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }
        public int UrunId { get; set; }
        public int CariId { get; set; }
        public int PersonelId { get; set; }

        //satishareket-urun 
        public virtual Urun Urun { get; set; }
        //satishareket-cari
        public virtual Cariler Cariler { get; set; }
        //satishareket-personel
        public virtual Personel Personel { get; set; }
    }
}