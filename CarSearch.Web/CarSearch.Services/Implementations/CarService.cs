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


        public IEnumerable<Car> All() => this.db.Cars.ToList();

        public IEnumerable<string> GetImporters() => this.db.Cars.Select(c => c.Importer).Distinct().ToList();

        public IEnumerable<Car> SearchByImporter(string importer)
        {
            var cars = this.db.Cars.Where(c => c.Importer == importer).ToList();

            return cars;
        }

        public IEnumerable<Car> SearchByImporterAndString(string importer, string searchString)
        {
            var cars = SearchByImporter(importer);

            var strings = searchString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var str in strings)
            {
                cars = cars.Where(c => c.Description.ToLower().Contains(str.ToLower())).ToList();
            }

            if (cars.Count() != 0)
            {
                foreach (var car in cars)
                {
                    car.Description = Replace(car.Description, strings);
                }
            }

            return cars;
        }

        public IEnumerable<Car> SearchByString(string searchString)
        {
            var cars = this.db.Cars.ToList();

            var strings = searchString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var str in strings)
            {
                cars = cars.Where(c => c.Description.ToLower().Contains(str.ToLower())).ToList();
            }

            if (cars.Count != 0)
            {
                foreach (var car in cars)
                {
                    car.Description = Replace(car.Description, strings);
                }
            }

            return cars;
        }

        private string Replace(string description, string[] strings)
        {
            foreach (var str in strings)
            {
                description = description.Replace(str, $"<mark>{str}</mark>");
            }

            return description;
        }
    }
}
