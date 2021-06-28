using System;
using System.Collections.Generic;

#nullable disable

namespace CGZT.School.Demo.DataContext.DemoDataModels
{
    public partial class DemoTNotification
    {
        public DemoTNotification()
        {
            DemoTNotificationRecipients = new HashSet<DemoTNotificationRecipient>();
        }

        public int Id { get; set; }
        public int DemoTTeacherId { get; set; }
        public string Notification { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual DemoTTeacher DemoTTeacher { get; set; }
        public virtual ICollection<DemoTNotificationRecipient> DemoTNotificationRecipients { get; set; }
    }
}
