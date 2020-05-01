using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Esnafim.Models;
using Esnafim.Helpers;

namespace Esnafim.Controllers
{
    [Route("api/app")]
    public class AppController : ControllerBase
    {
        private readonly IAppOperation _appOperation;

        public AppController(IAppOperation appOperation)
        {
            _appOperation = appOperation;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "home page" };
        }

        [Route("login"), HttpPost]
        public async Task<ActionResult<MusteriUser>> Login([FromBody]JObject data)
        {
            var user = await _appOperation.Login(data);

            return Ok(user);
        }

        [Route("get_all_shops"), HttpGet]
        public async Task<ActionResult<DukkanKategori>> GetAllShops()
        {
            var shops = await _appOperation.AllShops();

            return Ok(shops);
        }

        [Route("get_products/{id:int}"), HttpGet]
        public async Task<ActionResult<Kategoriler>> GetProducts(int id)
        {
            var products = await _appOperation.GetProducts();

            return Ok(products);
        }

        [Route("add_order_product"), HttpGet]
        public async Task<ActionResult<Siparisler>> AddOrderProduct([FromBody]JObject product)
        {
            var addProduct = await _appOperation.AddOrderProduct(product);

            return Ok(addProduct);
        }

    }
}
