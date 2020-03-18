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

        [Column("esnaf_user_id")]
        public int EsnafUserId { get; set; }

        [Column("urun_id")]
        public int UrunId { get; set; }

        public virtual EsnafUser Esnaf { get; set; }
        public virtual Urunler Urun { get; set; }

    }
}