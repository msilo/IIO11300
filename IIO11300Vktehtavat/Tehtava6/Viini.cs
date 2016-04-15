using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava6
{
  public class Viini
  {
    private string nimi;

    public string Nimi
    {
      get { return nimi; }
      set { nimi = value; }
    }

    private string maa;

    public string Maa
    {
      get { return maa; }
      set { maa = value; }
    }

    private int arvio;

    public int Arvio
    {
      get { return arvio; }
      set { arvio = value; }
    }

    public Viini()
    {

    }

    public Viini(string nimi, string maa, int arvio)
    {
      this.nimi = nimi;
      this.maa = maa;
      this.arvio = arvio;
    }
  }
}
