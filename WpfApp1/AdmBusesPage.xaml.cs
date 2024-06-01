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
    /// Логика взаимодействия для AdmBusesPage.xaml
    /// </summary>
    public partial class AdmBusesPage : Page
    {
        private BusStationEntities busStation = new BusStationEntities();
        public AdmBusesPage()
        {
            InitializeComponent();

            datagrid1.ItemsSource = busStation.Buses.ToList();
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminMainPage());
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Buses bus = new Buses();
                bus.Manufacturer = txt1.Text;
                bus.Realese_Year = Convert.ToInt32(txt2.Text);
                bus.Seats_Number = Convert.ToInt32(txt3.Text);

                busStation.Buses.Add(bus);
                busStation.SaveChanges();

                datagrid1.ItemsSource = busStation.Buses.ToList();
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
                    var selected = datagrid1.SelectedItem as Buses;
                    selected.Manufacturer = txt1.Text;
                    selected.Realese_Year = Convert.ToInt32(txt2.Text);
                    selected.Seats_Number = Convert.ToInt32(txt3.Text);
                }

                busStation.SaveChanges();
                datagrid1.ItemsSource = busStation.Buses.ToList();
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
                    busStation.Buses.Remove(datagrid1.SelectedItem as Buses);
                    busStation.SaveChanges();
                    datagrid1.ItemsSource = busStation.Buses.ToList();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
