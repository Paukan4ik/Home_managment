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
            this.phoneTextBox.PreviewTextInput += new TextCompositionEventHandler(phoneTextBox_PreviewTextInput);
                 this.sumTextBox.PreviewTextInput += new TextCompositionEventHandler(sumTextBox_PreviewTextInput);
        }

        private void Window_Closed_1(object sender, EventArgs e)
        {
            App.Current.Shutdown();
            
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
          
            if (tablesChn.SelectedIndex == 0)
            {
                poslugi.Items.Clear();
                numbers.Items.Clear();
                users_list.Items.Clear();
                delete.Visibility = Visibility.Hidden;
                Flats.Visibility = Visibility.Hidden;
                Users.Visibility = Visibility.Visible;
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
                        users_list.Items.Add(dr.GetValue(1).ToString() +"  "+ dr.GetValue(4).ToString());
                    }
                    ConnCe.Close();
                    ConnCe.Dispose();
                }
                
            }
            if (tablesChn.SelectedIndex == 2 || tablesmoder.SelectedIndex == 1)
            {
                poslugi.Items.Clear();
                numbers.Items.Clear();
                users_list.Items.Clear();
                delete.Visibility = Visibility.Hidden;
                Flats.Visibility = Visibility.Visible;
                Users.Visibility = Visibility.Hidden;
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
                poslugi.Items.Clear();
                numbers.Items.Clear();
                users_list.Items.Clear();
                delete.Visibility = Visibility.Visible;
                Flats.Visibility = Visibility.Hidden;
                Users.Visibility = Visibility.Hidden;
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
                        poslugi.Items.Add(dr.GetValue(0).ToString());
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
                poslugi.Items.Clear();
                numbers.Items.Clear();
                users_list.Items.Clear();
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
                            users_list.Items.Add(dr.GetValue(1).ToString() + "  " + dr.GetValue(4).ToString());
                        }
                        ConnCe.Close();
                        ConnCe.Dispose();
                    }
                    userlogin.Clear();
                }
                else MessageBox.Show("Некоректна інформація");
            }
            if (tablesChn.SelectedIndex == 2 || tablesmoder.SelectedIndex == 1)
            {
                if (streetTextBox.Text != "" && homeTextBox.Text != "" && flatTextBox.Text != "" && surnameTextBox.Text != "" && nameTextBox.Text != "" && lastnameTextBox.Text != "" && phoneTextBox.Text != "" && sumTextBox.Text != "")
                {
                    poslugi.Items.Clear();
                    numbers.Items.Clear();
                    users_list.Items.Clear();
                    con.NewAbon(streetTextBox.Text,homeTextBox.Text,flatTextBox.Text,surnameTextBox.Text,nameTextBox.Text,lastnameTextBox.Text,Convert.ToInt32(phoneTextBox.Text),sumTextBox.Text);
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
                    nameTextBox.Clear();
                    streetTextBox.Clear();
                    flatTextBox.Clear();
                    homeTextBox.Clear();
                    sumTextBox.Clear();
                    surnameTextBox.Clear();
                    lastnameTextBox.Clear();

                }
                else MessageBox.Show("Некоректна інформація");
            }
            if (tablesChn.SelectedIndex == 1 || tablesmoder.SelectedIndex == 0)
            {
               if (назваTextBox.Text!="" && цінаTextBox.Text!="")
                {
                    poslugi.Items.Clear();
                    numbers.Items.Clear();
                    users_list.Items.Clear(); 
                   con.NewPosl(назваTextBox.Text,цінаTextBox.Text);

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
                            poslugi.Items.Add(dr.GetValue(0).ToString());
                        }
                        ConnCe.Close();
                        ConnCe.Dispose();
                    }
                    назваTextBox.Clear();
                    цінаTextBox.Clear();

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

        private void delete_Click(object sender, RoutedEventArgs e)
        {
        
                if (poslugi.SelectedItem != null)
                {
                    string tl = poslugi.SelectedItem.ToString();
                    con.Delete(tl);
                    poslugi.Items.Clear();
                   
                }
            

        }

        private void phoneTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void sumTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void poslugi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (poslugi.SelectedItem != null)
            {
                string tl = poslugi.SelectedItem.ToString();
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
                SqlCeCommand cmd = new SqlCeCommand("Select * From [Полсуги] Where [Назва] = '" + tl + "';", ConnCe);

                using (SqlCeDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (dr.Read())
                    {
                        MessageBox.Show("Назва послуги: "+dr.GetValue(0).ToString() + "\nЦіна: " + dr.GetValue(1).ToString() + " грн.");
                    }
                    ConnCe.Close();
                    ConnCe.Dispose();
                }

            }
        }

    

    }
}
