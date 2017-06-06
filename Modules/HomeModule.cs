using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace animalShelter
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/animals"] = _ => {
        List<Animal> AllAnimals = Animal.GetAll();
        return View["animals.cshtml", AllAnimals];
      };
      Get["/species"] = _ => {
        List<Species> AllSpecies = Species.GetAll();
        return View["species.cshtml", AllSpecies];
      };
      Get["/species/new"] = _ => {
        return View["species_form.cshtml"];
      };
      Post["/species/new"] = _ => {
        Species newSpecies = new Species(Request.Form["species-name"]);
        newSpecies.Save();
        return View["success.cshtml"];
      };
      Get["/animals/new"] = _ => {
        List<Species> AllSpecies = Species.GetAll();
        return View["animals_form.cshtml", AllSpecies];
      };
      Post["/animals/new"] = _ => {
        Animal newAnimal = new Animal(Request.Form["animal-name"], Request.Form["animal-gender"], Request.Form["animal-breed"],Request.Form["animal-date"], Request.Form["species-id"]);
        newAnimal.Save();
        return View["success.cshtml"];
      };
    }
  }
}
