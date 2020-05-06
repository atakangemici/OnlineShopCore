using Esnafim.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Esnafim.Models
{
    public class Kategoriler : BaseEntity
    {
        [Column("kategori_adi")]
        public string KategoriAdi { get; set; }

        public int DukkanId { get; set; }

        [ForeignKey("DukkanId")]
        public Dukkanlar Dukkan { get; set; }

        public List<Urunler> Urun { get; set; }


    }
}