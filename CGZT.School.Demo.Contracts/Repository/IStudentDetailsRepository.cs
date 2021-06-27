using CGZT.School.Demo.Entities.DTO.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.Contracts.Repository
{
    public interface IStudentDetailsRepository
    {
        Student AddStudentDetail(Student cmodityDetail);
        Task<List<Student>> GetAllStudentDetailAsync();
        bool IsExistStudentDetail(string name);
        Student SelectSpecificStudentDetail(int id);
        Student SelectSpecificStudentDetailByEmail(string email);
        Student UpdateStudentDetail(Student cmodityDetail);
    }
}
