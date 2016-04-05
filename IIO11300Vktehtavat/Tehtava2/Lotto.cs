using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace JAMK.IT.IIO11300
{
  class Lotto
  {
    // Attributes ************
    private int mode;
    private int drawns;
    List<String> lista;

    public delegate string metodi();

    // Properties *************
    public int Mode
    {
      get { return mode; }
      set { mode = value; }
    }

    public int Drawns
    {
      get { return drawns; }
      set { drawns = value; }
    }

    // Constructors ************
    public Lotto()
    {
      // Create instance of List and populate it
      lista = new List<String>();
      // Key - Value
      lista.Add("Suomi");
      lista.Add("Viking Lotto");
      lista.Add("Euro Jackpot");
    }

    // Methods *****************
    public string arvonta(TextBox outcome)
    {
      metodi m;
      
      switch (mode)
      {
        case 0:
          m = Logics.suomi;
          break;
        case 1:
          m = Logics.viking;
          break;
        case 2:
          m = Logics.euro;
          break;
        default:
          // If mode is not defined throw exception
          throw new Exception("Error #666. Lottery mode was not defined!");
      }
      
      for(int i = 0; i < drawns; i++)
      {
        outcome.AppendText(m() + "\n");
      }

      return "Arvonta tehty :D";
    }

    public string arvonta(metodi m)
    {
      return m();
    }

    public List<string> getLotot()
    {
      return lista;
    }
  }
}
