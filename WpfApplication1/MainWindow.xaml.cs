using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
        public MainWindow()
        {
            InitializeComponent();           
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


///            MediaPlayer player = new MediaPlayer();
///            player.Open(new Uri(@"WpfApplication1/Heart sounds wav/001. Normal Heart Sound- normal speed.wav", UriKind.Relative));
///            player.Play();


        }
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            SoundPlayer p = new SoundPlayer(@"C:\Users\angel\Documents\biomedische\Biosignal-recognition-training-tool\WpfApplication1\Heart sounds wav\001. Normal Heart Sound- normal speed.wav");
            p.Load();
            p.Play();

        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            // Displays an OpenFileDialog so the user can select a Cursor.  
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Wav|*.wav";
            openFileDialog1.Title = "Select a wav";

            // Show the Dialog.  
            // If the user clicked OK in the dialog and  
            // a .CUR file was selected, open it.  
            if (openFileDialog1.ShowDialog() == DialogResult)
            {
                SoundPlayer simpleSound = new SoundPlayer(openFileDialog1.OpenFile());
                simpleSound.Play();
            }
        }
        private void Button_Click3(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click4(object sender, RoutedEventArgs e)
        {

        }
    }
}
