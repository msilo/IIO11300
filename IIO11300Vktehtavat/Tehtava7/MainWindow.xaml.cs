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

namespace Tehtava7
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    Password password;

    public MainWindow()
    {
      InitializeComponent();
      Init();
    }

    private void Init()
    {
      password = new Password();
      Update();
    }
      

    private void tbInput_TextChanged(object sender, TextChangedEventArgs e)
    {
      try
      {
        BLSalasana.CheckPassWord(ref password, tbInput.Text);
        Update();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void Update()
    {
      tbMerkkeja.Text = password.Count.ToString();
      tbIsoja.Text = password.Capitals.ToString();
      tbPienia.Text = password.Smalls.ToString();
      tbNumeroita.Text = password.Numerals.ToString();
      tbErikois.Text = password.Specials.ToString();

      tbFeedback.Text = password.Criteria;
    }
  }
}
