using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace animalShelter
{
  public class AnimalsTest : IDisposable
  {
    public AnimalsTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb; Initial Catalog=animal_shelter_test; Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      //Arrange, Act
      int result = Animal.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }
    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      //Arrange
      Animal testAnimal = new Animal("Olive", "female", "domestic shorthair", "10-14-1993", 1);

      //Act
      testAnimal.Save();
      List<Animal> result = Animal.GetAll();
      List<Animal> testList = new List<Animal>{testAnimal};

      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Save_AssignsIdToObject()
    {
      //Arrange
      Animal testAnimal = new Animal("Olive", "female", "domestic shorthair", "10-14-1993", 1);

      //Act
      testAnimal.Save();
      Animal savedAnimal = Animal.GetAll()[0];
      Console.WriteLine(savedAnimal.GetId());

      int result = savedAnimal.GetId();
      int testId = testAnimal.GetId();

      //Assert
      Assert.Equal(testId, result);
    }



    public void Dispose()
    {
      Animal.DeleteAll();
    }
  }
}
