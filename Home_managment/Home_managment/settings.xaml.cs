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
    /// Логика взаимодействия для settings.xaml
    /// </summary>
    public partial class settings : Window
    {
        public settings()
        {
            InitializeComponent();
            this.Background = Home_managment.Properties.Settings.Default.Color;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (colors.SelectedIndex == 0)
            { Home_managment.Properties.Settings.Default.Color = new SolidColorBrush(Colors.Red); }
            if (colors.SelectedIndex == 0)
            { Home_managment.Properties.Settings.Default.Color = new SolidColorBrush(Colors.Yellow); }
            if (colors.SelectedIndex == 0)
            { Home_managment.Properties.Settings.Default.Color = new SolidColorBrush(Colors.Aqua); }
            if (colors.SelectedIndex == 0)
            {
                Home_managment.Properties.Settings.Default.Color = new SolidColorBrush(Colors.Gray);
            }
            if (colors.SelectedIndex == 0)
            {
            Home_managment.Properties.Settings.Default.Color = new SolidColorBrush(Colors.White);
            }
            Home_managment.Properties.Settings.Default.Save();
            this.Hide();
        }
    }
}
