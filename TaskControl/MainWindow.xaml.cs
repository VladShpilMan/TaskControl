using System.Windows;
using TaskControl.ViewModel;

namespace TaskControl
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new MainWindowModel();
            InitializeComponent();
        }
    }
}
