using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
///using System.Data.Entity.Core.Objects;
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
 ///       SoundEntity dataEntities = new SoundEntity();
        public MainWindow()
        {
            InitializeComponent();

            /*DataSet musicOrders = new DataSet("Music");
            MusicGrid.DataContext = musicOrders;
            DataTable ordersTable = musicOrders.Tables.Add("Sound");

            DataColumn pkSoundID =
                ordersTable.Columns.Add("SoundID", typeof(Int32));
            ordersTable.Columns.Add("Type", typeof(string));
            ordersTable.Columns.Add("Afwijking", typeof(string));
            ordersTable.Columns.Add("Leeftijd", typeof(Int32));
            ordersTable.Columns.Add("Duur", typeof(Int32));
            ordersTable.Columns.Add("Locatie", typeof(string));

            ordersTable.PrimaryKey = new DataColumn[] { pkSoundID };*/
        }

        private void Button_Start1(object sender, RoutedEventArgs e)
        {
            Training tr = new Training();
            tr.Show();
            this.Close();
        }
        private void Button_Start2(object sender, RoutedEventArgs e)
        {
            Learning lr = new Learning();
            lr.Show();
            this.Close();
        }
        private void Button_Start3(object sender, RoutedEventArgs e)
        {
            Exam ex = new Exam();
            ex.Show();
            this.Close();
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

 ///           var query =
 ///   from table in dataEntities.Tables
///    where table.Type == "Heart"
///    orderby table.Afwijking
///    select new { table.Id, table.Type, CategoryName = table.Type, table.duur };

 ///           dataGrid1.ItemsSource = query.ToList();

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            WpfApplication1.Database1DataSet database1DataSet = ((WpfApplication1.Database1DataSet)(this.FindResource("database1DataSet")));
            // Load data into the table Table. You can modify this code as needed.
            WpfApplication1.Database1DataSetTableAdapters.TableTableAdapter database1DataSetTableTableAdapter = new WpfApplication1.Database1DataSetTableAdapters.TableTableAdapter();
            database1DataSetTableTableAdapter.Fill(database1DataSet.Table);
            System.Windows.Data.CollectionViewSource tableViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tableViewSource")));
            tableViewSource.View.MoveCurrentToFirst();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            WpfApplication1.Database1DataSet database1DataSet = ((WpfApplication1.Database1DataSet)(this.FindResource("database1DataSet")));
            WpfApplication1.Database1DataSetTableAdapters.TableTableAdapter database1DataSetTableTableAdapter= new WpfApplication1.Database1DataSetTableAdapters.TableTableAdapter();
            database1DataSetTableTableAdapter.Update(database1DataSet.Table);
        }
    }
}
