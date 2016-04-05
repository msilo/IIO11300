using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300
{
  class Logics
  {
    private static Random random = new Random((int)DateTime.Now.Ticks);

    public static string suomi()
    {
      const int numerot = 7;
      int noppa = 0;

      string[] tulos = new string[numerot];
      StringBuilder paluu = new StringBuilder();

      for (int i = 0; i < numerot; i++)
      {
        noppa = random.Next(1, 39);
        tulos[i] = noppa.ToString();
        paluu.Append(noppa.ToString());
        paluu.Append(" ");
      }

      return paluu.ToString();
    }

    public static string viking()
    {
      const int numerot = 6;
      int noppa = 0;

      string[] tulos = new string[numerot];
      StringBuilder paluu = new StringBuilder();

      for (int i = 0; i < numerot; i++)
      {
        noppa = random.Next(1, 48);
        tulos[i] = noppa.ToString();
        paluu.Append(noppa.ToString());
        paluu.Append(" ");
      }

      return paluu.ToString();
    }

    public static string euro()
    {
      const int numerot = 5;
      const int tahtinumerot = 2;
      int noppa = 0;

      string[] tulos = new string[numerot];
      StringBuilder paluu = new StringBuilder();

      // Randomize numbers
      for (int i = 0; i < numerot; i++)
      {
        noppa = random.Next(1, 50);
        tulos[i] = noppa.ToString();
        paluu.Append(noppa.ToString());
        paluu.Append(" ");
      }

      paluu.Append("TÄHTI: ");

      // Randomize additinonal numbers
      for (int i = 0; i < tahtinumerot; i++)
      {
        noppa = random.Next(1, 8);
        tulos[i] = noppa.ToString();
        paluu.Append(noppa.ToString());
        paluu.Append(" ");
      }
      return paluu.ToString();
    }
  }
}
