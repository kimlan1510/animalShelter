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



    public void Dispose()
    {
      Species.DeleteAll();
    }
  }
}
