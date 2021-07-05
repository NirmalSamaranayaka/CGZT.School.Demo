using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.Entities.DTO.StudentTeacher
{
    public class TeacherStudentWithIDMapper:BaseEntity
    { 
        public int TeacherId { get; set; }
        public int StudentId { get; set; }

    }
}
