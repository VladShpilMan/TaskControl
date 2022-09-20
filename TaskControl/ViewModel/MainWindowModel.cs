using System.Windows.Controls;
using TaskControl.View;

namespace TaskControl.ViewModel
{
    class MainWindowModel : BaseViewModelClass
    {
        private UserControl _currentWindow;

        public UserControl CurrentWindow
        {
            get { return _currentWindow; }
            set
            {
                _currentWindow = value;
                OnPropertyChanged("CurrentWindow");
            }
        }

        public MainWindowModel()
        {

        }
    }
}
