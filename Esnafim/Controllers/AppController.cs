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

        [Route("add_order_product"), HttpPost]
        public async Task<ActionResult<Sepet>> AddOrderProduct([FromBody]JObject product)
        {
            var addProduct = await _appOperation.AddOrderProduct(product);

            return Ok(addProduct);
        }

        [Route("get_order/{id:int}"), HttpGet]
        public async Task<ActionResult<Sepet>> GetOrderProduct(int id)
        {
            var getProduct = await _appOperation.GetOrder(id);

            return Ok(getProduct);
        }

        [Route("get_all_shops"), HttpGet]
        public async Task<ActionResult<DukkanKategori>> GetAllShops()
        {
            var shops = await _appOperation.AllShops();

            return Ok(shops);
        }

        [Route("get_shop/{id:int}"), HttpGet]
        public async Task<Dukkanlar> GetShop(int id)
        {
            var getShop = await _appOperation.GetShop(id);

            return getShop;
        }

        [Route("order_approved"), HttpPost]
        public async Task<ActionResult<Siparis>> OrderApproved([FromBody]JObject product)
        {
            var orderApproved = await _appOperation.OrderApproved(product);

            return Ok(orderApproved);
        }

        [Route("get_orders_approved/{id:int}"), HttpGet]
        public async Task<ActionResult<Siparis>> GetOrdersApproved(int id)
        {
            var getOrdersApproved = await _appOperation.GetOrdersApproved(id);

            return Ok(getOrdersApproved);
        }

        [Route("get_approved_orders/{id:int}"), HttpGet]
        public async Task<ActionResult<Sepet>> GetAapprovedOrders(int id)
        {
            var getAapprovedOrders = await _appOperation.GetAapprovedOrders(id);

            return Ok(getAapprovedOrders);
        }

        [Route("order_update/{id:int}"), HttpGet]
        public async Task<Sepet> OrderUpdate(int id)
        {
            var orderUpdate = await _appOperation.OrderUpdate(id);

            return orderUpdate;
        }
    }
}
