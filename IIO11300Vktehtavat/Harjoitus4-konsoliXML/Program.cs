using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Harjoitus4_konsoliXML
{
  class Program
  {
    static void ReadWorkersFromXML(string filu)
    {
      // Tutkitaan löytyykö tiedostoa
      if(System.IO.File.Exists(filu))
      {
        // Luetaan koko XML-tiedosto XmlDocument olioon
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.Load(filu);
        // XPath kyselyllä haetaan halutut elementit
        XmlNodeList xnl = xmldoc.SelectNodes("/tyontekijat/tyontekija");
        XmlNodeList xnl2;
        XmlNode xn; // Edustaa yksittäistä nodea XML dokumentissa
        XmlNode xn2;
        Console.WriteLine(string.Format("Tiedostosta {0} löytyi {1} työntekijää", filu, xnl.Count));
        for(int i = 0; i < xnl.Count; i++)
        {
          xn = xnl.Item(i);
          // Listataan=näytetään sisältöä kokonaisuudessaan
          Console.WriteLine(xn.InnerText);
          // Haetaan noden kaikki nodet (=elementit) ja näytetään ne
          xnl2 = xn.ChildNodes;

          for (int j = 0; j < xnl2.Count; j++)
          {
            xn2 = xnl2.Item(j);
            Console.WriteLine(xn2.InnerText);
          }
        }
      }
    }


    static void Main(string[] args)
    {
      ReadWorkersFromXML("d:\\g8499\\Työntekijät2013.xml");
    }
  }
}
