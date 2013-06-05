using System;
using System.Windows.Input;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using MessengerHacking.Core.Services;

namespace MessengerHacking.Core.ViewModels
{
    public class SecondViewModel 
        : MvxViewModel
    {
        private MvxSubscriptionToken _token;
        private ITickService _tickService;

        public SecondViewModel(ITickService tickService, IMvxMessenger messenger)
        {
            _tickService = tickService;
            _token = messenger.Subscribe<TickMessage>(OnTick);
            Update();
        }

        private void OnTick(TickMessage obj)
        {
            Update();
        }

        private void Update()
        {
            Hello = "Count:" + _tickService.Count.ToString();
        }

        private string _hello = "Hello MvvmCross";
        public string Hello
        { 
            get { return _hello; }
            set { _hello = value; RaisePropertyChanged(() => Hello); }
        }

        public ICommand GCCollectCommand
        {
            get { return new MvxCommand(GC.Collect);}
        }
    }
}