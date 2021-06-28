using CGZT.School.Demo.Entities.DTO.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.Business.Wrapper
{
    public class NotificationDataMapperWrapper
    {
        public NotificationRecipients notificationMapper { get; set; }
        public NotificationRequest NotificationRequestMapper { get; set; }
    }
}
