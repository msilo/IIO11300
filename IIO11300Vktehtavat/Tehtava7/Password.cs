using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava7
{
  public class Password
  {
    private int count;

    public int Count
    {
      get { return count; }
      set { count = value; }
    }

    private int capitals;

    public int Capitals
    {
      get { return capitals; }
      set { capitals = value; }
    }

    private int smalls;

    public int Smalls
    {
      get { return smalls; }
      set { smalls = value; }
    }

    private int numerals;

    public int Numerals
    {
      get { return numerals; }
      set { numerals = value; }
    }

    private int specials;

    public int Specials
    {
      get { return specials; }
      set { specials = value; }
    }

    private string criteria;

    public string Criteria
    {
      get { return criteria; }
      set { criteria = value; }
    }

    public Password()
    {
      count = 0;
      capitals = 0;
      smalls = 0;
      numerals = 0;
      specials = 0;

      criteria = "Anna salasana";
    }

  }
}
