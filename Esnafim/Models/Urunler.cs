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

        [Column("birim")]
        public string Birim { get; set; }

        [Column("kg")]
        public string Kg { get; set; }

        public int KategoriId { get; set; }

        [ForeignKey("KategoriId")]
        public virtual Kategoriler Kategori { get; set; }

    }
}