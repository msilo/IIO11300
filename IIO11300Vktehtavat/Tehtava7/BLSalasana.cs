using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava7
{
  public class BLSalasana
  {
    public static void CheckPassWord(ref Password password, string word)
    {
      password.Count = word.Count();
      password.Capitals = word.Count(char.IsUpper);
      password.Smalls = word.Count(char.IsLower);
      password.Numerals = word.Count(char.IsDigit);
      password.Specials = word.Count(char.IsSymbol);

      if((password.Count < 8))
      {
        password.Criteria = "Bad";
      }
      else if (password.Count < 12)
      {
        password.Criteria = "Fair";
      }
      else if (password.Count < 16)
      {
        password.Criteria = "Moderate";
      }
      else if ((password.Count >= 16) && (password.Capitals > 0 && password.Smalls > 0 && password.Numerals > 0 && password.Specials > 0))
      {
        password.Criteria = "Good";
      }

    }
  }
}
