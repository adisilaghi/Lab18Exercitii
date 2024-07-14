using Lab18Exercitii.Models;
using Lab18Exercitii;

using (var context = new CarDbContext())
{

    context.Database.EnsureCreated();
    SeedData(context);

   /* var vehicleService = new VehicleService(context);
    vehicleService.DeleteVehicle(5);*/

   
    var manufacturer = context.Manufacturer.ToList();
    if (manufacturer.Count == 0)
    {
        Console.WriteLine("No manufacturer found.");
        return;
    }
    string newVehicleName = "Sandero";
    var existingVehicle = context.Vehicles.FirstOrDefault(v => v.Name == newVehicleName);
    if (existingVehicle == null)
    {
        var newVehicle = new Vehicle
        {
            Name = newVehicleName,
            ManufacturerId = manufacturer[0].Id,
            Manufacturer = manufacturer[0],
            Key = new List<Key> { new Key { AccessCode = Guid.NewGuid() } },
            TechnicalBook = new TechnicalBook
            {
                CC = 2000,
                ManufacturingYear = 2024,
                VINNumber = "ABCDEFG123456"
            }
        };

        context.Vehicles.Add(newVehicle);
        context.SaveChanges();
        Console.WriteLine("New vehicle added successfully.");
    }
    else
    {
        Console.WriteLine($"A vehicle with the name '{newVehicleName}' already exists.");
    }
}

Console.WriteLine("Press any key to exit...");
Console.ReadKey();


static void SeedData(CarDbContext context)
{
    if (context.Manufacturer.Any() || context.Vehicles.Any())
    {
        return;
    }

    var manufacturer = new List<Manufacturer>
        {
            new() { Name = "Ford", Address = "123 Main Street" },
            new() { Name = "Toyota", Address = "456 Oak Avenue" },
            new() { Name = "Dacia", Address = "405 Mioveni" }
        };

    context.Manufacturer.AddRange(manufacturer);
    context.SaveChanges();

    var vehicles = new List<Vehicle>
        {
            new Vehicle
            {
                Name = "Fiesta",
                ManufacturerId = manufacturer[0].Id,
                Key = new List<Key> { new Key { AccessCode = Guid.NewGuid() } },
                TechnicalBook = new TechnicalBook
                {
                    CC = 1500,
                    ManufacturingYear = 2023,
                    VINNumber = "123456789"
                }
            },
            new Vehicle
            {
                Name = "Corolla",
                ManufacturerId = manufacturer[1].Id,
                Key = new List<Key> { new Key { AccessCode = Guid.NewGuid() } },
                TechnicalBook = new TechnicalBook
                {
                    CC = 1800,
                    ManufacturingYear = 2022,
                    VINNumber = "987654321"
                }
            }
        };

    context.Vehicles.AddRange(vehicles);
    context.SaveChanges();
}
