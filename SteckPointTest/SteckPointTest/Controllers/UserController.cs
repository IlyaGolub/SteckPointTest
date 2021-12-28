using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SteckPointTestSendData.Model;
using SteckPointTestSendData.Services;
using System.Threading.Tasks;

namespace SteckPointTestSendData.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IConfiguration configuration;
        private readonly ISendDataServices sendDataServices;


        public UserController(ILogger<UserController> logger, IConfiguration configuration, ISendDataServices sendDataServices)
        {
            _logger = logger;
            this.configuration = configuration;
            this.sendDataServices = sendDataServices;
        }

        [HttpPost("SetUserData")]
        public async Task<ActionResult> Get([FromBody] User dataUser)
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
            
            if (result == System.Net.HttpStatusCode.OK) return Ok(new { result });
            else return BadRequest(new  {StatusCode = result });
        }
    }
}
