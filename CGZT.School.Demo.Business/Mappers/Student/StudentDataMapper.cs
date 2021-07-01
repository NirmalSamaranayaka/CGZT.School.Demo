using CGZT.School.Demo.Business.Wrapper;
using CGZT.School.Demo.Contracts.Common;
using CGZT.School.Demo.Entities.DTO.StudentTeacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.Business.Mappers.Student
{
    public class StudentDataMapper : IMapper<StudentDataMapperWrapper, Students>
    {

        public StudentDataMapper()
        {

        }
        public Students Map(StudentDataMapperWrapper input)
        {
            if (input.StudentMapper.Id > 0)
            {
                input.StudentMapper.UpdatedBy = "Nirmal";
                input.StudentMapper.UpdatedAt = DateTime.Now;
            }
            else
            {
                input.StudentMapper.CreatedBy = "Nirmal";
                input.StudentMapper.CreatedAt = DateTime.Now;

            }
            return input.StudentMapper;
        }
    }

}
