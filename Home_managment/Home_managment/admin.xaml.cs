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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Closed_1(object sender, EventArgs e)
        {
            App.Current.Shutdown();
            SqlConnectionStringBuilder strConn = new SqlConnectionStringBuilder();
            strConn["Data Source"] = "HomeManagment.sdf";
            SqlCeConnection ConnCe = new SqlCeConnection(strConn.ConnectionString);
            SqlCeCommand cmd = new SqlCeCommand("Select * From [Users]", ConnCe);
            tables.DataContext = cmd;
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
          
            if (tablesChn.Text == "Користувачі")
            {  }
        }
    }
}
