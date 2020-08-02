using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Freerider.Services
{
    public class NotificationService
    {
        private INotificationManager _notificationManager;

        public NotificationService()
        {
            _notificationManager = Xamarin.Forms.DependencyService.Get<INotificationManager>();
        }

        public void SendNotification(string title, string message)
        {
            _notificationManager.ScheduleNotification(title, message);
        }
    }
}