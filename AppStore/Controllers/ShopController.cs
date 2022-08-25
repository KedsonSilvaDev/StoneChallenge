using AppStore.Business.Entities;
using AppStore.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopController : ControllerBase
    {
        private readonly IShopServices _shopServices;
        private readonly ILogger _loggerShop;

        public ShopController(IShopServices shopServices, ILogger<ShopController> loggerPurchase)
        {
            this._shopServices = shopServices;
            this._loggerShop = loggerPurchase;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Purchase), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Purchase), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetShop()
        {
            try
            {
                List<Shop> shopApps = await _shopServices.GetShop();

                return Ok(shopApps);
            }
            catch (Exception ex)
            {
                _loggerShop.LogInformation(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
