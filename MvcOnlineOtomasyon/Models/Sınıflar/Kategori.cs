using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineOtomasyon.Models.Sınıflar
{
    public class Kategori
    {
        [Key]
        public int KategoriId { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string KategoriAd { get; set; }

        //Kategori - Urun İlişki

        public ICollection<Urun> Uruns { get; set; }

    }
}