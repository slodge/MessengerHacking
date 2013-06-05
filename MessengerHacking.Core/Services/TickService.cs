using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Cirrious.MvvmCross.Plugins.Messenger;

namespace MessengerHacking.Core.Services
{
    public interface ITickService
    {
        int Count { get; }
    }

    public class TickService
        : ITickService
    {
        private IMvxMessenger _messenger;
        private Timer _timer;

        public TickService(IMvxMessenger messenger)
        {
            _messenger = messenger;
            _timer = new Timer(OnTick, null, 1000, 1000);

        }

        private void OnTick(object state)
        {
            _messenger.Publish(new TickMessage(this));   
        }

        public int Count { get { return _messenger.CountSubscriptionsFor<TickMessage>(); }}
    }

    public class TickMessage : MvxMessage
    {
        public TickMessage(object sender) : base(sender)
        {
        }
    }
}
