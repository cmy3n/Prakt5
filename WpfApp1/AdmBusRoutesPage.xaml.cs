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
    /// Логика взаимодействия для AdmBusRoutesPage.xaml
    /// </summary>
    public partial class AdmBusRoutesPage : Page
    {
        private BusStationEntities busStation = new BusStationEntities();
        public AdmBusRoutesPage()
        {
            InitializeComponent();

            datagrid1.ItemsSource = busStation.Bus_Routes.ToList();
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminMainPage());
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Bus_Routes route = new Bus_Routes();
                route.Route_Number = Convert.ToInt32(txt1.Text);
                route.Bus_ID = Convert.ToInt32(txt2.Text);
                route.Road_ID = Convert.ToInt32(txt3.Text);

                busStation.Bus_Routes.Add(route);
                busStation.SaveChanges();

                datagrid1.ItemsSource = busStation.Bus_Routes.ToList();
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
                    var selected = datagrid1.SelectedItem as Bus_Routes;
                    selected.Route_Number = Convert.ToInt32(txt1.Text);
                    selected.Bus_ID = Convert.ToInt32(txt2.Text);
                    selected.Road_ID = Convert.ToInt32(txt3.Text);
                }

                busStation.SaveChanges();
                datagrid1.ItemsSource = busStation.Bus_Routes.ToList();
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
                    busStation.Bus_Routes.Remove(datagrid1.SelectedItem as Bus_Routes);
                    busStation.SaveChanges();
                    datagrid1.ItemsSource = busStation.Bus_Routes.ToList();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
