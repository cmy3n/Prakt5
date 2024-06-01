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
    public partial class MainWindow : Window
    {
        private BusStationEntities busStation = new BusStationEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string login = logintxt.Text;
            string password = passwordtxt.Password;

            var user = busStation.Logins.FirstOrDefault(u => u.Login == login && u.Password == password);

            if (user != null)
            {
                if (user.Role_ID.Equals(1))
                {
                    AdminMainWindow adminMainWindow = new AdminMainWindow();
                    adminMainWindow.Show();
                    this.Close();
                }
                else if (user.Role_ID.Equals(2))
                {
                    KassaMainWindow kassaMainWindow = new KassaMainWindow();
                    kassaMainWindow.Show();
                    this.Close();
                }
                else if (user.Role_ID != 1 && user.Role_ID != 2)
                {
                    UserMainWindow userMainWindow = new UserMainWindow();
                    userMainWindow.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!");
            }
        }
    }
}
