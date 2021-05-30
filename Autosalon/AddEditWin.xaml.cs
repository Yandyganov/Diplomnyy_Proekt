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

namespace Autosalon
{
    /// <summary>
    /// Логика взаимодействия для AddEditWin.xaml
    /// </summary>
    public partial class AddEditWin : Window
    {
        public Product CurrentProduct { get; set; }
        public IEnumerable<ProductType> productTypes { get; set; }
        public AddEditWin(Product products)
        {
            InitializeComponent();
            DataContext = this;
            CurrentProduct = products;
            productTypes = Core.DB.ProductType.ToArray();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CurrentProduct.ID == 0)
                    Core.DB.Product.Add(CurrentProduct);
                Core.DB.SaveChanges();
                DialogResult = true;
                MessageBox.Show($"Успешно сохранено");
            }
            catch
            {
                MessageBox.Show($"Возникла ошибка" +
                    $"ERROR");
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
