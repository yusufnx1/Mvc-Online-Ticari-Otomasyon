using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineOtomasyon.Models.Sınıflar
{
    public class Cariler
    {
        [Key]
        public int CariId { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string CariAd { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string CariSoyad { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string CariSehir { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string CariMail { get; set; }
        public bool Durum { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string Sifre { get; set; }



        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}