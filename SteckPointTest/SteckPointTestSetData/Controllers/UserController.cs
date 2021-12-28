using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SteckPointTestSetData.Model;
using SteckPointTestSetData.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteckPointTestSetData.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IConfiguration configuration;
        private readonly IUserServices sendDataServices;
        public UserController(ILogger<UserController> logger, IUserServices sendDataServices)
        {
            _logger = logger;
            this.sendDataServices = sendDataServices;
        }

        [HttpPost("SetUser")]
        public async Task<ActionResult> Post([FromBody] User dataUser)
        {
            if (string.IsNullOrEmpty(dataUser.Email))
            {
                _logger.LogInformation("Email Must be filled");
                return BadRequest("Email Must be filled");
            }
            if (string.IsNullOrEmpty(dataUser.Name))
            {
                _logger.LogInformation("Name Must be filled");
                return BadRequest("Name Must be filled");
            }
            if (string.IsNullOrEmpty(dataUser.LastName))
            {
                _logger.LogInformation("LastName Must be filled");
                return BadRequest("LastName Must be filled");
            }
            if (string.IsNullOrEmpty(dataUser.PhoneNamber))
            {
                _logger.LogInformation("PhoneNamber Must be filled");
                return BadRequest("PhoneNamber Must be filled");
            }

            var result = await sendDataServices.SendUserData(dataUser);

            return Ok(new { Success = result });
        }
    }
}
