using AppStore.Business.Entities;
using AppStore.Business.Interfaces;
using AppStore.Business.Mapper;
using AppStore.Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AppStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly ILogger _loggerUser;

        public UserController(IUserServices userServices, ILogger<UserController> loggerUser)
        {
            this._userServices = userServices;
            this._loggerUser = loggerUser;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Purchase), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Purchase), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUserLogin(UserModel userModel)
        {
            try
            {
                TryValidateModel(userModel);

                User user = await _userServices.CreateUserLogin(userModel.UserToModel());
                return Ok(user);
            }
            catch (Exception ex)
            {
                _loggerUser.LogInformation(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
