﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineOtomasyon.Models.Sınıflar
{
    public class Faturalar
    {
        [Key]
        public int FaturaId { get; set; }
        [Column(TypeName = "char")]
        [StringLength(1)]
        public string FaturaSeriNo { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        public string FaturaSıraNo { get; set; }
        public DateTime Tarih { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(75)]
        public string VergiDairesi { get; set; }
        //public DateTime Saat { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string TeslimEden { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string TeslimAlan { get; set; }
        [Column(TypeName ="varchar")]
        [StringLength(5)]
        public string Saat { get; set; }
        public decimal Toplam { get; set; }

        //faturakalem-fatura ilişkisi
        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}