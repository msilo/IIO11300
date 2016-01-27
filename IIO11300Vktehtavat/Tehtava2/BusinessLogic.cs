using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JAMK.IT.IIO11300
{
  class BusinessLogic
  {
    // Attributes
    private Lotto lotto;

    // Consturctors
    public BusinessLogic()
    {
      lotto = new Lotto();
    }

    // Methods
    public string arvonta(int draws, int mode)
    {
      string paluu = "";
      MessageBox.Show("business");
      lotto.Drawns = draws;
      lotto.Mode = mode;

      switch (mode)
      {
        case 0:
          paluu = lotto.arvonta(Logics.suomi);
          break;
        case 1:
          paluu = lotto.arvonta(Logics.viking);
          break;
        case 2:
          paluu = lotto.arvonta(Logics.euro);
          break;
        default:
          // If mode is not defined throw exception
          throw new Exception("Error #666. Lottery mode was not defined!");
      }

      return paluu;
    }
  }
}
