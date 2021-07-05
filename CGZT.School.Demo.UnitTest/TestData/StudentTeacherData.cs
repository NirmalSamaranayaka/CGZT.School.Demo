using CGZT.School.Demo.Entities.Common;
using CGZT.School.Demo.Entities.DTO.StudentTeacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.UnitTest.TestData
{
    public static class StudentTeacherData
    {
        public static ServiceResponse GetTeacherWiseStudentDetailTestResponse()
        {
            return new ServiceResponse
            {
                ReturnObject = GetTeacherWiseStudentDetail()
            };
        }
        public static List<TeacherStudentMappings> GetTeacherWiseStudentDetail()
        {
            return new List<TeacherStudentMappings>
                {

                     new TeacherStudentMappings{
                      Id=1,
                      Teacher= "teacherken@gmail.com",
                      Students=new List<string>(){
                        "studentjon@gmail.com",
                        "studenthon@gmail.com",
                        "commonstudent1@gmail.com",
                        "commonstudent2@gmail.com",
                        "student_only_under_teacher_ken@gmail.com"
                      }

                    },
                     new TeacherStudentMappings{
                      Id= 2,
                      Teacher= "teacherjoe@gmail.com",
                      Students=new List<string>(){
                        "commonstudent1@gmail.com",
                        "commonstudent2@gmail.com"
                      }
                    },
                    new TeacherStudentMappings {
                    Id= 3,
                    Teacher="teacherchar@gmail.com",
                    Students= new List<string>(){
                        "studentjon@gmail.com",
                        "studentmary@gmail.com"
                        } 
                    }
            };
        }
    }
}
