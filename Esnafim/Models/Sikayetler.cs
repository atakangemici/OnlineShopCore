using Esnafim.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Esnafim.Models
{
    public class Sikayetler : BaseEntity
    {
        [Column("dukkan_id")]
        public int DukkanId { get; set; }

        [Column("musteri_id")]
        public int MusteriId { get; set; }

        [Column("mesaj")]
        public string Mesaj { get; set; }

    }
}