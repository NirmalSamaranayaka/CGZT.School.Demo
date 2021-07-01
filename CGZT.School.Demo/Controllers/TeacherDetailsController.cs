using CGZT.School.Demo.Business.Managers;
using CGZT.School.Demo.Contracts.Common;
using CGZT.School.Demo.Contracts.Manager;
using CGZT.School.Demo.Contracts.MessageHandlers;
using CGZT.School.Demo.Entities;
using CGZT.School.Demo.Entities.Common;
using CGZT.School.Demo.Entities.DTO.StudentTeacher;
using CGZT.School.Demo.Resources.Teacher;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGZT.School.Demo.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Teacher/V1")]
    public class TeacherDetailsController : Controller
    {
        /// <summary>
        /// The teacher detailse manager
        /// </summary>
        private readonly ITeacherDetailsManager _teacherDetailseManager;


        private readonly ILogger<TeacherDetailsController> _logger;

        /// <summary>
        /// The service response error mapper
        /// </summary>
        private readonly IMapper<IList<Message>, ServiceResponse> _serviceResponseErrorMapper;

        /// <summary>
        /// The teacher details error message handler
        /// </summary>
        private readonly ITeacherDetailsErrorMessageHandler _teacherDetailsErrorMessageHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="teacherDetailsController"/> class.
        /// </summary>
        /// <param name="teacherDetailseManager">The teacher detailse manager.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceResponseErrorMapper">The service response error mapper.</param>
        /// <param name="teacherDetailsErrorMessageHandler">The teacher details error message handler.</param>
        public TeacherDetailsController(ITeacherDetailsManager teacherDetailseManager, ILogger<TeacherDetailsController> logger, IMapper<IList<Message>, ServiceResponse> serviceResponseErrorMapper,
            ITeacherDetailsErrorMessageHandler teacherDetailsErrorMessageHandler)
        {
            _teacherDetailseManager = teacherDetailseManager;
            _logger = logger;
            _serviceResponseErrorMapper = serviceResponseErrorMapper;
            _teacherDetailsErrorMessageHandler = teacherDetailsErrorMessageHandler;
        }


        /// <summary>
        /// Gets all teacher detail.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ServiceResponse> GetAllTeacherDetail()
        {
            try
            {
                return await _teacherDetailseManager.GetTeacherDetailsList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return _serviceResponseErrorMapper.Map(new List<Message> { });
            }
        }

        /// <summary>
        /// Inserts the type of the test.
        /// </summary>
        /// <param name="testType">Type of the test.</param>
        /// <returns></returns>
        [HttpPost("AddTeacherDetail")]
        public ServiceResponse AddTeacherDetail([FromBody] Teacher testType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return _teacherDetailseManager.InsertTeacherDetails(testType);
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

        /// <summary>
        /// Updates the type of the test.
        /// </summary>
        /// <param name="testType">Type of the test.</param>
        /// <returns></returns>
        [HttpPost("UpdateteacherDetail")]
        public ServiceResponse UpdateteacherDetail([FromBody] Teacher testType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return _teacherDetailseManager.UpdateTeacherDetails(testType);
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
