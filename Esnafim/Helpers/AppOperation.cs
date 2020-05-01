using Esnafim.Models;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<List<Kategoriler>> GetProducts()
        {
            var products = _dbContext.Kategoriler
             .Include(x => x.Urunler)
            .Where(x => x.Deleted != true)
            .ToList();

            return products;
        }

        public async Task<MusteriUser> Login(JObject data)
        {
            var user = _dbContext.MusteriUser.Where(x => x.Email == (string)data["email"] && x.Sifre == (string)data["password"]).FirstOrDefault();

            return user;
        }
    }
}
