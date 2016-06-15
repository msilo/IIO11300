using System;
using System.Collections.Generic;
using System.IO;
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

namespace Tehtava3
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private List<string> files;

    public MainWindow()
    {
      InitializeComponent();
      init();
    }

    private void init()
    {
      files = new List<string>();
    }

    private void btnGetFiles_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        files = BLfiles.GetFiles(tbFolder.Text);
        lbFiles.ItemsSource = files;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void tbCombineFiles_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        BLfiles.CombineFiles(tbOutput.Text, files);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }
  }
}
