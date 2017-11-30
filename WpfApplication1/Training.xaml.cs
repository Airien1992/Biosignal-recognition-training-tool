﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        //private SoundPlayer p = new SoundPlayer(@"C:\Users\angel\Documents\biomedische\Biosignal-recognition-training-tool\WpfApplication1\Heart sounds wav\001. Normal Heart Sound- normal speed.wav");
        public Training()
        {
            InitializeComponent();
            if (DesignerProperties.GetIsInDesignMode(this))
            {
                return;
            }

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
    }
}
