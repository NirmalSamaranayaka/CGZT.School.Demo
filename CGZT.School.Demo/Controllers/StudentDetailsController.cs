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
    [Route("api/Student/V1")]
    public class StudentDetailsController : Controller
    {
        /// <summary>
        /// The Student detailse manager
        /// </summary>
        private readonly IStudentDetailsManager _studentDetailseManager;


        private readonly ILogger<StudentDetailsController> _logger;

        /// <summary>
        /// The service response error mapper
        /// </summary>
        private readonly IMapper<IList<Message>, ServiceResponse> _serviceResponseErrorMapper;

        /// <summary>
        /// The Student details error message handler
        /// </summary>
        private readonly IStudentDetailsErrorMessageHandler _studentDetailsErrorMessageHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentDetailsController"/> class.
        /// </summary>
        /// <param name="StudentDetailseManager">The Student detailse manager.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceResponseErrorMapper">The service response error mapper.</param>
        /// <param name="StudentDetailsErrorMessageHandler">The Student details error message handler.</param>
        public StudentDetailsController(IStudentDetailsManager studentDetailseManager, ILogger<StudentDetailsController> logger, IMapper<IList<Message>, ServiceResponse> serviceResponseErrorMapper,
            IStudentDetailsErrorMessageHandler studentDetailsErrorMessageHandler)
        {
            _studentDetailseManager = studentDetailseManager;
            _logger = logger;
            _serviceResponseErrorMapper = serviceResponseErrorMapper;
            _studentDetailsErrorMessageHandler = studentDetailsErrorMessageHandler;
        }


        /// <summary>
        /// Gets all Student detail.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ServiceResponse> GetAllStudentDetail()
        {
            try
            {
                return await _studentDetailseManager.GetStudentDetailsList();
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
        [HttpPost("AddStudentDetail")]
        public ServiceResponse AddStudentDetail([FromBody] Students student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return _studentDetailseManager.InsertStudentDetails(student);
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

        /// <summary>
        /// Updates the type of the test.
        /// </summary>
        /// <param name="testType">Type of the test.</param>
        /// <returns></returns>
        [HttpPost("UpdateStudentDetail")]
        public ServiceResponse UpdateStudentDetail([FromBody] Students student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return _studentDetailseManager.UpdateStudentDetails(student);
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
