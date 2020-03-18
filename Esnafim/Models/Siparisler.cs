using Esnafim.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Esnafim.Models
{
    public class Siparisler : BaseEntity
    {
        [Column("musteri_id")]
        public int MusteriId { get; set; }

        [Column("dukkan_id")]
        public int DukkanId { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("toplam_siparis_tutari")]
        public double ToplamSiparisTutari { get; set; }

        public virtual ICollection<SiparisDetaylari> SiparisDetay { get; set; }

    }
}