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

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO species (name) OUTPUT INSERTED.id VALUES (@SpeciesName);", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@SpeciesName";
      nameParameter.Value = this.GetName();
      cmd.Parameters.Add(nameParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }

    public static Species Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM species WHERE id = @SpeciesId;", conn);
      SqlParameter speciesIdParameter = new SqlParameter();
      speciesIdParameter.ParameterName = "@SpeciesId";
      speciesIdParameter.Value = id.ToString();
      cmd.Parameters.Add(speciesIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundSpeciesId = 0;
      string foundSpeciesName = null;

      while(rdr.Read())
      {
        foundSpeciesId = rdr.GetInt32(0);
        foundSpeciesName = rdr.GetString(1);
      }
      Species foundSpecies = new Species(foundSpeciesName, foundSpeciesId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return foundSpecies;
    }

    public List<Animal> GetAnimals()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM animals WHERE speciesId = @SpeciesId;", conn);
      SqlParameter speciesIdParameter = new SqlParameter();
      speciesIdParameter.ParameterName = "@SpeciesId";
      speciesIdParameter.Value = this.GetId();
      cmd.Parameters.Add(speciesIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      List<Animal> animals = new List<Animal> {};
      while(rdr.Read())
      {
        int animalId = rdr.GetInt32(0);
        string animalName = rdr.GetString(1);
        string animalGender = rdr.GetString(2);
        string animalBreed = rdr.GetString(3);
        string animalDate = rdr.GetString(4);
        int animalSpeciesId =rdr.GetInt32(5);
        Animal newAnimal = new Animal(animalName, animalGender, animalBreed, animalDate, animalSpeciesId, animalId);
        animals.Add(newAnimal);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return animals;
    }
  }
}
