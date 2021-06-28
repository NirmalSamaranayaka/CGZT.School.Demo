using CGZT.School.Demo.Entities.Common;
using CGZT.School.Demo.Entities.DTO.StudentTeacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.Contracts.Manager
{
    public interface IStudentTeacherDetailsManager
    {
        ServiceResponse GetTeacherWiseStudentDetails();
        ServiceResponse GetTeacherWiseStudentDetails(List<string> teacher);
        ServiceResponse AddTeacherWiseStudentDetails(TeacherStudentMapping request);
    }
}
