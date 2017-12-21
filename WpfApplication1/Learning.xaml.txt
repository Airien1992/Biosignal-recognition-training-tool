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
using System.Windows.Threading;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Learning.xaml
    /// </summary>
    public partial class Learning : Window
    {
        private string pth = Convert.ToString(Application.ResourceAssembly.Location.Trim(new char[] { 'e', 'x', 'e', '.', '1', 'n', 'o', 'i', 't', 'a', 'c', 'i', 'l', 'p', 'p', 'A', 'f', 'p', 'W' }));
        private int juist = 0;
        private string juistAntwoord;
        private WpfApplication1.DataSet1 dataSet = new DataSet1();
        private WpfApplication1.DataSet1TableAdapters.SoundTableAdapter dataSet1TableTableAdapter = new WpfApplication1.DataSet1TableAdapters.SoundTableAdapter();

        public Learning()
        {
            InitializeComponent();
            MixingSongs();
        }
            
        private void MixingSongs()
        {
            List<string> files = new List<string>();
            dataSet1TableTableAdapter.Fill(dataSet.Sound);
            Random rnd = new Random();
            int month = rnd.Next(17);
            List<int> mix = new List<int>();

            List<string> antwrd = new List<string>();
            int[] antwID = { 0, 0, 0, 0 };
            for (int i = 0; i < 16; i++)
            {

                int rand = rnd.Next(104);
                while (month == rand)
                    rand = rnd.Next(104);
                month = rand;
                mix.Add(month);
            }
            int optie = rnd.Next(4);
            int ant = rnd.Next(4);
            juist = 4 * optie + ant;
            foreach (DataSet1.SoundRow row in dataSet.Sound)
            {
                foreach (int a in mix)
                {
                    if (row.Id == a)
                    {
                        files.Add(pth + @row.Type + "\\" + row.Locatie.ToString().TrimStart(new char[] { '\\', 'H', 'e', 'a', 'r', 't', '\\', '\\', '\r', '\n' }));
                        
                    }
                }
                if (row.Id == juist)
                {
                    juistAntwoord = row.Afwijking;
                }

            }
            for (int i = 0; i < 3; i++)
            {
                int rand = rnd.Next(104);
                while (month == rand)
                    rand = rnd.Next(104);
                month = rand;
                if (month <= juist || juist == 0)
                    antwID[i] = month;
                else
                {
                    antwID[i] = juist;
                    juist = 0;
                    i += 1;
                    antwID[i] = month;
                }
            }
            cbAntwoorden.Items.Clear();
            foreach (DataSet1.SoundRow row in dataSet.Sound)
            {
                if (antwID.Contains(row.Id))
                {
                    cbAntwoorden.Items.Add(row.Afwijking);
                }
            }

            WaveIO wa = new WaveIO();
            string weg = pth + "\\ouput\\";
            wa.Merge(files.Take(4).ToList(), weg + "output1.wav");
            wa.Merge(files.Skip(4).Take(4).ToList(), weg + "output2.wav");
            wa.Merge(files.Skip(8).Take(4).ToList(), weg + "output3.wav");
            wa.Merge(files.Skip(12).Take(4).ToList(), weg + "output4.wav");
        }

        void InitializePropertyValues()
        {
            myMediaElement.Volume = volumeSlider.Value;

        }
        void timer_Tick(object sender, EventArgs e)
        {
            if (myMediaElement.Source != null)
                lblStatus.Content = String.Format("{0} / {1}", myMediaElement.Position.ToString(@"mm\:ss"), myMediaElement.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
            else
                lblStatus.Content = "Not playing...";
        }
        private void Element_MediaEnded(object sender, EventArgs e)
        {
            myMediaElement.Stop();
        }
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            myMediaElement.Source=new Uri(pth + "\\ouput\\output1.wav");
            myMediaElement.Play();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            InitializePropertyValues();
        }
        

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            myMediaElement.Source = new Uri(pth + "\\ouput\\output2.wav");
            myMediaElement.Play();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            InitializePropertyValues();
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            myMediaElement.Source = new Uri(pth + "\\ouput\\output3.wav");
            myMediaElement.Play();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            InitializePropertyValues();
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            myMediaElement.Source = new Uri(pth + "\\ouput\\output4.wav");
            myMediaElement.Play();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            InitializePropertyValues();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //pick the sound you think is correct
        }


        private void GenerateNextQuestion()
        {
            
            MixingSongs();
        }

        private void CheckAnswer()
        {
            if (juistAntwoord == cbAntwoorden.SelectedValue.ToString())
            {
                MessageBox.Show("Correct geantwoord!");
                GenerateNextQuestion();
                cbAntwoorden.SelectedIndex = 0;
            }
            else
                MessageBox.Show("Helaas, fout antwoord. Het juist antwoord is: " + juistAntwoord);
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myMediaElement.Stop();
            myMediaElement.Source = null;
            CheckAnswer();
            
        }

        private void Button_Home(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }

        private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            myMediaElement.Volume = (double)volumeSlider.Value;
        }
        
    }
}
