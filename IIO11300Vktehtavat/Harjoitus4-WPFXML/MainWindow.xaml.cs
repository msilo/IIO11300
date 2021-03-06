﻿using System;
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
using System.Xml;
using System.Xml.Linq;

namespace Harjoitus4_WPFXML
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    XElement xe;
    public MainWindow()
    {
      InitializeComponent();
    }

    private void btnGetXML_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        // Ladataan XML tiedosto ja asetetaan se DataGridin "data context":ksi
        xe = XElement.Load(GetFileName());
        dgData.DataContext = xe.Elements("tyontekija");

        // Lasketaan työntekijöiden määrä ja palkkasummaja näytetään se käyttäjälle
        int lkm = 0;
        lkm = xe.Elements().Count();
        tbMessage.Text = string.Format("Akun tehtaalla on kaikkiaan{0} työntekijää, joista valkituisia {1} palkat yhteensä {2}", lkm, CountWorkers("vakituinen"),CalculateSalarySum());
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private string GetFileName()
    {
      // Kovakoodattuna
      //return "d:\\g8499\\Työntekijät2013.xml";
      // Parempi tapa on sijoittaa App.Config tiedostoon
      return Harjoitus4_WPFXML.Properties.Settings.Default.XMLtiedosto;
    }

    private decimal CalculateSalarySum()
    {
      decimal result = 0;
      // Haetaan työntekijöiden palkat xml:stä LINQ-kyselyllä (XElement-olioon)
      var palkat = from ele in xe.Elements()
                   select ele.Element("palkka");

      foreach (var item in palkat)
      {
        result += decimal.Parse(item.Value);
      }
      return result;
    }

    private int CountWorkers(string tyosuhde)
    {
      // Lasketaan annetun työsuhteen mukaiset työntekijät

      var n = from ele in xe.Elements()
              where ele.Element("tyosuhde").Value == tyosuhde
              select ele.Element("etunimi");

      return n.Count();
    }
  }
}
