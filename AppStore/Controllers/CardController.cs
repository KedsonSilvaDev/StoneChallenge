using AppStore.Business.Entities;
using AppStore.Business.Interfaces;
using AppStore.Business.Mapper;
using AppStore.Business.Models;
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
    public class CardController : ControllerBase
    {
        private readonly ICardServices _cardServices;
        private readonly IUserServices _userServices;
        private readonly ILogger _loggerCard;

        public CardController(ICardServices cardServices, IUserServices userServices, ILogger<CardController> loggerCard)
        {
            this._cardServices = cardServices;
            this._userServices = userServices;
            this._loggerCard = loggerCard;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Purchase), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Purchase), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCard(CardModel cardModel)
        {
            try
            {
                TryValidateModel(cardModel);

                Card card = await _cardServices.CreateCard(cardModel.CardToModel());

                return Ok(card);
            }
            catch (Exception ex)
            {
                _loggerCard.LogInformation(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
