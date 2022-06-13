using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineOtomasyon.Models.Sınıflar
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemId { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string Açıklama { get; set; }
        public int Miktar { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal Tutar { get; set; }

        //fatura-faturakalem ilişki
        public virtual Faturalar Faturalar { get; set; }

        public int FaturaId { get; set; }

    }
}