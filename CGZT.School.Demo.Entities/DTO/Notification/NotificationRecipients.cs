using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.Entities.DTO.Notification
{
    public class NotificationRecipients : BaseEntity
    {
        public int Id { get; set; }
        public int DemoTNotificationId { get; set; }
        public int DemoTStudentId { get; set; }
        public bool? IsNotificationSent { get; set; }
        public virtual Notifications Notification { get; set; }
    }
}
