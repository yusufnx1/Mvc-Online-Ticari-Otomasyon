using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineOtomasyon.Models.Sınıflar
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string PersonelAd { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string PersonelSoyad { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string PersonelImage { get; set; }


        public ICollection<SatisHareket> SatisHarekets { get; set; }

        public int DepartmanId { get; set; }
        public virtual Departman Departman { get; set; }
    }
}