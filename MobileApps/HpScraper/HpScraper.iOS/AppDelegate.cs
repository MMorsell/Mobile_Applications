using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using HpScraper.Messages;
using UIKit;
using Xamarin.Forms;

namespace HpScraper.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        private void WireUpDownloadTask()
        {
            MessagingCenter.Subscribe<DownloadMessage>(this, "Download", async message =>
            {
                var downloader = new Downloader(message.Url);
                await downloader.DownloadFile();
            });
        }

        public static Action BackgroundSessionCompletionHandler;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            WireUpLongRunningTask();
            WireUpDownloadTask();

            return base.FinishedLaunching(app, options);
        }

        private iOSLongRunningTaskExample longRunningTaskExample;

        private void WireUpLongRunningTask()
        {
            MessagingCenter.Subscribe<StartLongRunningTaskMessage>(this, "StartLongRunningTaskMessage", async message =>
            {
                longRunningTaskExample = new iOSLongRunningTaskExample();
                await longRunningTaskExample.Start();
            });

            MessagingCenter.Subscribe<StopLongRunningTaskMessage>(this, "StopLongRunningTaskMessage", message =>
            {
                longRunningTaskExample.Stop();
            });
        }
    }
}