using Esnafim.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Esnafim.Models
{
    public class DukkanKategori : BaseEntity
    {
        [Column("kategori_adi")]
        public string KategoriAdi { get; set; }

        public virtual ICollection<Dukkanlar> Dukkanlar { get; set; }


    }
}