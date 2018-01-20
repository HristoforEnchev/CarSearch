namespace CarSearch.Services
{
    using CarSearch.Data.Models;
    using System.Collections.Generic;

    public interface ICarService
    {
        IEnumerable<Car> All();

        IEnumerable<string> GetImporters();

        IEnumerable<Car> SearchByImporterAndString(string importer, string searchString);

        IEnumerable<Car> SearchByImporter(string importer);

        IEnumerable<Car> SearchByString(string searchString);

        void Add(string make, int year, int power, string importer, string description);
    }
}
