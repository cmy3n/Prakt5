using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для KassaMainPage.xaml
    /// </summary>
    public partial class KassaMainPage : Page
    {
        public KassaMainPage()
        {
            InitializeComponent();
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void clients_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PassengerPage());
        }

        private void Tickets_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TicketsPage());
        }
    }
}
