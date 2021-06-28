using System;
using System.Collections.Generic;

#nullable disable

namespace CGZT.School.Demo.DataContext.DemoDataModels
{
    public partial class DemoTNotificationRecipient
    {
        public int Id { get; set; }
        public int DemoTNotificationId { get; set; }
        public int DemoTStudentId { get; set; }
        public bool? IsNotificationSent { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual DemoTNotification DemoTNotification { get; set; }
        public virtual DemoTStudent DemoTStudent { get; set; }
    }
}
