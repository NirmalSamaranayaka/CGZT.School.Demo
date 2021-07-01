using CGZT.School.Demo.Business.Wrapper;
using CGZT.School.Demo.Contracts.Common;
using CGZT.School.Demo.Entities.DTO.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.Business.Mappers.Notification
{
    public class NotificationDataMapper : IMapper<NotificationDataMapperWrapper, NotificationRecipients>
    {

        public NotificationDataMapper()
        {

        }
        public NotificationRecipients Map(NotificationDataMapperWrapper input)
        {
            if (input.notificationMapper!=null && input.notificationMapper.Id > 0)
            {
               
                input.notificationMapper.UpdatedBy = "Nirmal";
                input.notificationMapper.UpdatedAt = DateTime.Now;
                input.notificationMapper.Notification.UpdatedBy = "Nirmal";
                input.notificationMapper.Notification.UpdatedAt = DateTime.Now;
            }
            else
            {
                NotificationRecipients notify = new NotificationRecipients();


                notify.CreatedBy = input.NotificationRequestMapper.Teacher;
                notify.CreatedAt = DateTime.Now;
                notify.Notification = new Notifications
                {
                    Notification = input.NotificationRequestMapper.Notification,
                    CreatedBy = "Nirmal",
                    CreatedAt = DateTime.Now
                };
                input.notificationMapper = notify;
            }
            return input.notificationMapper;
        }
    }

}
