using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    /// Логика взаимодействия для AdmRoadsPage.xaml
    /// </summary>
    public partial class AdmRoadsPage : Page
    {
        private BusStationEntities busStation = new BusStationEntities();
        public AdmRoadsPage()
        {
            InitializeComponent();

            datagrid1.ItemsSource = busStation.Roads.ToList();
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminMainPage());
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Roads road = new Roads();
                road.Departure_Station = Convert.ToInt32(txt1.Text);
                road.Arrival_Station = Convert.ToInt32(txt2.Text);

                busStation.Roads.Add(road);
                busStation.SaveChanges();

                datagrid1.ItemsSource = busStation.Roads.ToList();
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
                    var selected = datagrid1.SelectedItem as Roads;
                    selected.Departure_Station = Convert.ToInt32(txt1.Text);
                    selected.Arrival_Station = Convert.ToInt32(txt2.Text);
                }

                busStation.SaveChanges();
                datagrid1.ItemsSource = busStation.Roads.ToList();
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
                    busStation.Roads.Remove(datagrid1.SelectedItem as Roads);
                    busStation.SaveChanges();
                    datagrid1.ItemsSource = busStation.Roads.ToList();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
