using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Learning.xaml
    /// </summary>
    public partial class Learning : Window
    {
        private string pth = Convert.ToString(Application.ResourceAssembly.Location.Trim(new char[] { 'e', 'x', 'e', '.', '1', 'n', 'o', 'i', 't', 'a', 'c', 'i', 'l', 'p', 'p', 'A', 'f', 'p', 'W' }));

        public Learning()
        {
            InitializeComponent();
            List<string> files = new List<string>();
            //string[] files = new string[4];
            WpfApplication1.DataSet1 dataSet = new DataSet1();
            WpfApplication1.DataSet1TableAdapters.SoundTableAdapter dataSet1TableTableAdapter = new WpfApplication1.DataSet1TableAdapters.SoundTableAdapter();
            dataSet1TableTableAdapter.Fill(dataSet.Sound);
            Random rnd = new Random();
            int month = rnd.Next(17);
            List<int> mix = new List<int>();
            for (int i = 0; i < 16; i++) 
            {
                int rand= rnd.Next(17);
                while (month == rand)
                    rand = rnd.Next(17);
                month = rand;
                mix.Add(month);
            }
            
            foreach (DataSet1.SoundRow row in dataSet.Sound)
            {
                foreach (int a in mix)
                {
                    if(row.Id==a)
                    files.Add(pth + row.Locatie);
                }
                // MessageBox.Show(row.Afwijking);

            }

            WaveIO wa = new WaveIO();
            string weg=pth + "\\ouput\\";
            wa.Merge(files.Take(4).ToList(), weg+"output1.wav");
            wa.Merge(files.Skip(4).Take(4).ToList(), weg + "output2.wav");
            wa.Merge(files.Skip(8).Take(4).ToList(), weg + "output3.wav");
            wa.Merge(files.Skip(12).Take(4).ToList(), weg + "output4.wav");
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            myMediaElement.Source=new Uri(pth + "\\ouput\\output1.wav");
            myMediaElement.Play();
    }
        private void Element_MediaEnded(object sender, EventArgs e)
        {
            myMediaElement.Stop();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            myMediaElement.Source = new Uri(pth + "\\ouput\\output2.wav");
            myMediaElement.Play();
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            myMediaElement.Source = new Uri(pth + "\\ouput\\output3.wav");
            myMediaElement.Play();
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            myMediaElement.Source = new Uri(pth + "\\ouput\\output4.wav");
            myMediaElement.Play();
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
