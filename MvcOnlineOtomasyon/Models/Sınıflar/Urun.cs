using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineOtomasyon.Models.Sınıflar
{
    public class Urun
    {
        [Key] 
        public int UrunId { get; set; }
        [Column(TypeName ="varchar")]
        [StringLength(50)]
        public string UrunAd { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Marka { get; set; }
        public short Stok { get; set; }
        public decimal AlisFiyat { get; set; }
        public decimal SatisFiyat { get; set; }
        public bool Durum { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string UrunGorsel { get; set; }


        public int KategoriId { get; set; }

        //Urun - Kategori iliski

        public virtual Kategori Kategori { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}