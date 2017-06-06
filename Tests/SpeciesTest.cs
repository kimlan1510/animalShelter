using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace animalShelter
{
  public class SpeciesTest : IDisposable
  {
    public SpeciesTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb; Initial Catalog=animal_shelter_test; Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_SpeciesEmptyAtFirst()
    {
      //Arrange, Act
      int result = Species.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Save_SavesSpeciesToDatabase()
    {
      //Arrange
      Species testSpecies = new Species("cat");
      testSpecies.Save();

      //Act
      List<Species> result = Species.GetAll();
      List<Species> testList = new List<Species>{testSpecies};

      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Save_AssignsIdToSpeciesObject()
    {
      //Arrange
      Species testSpecies = new Species("cat");
      testSpecies.Save();

      //Act
      Species savedSpecies = Species.GetAll()[0];

      int result = savedSpecies.GetId();
      int testId = testSpecies.GetId();

      //Assert
      Assert.Equal(testId, result);
    }

    [Fact]
    public void Test_Find_FindsSpeciesInDatabase()
    {
      //Arrange
      Species testSpecies = new Species("cat");
      testSpecies.Save();

      //Act
      Species foundSpecies = Species.Find(testSpecies.GetId());

      //Assert
      Assert.Equal(testSpecies, foundSpecies);
    }

    [Fact]
    public void Test_GetAnimals_RetrievesAllAnimalsWithSpecies()
    {
      Species testSpecies = new Species("cat");
      testSpecies.Save();

      Animal firstAnimal = new Animal("Olive", "female", "domestic shorthair", "10-14-1993",testSpecies.GetId(), 1);
      firstAnimal.Save();
      Animal secondAnimal = new Animal("lulu", "male", "domestic shorthair", "10-14-1994", testSpecies.GetId(), 2);
      secondAnimal.Save();


      List<Animal> testAnimalList = new List<Animal> {firstAnimal, secondAnimal};
      List<Animal> resultAnimalList = testSpecies.GetAnimals();

      Assert.Equal(testAnimalList, resultAnimalList);
    }



    public void Dispose()
    {
      Animal.DeleteAll();
      Species.DeleteAll();
    }
  }
}
