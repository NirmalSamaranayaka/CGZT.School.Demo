using CGZT.School.Demo.Contracts.MessageHandlers;
using CGZT.School.Demo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.Resources.Teacher
{
    public class TeacherDetailsErrorMessageHandler : ITeacherDetailsErrorMessageHandler
    {
        public Message TeacherDetailAlreadyExists()
        {
            return new Message
            {
                Code = "E0001",
                Description = TeacherDetailsErrorResourceMessageHandler.E0001
            };
        }
        public Message InvalidTeacherDetail()
        {
            return new Message
            {
                Code = "E0002",
                Description = TeacherDetailsErrorResourceMessageHandler.E0002
            };
        }
    }
}
