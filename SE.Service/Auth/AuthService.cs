using SE.DataObjects.Auth;
using System;
using System.Threading.Tasks;
using System.Linq;
using SE.Service.DbOperation;
using SE.DataObjects;

namespace SE.Service.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IDbOperation _db;
        public AuthService(IDbOperation db)
        {
            _db = db;
        }
        public async Task<EntityResponse<AuthDto>> Login()
        {
            try
            {
                string query = string.Format("SELECT * From students where id={0}", 1);
                var data = await _db.RunQueryAsync<AuthDto>(query);

                if (data != null)
                {
                    return new EntityResponse<AuthDto> { ResponseCode = ResponseCodes.Successful, EntityData = data.FirstOrDefault() };
                }
                return new EntityResponse<AuthDto>() { ResponseCode = ResponseCodes.IncorrectLoginCredentials, ResponseErrorMessage = "HATA" };
            }
            catch (Exception ex)
            {
                return new EntityResponse<AuthDto>() { ResponseCode = ResponseCodes.IncorrectLoginCredentials, ResponseErrorMessage = ex.Message };
            }
        }
        public async Task<EntityResponse<bool>> Deneme(Token token)
        {
            try
            {
                if (token != null)
                {
                    return new EntityResponse<bool> { ResponseCode = ResponseCodes.Successful, EntityData = true };
                }
                return new EntityResponse<bool>() { ResponseCode = ResponseCodes.IncorrectLoginCredentials, ResponseErrorMessage = "HATA" };
            }
            catch (Exception ex)
            {
                return new EntityResponse<bool>() { ResponseCode = ResponseCodes.IncorrectLoginCredentials, ResponseErrorMessage = ex.Message };
            }
        }

    }
}
