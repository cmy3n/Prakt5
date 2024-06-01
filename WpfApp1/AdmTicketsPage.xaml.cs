using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
    /// Логика взаимодействия для AdmTicketsPage.xaml
    /// </summary>
    public partial class AdmTicketsPage : Page
    {
        private BusStationEntities busStation = new BusStationEntities();
        public AdmTicketsPage()
        {
            InitializeComponent();

            datagrid1.ItemsSource = busStation.Tickets.ToList();
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (datagrid1.SelectedItem != null)
                {
                    busStation.Tickets.Remove(datagrid1.SelectedItem as Tickets);
                    busStation.SaveChanges();
                    datagrid1.ItemsSource = busStation.Tickets.ToList();
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
                    var selected = datagrid1.SelectedItem as Tickets;
                    selected.Number_Route = Convert.ToInt32(txt1.Text);
                    selected.Price_ID = Convert.ToInt32(txt2.Text);
                    selected.Worker_ID = Convert.ToInt32(txt2.Text);
                }

                busStation.SaveChanges();
                datagrid1.ItemsSource = busStation.Tickets.ToList();
            }
            catch
            {

            }
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Tickets ticket = new Tickets();
                ticket.Number_Route = Convert.ToInt32(txt1.Text);
                ticket.Price_ID = Convert.ToInt32(txt2.Text);
                ticket.Worker_ID = Convert.ToInt32(txt3.Text);

                busStation.Tickets.Add(ticket);
                busStation.SaveChanges();

                datagrid1.ItemsSource = busStation.Tickets.ToList();
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
