using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300
{
  public class MittausData
  {
    private string kello;

    #region PROPERTIES 
    public string Kello
    {
      get { return kello; }
      set { kello = value; }
    }

    private string mittaus;

    public string Mittaus
    {
      get { return mittaus; }
      set { mittaus = value; }
    }

    public MittausData()
    {
      this.kello = "0:00";
      this.mittaus = "Ei dataa";
    }

    public MittausData(string kello, string mittaus)
    {
      this.kello = kello;
      this.mittaus = mittaus;
    }
    #endregion
    // Ylikirjoitetaan ToString metodi

    public override string ToString()
    {
      //return base.ToString();
      return kello + " = " + mittaus;
    }

  }
}
