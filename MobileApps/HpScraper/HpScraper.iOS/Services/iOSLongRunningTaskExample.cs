using System;
using System.Threading;
using System.Threading.Tasks;
using FormsBackgrounding.Messages;
using HpScraper.Messages;
using UIKit;
using Xamarin.Forms;

namespace HpScraper.iOS
{
    public class iOSLongRunningTaskExample
    {
        private nint _taskId;
        private CancellationTokenSource _cts;

        public async Task Start()
        {
            _cts = new CancellationTokenSource();

            _taskId = UIApplication.SharedApplication.BeginBackgroundTask("LongRunningTask", OnExpiration);

            try
            {
                //INVOKE THE SHARED CODE
                var counter = new TaskCounter();
                await counter.RunCounter(_cts.Token);
            }
            catch (OperationCanceledException)
            {
            }
            finally
            {
                if (_cts.IsCancellationRequested)
                {
                    var message = new CancelledMessage();
                    Device.BeginInvokeOnMainThread(
                        () => MessagingCenter.Send(message, "CancelledMessage")
                    );
                }
            }

            UIApplication.SharedApplication.EndBackgroundTask(_taskId);
        }

        public void Stop()
        {
            _cts.Cancel();
        }

        private void OnExpiration()
        {
            _cts.Cancel();
        }
    }
}