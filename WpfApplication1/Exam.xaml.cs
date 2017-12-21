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
        private int pointTotal = 0;
        private int score = 0;
        private string[] ant = new string[5];
        private WpfApplication1.DataSet1 dataSet = new DataSet1();
        private WpfApplication1.DataSet1TableAdapters.SoundTableAdapter dataSet1TableTableAdapter = new WpfApplication1.DataSet1TableAdapters.SoundTableAdapter();
        private List<string> quest = new List<string>();
        private List<string> antwrd = new List<string>();
        List<string[]> stuAntw = new List<string[]>();
        List<Questions> gezetteVragen = new List<Questions>();


        public Exam()
        {
            InitializeComponent();
            vraag = 0;
            MixingSongs();
            settingOfTheQuestions("Wat is het type van het geluid?", "Wat is de eerste afwijking?", "Wat is de tweede afwijking?",
                "Wat is de derde afwijking?", "Wat is de vierde afwijking?",ant, pth + "\\ouput\\outpt.wav");
            settingTemplate(vraag);
        }
		
        private void settingOfTheQuestions(string v1,string v2, string v3, string v4, string v5,string[] a,/* string a1, string a2, string a3, string a4, string a5,*/ string musicElementPath)
        {
            quest.Add(v1);
            quest.Add(v2);
            quest.Add(v3);
            quest.Add(v4);
            quest.Add(v5);

           // antwrd.Add(a1);
           // antwrd.Add(a2);
           // antwrd.Add(a3);
           // antwrd.Add(a4);
           // antwrd.Add(a5);
           foreach(string an in a)
            {
                antwrd.Add(an);
            }

            Questions vr1 = new Questions(quest, antwrd, musicElementPath);
            gezetteVragen.Add(vr1);
            quest.Clear();
            antwrd.Clear();
        }
        private void settingTemplate(int nrVraag)
        {
            lblq1.Content = gezetteVragen[nrVraag].question1;
            lblq2.Content = gezetteVragen[nrVraag].question2;
            lblq3.Content = gezetteVragen[nrVraag].question3;
            lblq4.Content = gezetteVragen[nrVraag].question4;
            lblq5.Content = gezetteVragen[nrVraag].question5;
            myMediaElement.Source = new Uri(gezetteVragen[nrVraag].soundPath);
        }
        private int checkingAnswers(int nrVraag)
        {
            int score = 0;
            if (tbxQ1.Text == gezetteVragen[nrVraag].answers1)
                score += 1;
            if (tbxQ2.Text == gezetteVragen[nrVraag].answers2)
                score = +1;
            if (tbxQ3.Text == gezetteVragen[nrVraag].answers3)
                score += 1;
            if (tbxQ4.Text == gezetteVragen[nrVraag].answers4)
                score += 1;
            if (tbxQ5.Text == gezetteVragen[nrVraag].answers5)
                score += 1;
            return score;
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
                if (row.Id == 1)
                    ant[j]=row.Type;
                foreach (int a in mix)
                {
                    if (row.Id == a)
                    {
                        
                        files.Add(pth + @row.Type + "\\" + row.Locatie.ToString().TrimStart(new char[] { '\\', 'H', 'e', 'a', 'r', 't', '\\', '\\', '\r', '\n' }));
                        j++;
                        ant[j] = row.Afwijking;
                    }
                }
                
            }
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
            pointTotal += checkingAnswers(vraag);
            if (vraag < 3)
            {
                vraag++;
                MixingSongs();
                tbxQ1.Clear();
                tbxQ2.Clear();
                tbxQ3.Clear();
                tbxQ4.Clear();
                tbxQ5.Clear();
                settingOfTheQuestions("Wat is het type van het geluid?", "Wat is de eerste afwijking?", "Wat is de tweede afwijking?",
                    "Wat is de derde afwijking?", "Wat is de vierde afwijking?",ant, pth + "\\ouput\\outpt.wav");
                settingTemplate(vraag);
            }
            else
            {
                int va = 0;
                foreach (Questions q in gezetteVragen)
                {
                    if (stuAntw.Contains(ant))
                    {
                        score++;
                    }
                    else {
                        MessageBox.Show(q.answers1 + "," + q.answers2 + "," + q.answers3 + "," + q.answers4
                            + "," + q.answers5 + "Waren de antwoorden op vraag: " + va);
                        va++;
                    }
                
                        
                }
                
                MessageBox.Show(pointTotal.ToString());
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }

        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            myMediaElement.Pause();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }
    }
}
