using CGZT.School.Demo.Business.Wrapper;
using CGZT.School.Demo.Contracts.Common;
using CGZT.School.Demo.Entities.DTO.StudentTeacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.Business.Mappers.TeacherStudent
{
    public class TeacherStudentDataMapper : IMapper<TeacherStudentDataMapperWrapper, List<TeacherStudentWithIDMapper>>
    {

        public TeacherStudentDataMapper()
        {

        }
        public List<TeacherStudentWithIDMapper> Map(TeacherStudentDataMapperWrapper input)
        {
            input.teacherStudentWithIDMapper = new List<TeacherStudentWithIDMapper>();

            foreach(var studentId in input.teacherStudentWithID.StudentId)
            {
                var mapdata = new TeacherStudentWithIDMapper
                {
                    CreatedBy = "Nirmal",
                    CreatedAt = DateTime.Now,
                    StudentId = studentId,
                    TeacherId = input.teacherStudentWithID.TeacherId
                };
                
                input.teacherStudentWithIDMapper.Add(mapdata);
            }

            return input.teacherStudentWithIDMapper;
        }
    }
}
