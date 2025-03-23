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
            _viewModel.IncorrectDate += IncorrectDateEvent;
            _viewModel.AgeUpdate += UpdateAgeTextBlock;
            _viewModel.DisplayBirthdayMessage += FillBirthdayMessageTextBlock;
            _viewModel.DisplayZodiakSign += UpdateZodiakSignTextBlock;
        }
        

        private void FillBirthdayMessageTextBlock(object sender, string message)
        {
            CongratTextBlock.Text = message;
        }

        private void UpdateAgeTextBlock(object sender, int age)
        {
            AgeTextBlock.Text = age.ToString();
        }

        private void UpdateZodiakSignTextBlock(object sender, string sign)
        {
            ZodiakSignTextBlock.Text = sign;
        }

        private void IncorrectDateEvent(object sender, bool e)
        {
            IncorrectDateMessagebox();
            CleanAllCalculatedFields();

        }

        private void CleanAllCalculatedFields()
        {
            AgeTextBlock.Text= string.Empty;
            ZodiakSignTextBlock.Text = string.Empty;
        }

        private void IncorrectDateMessagebox()
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