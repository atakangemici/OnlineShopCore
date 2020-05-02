using Esnafim.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Esnafim.Models
{
    public class Sepet : BaseEntity
    {
        [Column("musteri_id")]
        public int MusteriId { get; set; }

        [Column("dukkan_id")]
        public int DukkanId { get; set; }

        [Column("urun_id")]
        public int UrunId { get; set; }

        [Column("urun_adi")]
        public string UrunAdi { get; set; }

        [Column("urun_fiyat")]
        public int UrunFiyat { get; set; }

        [Column("sepet_tutari")]
        public int SepetTutari { get; set; }

        [Column("siparis_id")]
        public int SiparisId { get; set; }
    }
}