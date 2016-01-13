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

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            // Soitetaan käyttäjän valitsemaa mediatiedostoa
            string file = @"d:\G8499\testi.mp4";

            // Tutkitaan onko tiedotoa olemassa
            if (System.IO.File.Exists(file))
            {
                //MessageBox.Show("Balalaikka" + " soi " + file);
                mediaElement.Source = new Uri(file);
                mediaElement.Play();
            }
        }
    }
}
