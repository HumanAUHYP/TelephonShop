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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TelephonShop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            myFrame.Navigate(new LoginPage());
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            if (myFrame.CanGoBack) myFrame.GoBack();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (myFrame.CanGoForward) myFrame.GoForward();
        }
    }
}
