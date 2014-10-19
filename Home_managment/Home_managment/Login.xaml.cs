using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data;
using System.Data.SqlServerCe;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Home_managment
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

 
        private void InputLogin_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                buttonGoClick(sender, e);
            }
        }

        private void InputPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                buttonGoClick(sender, e);
            }
        }

        private void buttonGoClick(object sender, RoutedEventArgs e)
        {
            Connect con = new Connect();
            con.CheckUser(InputLogin.Text);

            if (InputLogin.Text == con.Login && InputPassword.Password == con.Password)
            {
               if (con.Role == "Admin" || con.Role=="admin")
                {
                    Window1 adminFrame = new Window1();
                    adminFrame.ShowDialog();
                }
               if (con.Role == "user" || con.Role == "User")
                {
                    
                }
            }
            else
            {
                MessageBox.Show("Щось пішло не так!");
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Window2 reg = new Window2();
            this.Hide();
            reg.ShowDialog();
        }

        private void Loginin_Closed(object sender, EventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
