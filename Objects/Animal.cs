using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace animalShelter
{
  public class Animal
  {
    private int _id;
    private string _name;
    private string _gender;
    private string _breed;
    private string _date;
    private int _speciesId;

    public Animal(string name, string gender, string breed, string date, int speciesId, int Id = 0)
    {
      _id = Id;
      _name = name;
      _gender = gender;
      _breed = breed;
      _date = date;
      _speciesId = speciesId;
    }

    public override bool Equals(System.Object otherAnimal)
    {
      if(!(otherAnimal is Animal))
      {
        return false;
      }
      else
      {
        Animal newAnimal = (Animal) otherAnimal;
        bool idEquality = (this.GetId() == newAnimal.GetId());
        bool animalNameEquality = (this.GetName() == newAnimal.GetName());
        bool animalGenderEquality = (this.GetGender() == newAnimal.GetGender());
        bool animalBreedEquality = (this.GetBreed() == newAnimal.GetBreed());
        bool animalDateEquality = (this.GetDate() == newAnimal.GetDate());
        bool animalSpeciesIdEquality = (this.GetSpeciesId() == newAnimal.GetSpeciesId());
        return (idEquality && animalNameEquality && animalGenderEquality && animalBreedEquality && animalDateEquality && animalSpeciesIdEquality);
      }
    }

    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public string GetGender()
    {
      return _gender;
    }
    public string GetBreed()
    {
      return _breed;
    }
    public string GetDate()
    {
      return _date;
    }
    public int GetSpeciesId()
    {
      return _speciesId;
    }
    public void SetSpeciesId(int speciesId)
    {
      _speciesId = speciesId;
    }

    public static List<Animal> GetAll()
    {
      List<Animal> AllAnimals = new List<Animal>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM animals;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int animalId = rdr.GetInt32(0);
        string animalName = rdr.GetString(1);
        string animalGender = rdr.GetString(2);
        string animalBreed = rdr.GetString(3);
        string animalDate = rdr.GetString(4);
        int animalSpeciesId = rdr.GetInt32(5);
        Animal newAnimal = new Animal(animalName, animalGender, animalBreed, animalDate, animalSpeciesId, animalId);
        AllAnimals.Add(newAnimal);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return AllAnimals;
    }
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM animals;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO animals (name, gender, breed, admittance, speciesId) OUTPUT INSERTED.id VALUES (@AnimalName, @AnimalGender, @AnimalBreed, @AnimalDate, @AnimalSpeciesId);", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@AnimalName";
      nameParameter.Value = this.GetName();

      SqlParameter genderParameter = new SqlParameter();
      genderParameter.ParameterName = "@AnimalGender";
      genderParameter.Value = this.GetGender();

      SqlParameter breedParameter = new SqlParameter();
      breedParameter.ParameterName = "@AnimalBreed";
      breedParameter.Value = this.GetBreed();

      SqlParameter dateParameter = new SqlParameter();
      dateParameter.ParameterName = "@AnimalDate";
      dateParameter.Value = this.GetDate();

      SqlParameter speciesIdParameter = new SqlParameter();
      speciesIdParameter.ParameterName = "@AnimalSpeciesId";
      speciesIdParameter.Value = this.GetSpeciesId();

      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(genderParameter);
      cmd.Parameters.Add(breedParameter);
      cmd.Parameters.Add(dateParameter);
      cmd.Parameters.Add(speciesIdParameter);
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

    public static Animal Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM animals WHERE id = @animalId;", conn);
      SqlParameter animalIdParameter = new SqlParameter();
      animalIdParameter.ParameterName = "@AnimalId";
      animalIdParameter.Value = id.ToString();
      cmd.Parameters.Add(animalIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundAnimalId = 0;
      string foundAnimalName = null;
      string foundAnimalGender = null;
      string foundAnimalBreed = null;
      string foundAnimalDate = null;
      int foundAnimalSpeciesId = 0;
      while(rdr.Read())
      {
        foundAnimalId = rdr.GetInt32(0);
        foundAnimalName = rdr.GetString(1);
        foundAnimalGender = rdr.GetString(2);
        foundAnimalBreed = rdr.GetString(3);
        foundAnimalDate = rdr.GetString(4);
        foundAnimalSpeciesId = rdr.GetInt32(5);
      }
      Animal foundAnimal = new Animal(foundAnimalName, foundAnimalGender, foundAnimalBreed, foundAnimalDate, foundAnimalSpeciesId, foundAnimalId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return foundAnimal;
    }

    public static List<Animal> ByBreed()
    {
      List<Animal> AllAnimals = new List<Animal>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM animals ORDER BY breed;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int animalId = rdr.GetInt32(0);
        string animalName = rdr.GetString(1);
        string animalGender = rdr.GetString(2);
        string animalBreed = rdr.GetString(3);
        string animalDate = rdr.GetString(4);
        int animalSpeciesId = rdr.GetInt32(5);
        Animal newAnimal = new Animal(animalName, animalGender, animalBreed, animalDate, animalSpeciesId, animalId);
        AllAnimals.Add(newAnimal);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return AllAnimals;
    }


  }
}
