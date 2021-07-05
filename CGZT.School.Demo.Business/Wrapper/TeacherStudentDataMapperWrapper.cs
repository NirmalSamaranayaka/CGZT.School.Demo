using CGZT.School.Demo.Entities.DTO.StudentTeacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.Business.Wrapper
{
    public class TeacherStudentDataMapperWrapper
    {
        public List<TeacherStudentWithIDMapper> teacherStudentWithIDMapper { get; set; }
        public TeacherStudentWithID teacherStudentWithID { get; set; }
    }
}
