using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JAMK.IT.IIO11300
{
  class Lotto
  {
    private int mode;
    private int drawns;

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

    public Lotto()
    {

    }

    public void arvonta()
    {
      MessageBox.Show("Arvotaan");
    }

    public void suomi()
    {

    }

    public void viking()
    {

    }

    public void euro()
    {

    }

  }
}
