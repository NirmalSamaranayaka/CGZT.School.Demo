using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.Entities.DTO.Notification
{
    public class Notifications :BaseEntity
    {
        public int Id { get; set; }
        public int DemoTTeacherId { get; set; }
        public string Notification { get; set; }
    }
}
