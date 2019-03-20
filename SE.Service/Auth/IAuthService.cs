using SE.DataObjects;
using SE.DataObjects.Auth;
using System.Threading.Tasks;

namespace SE.Service.Auth
{
    public interface IAuthService
    {
        Task<EntityResponse<AuthDto>> Login();
        Task<EntityResponse<bool>> Deneme(Token token);
    }
}
