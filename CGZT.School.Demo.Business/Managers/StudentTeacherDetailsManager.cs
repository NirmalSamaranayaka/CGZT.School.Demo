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
    public class StudentTeacherDetailsManager : IStudentTeacherDetailsManager
    {
        private readonly IStudentTeacherDetailsRepository _studentTeacherDetailsRepository;


        private readonly IMapper<object, ServiceResponse> _serviceResponseMapper;

        private readonly IMapper<TeacherStudentDataMapperWrapper, List<TeacherStudentWithIDMapper>> _teacherStudentDataMapper;

        public StudentTeacherDetailsManager(IStudentTeacherDetailsRepository studentTeacherDetailsRepository, IMapper<object, ServiceResponse> serviceResponseMapper, IMapper<TeacherStudentDataMapperWrapper, List<TeacherStudentWithIDMapper>> teacherStudentDataMapper)
        {
            _studentTeacherDetailsRepository = studentTeacherDetailsRepository;
            _serviceResponseMapper = serviceResponseMapper;
            _teacherStudentDataMapper = teacherStudentDataMapper;
        }

        public ServiceResponse GetTeacherWiseStudentDetails()
        {
            try
            {
                var returnObject = _studentTeacherDetailsRepository.GetTeacherWiseStudentDetails();
                return _serviceResponseMapper.Map(returnObject);
            }
            catch
            {
                throw;
            }
        }

        public ServiceResponse GetTeacherWiseStudentDetails(List<string> teacher)
        {
            try
            {
                var returnObject = _studentTeacherDetailsRepository.GetTeacherWiseStudentDetails(teacher);
                return _serviceResponseMapper.Map(returnObject);
            }
            catch
            {
                throw;
            }
        }

        public ServiceResponse AddTeacherWiseStudentDetails(TeacherStudentMappings request)
        {
            try
            {
                StringExtensions.TrimStringProperties<TeacherStudentMappings>(request);

                var returnObj= _studentTeacherDetailsRepository.getTeacherStudentByEmail(request);


                var teacherStudentDataMapperWrapper = new TeacherStudentDataMapperWrapper {teacherStudentWithID  = returnObj };
                //if (!_studentDetailsValidator.Validate(request, out IList<Message> messages))
                //{
                //    return _serviceResponseErrorMapper.Map(messages);
                //}

                var saveObject = _teacherStudentDataMapper.Map(teacherStudentDataMapperWrapper);
                var returnObject = _studentTeacherDetailsRepository.SaveStudentTeacherDetails(saveObject);
                return _serviceResponseMapper.Map(returnObject);

            }
            catch
            {
                throw;
            }
        }

    }

}
