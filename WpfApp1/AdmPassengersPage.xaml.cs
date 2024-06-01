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
    /// Логика взаимодействия для AdmPassengersPage.xaml
    /// </summary>
    public partial class AdmPassengersPage : Page
    {
        private BusStationEntities busStation = new BusStationEntities();
        public AdmPassengersPage()
        {
            InitializeComponent();

            datagrid1.ItemsSource = busStation.Passengers.ToList();
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminMainPage());
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Passengers passenger = new Passengers();
                passenger.Passenger_Surname = txt1.Text;
                passenger.Passenger_Name = txt2.Text;
                passenger.Passenger_Middlename = txt3.Text;
                passenger.Passenger_PhoneNumber = txt4.Text;

                busStation.Passengers.Add(passenger);
                busStation.SaveChanges();

                datagrid1.ItemsSource = busStation.Passengers.ToList();
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
                    var selected = datagrid1.SelectedItem as Passengers;
                    selected.Passenger_Surname = txt1.Text;
                    selected.Passenger_Name = txt2.Text;
                    selected.Passenger_Middlename = txt3.Text;
                    selected.Passenger_PhoneNumber = txt4.Text;
                }

                busStation.SaveChanges();
                datagrid1.ItemsSource = busStation.Passengers.ToList();
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
                    busStation.Passengers.Remove(datagrid1.SelectedItem as Passengers);
                    busStation.SaveChanges();
                    datagrid1.ItemsSource = busStation.Passengers.ToList();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
