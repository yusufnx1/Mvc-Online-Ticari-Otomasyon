using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineOtomasyon.Models.Sınıflar
{
    public class Departman
    {
        [Key]
        public int DepartmanId { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string DepartmanAd { get; set; }
        public bool Durum { get; set; } 

        //personel-departman
        public ICollection<Personel> Personels { get; set; }
    }
}