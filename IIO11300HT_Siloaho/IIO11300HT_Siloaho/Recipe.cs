using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIO11300HT_Siloaho
{
  public class Recipe
  {
    #region PROPERTIES

    private int id;

    public int Id
    {
      get { return id; }
      set { id = value; }
    }

    private string name;

    public string Name
    {
      get { return name; }
      set { name = value; }
    }

    private string time;

    public string Time
    {
      get { return time; }
      set { time = value; }
    }

    private string instructions;

    public string Instructions
    {
      get { return instructions; }
      set { instructions = value; }
    }

    private string writer;

    public string Writer
    {
      get { return writer; }
      set { writer = value; }
    }


    #endregion

    #region CONSTRUCTORS

    public Recipe()
    {

    }

    public Recipe(int id, string name, string time, string instructions, string writer)
    {
      this.id = id;
      this.name = name;
      this.time = time;
      this.instructions = instructions;
      this.writer = writer;
    }

    public Recipe(string name, string time, string instructions, string writer)
    {
      this.name = name;
      this.time = time;
      this.instructions = instructions;
      this.writer = writer;
    }

    #endregion

    #region METHODS

    #endregion
  }
}
