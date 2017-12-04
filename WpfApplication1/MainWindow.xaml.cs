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
using System.Data.SQLite;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        
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

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

        DataSet1 dataSet = new DataSet1();
            // Load data into the table Table. You can modify this code as needed.
            DataSet1TableAdapters.SoundTableAdapter dataSet1TableTableAdapter = new WpfApplication1.DataSet1TableAdapters.SoundTableAdapter();
        dataSet1TableTableAdapter.Fill(dataSet.Sound);
            tableDataGrid.DataContext = dataSet.Sound;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            WpfApplication1.DataSet1 dataSet = ((WpfApplication1.DataSet1)(this.FindResource("dataSet")));
            WpfApplication1.DataSet1TableAdapters.SoundTableAdapter dataSet1TableTableAdapter = new WpfApplication1.DataSet1TableAdapters.SoundTableAdapter();

            //dataSet1TableTableAdapter.InsertSound(Convert.ToInt32(txtbxId.Text), txtbxType.Text, txtbxAfwijking.Text,txtbxLocatie.Text);
            
            dataSet1TableTableAdapter.Insert(Convert.ToInt32(txtbxId.Text), txtbxType.Text, txtbxAfwijking.Text, txtbxLocatie.Text);
            dataSet1TableTableAdapter.Update(dataSet.Sound);
            dataSet1TableTableAdapter.Fill(dataSet.Sound);
            tableDataGrid.DataContext = dataSet.Sound; 
        }
        
    }
}
