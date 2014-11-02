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
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using System.Reflection;


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
            phone.Focus();
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
                Print.Width = 272;
                Print.Margin = new Thickness(5, 252, 0, 0);
                label.Height = 188;
                label.Width = 272;
                label.Margin = new Thickness(8,50,0,0);
                label.Text="Шановний(а) "+con.surname+" "+con.name+" "+con.lastname+" Вам виставлено рахунок за користування комунальними та додатковими послугами по адресі вул. "+con.street+" ,буд. "+con.home+" кв. "+con.flat+" ."+"За поточний місяць Вам виставоена плата на суму "+con.summ+" грн. з урахуванням ПДВ без внеску до ПФ";
                Print.Click += new RoutedEventHandler(PrintB);
                Menu.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Ваш номер не зареєстрований або всі Ваші платежі сплачені");
                user userW = new user();
                    this.Hide();
                userW.ShowDialog();
            }
        }
        private void PrintB(object sender, EventArgs e)
        {       

            Connect con = new Connect();
                con.Pay(phone.Text);
  object oMissing = System.Reflection.Missing.Value;
                   object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

                   //Start Word and create a new document.
                   Word._Application oWord;
                   Word._Document oDoc;
                   oWord = new Word.Application();
                   oWord.Visible = true;
                   oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
                       ref oMissing, ref oMissing);

                   //Insert a paragraph at the beginning of the document.
                   Word.Paragraph oPara1;
                   oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
                   oPara1.Range.Text = label.Text + "\nПідпис платника                                                       Підпис приймача оплати ";
                   oPara1.Range.Font.Bold = 1;
                   oPara1.Format.SpaceAfter = 30;    //24 pt spacing after paragraph.
                   oPara1.Range.InsertParagraphAfter();

            
        }

        private void Window_Closed_1(object sender, EventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Go_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click_1(sender, e);
            }
        }
        private void Button_Click_Pro(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Додаток розроблений спеціально для Житлово-Комунальних установ! \n©2014 by Paukan4ik");
        }

        private void Button_Click_Pay(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Способи оплати: \n1.Через термінал \n2.В відділенні банку \n3.В відділенні ЖЕК \n4.Через платіжні системи Приват24");
        }

        private void phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
    }
}
