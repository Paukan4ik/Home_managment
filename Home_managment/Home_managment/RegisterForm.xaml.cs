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
using System.Windows.Shapes;

namespace Home_managment
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        MainWindow LoginW = new MainWindow();
        public Window2()
        {
            InitializeComponent();
        }

        private void CancelBut_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LoginW.ShowDialog();
        }

        private void RegisterBut_Click(object sender, RoutedEventArgs e)
        {
            Connect con = new Connect();
            con.NewUser(Login.Text, Password.Password, Name.Text);
            this.Hide();
            LoginW.ShowDialog();
        }

        private void RegisterForm_Closed(object sender, EventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
