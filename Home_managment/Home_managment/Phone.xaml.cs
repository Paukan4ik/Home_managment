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
    /// Логика взаимодействия для Phone.xaml
    /// </summary>
    public partial class Phone : Window
    {
        public Phone()
        {
            InitializeComponent();
            this.Title = "Підтвердження";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Connect con = new Connect();
            con.PhoneAutorize(phone.Text);
            

            if (con.Phone == phone.Text)
            {
                this.Title = "Панель користувача";
                this.Height = 350;
                this.Width = 300;
                Print.Height = 57;
                Go.Visibility = Visibility.Hidden;
                phone.Visibility = Visibility.Hidden;
                Print.Width = 125;
                Preview.Width = 125;
                Preview.Height = 57;
                Preview.Margin=new Thickness(157,252,0,0);
                Print.Margin = new Thickness(5, 252, 0, 0);
                label.Height = 188;
                label.Width = 272;
                label.Margin = new Thickness(8,10,0,0);
                label.Text="Шановний(а) "+con.surname+" "+con.name+" "+con.lastname+" Вам виставлено рахунок за користування комунальнимим та додатковими послугами по адресі вул. "+con.street+" ,буд. "+con.home+" кв. "+con.flat+" ."+"За поточний місяць Вам виставоена плата на суму "+con.summ+" грн. з урахуванням ПДВ без внеску до ПФ";
                Print.Click += new RoutedEventHandler(PrintB);
            }
            else
            {
                MessageBox.Show("Ваш номер не зареєстрований або всі Ваші платежі сплачені");
                user userW = new user();
                userW.ShowDialog();
            }
        }
        private void PrintB(object sender, EventArgs e)
        {       
            Connect con = new Connect();
                con.Pay(phone.Text);
                label.Width = 580;
                label.Height = 180;
                label.FontSize = 32;
                label.TextWrapping = TextWrapping.WrapWithOverflow;
            PrintDialog testPrint = new PrintDialog();
                if (testPrint.ShowDialog() == true)
                {
                    //Где border1 - это лист документа
                    testPrint.PrintVisual(label, "Счёт");
                }
        }

        private void Window_Closed_1(object sender, EventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
