using CGZT.School.Demo.Entities.Common;
using CGZT.School.Demo.Entities.DTO.StudentTeacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.Contracts.Manager
{
    public interface IStudentDetailsManager
    {
        Task<ServiceResponse> GetStudentDetailsList();
        ServiceResponse InsertStudentDetails(Students StudentDetail);
        ServiceResponse UpdateStudentDetails(Students StudentDetail);

        ServiceResponse StudentSuspendDetails(StudentSuspend student);
    }
}
