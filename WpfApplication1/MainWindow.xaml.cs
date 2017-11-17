using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Media;
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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SoundEntity dataEntities = new SoundEntity();
        public MainWindow()
        {
            InitializeComponent();           
        }

        private void Button_Start(object sender, RoutedEventArgs e)
        {
            Training tr = new Training();
            tr.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            var query =
    from table in dataEntities.Tables
    where table.Type == "Heart"
    orderby table.Afwijking
    select new { table.Id, table.Type, CategoryName = table.Type, table.duur };

            dataGrid1.ItemsSource = query.ToList();

        }
    }
}
