using AppStore.Business.Entities;
using AppStore.Business.Enums;
using AppStore.Business.Interfaces;
using AppStore.Business.Mapper;
using AppStore.Business.Models;
using AppStore.Business.Validator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseServices _purchaseServices;
        private readonly IUserServices _userServices;
        private readonly ICardServices _cardServices;
        private readonly IShopServices _shopServices;
        private readonly ILogger _loggerPurchase;

        public PurchaseController(IPurchaseServices purchaseServices, IUserServices userServices, ICardServices cardServices, IShopServices shopServices, ILogger<PurchaseController> loggerPurchase)
        {
           this._purchaseServices = purchaseServices;
           this._userServices = userServices;
           this._cardServices = cardServices;
           this._shopServices = shopServices;
           this._loggerPurchase = loggerPurchase;
        }

        [HttpPost("CreatePurchaseUser")]
        [ProducesResponseType(typeof(Purchase), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Purchase), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePurchaseUser(PurchaseModel purchaseModel)
        {
            try
            {
                TryValidateModel(purchaseModel);                                     

                Purchase purchase = await _purchaseServices.CreatePurchaseUser(purchaseModel.PurchaseToModel());

                return Ok(purchase);
            }
            catch (Exception ex)
            {
                _loggerPurchase.LogInformation(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet()]
        [ProducesResponseType(typeof(Purchase), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Purchase), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPurchaseById(string purchaseId)
        {
            try
            {
                if (purchaseId.Length != 24)
                    throw new Exception("Id de compra deve conter 24 caracteres");

                Purchase purchase = await _purchaseServices.GetPurchaseById(purchaseId);

                if (purchase == null)
                    throw new Exception("Compra não encontrada");
                
                return Ok(purchase);
            }
            catch (Exception ex)
            {
                _loggerPurchase.LogInformation(ex.Message);
                return BadRequest(ex.Message);
            }

            
        }
    }
}
