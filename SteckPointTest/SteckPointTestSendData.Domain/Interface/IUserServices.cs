using System.Net;
using System.Threading.Tasks;

namespace SteckPointTestSetData.Services
{
    public interface IUserServices
    {
        Task<bool> SendUserData(object user);
    }
}
