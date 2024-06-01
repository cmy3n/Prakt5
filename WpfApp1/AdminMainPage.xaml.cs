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
    public partial class AdminMainPage : Page
    {
        private BusStationEntities _context;
        public AdminMainPage()
        {
            InitializeComponent();

            _context = new BusStationEntities(); 
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void Stations_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdmStationPage());
        }

        private void Roads_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdmRoadsPage());
        }

        private void Buses_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdmBusesPage());
        }

        private void Bus_Routes_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdmBusRoutesPage());
        }

        private void Shedule_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdmShedulePage());
        }

        private void Drivers_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdmDriversPage());
        }

        private void Roles_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdmRolesPage());
        }

        private void Logins_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdmLoginsPage());
        }

        private void Workers_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdmWorkersPage());
        }

        private void Ticket_Price_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdmTicketsPricePage());
        }

        private void Tickets_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdmTicketsPage());
        }

        private void Passengers_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdmPassengersPage());
        }

        private void PassengersTickets_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdmPassengerTicketsPage());
        }

        private void backup_button_Click(object sender, RoutedEventArgs e)
        {
            string backupPath = "C:\\Users\\Public";

            string command = $"BACKUP DATABASE BusStation TO DISK = '{backupPath}\\BusStation-{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")}.bak'";
            
            _context.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, command);
        }
    }
}
