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
        Task<int> AddOrderProduct(JObject data);
        Task<Dukkanlar> GetShop(int id);
        Task<List<Sepet>> GetOrder(int id);
        Task<int> OrderApproved(JObject data);
        Task<List<Siparis>> GetOrdersApproved(int id);
        Task<List<Sepet>> GetAapprovedOrders(int id);
        Task<Sepet> OrderUpdate(int id);

    }
}
