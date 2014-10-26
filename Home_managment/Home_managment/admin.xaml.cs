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
        public Window1()
        {
            InitializeComponent();
            this.Background = Home_managment.Properties.Settings.Default.Color;      
        }

        private void Window_Closed_1(object sender, EventArgs e)
        {
            App.Current.Shutdown();
            
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
          
            if (tablesChn.SelectedIndex == 0)
            {
                usersDataGrid.Visibility = Visibility.Visible;
                flatsDataGrid.Visibility = Visibility.Hidden;
                оплатаDataGrid.Visibility = Visibility.Hidden;
                послугиDataGrid.Visibility = Visibility.Hidden;
            }
            if (tablesChn.SelectedIndex == 1)
            {
                usersDataGrid.Visibility = Visibility.Hidden;
                flatsDataGrid.Visibility = Visibility.Hidden;
                оплатаDataGrid.Visibility = Visibility.Hidden;
                послугиDataGrid.Visibility = Visibility.Visible;
            }
            if (tablesChn.SelectedIndex == 2)
            {
                usersDataGrid.Visibility = Visibility.Hidden;
                flatsDataGrid.Visibility = Visibility.Hidden;
                оплатаDataGrid.Visibility = Visibility.Visible;
                послугиDataGrid.Visibility = Visibility.Hidden;
            }
            if (tablesChn.SelectedIndex == 3)
            {
                usersDataGrid.Visibility = Visibility.Hidden;
                flatsDataGrid.Visibility = Visibility.Visible;
                оплатаDataGrid.Visibility = Visibility.Hidden;
                послугиDataGrid.Visibility = Visibility.Hidden;
            }
            if (tablesmoder.SelectedIndex == 0)
            {
                usersDataGrid.Visibility = Visibility.Hidden;
                flatsDataGrid.Visibility = Visibility.Hidden;
                оплатаDataGrid.Visibility = Visibility.Hidden;
                послугиDataGrid.Visibility = Visibility.Visible;
            }
            if (tablesmoder.SelectedIndex == 1)
            {
                usersDataGrid.Visibility = Visibility.Hidden;
                flatsDataGrid.Visibility = Visibility.Hidden;
                оплатаDataGrid.Visibility = Visibility.Visible;
                послугиDataGrid.Visibility = Visibility.Hidden;
            }
            if (tablesmoder.SelectedIndex == 2)
            {
                usersDataGrid.Visibility = Visibility.Hidden;
                flatsDataGrid.Visibility = Visibility.Visible;
                оплатаDataGrid.Visibility = Visibility.Hidden;
                послугиDataGrid.Visibility = Visibility.Hidden;
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
            Home_managment.HomeManagmentDataSet homeManagmentDataSet = ((Home_managment.HomeManagmentDataSet)(this.FindResource("homeManagmentDataSet")));
            // Загрузить данные в таблицу Flats. Можно изменить этот код как требуется.
            Home_managment.HomeManagmentDataSetTableAdapters.FlatsTableAdapter homeManagmentDataSetFlatsTableAdapter = new Home_managment.HomeManagmentDataSetTableAdapters.FlatsTableAdapter();
            homeManagmentDataSetFlatsTableAdapter.Fill(homeManagmentDataSet.Flats);
            System.Windows.Data.CollectionViewSource flatsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("flatsViewSource")));
            flatsViewSource.View.MoveCurrentToFirst();
            // Загрузить данные в таблицу Users. Можно изменить этот код как требуется.
            Home_managment.HomeManagmentDataSetTableAdapters.UsersTableAdapter homeManagmentDataSetUsersTableAdapter = new Home_managment.HomeManagmentDataSetTableAdapters.UsersTableAdapter();
            homeManagmentDataSetUsersTableAdapter.Fill(homeManagmentDataSet.Users);
            System.Windows.Data.CollectionViewSource usersViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("usersViewSource")));
            usersViewSource.View.MoveCurrentToFirst();
            // Загрузить данные в таблицу Оплата. Можно изменить этот код как требуется.
            Home_managment.HomeManagmentDataSetTableAdapters.ОплатаTableAdapter homeManagmentDataSetОплатаTableAdapter = new Home_managment.HomeManagmentDataSetTableAdapters.ОплатаTableAdapter();
            homeManagmentDataSetОплатаTableAdapter.Fill(homeManagmentDataSet.Оплата);
            System.Windows.Data.CollectionViewSource оплатаViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("оплатаViewSource")));
            оплатаViewSource.View.MoveCurrentToFirst();
            // Загрузить данные в таблицу Послуги. Можно изменить этот код как требуется.
            Home_managment.HomeManagmentDataSetTableAdapters.ПослугиTableAdapter homeManagmentDataSetПослугиTableAdapter = new Home_managment.HomeManagmentDataSetTableAdapters.ПослугиTableAdapter();
            System.Windows.Data.CollectionViewSource послугиViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("послугиViewSource")));
            послугиViewSource.View.MoveCurrentToFirst();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
           

            SqlCeDataAdapter sqlda=new SqlCeDataAdapter();
            try
            {
                //sqlda.Update((DataTable)usersDataGrid.ItemsSource);
                //flatsDataGrid.Items.Refresh();
                //оплатаDataGrid.Items.Refresh();
                //    послугиDataGrid.Items.Refresh();
                //sqlda.Update((DataTable)usersDataGrid.ItemsSource);
                //    sqlda.Update((DataTable)flatsDataGrid.ItemsSource);
                //    sqlda.Update((DataTable)оплатаDataGrid.ItemsSource);
                //    sqlda.Update((DataTable)послугиDataGrid.ItemsSource);
                 
                MessageBox.Show("Изменения в базе данных выполнены!",
                  "Уведомление о результатах");
            }
            catch (Exception)
            {
                MessageBox.Show("Изменения в базе данных выполнить не удалось!",
                  "Уведомление о результатах");
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
