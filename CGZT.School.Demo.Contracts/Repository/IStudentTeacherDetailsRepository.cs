using CGZT.School.Demo.Entities.DTO.StudentTeacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.Contracts.Repository
{
    public interface IStudentTeacherDetailsRepository
    {
        List<TeacherStudentMappings> GetTeacherWiseStudentDetails();
        List<string> GetTeacherWiseStudentDetails(List<string> teacher);
        void Save();
        TeacherStudentMappings SaveStudentTeacherDetails(TeacherStudentMappings saveObject);
    }
}
