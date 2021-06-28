using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.Entities.DTO.StudentTeacher
{
    public class TeacherStudentMapping
    {
        public int Id { get; set; }
        public string Teacher { get; set; }
        public IEnumerable<string> Students { get; set; }
    }
}
