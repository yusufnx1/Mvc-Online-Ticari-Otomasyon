using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineOtomasyon.Models.Sınıflar
{
    public class Mesajlar
    {
        [Key]
        public int MesajId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Gonderici { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Alici { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Konu { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string İcerik { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Tarih { get; set; }
    }
}