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
    /// Логика взаимодействия для user.xaml
    /// </summary>
    public partial class user : Window
    {
       public user()
        {
            InitializeComponent();
            Message.Text = "Для реєстрації/внесення Вших данних надішліть лист з заповненим бланком до  Вашого Районного ЖКГ"; 
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            Shower.Navigate(AppDomain.CurrentDomain.BaseDirectory + "Blank.docx");
            //   this.Close();
        }

        private void Window_Closed_1(object sender, EventArgs e)
        {
            App.Current.Shutdown();
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
