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
    /// Логика взаимодействия для AdmShedulePage.xaml
    /// </summary>
    public partial class AdmShedulePage : Page
    {
        private BusStationEntities busStation = new BusStationEntities();
        public AdmShedulePage()
        {
            InitializeComponent();

            datagrid1.ItemsSource = busStation.Schedule.ToList();
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (datagrid1.SelectedItem != null)
                {
                    busStation.Schedule.Remove(datagrid1.SelectedItem as Schedule);
                    busStation.SaveChanges();
                    datagrid1.ItemsSource = busStation.Schedule.ToList();
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
                    var selected = datagrid1.SelectedItem as Schedule;
                    selected.Number_Route = Convert.ToInt32(txt1.Text);
                    selected.Departure_Time = txt2.Text;
                    selected.Arrival_Time = txt3.Text;
                }

                busStation.SaveChanges();
                datagrid1.ItemsSource = busStation.Schedule.ToList();
            }
            catch (Exception ex)
            {

            }
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Schedule schedule = new Schedule();
                schedule.Number_Route = Convert.ToInt32(txt1.Text);
                schedule.Departure_Time = txt2.Text;
                schedule.Arrival_Time = txt3.Text;

                busStation.Schedule.Add(schedule);
                busStation.SaveChanges();

                datagrid1.ItemsSource = busStation.Schedule.ToList();
            }
            catch (Exception ex)
            {

            }
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminMainPage());
        }
    }
}
