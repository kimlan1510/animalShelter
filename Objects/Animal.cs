using System;
using System.Collection.Generic;
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
    private int _typeId;

    public Animal(string name, string gender, string breed, string date, int Id = 0 ,int typeId)
    {
      _id = Id;
      _name = name;
      _gender = gender;
      _breed = breed;
      _date = date;
      _typeId = typeId;
    }

    public override bool Equals(System.Object otherAnimal)
    {
      if(!(otherAnimal is Animal))
      {
        return false;
      }
      else
      {
        otherAnimal newAnimal = (Animal) otherAnimal;
        bool idEquality = (this.GetId() == newAnimal.GetId());
        bool animalNameEquality = (this.GetName() == newAnimal.GetName());
        bool animalGenderEquality = (this.GetGender() == newAnimal.GetGender());
        bool animalBreedEquality = (this.GetBreed() == newAnimal.GetBreed());
        bool animalDateEquality = (this.GetDate() == newAnimal.GetDate());
        bool animalTypeIdEquality = (this.GetTypeId() == newAnimal.GetTypeId());
        return (idEquality && animalNameEquality && animalGenderEquality && animalBreedEquality && animalDateEquality && animalTypeIdEquality);
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
    public int GetTypeId()
    {
      return _typeId;
    }


  }
}
