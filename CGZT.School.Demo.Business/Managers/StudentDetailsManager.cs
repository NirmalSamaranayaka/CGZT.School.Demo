using CGZT.School.Demo.Business.Wrapper;
using CGZT.School.Demo.Common;
using CGZT.School.Demo.Contracts.Common;
using CGZT.School.Demo.Contracts.Manager;
using CGZT.School.Demo.Contracts.Repository;
using CGZT.School.Demo.Entities;
using CGZT.School.Demo.Entities.Common;
using CGZT.School.Demo.Entities.DTO.StudentTeacher;
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
    public class StudentDetailsManager :  IStudentDetailsManager
    {
        /// <summary>
        /// The Student detail repository
        /// </summary>
        private readonly IStudentDetailsRepository _studentDetailsRepository;

        /// <summary>
        /// The student details validator
        /// </summary>
        private readonly IValidator<Students> _studentDetailsValidator;
        /// <summary>
        /// The student details validator
        /// </summary>

        /// <summary>
        /// The service response mapper
        /// </summary>
        private readonly IMapper<object, ServiceResponse> _serviceResponseMapper;

        /// <summary>
        /// The service response error mapper
        /// </summary>
        private readonly IMapper<IList<Message>, ServiceResponse> _serviceResponseErrorMapper;


        private readonly IMapper<StudentDataMapperWrapper, Students> _studentDataMapper;


        /// <summary>
        /// Initializes a new instance of the <see cref="studentDetailsManager"/> class.
        /// </summary>
        /// <param name="studentDetailsRepository">The student details repository.</param>
        /// <param name="studentDetailsValidator">The student details validator.</param>
        /// <param name="serviceResponseMapper">The service response mapper.</param>
        /// <param name="serviceResponseErrorMapper">The service response error mapper.</param>
        public StudentDetailsManager(IStudentDetailsRepository studentDetailsRepository, IValidator<Students> studentDetailsValidator, IMapper<object, ServiceResponse> serviceResponseMapper, IMapper<IList<Message>, ServiceResponse> serviceResponseErrorMapper, IMapper<StudentDataMapperWrapper, Students> studentDataMapper )
        {
            _studentDetailsRepository = studentDetailsRepository;
            _studentDetailsValidator = studentDetailsValidator;
            _serviceResponseErrorMapper = serviceResponseErrorMapper;
            _serviceResponseMapper = serviceResponseMapper;
            _studentDataMapper = studentDataMapper;
        }


        /// <summary>
        /// Gets the student details list.
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResponse> GetStudentDetailsList()
        {
            try
            {
                var returnObject = await _studentDetailsRepository.GetAllStudentDetailAsync();
                return _serviceResponseMapper.Map(returnObject);
            }
            catch
            {
                throw;
            }

        }

        /// <summary>
        /// Inserts the Student details.
        /// </summary>
        /// <param name="StudentDetail">The Student detail.</param>
        /// <returns></returns>
        public ServiceResponse InsertStudentDetails(Students studentDetail)
        {
            try
            {
                StringExtensions.TrimStringProperties<Students>(studentDetail);

                var studentDataMapperWrapper = new StudentDataMapperWrapper { StudentMapper = studentDetail };

                if (!_studentDetailsValidator.Validate(studentDetail, out IList<Message> messages))
                {
                    return _serviceResponseErrorMapper.Map(messages);
                }

                var saveObject = _studentDataMapper.Map(studentDataMapperWrapper);

                var returnObject = _studentDetailsRepository.AddStudentDetail(saveObject);
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
        /// <param name="StudentDetail">The Student detail.</param>
        /// <returns></returns>
        public ServiceResponse UpdateStudentDetails(Students studentDetail)
        {
            try
            {
                StringExtensions.TrimStringProperties<Students>(studentDetail);
                var studentDataMapperWrapper = new StudentDataMapperWrapper { StudentMapper = studentDetail };

                if (!_studentDetailsValidator.Validate(studentDetail, out IList<Message> messages))
                {
                    return _serviceResponseErrorMapper.Map(messages);
                }

                var saveObject = _studentDataMapper.Map(studentDataMapperWrapper);
                var returnObject = _studentDetailsRepository.UpdateStudentDetail(saveObject);
                return _serviceResponseMapper.Map(returnObject);
            }
            catch
            {
                throw;
            }
        }

        public ServiceResponse StudentSuspendDetails(StudentSuspend student)
        {
            try
            {
                
                var studentObj =_studentDetailsRepository.SelectSpecificStudentDetailByEmail(StringExtensions.TrimStringProperties<string>(student.Student));

                var studentDataMapperWrapper = new StudentDataMapperWrapper { StudentMapper = studentObj };

                if (!_studentDetailsValidator.Validate(studentObj, out IList<Message> messages))
                {
                    return _serviceResponseErrorMapper.Map(messages);
                }

                var saveObject = _studentDataMapper.Map(studentDataMapperWrapper);
                saveObject.IsSuspend = true;
                var returnObject = _studentDetailsRepository.UpdateStudentDetail(saveObject);
                return _serviceResponseMapper.Map(returnObject);
            }
            catch
            {
                throw;
            }
        }


    }

}
