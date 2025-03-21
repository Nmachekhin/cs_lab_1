using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MachekhinZodiak
{
    public partial class MainWindow : Window
    {
        private ViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new ViewModel();
            DataContext = _viewModel;
            _viewModel.IncorrectDate += IncorrectDateMessagebox;
        }

        private void IncorrectDateMessagebox(object sender, bool e)
        {
            MessageBox.Show("Entered birth date is incorrect!", "Birth date error!",
            MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ConfirmDateButtonClick(object sender, RoutedEventArgs e)
        {
            _viewModel.ConfirmDateButtonClick(sender, e);
        }

    }
}