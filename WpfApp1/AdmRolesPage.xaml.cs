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
    /// Логика взаимодействия для AdmRolesPage.xaml
    /// </summary>
    public partial class AdmRolesPage : Page
    {
        private BusStationEntities busStation = new BusStationEntities();
        public AdmRolesPage()
        {
            InitializeComponent();

            datagrid1.ItemsSource = busStation.Roles.ToList();
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Roles role = new Roles();
                role.Role_Name = txt1.Text;

                busStation.Roles.Add(role);
                busStation.SaveChanges();

                datagrid1.ItemsSource = busStation.Roles.ToList();
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
                    var selected = datagrid1.SelectedItem as Roles;
                    selected.Role_Name = txt1.Text;
                }

                busStation.SaveChanges();
                datagrid1.ItemsSource = busStation.Roles.ToList();
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
                    busStation.Roles.Remove(datagrid1.SelectedItem as Roles);
                    busStation.SaveChanges();
                    datagrid1.ItemsSource = busStation.Roles.ToList();
                }
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
