using CGZT.School.Demo.Contracts.Common;
using CGZT.School.Demo.Contracts.Manager;
using CGZT.School.Demo.Entities;
using CGZT.School.Demo.Entities.Common;
using CGZT.School.Demo.Entities.DTO.Notification;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGZT.School.Demo.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/RetrieveForNotifications/V1")]
    public class NotificationController : Controller
    {
        private readonly INotificationDetailsManager _notificationDetailsManager;

        private readonly ILogger<NotificationController> _logger;

        private readonly IMapper<IList<Message>, ServiceResponse> _serviceResponseErrorMapper;

        public NotificationController(INotificationDetailsManager notificationDetailsManager, ILogger<NotificationController> logger, IMapper<IList<Message>, ServiceResponse> serviceResponseErrorMapper )
        {
            _notificationDetailsManager = notificationDetailsManager;
            _logger = logger;
            _serviceResponseErrorMapper = serviceResponseErrorMapper;

        }

        [HttpPost("SendNotification")]
        public ServiceResponse AddNotificationDetail([FromBody] NotificationRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return _notificationDetailsManager.AddNotificationDetails(request);
                }
                else
                {
                    return _serviceResponseErrorMapper.Map(new List<Message> {  });
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return _serviceResponseErrorMapper.Map(new List<Message> { });
            }
        }
    }
}
