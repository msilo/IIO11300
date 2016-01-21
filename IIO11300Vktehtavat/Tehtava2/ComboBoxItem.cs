using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava2
{
  class ComboBoxItem
  {
    private string key;
    private int value;

    public string Key
    {
      get { return key; }
      set { key = value; }
    }

    public int Value
    {
      get { return this.value; }
      set { this.value = value; }
    }

    public ComboBoxItem()
    {
      this.key = "";
      this.value = 0;
    }

    public ComboBoxItem(string key, int value)
    {
      this.key = key;
      this.value = value;
    }
  }
}
