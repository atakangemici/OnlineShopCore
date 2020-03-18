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

namespace Esnafim.Controllers
{
    [Route("api/app")]
    public class AppController : ControllerBase
    {
        private readonly EsnafimContext dbContext;
        private readonly IConfiguration _config;


        public AppController(EsnafimContext context, IConfiguration config)
        {
            dbContext = context;
            _config = config;
        }


        [Route("get_all_dukkanlar"), HttpGet]
        public async Task<ActionResult<Dukkanlar>> getAllDukkanlar()
        {
           var dukkanlar = dbContext.Dukkanlar
            .Where(x => x.Deleted != true).ToList();

            return Ok(dukkanlar);
        }

    }
}
