using SE.DataObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SE.Service.Student
{
    public interface IStudentService
    {
        Task<EntityListResponse<object>> GetStudentList();
    }
}
