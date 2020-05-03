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
                .Include(y=>y.DukkanKategori)
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

            var dukkan = _dbContext.Dukkanlar.Where(x => x.Deleted == false && x.Id == (int)data["dukkanId"]).FirstOrDefault();

            order.DukkanAdi = dukkan.DukkanAdi;

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
            order.OdemeTipi = (string)data["odemeTipi"];


            var dukkan = _dbContext.Dukkanlar.Where(x => x.Deleted == false && x.Id == (int)data["dukkanId"]).FirstOrDefault();

            order.DukkanAdi = dukkan.DukkanAdi;

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

            return order.Id;
        }

        public async Task<List<Siparis>> GetOrdersApproved(int id)
        {
            var getOrderApproved = _dbContext.Siparis
              .Where(x => x.MusteriId == id && x.Deleted == false)
              .ToList();

            return getOrderApproved;
        }

        public async Task<List<Sepet>> GetAapprovedOrders(int id)
        {
            var getOrdersApproved = _dbContext.Sepet
              .Where(x => x.SiparisId == id && x.Deleted == true)
              .ToList();

            return getOrdersApproved;
        }

        public async Task<Sepet> OrderUpdate(int id)
        {
            var orderUpdate = _dbContext.Sepet
              .Where(x => x.Id == id && x.Deleted == false)
              .FirstOrDefault();

            orderUpdate.Deleted = true;

            _dbContext.Sepet.Update(orderUpdate);
            await _dbContext.SaveChangesAsync();

            return orderUpdate;
        }

        public async Task<Siparis> GetProductOrder(int id)
        {
            var getOrdersApproved = _dbContext.Siparis
              .Where(x => x.Id == id && x.Deleted == false)
              .FirstOrDefault();

            return getOrdersApproved;
        }

        public async Task<MusteriUser> AddUser(JObject User)
        {
            if (User == null)
                return null;

            MusteriUser userData = new MusteriUser
            {
                Ad = (string)User["ad"],
                Soyad = (string)User["soyad"],
                Email = (string)User["email"],
                Sifre = (string)User["sifre"],
                Telefon = (string)User["telefon"],
                Adres = (string)User["adres"],
                Deleted = false,
                CreatedAt = DateTime.Now               
            };


            _dbContext.MusteriUser.Add(userData);
            await _dbContext.SaveChangesAsync();

            return userData;
        }
    }
}
