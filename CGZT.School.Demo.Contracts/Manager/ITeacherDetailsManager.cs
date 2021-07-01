using CGZT.School.Demo.Entities.Common;
using CGZT.School.Demo.Entities.DTO.StudentTeacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.Contracts.Manager
{
    public interface ITeacherDetailsManager
    {
        Task<ServiceResponse> GetTeacherDetailsList();
        ServiceResponse InsertTeacherDetails(Teacher TeacherDetail);
        ServiceResponse UpdateTeacherDetails(Teacher TeacherDetail);
    }
}
