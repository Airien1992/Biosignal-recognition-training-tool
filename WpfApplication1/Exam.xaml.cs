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
    /// Interaction logic for Exam.xaml
    /// </summary>
    public partial class Exam : Window
    {
        private string pth = Convert.ToString(Application.ResourceAssembly.Location.Trim(new char[] { 'e', 'x', 'e', '.', '1', 'n', 'o', 'i', 't', 'a', 'c', 'i', 'l', 'p', 'p', 'A', 'f', 'p', 'W' }));
        private int vraag = 0;
        private WpfApplication1.DataSet1 dataSet = new DataSet1();
        private WpfApplication1.DataSet1TableAdapters.SoundTableAdapter dataSet1TableTableAdapter = new WpfApplication1.DataSet1TableAdapters.SoundTableAdapter();
        private List<string[]> antwrd = new List<string[]>();
        List<string[]> stuAntw = new List<string[]>();


        public Exam()
        {
            InitializeComponent();
        }
        private void MixingSongs()
        {
            List<string> files = new List<string>();
            dataSet1TableTableAdapter.Fill(dataSet.Sound);
            Random rnd = new Random();
            int month = rnd.Next(17);
            List<int> mix = new List<int>();
            
            string[] antwID = { "", "", "", "" };
            for (int i = 0; i < 4; i++)
            {
                int rand = rnd.Next(104);
                while (month == rand)
                    rand = rnd.Next(104);
                month = rand;
                mix.Add(month);
            }
            int j = 0;
            foreach (DataSet1.SoundRow row in dataSet.Sound)
            {
                
                foreach (int a in mix)
                {
                    if (row.Id == a)
                    {
                        antwID[j] = row.Afwijking;
                        j++;
                        files.Add(pth + @row.Type + "\\" + row.Locatie.ToString().TrimStart(new char[] { '\\', 'H', 'e', 'a', 'r', 't', '\\', '\\', '\r', '\n' }));
                        
                    }
                }
                
            }
            antwrd.Add(antwID);
            WaveIO wa = new WaveIO();
            string weg = pth + "\\ouput\\";
            wa.Merge(files.Take(4).ToList(), weg + "output.wav");
            
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            myMediaElement.Source = new Uri(pth + "\\ouput\\output.wav");
            myMediaElement.Play();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            myMediaElement.Stop();
            myMediaElement.Source = new Uri("F:\\");
        }
        private void Element_MediaEnded(object sender, EventArgs e)
        {
            myMediaElement.Stop();
        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            int score = 0;
            int va = 1;
            if (vraag < 3)
            {
                stuAntw.Add(new string[] { tbxAfwijking1.Text, tbxAfwijking2.Text, tbxAfwijking3.Text, tbxAfwijking4.Text });
                vraag++;
                MixingSongs();
            }
            else
            {
                foreach(string[] ant in antwrd)
                {
                    if (stuAntw.Contains(ant))
                    {
                        score++;
                    }
                    else
                        MessageBox.Show(ant[0]+","+ ant[1] + "," + ant[2] + "," + ant[3] + "Waren de antwoorden op vraag: "+ va);
                    va++;
                }
                
                MessageBox.Show(score.ToString());
            }
            

        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            myMediaElement.Pause();
        }
    }
}
