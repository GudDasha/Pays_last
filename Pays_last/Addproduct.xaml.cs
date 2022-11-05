using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace Pays_last
{
    /// <summary>
    /// Логика взаимодействия для Addproduct.xaml
    /// </summary>
    public partial class Addproduct : Page
    {
        private products_user pays = new products_user();
        public Addproduct()
        {
            InitializeComponent();
            DataContext = pays;
            cmb.ItemsSource = Расчет_платежейEntities.GetContext().Categories.ToList();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(txt_product.Text))
                error.AppendLine("Укажите продукт");
            if (string.IsNullOrWhiteSpace(txt_cost.Text))
                error.AppendLine("Укажите количество");
            if (string.IsNullOrWhiteSpace(txt_count.Text))
                error.AppendLine("Укажите цену");
            
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            
                var category = cmb.SelectedItem as Category;
                pays.Категория = category.id;
                pays.Наименование = txt_product.Text;
                pays.Количество = int.Parse(txt_count.Text);
                pays.Цена = int.Parse(txt_cost.Text);
                pays.Сумма = pays.Цена * pays.Количество;
                Instance.db.products_user.Add(pays);
                Instance.db.SaveChanges();
                NavigationService.Navigate(new Uri("/MainTable.xaml", UriKind.Relative));
            
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainTable.xaml", UriKind.Relative));
        }
      
    }
}
