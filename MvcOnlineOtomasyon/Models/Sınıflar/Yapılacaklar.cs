using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineOtomasyon.Models.Sınıflar
{
    public class Yapılacaklar
    {
        [Key]
        public int YapılacakId { get; set; }
        [Column(TypeName ="Varchar")]
        [StringLength(100)]
        public string Baslik { get; set; }
        public bool Durum { get; set; }

    }
}