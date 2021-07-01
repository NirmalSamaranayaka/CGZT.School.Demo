using CGZT.School.Demo.Entities.DTO.StudentTeacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.Contracts.Repository
{
    public interface IStudentDetailsRepository
    {
        Students AddStudentDetail(Students cmodityDetail);
        Task<List<Students>> GetAllStudentDetailAsync();
        bool IsExistStudentDetail(string name);
        Students SelectSpecificStudentDetail(int id);
        Students SelectSpecificStudentDetailByEmail(string email);
        Students UpdateStudentDetail(Students cmodityDetail);
    }
}
