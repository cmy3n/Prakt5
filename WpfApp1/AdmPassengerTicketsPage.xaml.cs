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
    /// Логика взаимодействия для AdmPassengerTicketsPage.xaml
    /// </summary>
    public partial class AdmPassengerTicketsPage : Page
    {
        private BusStationEntities busStation = new BusStationEntities();
        public AdmPassengerTicketsPage()
        {
            InitializeComponent();

            datagrid1.ItemsSource = busStation.Passenger_Tickets.ToList();
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminMainPage());
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Passenger_Tickets pt = new Passenger_Tickets();
                pt.Passenger_ID = Convert.ToInt32(txt1.Text);
                pt.Ticket_Id = Convert.ToInt32(txt2.Text);

                busStation.Passenger_Tickets.Add(pt);
                busStation.SaveChanges();

                datagrid1.ItemsSource = busStation.Passenger_Tickets.ToList();
            }
            catch (Exception ex)
            {

            }
        }

        private void edit_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (datagrid1.SelectedItem != null)
                {
                    var selected = datagrid1.SelectedItem as Passenger_Tickets;
                    selected.Passenger_ID = Convert.ToInt32(txt1.Text);
                    selected.Ticket_Id = Convert.ToInt32(txt2.Text);
                }

                busStation.SaveChanges();
                datagrid1.ItemsSource = busStation.Passenger_Tickets.ToList();
            }
            catch (Exception ex)
            {

            }
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (datagrid1.SelectedItem != null)
                {
                    busStation.Passenger_Tickets.Remove(datagrid1.SelectedItem as Passenger_Tickets);
                    busStation.SaveChanges();
                    datagrid1.ItemsSource = busStation.Passenger_Tickets.ToList();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
