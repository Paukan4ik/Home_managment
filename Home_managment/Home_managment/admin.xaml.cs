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
using System.Windows.Threading;
using System.Threading;
namespace Home_managment
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Connect con = new Connect();
        public Window1()
        {
            InitializeComponent();
            
        }

        private void Window_Closed_1(object sender, EventArgs e)
        {
            App.Current.Shutdown();
            
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
          
            if (tablesChn.SelectedIndex == 0)
            {
                Flats.Visibility = Visibility.Hidden;
                Users.Visibility = Visibility.Visible;
                Pays.Visibility = Visibility.Hidden;
                Poslugs.Visibility = Visibility.Hidden;

                SqlConnectionStringBuilder strConn = new SqlConnectionStringBuilder();
                strConn["Data Source"] = "../../HomeManagment.sdf";
                SqlCeConnection ConnCe = new SqlCeConnection(strConn.ConnectionString);

                try
                {
                    ConnCe.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                SqlCeCommand cmd = new SqlCeCommand("Select * From [Users]", ConnCe);

                using (SqlCeDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (dr.Read())
                    {
                        users_list.Items.Add(dr.GetValue(1).ToString());
                    }
                    ConnCe.Close();
                    ConnCe.Dispose();
                }
                
            }
            if (tablesChn.SelectedIndex == 3 || tablesmoder.SelectedIndex == 2)
            {
                Flats.Visibility = Visibility.Visible;
                Users.Visibility = Visibility.Hidden;
                Pays.Visibility = Visibility.Hidden;
                Poslugs.Visibility = Visibility.Hidden;
                SqlConnectionStringBuilder strConn = new SqlConnectionStringBuilder();
                strConn["Data Source"] = "../../HomeManagment.sdf";
                SqlCeConnection ConnCe = new SqlCeConnection(strConn.ConnectionString);

                try
                {
                    ConnCe.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                SqlCeCommand cmd = new SqlCeCommand("Select * From [Flats]", ConnCe);

                using (SqlCeDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (dr.Read())
                    {
                        numbers.Items.Add(dr.GetValue(7).ToString());
                    }
                    ConnCe.Close();
                    ConnCe.Dispose();
                }
            }
            if (tablesChn.SelectedIndex == 1 || tablesmoder.SelectedIndex == 0)
            {
                Flats.Visibility = Visibility.Hidden;
                Users.Visibility = Visibility.Hidden;
                Pays.Visibility = Visibility.Hidden;
                Poslugs.Visibility = Visibility.Visible;
                SqlConnectionStringBuilder strConn = new SqlConnectionStringBuilder();
                strConn["Data Source"] = "../../HomeManagment.sdf";
                SqlCeConnection ConnCe = new SqlCeConnection(strConn.ConnectionString);

                try
                {
                    ConnCe.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                SqlCeCommand cmd = new SqlCeCommand("Select * From [Полсуги]", ConnCe);

                using (SqlCeDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (dr.Read())
                    {
                        poslugi.Items.Add(dr.GetValue(0).ToString()+dr.GetValue(1).ToString());
                    }
                    ConnCe.Close();
                    ConnCe.Dispose();
                }
              
            }
            if (tablesChn.SelectedIndex == 2 || tablesmoder.SelectedIndex == 1)
            {
                Flats.Visibility = Visibility.Hidden;
                Users.Visibility = Visibility.Hidden;
                Pays.Visibility = Visibility.Visible;
                Poslugs.Visibility = Visibility.Hidden;
                SqlConnectionStringBuilder strConn = new SqlConnectionStringBuilder();
                strConn["Data Source"] = "../../HomeManagment.sdf";
                SqlCeConnection ConnCe = new SqlCeConnection(strConn.ConnectionString);

                try
                {
                    ConnCe.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                SqlCeCommand cmd = new SqlCeCommand("Select * From [Оплата]", ConnCe);

                using (SqlCeDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (dr.Read())
                    {
                        upays.Items.Add(dr.GetValue(1).ToString() + dr.GetValue(2).ToString());
                    }
                    ConnCe.Close();
                    ConnCe.Dispose();
                }
                
            }
           
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Час на перерву! \n База не працює! ");
            Thread.Sleep(2000); 
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 50);
            dispatcherTimer.Start();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
         
            if (tablesChn.SelectedIndex == 0)
            {
                if (userlogin.Text != "")
                {
                    string uroles;

                    if (roles.SelectedIndex == 0)
                    {
                        uroles = "Admin";
                        con.ChangeRole(uroles, userlogin.Text);
                    }
                    if (roles.SelectedIndex == 1)
                    {
                        uroles = "User";
                        con.ChangeRole(uroles, userlogin.Text);
                    }
                    if (roles.SelectedIndex == 2)
                    {
                        uroles = "Moder";
                        con.ChangeRole(uroles, userlogin.Text);
                    }
                }
                else MessageBox.Show("Некоректна інформація");
            }
            if (tablesChn.SelectedIndex == 3 || tablesmoder.SelectedIndex == 2)
            {
                if (streetTextBox.Text != "" && homeTextBox.Text != "" && flatTextBox.Text != "" && surnameTextBox.Text != "" && nameTextBox.Text != "" && lastnameTextBox.Text != "" && phoneTextBox.Text != "" && sumTextBox.Text != "")
                {
                    con.NewAbon(streetTextBox.Text,homeTextBox.Text,flatTextBox.Text,surnameTextBox.Text,nameTextBox.Text,lastnameTextBox.Text,Convert.ToInt32(phoneTextBox.Text),sumTextBox.Text);
                }
                else MessageBox.Show("Некоректна інформація");
            }
            if (tablesChn.SelectedIndex == 1 || tablesmoder.SelectedIndex == 0)
            {
               if (назваTextBox.Text!="" && цінаTextBox.Text!="")
                {
                    con.NewPosl(назваTextBox.Text,цінаTextBox.Text);
                }
                else MessageBox.Show("Некоректна інформація");
            }
            if (tablesChn.SelectedIndex == 2 || tablesmoder.SelectedIndex == 1)
            {
                if (дата_РеєстраціїDatePicker.DataContext!=null || _Місяць_РікDatePicker.DataContext!=null)
                {
                    con.NewPay(дата_РеєстраціїDatePicker.DataContext, _Місяць_РікDatePicker.DataContext);
                }
                else MessageBox.Show("Некоректна інформація");
            }
 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Додаток розроблений спеціально для Житлово-Комунальних установ! \n©2014 by Paukan4ik");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Способи оплати: \n1.Через термінал \n2.В відділенні банку \n3.В відділенні ЖЕК \n4.Через платіжні системи Приват24");
        }


    }
}
