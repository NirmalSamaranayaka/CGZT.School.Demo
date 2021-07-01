using CGZT.School.Demo.Entities.DTO.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.Contracts.Repository
{
    public interface INotificationDetailsRepository
    {
        NotificationRecipients SaveStudentTeacherDetails(NotificationRecipients saveObject);
    }
}
