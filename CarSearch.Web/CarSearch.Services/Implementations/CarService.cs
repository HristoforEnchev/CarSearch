namespace CarSearch.Services.Implementations
{
    using CarSearch.Data;
    using CarSearch.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CarService : ICarService
    {
        private readonly CarSearchDbContext db;

        public CarService(CarSearchDbContext db)
        {
            this.db = db;
        }

        public void Add(string make, int year, int power, string importer, string description)
        {
            var car = new Car()
            {
                Make = make,
                Year = year,
                Power = power,
                Importer = importer,
                Description = description
            };

            this.db.Cars.Add(car);
            this.db.SaveChanges();
        }

        public IEnumerable<Car> All() => this.db.Cars.OrderByDescending(c => c.Id).ToList();

        public IEnumerable<string> GetImporters() => this.db.Cars.Select(c => c.Importer).Distinct().ToList();

        public IEnumerable<Car> SearchByImporter(string importer)
        {
            var cars = this.db.Cars.Where(c => c.Importer == importer).OrderBy(c => c.Year).ToList();

            return cars;
        }

        public IEnumerable<Car> SearchByImporterAndString(string importer, string searchString)
        {
            var cars = SearchByImporter(importer);

            var searchStrings = searchString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var str in searchStrings)
            {
                cars = cars
                    .Where(c => c.Description.ToLower()
                    .Contains(str.ToLower()))
                    .OrderBy(c => c.Year)
                    .ToList();
            }

            if (cars.Count() != 0)
            {
                foreach (var car in cars)
                {
                    car.Description = HighLight(car.Description, searchStrings);
                }
            }

            return cars;
        }

        public IEnumerable<Car> SearchByString(string searchString)
        {
            var cars = this.db.Cars.ToList();

            var searchStrings = searchString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var str in searchStrings)
            {
                cars = cars
                    .Where(c => c.Description.ToLower()
                    .Contains(str.ToLower()))
                    .OrderBy(c => c.Year)
                    .ToList();
            }

            if (cars.Count != 0)
            {
                foreach (var car in cars)
                {
                    car.Description = HighLight(car.Description, searchStrings);
                }
            }

            return cars;
        }

        private string HighLight(string description, string[] searchStrings)
        {
            foreach (var str in searchStrings)
            {
                description = description.Replace(str, $"<mark>{str}</mark>");
            }

            return description;
        }
    }
}
