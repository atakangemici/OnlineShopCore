using Esnafim.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Esnafim.Models
{
    public class Dukkanlar : BaseEntity
    {
        [Column("dukkan_adi")]
        public string DukkanAdi { get; set; }

        public virtual DukkanKategori DukkanKategori { get; set; }
        public virtual ICollection<Urunler> Urunler { get; set; }

    }
}