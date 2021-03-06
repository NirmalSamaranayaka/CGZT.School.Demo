using System;
using System.Collections.Generic;

#nullable disable

namespace CGZT.School.Demo.DataContext.DemoDataModels
{
    public partial class DemoTStudent
    {
        public DemoTStudent()
        {
            DemoTNotificationRecipients = new HashSet<DemoTNotificationRecipient>();
            DemoTTeacherStudentMappings = new HashSet<DemoTTeacherStudentMapping>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool? IsSuspend { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<DemoTNotificationRecipient> DemoTNotificationRecipients { get; set; }
        public virtual ICollection<DemoTTeacherStudentMapping> DemoTTeacherStudentMappings { get; set; }
    }
}
