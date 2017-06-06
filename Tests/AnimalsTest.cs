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





    public void Dispose()
    {
      Animal.DeleteAll();
    }
  }
}
