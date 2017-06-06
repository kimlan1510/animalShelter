using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace animalShelter
{
  public class Species
  {
    private int _id;
    private string _name;

    public Species(string name, int id = 0)
    {
      _id = id;
      _name = name;
    }

    public int GetId()
    {
     return _id;
    }
    public string GetName()
    {
     return _name;
    }
    public void SetName(string newName)
    {
     _name = newName;
    }
    public override bool Equals(System.Object otherSpecies)
    {
     if(!(otherSpecies is Species))
     {
       return false;
     }
     else
     {
       Species newSpecies = (Species) otherSpecies;
       bool idEquality = (this.GetId() == newSpecies.GetId());
       bool nameEquality = (this.GetName() == newSpecies.GetName());
       return (idEquality && nameEquality);
     }
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM species;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }

    public static List<Species> GetAll()
    {
      List<Species> AllSpecies = new List<Species>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM species;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int speciesId = rdr.GetInt32(0);
        string speciesName = rdr.GetString(1);
        Species newSpecies = new Species(speciesName, speciesId);
        AllSpecies.Add(newSpecies);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return AllSpecies;
    }




  }
}
