using HpScraper.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HpScraper.Helpers
{
    public class NotificationHelper
    {
        private INotificationManager _notificationManager;

        public NotificationHelper()
        {
            _notificationManager = Xamarin.Forms.DependencyService.Get<INotificationManager>();
        }

        public void SendNotification(string title, string message)
        {
            _notificationManager.ScheduleNotification(title, message);
        }
    }
}