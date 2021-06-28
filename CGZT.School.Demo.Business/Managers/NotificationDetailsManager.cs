using CGZT.School.Demo.Business.Wrapper;
using CGZT.School.Demo.Common;
using CGZT.School.Demo.Contracts.Common;
using CGZT.School.Demo.Contracts.Manager;
using CGZT.School.Demo.Contracts.Repository;
using CGZT.School.Demo.Entities.Common;
using CGZT.School.Demo.Entities.DTO.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.Business.Managers
{
    public class NotificationDetailsManager : INotificationDetailsManager
    {
        private readonly INotificationDetailsRepository _notificationDetailsRepository;

        private readonly ITeacherDetailsRepository teacherDetailsRepository;


        private readonly IMapper<object, ServiceResponse> _serviceResponseMapper;

        private readonly IMapper<NotificationDataMapperWrapper, NotificationRecipients> _notificationDataMapper;

        public NotificationDetailsManager(INotificationDetailsRepository notificationDetailsRepository, IMapper<object, ServiceResponse> serviceResponseMapper, IMapper<NotificationDataMapperWrapper, NotificationRecipients> notificationDataMapper)
        {
            _notificationDetailsRepository = notificationDetailsRepository;
            _serviceResponseMapper = serviceResponseMapper;
            _notificationDataMapper = notificationDataMapper;
        }

        public ServiceResponse AddNotificationDetails(NotificationRequest request)
        {
            try
            {
                StringExtensions.TrimStringProperties<NotificationRequest>(request);

                var notificationDataMapperWrapper = new NotificationDataMapperWrapper { NotificationRequestMapper = request };

                //if (!_studentDetailsValidator.Validate(request, out IList<Message> messages))
                //{
                //    return _serviceResponseErrorMapper.Map(messages);
                //}

                var saveObject = _notificationDataMapper.Map(notificationDataMapperWrapper);
                var returnObject = _notificationDetailsRepository.SaveStudentTeacherDetails(saveObject);
                return _serviceResponseMapper.Map(returnObject);

            }
            catch
            {
                throw;
            }
        }

    }

}
