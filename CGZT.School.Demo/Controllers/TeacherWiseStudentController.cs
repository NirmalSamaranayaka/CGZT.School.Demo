using CGZT.School.Demo.Contracts.Common;
using CGZT.School.Demo.Contracts.Manager;
using CGZT.School.Demo.Contracts.MessageHandlers;
using CGZT.School.Demo.Entities;
using CGZT.School.Demo.Entities.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGZT.School.Demo.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/CommonStudents/V1")]
    public class TeacherWiseStudentController : Controller
    {

        private readonly IStudentTeacherDetailsManager _studentTeacherDetailsManager;

        private readonly ILogger<StudentTeacherDetailsController> _logger;

        private readonly IMapper<IList<Message>, ServiceResponse> _serviceResponseErrorMapper;

        private readonly ITeacherDetailsErrorMessageHandler _teacherDetailsErrorMessageHandler;
        public TeacherWiseStudentController(IStudentTeacherDetailsManager studentTeacherDetailsManager, ILogger<StudentTeacherDetailsController> logger, IMapper<IList<Message>, ServiceResponse> serviceResponseErrorMapper, ITeacherDetailsErrorMessageHandler teacherDetailsErrorMessageHandler)
        {
            _studentTeacherDetailsManager = studentTeacherDetailsManager;
            _logger = logger;
            _teacherDetailsErrorMessageHandler = teacherDetailsErrorMessageHandler;
            _serviceResponseErrorMapper = serviceResponseErrorMapper;

        }


        [HttpGet("GetTeacherWiseCommonStudentList")]
        public ServiceResponse GetTeacherWiseStudentDetail(List<string> teacher)
        {
            try
            {
                return _studentTeacherDetailsManager.GetTeacherWiseStudentDetails(teacher);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return _serviceResponseErrorMapper.Map(new List<Message> { });
            }
        }

    }
}
