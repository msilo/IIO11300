using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Tehtava8
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

    private void btnGetCustomers_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        using (SqlConnection conn = new SqlConnection(Tehtava8.Properties.Settings.Default.connstr))
        {
          string sql = "SELECT firstname, lastname, address, city FROM vCustomers";
          SqlDataAdapter da = new SqlDataAdapter(sql, conn);
          DataTable dt = new DataTable("Viinit");
          da.Fill(dt);
          //sidotaan datatable UI-kontrolliin
          lbCustomers.DataContext = dt;
          conn.Close();
          MessageBox.Show("Onnistui varmaan");
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void lbCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      spInfo.DataContext = lbCustomers.SelectedItem;
    }
  }
}
