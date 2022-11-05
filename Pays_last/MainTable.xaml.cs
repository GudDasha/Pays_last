using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;
using Syncfusion.UI.Xaml.Grid.Converter;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.XlsIO;



namespace Pays_last
{
    /// <summary>
    /// Логика взаимодействия для MainTable.xaml
    /// </summary>
    public partial class MainTable : Page
    {
        public MainTable()
        {
            InitializeComponent();
            grid_categ.ItemsSource = Расчет_платежейEntities.GetContext().products_user.ToList();
            cmb_category.ItemsSource = Расчет_платежейEntities.GetContext().Categories.ToList();
        }

        private void btn_plus_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Addproduct.xaml", UriKind.Relative));
            
            
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Расчет_платежейEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            grid_categ.ItemsSource = Расчет_платежейEntities.GetContext().products_user.ToList();
        }

        private void btn_minus_Click(object sender, RoutedEventArgs e)
        {
            var paysRemoving = grid_categ.SelectedItems.Cast<products_user>().ToList();

            if(MessageBox.Show($"Вы точно хотите удалить {paysRemoving.Count()} строку","Внимание", MessageBoxButton.YesNo,MessageBoxImage.Question)==MessageBoxResult.Yes)
            {
                try
                {
                    Расчет_платежейEntities.GetContext().products_user.RemoveRange(paysRemoving);
                    Расчет_платежейEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    grid_categ.ItemsSource = Расчет_платежейEntities.GetContext().products_user.ToList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btn_report_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
