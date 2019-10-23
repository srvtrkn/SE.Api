using SE.DataObjects.Auth;
using System;
using System.Threading.Tasks;
using System.Linq;
using SE.DataObjects;

namespace SE.Service.Auth
{
    public class AuthService : IAuthService
    {
        public async Task<EntityResponse<UserDto>> Login(AuthDto authDto)
        {
            try
            {
                string query = string.Format("SELECT * FROM Users where Username={0} and Password={1}", authDto.Username, authDto.Password);
                var data = await DbOperation.RunQueryAsync<UserDto>(query);
                if (data != null)
                {
                    return new EntityResponse<UserDto> { ResponseCode = ResponseCodes.Successful, EntityData = data.FirstOrDefault() };
                }
                return new EntityResponse<UserDto>() { ResponseCode = ResponseCodes.IncorrectLoginCredentials, ResponseErrorMessage = "HATA" };
            }
            catch (Exception ex)
            {
                return new EntityResponse<UserDto>() { ResponseCode = ResponseCodes.IncorrectLoginCredentials, ResponseErrorMessage = ex.Message };
            }
        }
    }
}
