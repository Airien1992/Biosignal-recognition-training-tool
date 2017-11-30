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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Learning.xaml
    /// </summary>
    public partial class Learning : Window
    {
        public Learning()
        {
            InitializeComponent();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            //show random sound
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            //show random sound
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            //show random sound
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            //show random sound
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //pick the sound you think is correct
        }

        private void Next_Button(object sender, RoutedEventArgs e)
        {
            //submit your answer and after that check whether it's the correct one or not

            var newText = new TextBox();
            string message = string.Format("CORRECT! / FOUT!", newText.Text);
            MessageBox.Show(message);
            GenerateNextQuestion();          
        }

        private void GenerateNextQuestion()
        {

        }

        private void CheckAnswer()
        {

        }
    }
}
