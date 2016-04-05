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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Harjoitus1_MediaPlayer
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

        private bool isPaused = false;
        private TimeSpan aika;

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
          try
          {

            loadMediaFile();

            isPaused = false;
            mediaElement.Play();
          }
          catch (Exception ex)
          {
            MessageBox.Show(ex.Message);
          }
        }

    // Ladataan käyttäjän valitsema tiedosto
    private void loadMediaFile()
    {
      // Soitetaan käyttäjän valitsemaa mediatiedostoa
      string path = @"d:\G8499\media\";
      string file = @txtSource.Text;
      string jees = path + file;

      // Tutkitaan onko tiedotoa olemassa
      if (System.IO.File.Exists(jees))
      {
        mediaElement.Source = new Uri(jees);
      }
      // Jos ei niin poikkeusta kehiin
      else
      {
        throw new Exception("Tiedostoa " + jees + " ei löydy!");
      }
    }

    private void btnPause_Click(object sender, RoutedEventArgs e)
    {
      if(isPaused == true)
      {
        mediaElement.Position = aika;
        mediaElement.Play();
        isPaused = false;
        
      }
      else
      {
        aika = mediaElement.Position;
        isPaused = true;
        mediaElement.Pause();
      }
    }

    private void btnStop_Click(object sender, RoutedEventArgs e)
    {
      mediaElement.Stop();
    }
  }
}
