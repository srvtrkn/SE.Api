using SE.DataObjects;
using SE.DataObjects.Auth;
using System.Threading.Tasks;

namespace SE.Service.Auth
{
    public interface IAuthService
    {
        Task<EntityResponse<UserDto>> Login(AuthDto authDto);
    }
}
