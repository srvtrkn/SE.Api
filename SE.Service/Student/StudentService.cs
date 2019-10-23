using SE.DataObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SE.Service.Student
{
    public class StudentService : IStudentService
    {
        public async Task<EntityListResponse<object>> GetStudentList()
        {
            try
            {
                string query = string.Format("SELECT * FROM Students");
                var data = await DbOperation.RunQueryAsync<object>(query);
                if (data != null)
                {
                    return new EntityListResponse<object> { ResponseCode = ResponseCodes.Successful, EntityDataList = data };
                }
                return new EntityListResponse<object>() { ResponseCode = ResponseCodes.IncorrectLoginCredentials, ResponseErrorMessage = "HATA" };
            }
            catch (Exception ex)
            {
                return new EntityListResponse<object>() { ResponseCode = ResponseCodes.IncorrectLoginCredentials, ResponseErrorMessage = ex.Message };
            }
        }
    }
}
