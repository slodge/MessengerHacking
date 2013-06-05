using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace MessengerHacking.Core.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {
        public ICommand Go
        {
            get { return new MvxCommand(() => ShowViewModel<SecondViewModel>());}
        }
    }
}
