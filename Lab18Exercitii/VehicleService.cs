using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab18Exercitii.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab18Exercitii
{
    public class VehicleService
    {
        private readonly CarDbContext _context;

        public VehicleService(CarDbContext context)
        {
            _context = context;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
        }

        public void AddProducer(Manufacturer producer)
        {
            _context.Manufacturer.Add(producer);
            _context.SaveChanges();
        }

        public void AddKeyToVehicle(int vehicleId, Key key)
        {
            var vehicle = _context.Vehicles.Include(v => v.Key).FirstOrDefault(v => v.Id == vehicleId);
            if (vehicle != null)
            {
                vehicle.Key.Add(key);
                _context.SaveChanges();
            }
        }

        public void ReplaceTechnicalBook(int vehicleId, TechnicalBook newTechnicalBook)
        {
            var vehicle = _context.Vehicles.Include(v => v.TechnicalBook).FirstOrDefault(v => v.Id == vehicleId);
            if (vehicle != null)
            {
                vehicle.TechnicalBook = newTechnicalBook;
                _context.SaveChanges();
            }
        }

        public void DeleteVehicle(int vehicleId)
        {
            var vehicle = _context.Vehicles.Find(vehicleId);
            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
                _context.SaveChanges();
            }
        }

        public void DeleteManufacturer(int producerId)
        {
            var producer = _context.Manufacturer.Find(producerId);
            if (producer != null)
            {
                _context.Manufacturer.Remove(producer);
                _context.SaveChanges();
            }
        }

        public void DeleteKey(int keyId)
        {
            var key = _context.Keys.Find(keyId);
            if (key != null)
            {
                _context.Keys.Remove(key);
                _context.SaveChanges();
            }
        }
    }
}
