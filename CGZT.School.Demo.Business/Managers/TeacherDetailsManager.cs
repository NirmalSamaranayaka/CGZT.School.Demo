using CGZT.School.Demo.Common;
using CGZT.School.Demo.Contracts.Common;
using CGZT.School.Demo.Contracts.Manager;
using CGZT.School.Demo.Contracts.Repository;
using CGZT.School.Demo.Entities;
using CGZT.School.Demo.Entities.Common;
using CGZT.School.Demo.Entities.DTO.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.Business.Managers
{
    /// <summary>
    /// 
    /// </summary>
    public class TeacherDetailsManager : ITeacherDetailsManager
    {
        /// <summary>
        /// The Teacher detail repository
        /// </summary>
        private readonly ITeacherDetailsRepository _teacherDetailsRepository;

        /// <summary>
        /// The teacher details validator
        /// </summary>
        private readonly IValidator<Teacher> _teacherDetailsValidator;
        /// <summary>
        /// The Teacher details validator
        /// </summary>

        /// <summary>
        /// The service response mapper
        /// </summary>
        private readonly IMapper<object, ServiceResponse> _serviceResponseMapper;

        /// <summary>
        /// The service response error mapper
        /// </summary>
        private readonly IMapper<IList<Message>, ServiceResponse> _serviceResponseErrorMapper;


        /// <summary>
        /// Initializes a new instance of the <see cref="TeacherDetailsManager"/> class.
        /// </summary>
        /// <param name="teacherDetailsRepository">The teacher details repository.</param>
        /// <param name="teacherDetailsValidator">The teacher details validator.</param>
        /// <param name="serviceResponseMapper">The service response mapper.</param>
        /// <param name="serviceResponseErrorMapper">The service response error mapper.</param>
        public TeacherDetailsManager(ITeacherDetailsRepository teacherDetailsRepository, IValidator<Teacher> teacherDetailsValidator, IMapper<object, ServiceResponse> serviceResponseMapper, IMapper<IList<Message>, ServiceResponse> serviceResponseErrorMapper)
        {
            _teacherDetailsRepository = teacherDetailsRepository;
            _teacherDetailsValidator = teacherDetailsValidator;
            _serviceResponseErrorMapper = serviceResponseErrorMapper;
            _serviceResponseMapper = serviceResponseMapper;
        }


        /// <summary>
        /// Gets the teacher details list.
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResponse> GetTeacherDetailsList()
        {
            try
            {
                var returnObject = await _teacherDetailsRepository.GetAllTeacherDetailAsync();
                return _serviceResponseMapper.Map(returnObject);
            }
            catch
            {
                throw;
            }

        }

        /// <summary>
        /// Inserts the teacher details.
        /// </summary>
        /// <param name="TeacherDetail">The teacher detail.</param>
        /// <returns></returns>
        public ServiceResponse InsertTeacherDetails(Teacher TeacherDetail)
        {
            try
            {
                StringExtensions.TrimStringProperties<Teacher>(TeacherDetail);

                if (!_teacherDetailsValidator.Validate(TeacherDetail, out IList<Message> messages))
                {
                    return _serviceResponseErrorMapper.Map(messages);
                }

                var returnObject = _teacherDetailsRepository.AddTeacherDetail(TeacherDetail);
                return _serviceResponseMapper.Map(returnObject);

            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Updates the type of the test.
        /// </summary>
        /// <param name="TeacherDetail">The teacher detail.</param>
        /// <returns></returns>
        public ServiceResponse UpdateTeacherDetails(Teacher TeacherDetail)
        {
            try
            {
                StringExtensions.TrimStringProperties<Teacher>(TeacherDetail);


                if (!_teacherDetailsValidator.Validate(TeacherDetail, out IList<Message> messages))
                {
                    return _serviceResponseErrorMapper.Map(messages);
                }
                var returnObject = _teacherDetailsRepository.UpdateTeacherDetail(TeacherDetail);
                return _serviceResponseMapper.Map(returnObject);
            }
            catch
            {
                throw;
            }
        }

    }
}
