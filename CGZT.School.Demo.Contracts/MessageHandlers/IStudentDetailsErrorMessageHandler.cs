using CGZT.School.Demo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.Contracts.MessageHandlers
{
    public interface IStudentDetailsErrorMessageHandler
    {
        Message StudentDetailAlreadyExists();
        Message InvalidStudentDetail();
    }
}
