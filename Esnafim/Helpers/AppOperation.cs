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
            var order = new Sepet();
            order.Deleted = false;
            order.CreatedAt = DateTime.Now;
            order.MusteriId = (int)data["musteriId"];
            order.DukkanId = (int)data["dukkanId"];
            order.UrunId = (int)data["urunId"];
            order.UrunAdi = (string)data["urunAdi"];
            order.UrunFiyat = (int)data["urunFiyat"];



            _dbContext.Sepet.Add(order);
            var addOrder = await _dbContext.SaveChangesAsync();

            return addOrder;
        }

        public async Task<MusteriUser> Login(JObject data)
        {
            var user = _dbContext.MusteriUser.Where(x => x.Email == (string)data["email"] && x.Sifre == (string)data["password"]).FirstOrDefault();

            return user;
        }


        public async Task<List<Sepet>> GetOrder(int id)
        {
            var getOrder = _dbContext.Sepet
                .Where(x => x.MusteriId == id && x.Deleted == false)
                .ToList();

            return getOrder;
        }

        public async Task<int> OrderApproved(JObject data)
        {
            var order = new Siparis();
            order.Deleted = false;
            order.CreatedAt = DateTime.Now;
            order.MusteriId = (int)data["musteriId"];
            order.DukkanId = (int)data["dukkanId"];
            order.SiparisTutari = (int)data["toplamTutar"];

            _dbContext.Siparis.Add(order);
            var addOrder = await _dbContext.SaveChangesAsync();

            var getOrders = _dbContext.Sepet
                .Where(x => x.MusteriId == (int)data["musteriId"] && x.Deleted == false)
                .ToList();

            foreach (var getOrder in getOrders)
            {
                getOrder.Deleted = true;
                getOrder.SiparisId = order.Id;

                _dbContext.Sepet.Update(getOrder);
                await _dbContext.SaveChangesAsync();
            }

            return addOrder;
        }

    }
}
