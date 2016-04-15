using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Windows;

namespace Tehtava6
{
  class BLViinit
  {
    public static List<Viini> HaeViinit(string path)
    {
      try
      {
        List<Viini> viinit = new List<Viini>();

        XElement e = XElement.Load(path);

        foreach (var element in e.Elements("wine"))
        {
          
          var nimi = element.Element("nimi");
          var maa = element.Element("maa");
          var arvio = element.Element("arvio");
 
          Viini viini = new Viini(nimi.Value, maa.Value, Int32.Parse(arvio.Value));
          viinit.Add(viini);
        }
        return viinit;

      }
      catch (Exception)
      {
        throw;
      }
    }
     
  }
}
