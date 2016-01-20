using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JAMK.IT.IIO11300
{
  class Ikkuna
  {
    private double width;
    private double height;
    private double border;

    // Property = Ominaisuus
    public double Width
    {
      get { return width; }
      set { width = value; }
    }

    public double Height
    {
      get { return height; }
      set { height = value; }
    }

    public double Border
    {
      get { return border; }
      set { border = value; }
    }

    // Read only tyyppinen property
    public double PintaAla
    {
      get { return laskePintaAla(); }
    }

    public Ikkuna()
    {
      this.width = 0;
      this.height = 0;
      this.border = 0;
    }

    public Ikkuna(double width, double height, double border)
    {
      this.width = width;
      this.height = height;
      this.border = border;
    }

    // Turha metodi. Luokan tehtävään ei kuulu tiedon tulostaminen käyttäjälle.
    public void tulosta()
    {
      MessageBox.Show("Width: " + width + "\nHeight: " + height + "\nBorder: " + border);
    }

    // Luokan oma metodi, Palauttaa pinta-alan luokan attribuuttien mukaan
    private double laskePintaAla()
    {
      return this.width * this.height;
    }

    // Luokan julkinen metodi. Palauttaa pinta-alan annettujen parametrien mukaan
    public double laskePintaAla(double width, double height)
    {
      return width * height;
    }

   

    public double laskeKarminPiiri()
    {
      return (width+(border*2)) * 2;
    }

    public double laskeKarminPintaAla()
    {
      return 0;
    }

  }
}
