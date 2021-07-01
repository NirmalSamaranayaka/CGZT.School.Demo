using CGZT.School.Demo.Entities.Common;
using CGZT.School.Demo.Entities.DTO.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.Contracts.Manager
{
    public interface INotificationDetailsManager
    {
        ServiceResponse AddNotificationDetails(NotificationRequest request);
    }
}
