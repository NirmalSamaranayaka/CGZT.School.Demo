using CGZT.School.Demo.Contracts.Common;
using CGZT.School.Demo.Contracts.Repository;
using CGZT.School.Demo.DataContext.DemoDataModels;
using CGZT.School.Demo.DataContext.DemoDbContext;
using CGZT.School.Demo.Entities.DTO.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.DataAccess.Repository
{
    public class NotificationDetailsRepository : INotificationDetailsRepository
    {
        private readonly IEntityMapper _entityMapper;
        private readonly DemoEntities _demoEntities;

        public NotificationDetailsRepository(IEntityMapper entityMapper, DemoEntities demoEntities)
        {
            _entityMapper = entityMapper;
            _demoEntities = demoEntities;
        }

        public NotificationRecipients SaveStudentTeacherDetails(NotificationRecipients saveObject)
        {
            var getRecipient = saveObject.Notification.Notification.Split(" @");

            saveObject.Notification.Notification =(getRecipient.Length>0)? getRecipient[0]: saveObject.Notification.Notification;

            string[] emailList = getRecipient.Skip(1).ToArray();
           



            var mappedentity = _entityMapper.Map<NotificationRecipients, DemoTNotificationRecipient>(saveObject);
            _demoEntities.Set<DemoTNotificationRecipient>().Add(mappedentity);
            Save();
            return _entityMapper.Map<DemoTNotificationRecipient, NotificationRecipients>(mappedentity);
        }

        public void Save()
        {
            _demoEntities.SaveChanges();
        }


    }


}
