using Esnafim.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Esnafim.Models
{
    public class SiparisDetaylari : BaseEntity
    {
        [Column("urun_id")]
        public int UrunId { get; set; }

        [Column("siparis_id")]
        public int SiparisId { get; set; }

        [Column("fiyat")]
        public double Fiyat { get; set; }

        [Column("adet_kg")]
        public string AdetKg { get; set; }

        public virtual Siparisler Siparis { get; set; }

    }
}