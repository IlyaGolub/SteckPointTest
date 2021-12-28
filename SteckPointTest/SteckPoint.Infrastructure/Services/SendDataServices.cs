using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SteckPointTestSendData.Domain.Entities;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SteckPointTestSendData.Services
{
    public class SendDataServices: ISendDataServices
    {
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;

        public SendDataServices(IConfiguration configuration, IMapper mapper)
        {         
            this.configuration = configuration;
            this.mapper = mapper;
        }

        public async Task<HttpStatusCode> SendUserData(object user)
        {
            var userDTO = mapper.Map<UsersDTO>(user);
            var client = new HttpClient();            
            var response = await client.PostAsync($"{configuration.GetSection("UrlForSendData").Value}", new StringContent(JsonSerializer.Serialize(userDTO).ToString(), Encoding.UTF8, "application/json"));
            return response.StatusCode;
        }
    }
}
