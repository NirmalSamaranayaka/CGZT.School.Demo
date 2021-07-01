using CGZT.School.Demo.Entities.DTO.StudentTeacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.Contracts.Repository
{
    public interface ITeacherDetailsRepository
    {
        Teacher AddTeacherDetail(Teacher cmodityDetail);
        Task<List<Teacher>> GetAllTeacherDetailAsync();
        bool IsExistTeacherDetail(string name);
        Teacher SelectSpecificTeacherDetail(int id);
        Teacher SelectSpecificTeacherDetailByEmail(string email);
        Teacher UpdateTeacherDetail(Teacher cmodityDetail);
    }
}
