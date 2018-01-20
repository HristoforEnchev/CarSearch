namespace CarSearch.Web.Controllers
{
    using CarSearch.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models.Cars;
    using System.Collections.Generic;
    using System.Linq;

    public class CarsController : Controller
    {
        public readonly ICarService cars;

        public CarsController(ICarService cars)
        {
            this.cars = cars;
        }


        public IActionResult SearchCar()
        {
            var importersListItem = GetImportersListItem();

            return View(new SearchCarFormModel
            {
                Importers = importersListItem
            });
        }

        [HttpPost]
        public IActionResult SearchCar(SearchCarFormModel model)
        {
            var importer = model.Importer;
            var searchString = model.SearchString;

            if (importer != null && searchString == null)
            {
                return View("All", this.cars.SearchByImporter(importer));
            }
            else if (importer == null && searchString != null)
            {
                if (!ModelState.IsValid)
                {
                    var importersListItem = GetImportersListItem();

                    return View(new SearchCarFormModel
                    {
                        Importers = importersListItem
                    });
                }

                return View("All", this.cars.SearchByString(searchString));
            }
            else if (importer == null && searchString == null)
            {
                ModelState.Remove("SearchString");
                ModelState.AddModelError("SearchString", Message());

                if (!ModelState.IsValid)
                {
                    var importersListItem = GetImportersListItem();

                    return View(new SearchCarFormModel
                    {
                        Importers = importersListItem
                    });
                }
            }

            if (!ModelState.IsValid)
            {
                var importersListItem = GetImportersListItem();

                return View(new SearchCarFormModel
                {
                    Importers = importersListItem
                });
            }

            var filteredCars = this.cars.SearchByImporterAndString(importer, searchString);

            return View("All", filteredCars);
        }

        public IActionResult AddCar()
        {
            return View(new AddCarFormModel());
        }

        [HttpPost]
        public IActionResult AddCar(AddCarFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //html sanitizer for model.Description

            this.cars.Add(model.Make, model.Year, model.Power, model.Importer, model.Description);

            TempData["SuccessMessage"] = "Car added successfully!";

            return RedirectToAction(nameof(All));
        }

        public IActionResult All()
        {
            return View(this.cars.All());
        }


        private List<SelectListItem> GetImportersListItem()
        {
            var importers = this.cars.GetImporters().ToList();

            var importersListItems = new List<SelectListItem>();

            importersListItems.Add(new SelectListItem { Text = "Chose Importer", Value = "" });

            foreach (var importer in importers)
            {
                importersListItems.Add(new SelectListItem { Text = importer, Value = importer });
            }

            return importersListItems;
        }

        private string Message()
        {
            return "Hristofor, priqtno mi e! Noviqt vi kolega :) else Please fill in at least one search field.";
        }

    }
}
