using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using static System.Collections.Specialized.BitVector32;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AdmTicketsPricePage.xaml
    /// </summary>
    public partial class AdmTicketsPricePage : Page
    {
        private BusStationEntities busStation = new BusStationEntities();
        public AdmTicketsPricePage()
        {
            InitializeComponent();

            datagrid1.ItemsSource = busStation.Tickets_Price.ToList();
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminMainPage());
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Tickets_Price price = new Tickets_Price();
                price.Price = Convert.ToDecimal(txt1.Text);
                price.Number_Route = Convert.ToInt32(txt2.Text);

                busStation.Tickets_Price.Add(price);
                busStation.SaveChanges();

                datagrid1.ItemsSource = busStation.Tickets_Price.ToList();
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
                    var selected = datagrid1.SelectedItem as Tickets_Price;
                    selected.Price = Convert.ToDecimal(txt1.Text);
                    selected.Number_Route = Convert.ToInt32(txt2.Text);
                }

                busStation.SaveChanges();
                datagrid1.ItemsSource = busStation.Tickets_Price.ToList();
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
                    busStation.Tickets_Price.Remove(datagrid1.SelectedItem as Tickets_Price);
                    busStation.SaveChanges();
                    datagrid1.ItemsSource = busStation.Tickets_Price.ToList();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}