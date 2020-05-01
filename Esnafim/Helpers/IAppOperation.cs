using Esnafim.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esnafim.Helpers
{
    public interface IAppOperation
    {
        Task<List<DukkanKategori>> AllShops();
        Task<MusteriUser> Login(JObject data);
        Task<List<Kategoriler>> GetProducts();

    }
}
