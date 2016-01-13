/*
* Copyright (C) JAMK/IT/Esa Salmikangas
* This file is part of the IIO11300 course project.
* Created: 12.1.2016 Modified: 13.1.2016
* Authors: Mikko Siloaho ,Esa Salmikangas
*/
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

namespace Tehtava1
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

    private void btnCalculate_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        double windowArea = 0;
        double borderPerimeter = 0;
        double borderArea = 0; 

        double winX   = Double.Parse(txtWidth.Text);
        double winY   = Double.Parse(txtHeight.Text);
        double border = Double.Parse(txtBorder.Text); 

        windowArea = BusinessLogicWindow.CalculateArea(winX, winY);
        borderPerimeter = BusinessLogicWindow.CalculatePerimeter(winX + (border*2), winY + (border*2));
        borderArea = BusinessLogicWindow.CalculateArea(winX + (border*2), winY + (border*2)) - windowArea;

        txtWindowArea.Text = windowArea.ToString();
        txtBorderPerimeter.Text = borderPerimeter.ToString();
        txtBorderArea.Text = borderArea.ToString();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
      finally
      {
        //yield to an user that everything okay
      }
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
      this.Close();
    }
  }

  /// <summary>
  /// Business logic for MainWindow.xaml
  /// </summary>
  public class BusinessLogicWindow
  {
      /// <summary>
      /// CalculateArea calculates area.
      /// Aimed for reusability
      /// </summary>
      public static double CalculateArea(double width, double height)
      {
        return width * height;
      }

    /// <summary>
    /// CalculatePerimeter calculates perimeter
    /// Aimed for reusability
    /// </summary>
    public static double CalculatePerimeter(double width, double height)
      {
        return width*2 + height*2;
      }
  }
}
