using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using TelephonShop.BD;

namespace TelephonShop
{
    /// <summary>
    /// Логика взаимодействия для TelephonListPage.xaml
    /// </summary>
    public partial class TelephonListPage : Page
    {
        List<Telephone> Telephones;
        public TelephonListPage()
        {
            InitializeComponent();
            DisplayProductsInPage();
        }

        private void BtnAddClientClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddClientPage());
        }

        private void BtnReturnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ReturnTelPage());
        }

        private void BtnSaleClick(object sender, RoutedEventArgs e)
        {
            
            try
            {
                var telephone = ProductTable.SelectedItem as Telephone;
                telephone.IsSaled = true;

                var sale = new Client_Telephon();
                sale.ClientId = 1;
                sale.TelephoneId = telephone.Id;
                sale.UseTimeId = 1;

                db.connection.Client_Telephon.Add(sale);
                db.connection.SaveChanges();
                DisplayProductsInPage();
            }
            catch (TargetException)
            {
                MessageBox.Show("Не выбран телефон для продажи");
            }
        }

        private void DisplayProductsInPage()
        {
            Telephones = db.connection.Telephone.Where(a => a.IsSaled == false).ToList();
            ProductTable.ItemsSource = Telephones;
        }
    }
}
