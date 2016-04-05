using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace Tehtava4
{
  class XMLManager
  {
    XElement xe;
    public XMLManager()
    {
      
    }

    public List<string> GetSeurat(string file)
    {
      List<string> seuraNimet = new List<string>();
      try
      {
        xe = XElement.Load(file);

        var nimet = from ele in xe.Elements()
                    select ele.Element("nimi");

        foreach (var item in nimet)
        {
          seuraNimet.Add(item.Value);
        }
        
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }

      return seuraNimet;
    }

    public List<Pelaaja> GetPelaajat(string file)
    {
      List<Pelaaja> pelaajat = new List<Pelaaja>();
      try
      {
        xe = XElement.Load(file);

        var pelaajats = xe.Elements();

        foreach (var item in pelaajats)
        {
          var etunimi = item.Element("etunimi").Value;
          var sukunimi = item.Element("sukunimi").Value;
          var hinta = item.Element("siirtohinta").Value;
          var seura = item.Element("seura").Value;
          //MessageBox.Show(shit+shite+poo+crap);
          pelaajat.Add(new Pelaaja(etunimi, sukunimi, int.Parse(hinta), seura));
          //result += decimal.Parse(item.Value);
        }

      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }

      return pelaajat;
    }
  }
}
