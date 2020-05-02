using Esnafim.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esnafim.Helpers
{
    public class AppOperation : IAppOperation
    {
        private readonly EsnafimContext _dbContext;

        public AppOperation(EsnafimContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DukkanKategori>> AllShops()
        {
            var shops = _dbContext.DukkanKategori
             .Include(x => x.Dukkanlar)
            .Where(x => x.Deleted != true)
            .ToList();

            return shops;
        }

        public async Task<Dukkanlar> GetShop(int id)
        {
            var getShop = _dbContext.Dukkanlar
                .Where(x => x.Id == id)
                .Include(s => s.Kategori)
                .ThenInclude(sn => sn.Urun)
                .FirstOrDefault();

            return getShop;
        }

        public async Task<int> AddOrderProduct(JObject data)
        {
            var order = new Siparisler();
            order.Deleted = false;
            order.CreatedAt = DateTime.Now;
            order.MusteriId = (int)data["musteriId"];
            order.DukkanId = (int)data["dukkanId"];
            order.Status = (string)data["OnayBekliyor"];
            order.ToplamSiparisTutari = (double)data["toplamTutar"];

            _dbContext.Siparisler.Add(order);
            var addProduct = await _dbContext.SaveChangesAsync();

            return addProduct;
        }

        public async Task<MusteriUser> Login(JObject data)
        {
            var user = _dbContext.MusteriUser.Where(x => x.Email == (string)data["email"] && x.Sifre == (string)data["password"]).FirstOrDefault();

            return user;
        }
    }
}
