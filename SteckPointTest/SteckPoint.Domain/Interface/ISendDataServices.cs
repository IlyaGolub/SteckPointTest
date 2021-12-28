using SteckPointTestSendData.Domain.Entities;
using System.Net;
using System.Threading.Tasks;

namespace SteckPointTestSendData.Services
{
    public interface ISendDataServices
    {
        Task<HttpStatusCode> SendUserData(object user);
    }
}
