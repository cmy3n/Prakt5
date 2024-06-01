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
    /// Логика взаимодействия для AdmLoginsPage.xaml
    /// </summary>
    public partial class AdmLoginsPage : Page
    {
        private BusStationEntities busStation = new BusStationEntities();
        public AdmLoginsPage()
        {
            InitializeComponent();

            datagrid1.ItemsSource = busStation.Logins.ToList();
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (datagrid1.SelectedItem != null)
                {
                    busStation.Logins.Remove(datagrid1.SelectedItem as Logins);
                    busStation.SaveChanges();
                    datagrid1.ItemsSource = busStation.Logins.ToList();
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
                    var selected = datagrid1.SelectedItem as Logins;
                    selected.Login = txt1.Text;
                    selected.Password = txt2.Text;
                    selected.Role_ID = Convert.ToInt32(txt3.Text);
                }

                busStation.SaveChanges();
                datagrid1.ItemsSource = busStation.Logins.ToList();
            }
            catch (Exception ex)
            {

            }
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Logins log = new Logins();
                log.Login = txt1.Text;
                log.Password = txt2.Text;
                log.Role_ID = Convert.ToInt32(txt3.Text);

                busStation.Logins.Add(log);
                busStation.SaveChanges();

                datagrid1.ItemsSource = busStation.Logins.ToList();
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
