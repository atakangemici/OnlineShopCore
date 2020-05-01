using Esnafim.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Esnafim.Models
{
    public class Urunler : BaseEntity
    {
        [Column("urun_adi")]
        public string UrunAdi { get; set; }

        [Column("fiyat")]
        public double Fiyat { get; set; }

        [Column("adet_kg")]
        public string AdetKg { get; set; }

        public virtual Kategoriler Kategori { get; set; }
        public virtual Dukkanlar Dukkan { get; set; }


    }
}