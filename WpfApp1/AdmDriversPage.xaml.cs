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
    /// Логика взаимодействия для AdmDriversPage.xaml
    /// </summary>
    public partial class AdmDriversPage : Page
    {
        private BusStationEntities busStation = new BusStationEntities();
        public AdmDriversPage()
        {
            InitializeComponent();

            datagrid1.ItemsSource = busStation.Drivers.ToList();
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminMainPage());
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Drivers driver = new Drivers();
                driver.Driver_Surname = txt1.Text;
                driver.Driver_Name = txt2.Text;
                driver.Driver_Middlename = txt3.Text;
                driver.Driver_Email = txt4.Text;
                driver.Number_Route = Convert.ToInt32(txt5.Text);

                busStation.Drivers.Add(driver);
                busStation.SaveChanges();

                datagrid1.ItemsSource = busStation.Drivers.ToList();
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
                    var selected = datagrid1.SelectedItem as Drivers;
                    selected.Driver_Surname = txt1.Text;
                    selected.Driver_Name = txt2.Text;
                    selected.Driver_Middlename = txt3.Text;
                    selected.Driver_Email = txt4.Text;
                    selected.Number_Route = Convert.ToInt32(txt5.Text);
                }

                busStation.SaveChanges();
                datagrid1.ItemsSource = busStation.Drivers.ToList();
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
                    busStation.Drivers.Remove(datagrid1.SelectedItem as Drivers);
                    busStation.SaveChanges();
                    datagrid1.ItemsSource = busStation.Drivers.ToList();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
