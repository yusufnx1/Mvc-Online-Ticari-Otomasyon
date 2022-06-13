using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineOtomasyon.Models.Sınıflar
{
    public class Gider
    {
        [Key]
        public int GiderId { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(150)]
        public string Açiklama { get; set; }
        public DateTime Tarih { get; set; }
        public decimal Tutar { get; set; }
    }
}