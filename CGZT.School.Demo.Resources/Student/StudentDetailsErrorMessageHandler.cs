using CGZT.School.Demo.Contracts.MessageHandlers;
using CGZT.School.Demo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.Resources.Student
{
    public class StudentDetailsErrorMessageHandler : IStudentDetailsErrorMessageHandler
    {
        public Message StudentDetailAlreadyExists()
        {
            return new Message
            {
                Code = "E0001",
                Description = StudentDetailsErrorResourceMessageHandler.E0001
            };
        }
        public Message InvalidStudentDetail()
        {
            return new Message
            {
                Code = "E0002",
                Description = StudentDetailsErrorResourceMessageHandler.E0002
            };
        }
    }
}
