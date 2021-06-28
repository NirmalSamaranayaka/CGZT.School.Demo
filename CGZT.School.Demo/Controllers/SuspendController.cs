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
    [Route("api/Suspend/V1")]
    public class SuspendController : Controller
    {
        private readonly IStudentDetailsManager _studentDetailsManager;

        private readonly ILogger<SuspendController> _logger;

        private readonly IMapper<IList<Message>, ServiceResponse> _serviceResponseErrorMapper;

        private readonly IStudentDetailsErrorMessageHandler _studentDetailsErrorMessageHandler;
        public SuspendController(IStudentDetailsManager studentDetailsManager, ILogger<SuspendController> logger, IMapper<IList<Message>, ServiceResponse> serviceResponseErrorMapper, IStudentDetailsErrorMessageHandler studentDetailsErrorMessageHandler)
        {
            _studentDetailsManager = studentDetailsManager;
            _logger = logger;
            _studentDetailsErrorMessageHandler = studentDetailsErrorMessageHandler;
            _serviceResponseErrorMapper = serviceResponseErrorMapper;

        }

        [HttpPost("StudentSuspend")]
        public ServiceResponse AddStudentDetail([FromBody] StudentSuspend request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return _studentDetailsManager.StudentSuspendDetails(request);
                }
                else
                {
                    return _serviceResponseErrorMapper.Map(new List<Message> { _studentDetailsErrorMessageHandler.InvalidStudentDetail() });
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
