using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Training.xaml
    /// </summary>
    public partial class Training : Window
    {
        private SoundPlayer p = new SoundPlayer(Application.ResourceAssembly.Location.Trim(new char[]{ 'e', 'x', 'e', '.', '1', 'n', 'o', 'i', 't', 'a', 'c', 'i', 'l', 'p', 'p', 'A', 'f', 'p', 'W' }));
        public Training()
        {
            InitializeComponent();
            
            if (DesignerProperties.GetIsInDesignMode(this))
            {
                return;
            }
            DirectoryInfo d = new DirectoryInfo(Convert.ToString(Application.ResourceAssembly.Location.Trim(new char[] { 'e', 'x', 'e', '.', '1', 'n', 'o', 'i', 't', 'a', 'c', 'i', 'l', 'p', 'p', 'A', 'f', 'p', 'W' })+"\\Heart"));//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.wav"); //Getting Text files
            List<string> keuzes = new List<string>();
            foreach (FileInfo file in Files)
            {
                
                keuzes.Add(Convert.ToString(file.Name));
            }
            foreach(string keuze in keuzes)
            {
                KeuzeSound.Items.Add(keuze);
            }
            TextWriter tw = new StreamWriter("SavedList.txt");

            foreach (String s in keuzes)
                tw.WriteLine(s);

            tw.Close();

        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (myMediaElement.Source != null)
                lblStatus.Content = String.Format("{0} / {1}", myMediaElement.Position.ToString(@"mm\:ss"), myMediaElement.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
            else
                lblStatus.Content = "No file selected...";
        }
        private void ButtonPlay(object sender, RoutedEventArgs e)
        {
            myMediaElement.Play();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            InitializePropertyValues();

        }
        private void ButtonPause(object sender, RoutedEventArgs e)
        {
            // Displays an OpenFileDialog so the user can select a Cursor.  
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.Filter = "Wav|*.wav";
            //openFileDialog1.Title = "Select a wav";

            // Show the Dialog.  
            // If the user clicked OK in the dialog and  
            // a .CUR file was selected, open it.  
            //if (openFileDialog1.ShowDialog() != DialogResult)
            //{
            // SoundPlayer simpleSound = new SoundPlayer(openFileDialog1.FileName);
            // simpleSound.Load();
            //simpleSound.Play();
            //}
            // myMediaElement.Pause();
            myMediaElement.Pause();
        }
        private void ButtonStop(object sender, RoutedEventArgs e)
        {
            myMediaElement.Stop();
        }


        private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            myMediaElement.Volume = (double)volumeSlider.Value;
        }


        private void Element_MediaEnded(object sender, EventArgs e)
        {
            myMediaElement.Stop();
        }

        void InitializePropertyValues()
        {
            myMediaElement.Volume = volumeSlider.Value;

        }

        private void ButtonBack(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }

        private void KeuzeSound_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           Uri a=new Uri(Convert.ToString(Application.ResourceAssembly.Location.Trim(new char[] { 'e', 'x', 'e', '.', '1', 'n', 'o', 'i', 't', 'a', 'c', 'i', 'l', 'p', 'p', 'A', 'f', 'p', 'W' }) + @"Heart") + @"\" + KeuzeSound.SelectedItem.ToString());
            myMediaElement.Source = a;
        }
    }
}