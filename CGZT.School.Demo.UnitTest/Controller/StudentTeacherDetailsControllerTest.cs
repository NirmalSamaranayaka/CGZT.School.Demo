using CGZT.School.Demo.Contracts.Common;
using CGZT.School.Demo.Contracts.Manager;
using CGZT.School.Demo.Contracts.MessageHandlers;
using CGZT.School.Demo.Entities;
using CGZT.School.Demo.Entities.Common;
using CGZT.School.Demo.Entities.DTO.StudentTeacher;
using CGZT.School.Demo.UnitTest.Helpers;
using CGZT.School.Demo.UnitTest.TestData;
using CGZT.School.Demo.WebAPI.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace CGZT.School.Demo.UnitTest.Controller
{
    public class StudentTeacherDetailsControllerTest
    {
        [Fact]
        public void Api_should_return_known_studentteacher_list()
        {
            // ARRANGE 
            var mockStudentTeacherManager = new Mock<IStudentTeacherDetailsManager>();
            var mockCustomLogger = new Mock<ILogger<StudentTeacherDetailsController>>();
            var mockErrorMessages = new Mock<ITeacherDetailsErrorMessageHandler>();
            var mokeserviceResponseErrorMapper = new Mock<IMapper<IList<Message>, ServiceResponse>>();

            var qs = new Dictionary<string, StringValues>
            {
            };

            var queryCollection = new QueryCollection(qs);
            var httpRequest = TestFactory.CreateHttpRequest(queryCollection, null);

            mockStudentTeacherManager.Setup(x => x.GetTeacherWiseStudentDetails())
               .Returns(StudentTeacherData.GetTeacherWiseStudentDetailTestResponse());


            // INJECT 
            StudentTeacherDetailsController studentTeacherDetailsController = new StudentTeacherDetailsController(
                mockStudentTeacherManager.Object, mockCustomLogger.Object, mokeserviceResponseErrorMapper.Object, mockErrorMessages.Object);

            //ACT
            var response = studentTeacherDetailsController.GetTeacherWiseStudentDetail();

            //ASSERT
            var serviceResponse = Assert.IsType<ServiceResponse>(response);
            var returnObject = Assert.IsType<List<TeacherStudentMappings>>(serviceResponse.ReturnObject);
            Assert.Equal((StudentTeacherData.GetTeacherWiseStudentDetailTestResponse().ReturnObject as List<TeacherStudentMappings>).Count, returnObject.Count);
        }

    }
}
