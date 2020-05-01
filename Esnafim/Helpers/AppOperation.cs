using Esnafim.Models;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<List<Dukkanlar>> AllShops()
        {
            var shops = _dbContext.Dukkanlar
            .Where(x => x.Deleted != true).ToList();

            return shops;
        }
    }
}
