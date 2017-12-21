using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication1
{
    public class Questions : Window
    { 
        public string question1 { get; set; }
        public string question2 { get; set; }
        public string question3 { get; set; }
        public string question4 { get; set; }
        public string question5 { get; set; }
        public string answers1 { get; set; }
        public string answers2 { get; set; }
        public string answers3 { get; set; }
        public string answers4 { get; set; }
        public string answers5 { get; set; }
        public string soundPath { get; set; }
        private string pth = Convert.ToString(System.Windows.Application.ResourceAssembly.Location.Trim(new char[] { 'e', 'x', 'e', '.', '1', 'n', 'o', 'i', 't', 'a', 'c', 'i', 'l', 'p', 'p', 'A', 'f', 'p', 'W' }));
        private WpfApplication1.DataSet1 dataSet = new DataSet1();
        private WpfApplication1.DataSet1TableAdapters.SoundTableAdapter dataSet1TableTableAdapter = new WpfApplication1.DataSet1TableAdapters.SoundTableAdapter();
        private List<string[]> antwrd = new List<string[]>();
        public Questions(List<string> questions,List<string> answers, string musicPath)
        {
            for(int i = 1; i < 6; i++)
            {
                switch (i)
                {
                    case 1:
                        question1 = questions[0];
                        answers1 = answers[0];
                        break;
                    case 2:
                        question2 = questions[1];
                        answers2 = answers[1];
                        break;
                    case 3:
                        question3 = questions[2];
                        answers3 = answers[2];
                        break;
                    case 4:
                        question4 = questions[3];
                        answers4 = answers[3];
                        break;
                    case 5:
                        question5 = questions[4];
                        answers5 = answers[4];
                        break;
                }
                soundPath = musicPath;
            }

        }
        
    }
}
