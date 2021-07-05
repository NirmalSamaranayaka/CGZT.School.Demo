using CGZT.School.Demo.Contracts.Common;
using CGZT.School.Demo.Contracts.Manager;
using CGZT.School.Demo.Contracts.MessageHandlers;
using CGZT.School.Demo.Entities;
using CGZT.School.Demo.Entities.Common;
using CGZT.School.Demo.Entities.DTO.StudentTeacher;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGZT.School.Demo.WebAPI.Controllers
{

    [Produces("application/json")]
    [Route("api/Register/V1")]
    public class StudentTeacherDetailsController : Controller
    {
        private readonly IStudentTeacherDetailsManager _studentTeacherDetailsManager;

        private readonly ILogger<StudentTeacherDetailsController> _logger;

        private readonly IMapper<IList<Message>, ServiceResponse> _serviceResponseErrorMapper;

        private readonly ITeacherDetailsErrorMessageHandler _teacherDetailsErrorMessageHandler;
        public StudentTeacherDetailsController(IStudentTeacherDetailsManager studentTeacherDetailsManager, ILogger<StudentTeacherDetailsController> logger, IMapper<IList<Message>, ServiceResponse> serviceResponseErrorMapper, ITeacherDetailsErrorMessageHandler teacherDetailsErrorMessageHandler)
        {
            _studentTeacherDetailsManager = studentTeacherDetailsManager;
            _logger = logger;
            _serviceResponseErrorMapper = serviceResponseErrorMapper;
            _teacherDetailsErrorMessageHandler = teacherDetailsErrorMessageHandler;

        }


        [HttpGet("GetTeacherWiseStudentList")]
        public ServiceResponse GetTeacherWiseStudentDetail()
        {
            try
            {
                return _studentTeacherDetailsManager.GetTeacherWiseStudentDetails();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return _serviceResponseErrorMapper.Map(new List<Message> { });
            }
        }

        [HttpPost("AddTeacherWiseStudentList")]
        public ServiceResponse AddStudentDetail(TeacherStudentMappings request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return _studentTeacherDetailsManager.AddTeacherWiseStudentDetails(request);
                }
                else
                {
                    return _serviceResponseErrorMapper.Map(new List<Message> { _teacherDetailsErrorMessageHandler.InvalidTeacherDetail() });
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return _serviceResponseErrorMapper.Map(new List<Message> { });
            }
        }
    }

}
