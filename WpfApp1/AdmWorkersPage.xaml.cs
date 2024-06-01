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
    /// Логика взаимодействия для AdmWorkersPage.xaml
    /// </summary>
    public partial class AdmWorkersPage : Page
    {
        private BusStationEntities busStation = new BusStationEntities();
        public AdmWorkersPage()
        {
            InitializeComponent();

            datagrid1.ItemsSource = busStation.Workers.ToList();
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminMainPage());
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Workers work = new Workers();
                work.Worker_Surname = txt1.Text;
                work.Worker_Name = txt2.Text;
                work.Worker_Middlename = txt3.Text;
                work.Worker_Email = txt4.Text;
                work.Role_ID = Convert.ToInt32(txt5.Text);

                busStation.Workers.Add(work);
                busStation.SaveChanges();

                datagrid1.ItemsSource = busStation.Workers.ToList();
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
                    var selected = datagrid1.SelectedItem as Workers;
                    selected.Worker_Surname = txt1.Text;
                    selected.Worker_Name = txt2.Text;
                    selected.Worker_Middlename = txt3.Text;
                    selected.Worker_Email = txt4.Text;
                    selected.Role_ID = Convert.ToInt32(txt5.Text);
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
                    busStation.Workers.Remove(datagrid1.SelectedItem as Workers);
                    busStation.SaveChanges();
                    datagrid1.ItemsSource = busStation.Workers.ToList();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
