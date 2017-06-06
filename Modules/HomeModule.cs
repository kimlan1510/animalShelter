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
        return View["allSpecies.cshtml", AllSpecies];
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
      Post["/animals/delete"] = _ => {
        Animal.DeleteAll();
        return View["cleared.cshtml"];
      };
      Get["/animals/{id}"] = parameters => {
        Animal selectedAnimal = Animal.Find(parameters.id);
        return View["animal.cshtml", selectedAnimal];
      };
      Get["/species/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var SelectedSpecies = Species.Find(parameters.id);
        var SpeciesAnimals = SelectedSpecies.GetAnimals();
        model.Add("species", SelectedSpecies);
        model.Add("animals", SpeciesAnimals);
        return View["species.cshtml", model];
      };
      Get["/animals/bybreed"] = _ => {
        List<Animal> AnimalsByBreed = Animal.ByBreed();
        return View["animals_by_breed.cshtml", AnimalsByBreed];
      };
    }
  }
}
