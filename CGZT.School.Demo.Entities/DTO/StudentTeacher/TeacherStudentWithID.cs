using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.Entities.DTO.StudentTeacher
{
    public class TeacherStudentWithID
    {
        public int TeacherId { get; set; }
        public List<int> StudentId { get; set; }
    }
}
