using AutoMapper;
using AutoMapper.Configuration;
using SteckPointTestSetData.Domain.Entities;
using SteckPointTestSeTData.Infrastructure.Data;
using System.Threading.Tasks;

namespace SteckPointTestSendData.Infrastructure
{
    public class UserServices
    {
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
        private readonly UsersContex context;

        public UserServices(IConfiguration configuration, IMapper mapper)
        {
            this.configuration = configuration;
            this.mapper = mapper;
        }
        public async Task<bool> SendUserData(object user)
        {

            var userDTO = mapper.Map<UsersDTO>(user);

            if (userDTO != null)
            {
                context.Users.Add(userDTO);
                var result = await context.SaveChangesAsync();
                return result == 1;
            }
            else
            {
                return false;
            }
        }
    }
}
