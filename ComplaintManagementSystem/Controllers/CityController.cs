using ComplaintManagementSystem.Context;
using ComplaintManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplaintManagementSystem.Controllers
{
    public class CityController
    {
        private readonly ComplaintSystemContext _context;

        public CityController(ComplaintSystemContext context)
        {
            _context = context;
        }

        // Get all cities
        public List<City> GetAllCities()
        {
            return _context.Cities.Where(c => !c.IsDeleted).OrderBy(c =>c.Name).ToList();
        }

        // Get city by Id
        public City GetCityById(int cityId)
        {
            var city = _context.Cities.Where(c => !c.IsDeleted).FirstOrDefault(c=> c.Id == cityId);

            if (city == null)
            {
                throw new KeyNotFoundException("City not found.");
            }

            return city;
        }

        // Get city by Name
        public City GetCityByName(string cityName)
        {
            var city = _context.Cities.Where(c => !c.IsDeleted).FirstOrDefault(c => c.Name.Equals(cityName, StringComparison.OrdinalIgnoreCase));

            if (city == null)
            {
                throw new KeyNotFoundException("City not found.");
            }

            return city;
        }

        // Add a new city
        public void AddCity(City city)
        {
            _context.Cities.Add(city);
            _context.SaveChanges();
        }
        
        // Update existing city
        public void UpdateCity(int oldCityId, City newCity)
        {
            if (_context.Cities.Where(c => !c.IsDeleted).Any(c => c.Name == newCity.Name && c.Id != oldCityId))
            {
                throw new InvalidOperationException("City name must be unique.");
            }

            var city = _context.Cities.Where(c => !c.IsDeleted).FirstOrDefault(c => c.Id == oldCityId);

            if (city != null)
            {
                city.Name = newCity.Name;
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("City not found.");
            }
        }

        // Remove a city
        public void RemoveCity(int cityId)
        {
            var city = _context.Cities.Where(c => !c.IsDeleted).FirstOrDefault(c => c.Id == cityId);
            if (city != null)
            {
                city.IsDeleted = true;

                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("City not found.");
            }
        }
    
    
    }

}
