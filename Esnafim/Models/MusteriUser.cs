using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Esnafim.Models
{
    public class MusteriUser : BaseEntity
    {
        [Column("ad")]
        public string Ad { get; set; }

        [Column("soyad")]
        public string Soyad { get; set; }

        [Column("adres")]
        public string Adres { get; set; }

        [Column("telefon")]
        public string Telefon { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("sifre")]
        public string Sifre { get; set; }

    }
}