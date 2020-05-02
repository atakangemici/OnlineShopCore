using Esnafim.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Esnafim.Models
{
    public class Siparis : BaseEntity
    {
        [Column("musteri_id")]
        public int MusteriId { get; set; }

        [Column("dukkan_id")]
        public int DukkanId { get; set; }

        [Column("dukkan_adi")]
        public string DukkanAdi { get; set; }

        [Column("urun_id")]
        public int UrunId { get; set; }

        [Column("siparis_tutari")]
        public int SiparisTutari { get; set; }
    }
}