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
    /// Логика взаимодействия для AdmStationPage.xaml
    /// </summary>
    public partial class AdmStationPage : Page
    {
        private BusStationEntities busStation = new BusStationEntities();
        public AdmStationPage()
        {
            InitializeComponent();

            datagrid1.ItemsSource = busStation.Stations.ToList();
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminMainPage());
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Stations station = new Stations();
                station.Station_Name = txt1.Text;

                busStation.Stations.Add(station);
                busStation.SaveChanges();

                datagrid1.ItemsSource = busStation.Stations.ToList();
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
                    busStation.Stations.Remove(datagrid1.SelectedItem as Stations);
                    busStation.SaveChanges();
                    datagrid1.ItemsSource = busStation.Stations.ToList();
                }
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
                    var selected = datagrid1.SelectedItem as Stations;
                    selected.Station_Name = txt1.Text;
                }

                busStation.SaveChanges();
                datagrid1.ItemsSource = busStation.Stations.ToList();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
