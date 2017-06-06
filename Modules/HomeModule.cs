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
        List<Species> AllSpecies = Species.GetAll();
        return View["index.cshtml", AllSpecies];
      };
    }
  }
}
