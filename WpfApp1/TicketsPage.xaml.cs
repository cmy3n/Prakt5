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
    /// Логика взаимодействия для TicketsPage.xaml
    /// </summary>
    public partial class TicketsPage : Page
    {
        private BusStationEntities busStation = new BusStationEntities();
        public TicketsPage()
        {
            InitializeComponent();

            datagrid1.ItemsSource = busStation.Tickets.ToList();

            cb1.ItemsSource = busStation.Tickets.ToList();
            cb2.ItemsSource = busStation.Tickets.ToList();
            cb3.ItemsSource = busStation.Tickets.ToList();
            cb1.DisplayMemberPath = "Number_Route";
            cb2.DisplayMemberPath = "Price_ID";
            cb3.DisplayMemberPath = "Worker_ID";
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            Tickets ticket = new Tickets();
            ticket.Number_Route = (cb1.SelectedItem as Tickets).Number_Route;
            ticket.Price_ID = (cb2.SelectedItem as Tickets).Price_ID;
            ticket.Worker_ID = (cb3.SelectedItem as Tickets).Worker_ID;

            busStation.Tickets.Add(ticket);
            busStation.SaveChanges();

            datagrid1.ItemsSource = busStation.Tickets.ToList();
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new KassaMainPage());
        }

        private void del_button_Click(object sender, RoutedEventArgs e)
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
    }
}
