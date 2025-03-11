// See https://aka.ms/new-console-template for more information
using CarService;
using static System.Reflection.Metadata.BlobBuilder;
using System.Reflection.PortableExecutable;
List<Clients> clients = new List<Clients>();
List<Vehicles>vehicles = new List<Vehicles>();
List<Repairs> repairs=new List<Repairs>();
while (true)
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1.Add client");
    Console.WriteLine("2.Add vehicle");
    Console.WriteLine("3.Add repair");
    Console.WriteLine("4.View all clients");
    Console.WriteLine("5.View all vehicles and their owner");
    Console.WriteLine("6.View all repairs");
    Console.WriteLine("7.View active clients");
    Console.WriteLine("8.View current repairs");
    Console.WriteLine("9.View vehicles in service");
    Console.WriteLine("10.Most common repairs");
    Console.WriteLine("11.Most repaired car brand");
    Console.WriteLine("12.Average repair cost");
    Console.WriteLine("13.Exit");
    int num = int.Parse(Console.ReadLine());
    if (num == 13)
    {
        break;
    }
    switch (num)
    {
        case 1:
            AddClient();
            break;
        case 2:
            AddVehicles();
            break;
        case 3:
            AddRepairs();
            break;
        case 4:
            ViewAllClients();
            break;
        case 5:
            ViewAllVehicles();
            break;
        case 6:
            ViewAllRepairs();
            break;
        case 7:
            ViewActiveClients();
            break;
        case 8:
            ViewCurrentRepairs();
            break;
        case 9:
            ViewVehiclesInService();
            break;
        case 10:
            MostCommonRepairs();
            break;
        case 11:
            MostRepairedCarBrand();
            break;
        case 12:
            AverageRepairCost();
            break;
        case 13:
            Console.WriteLine();
            break;
        default:
            Console.WriteLine("This option does nit exist!");
            break;
    }
}
void AddClient()
{
    Console.WriteLine("Enter client first name: ");
    string firstName = Console.ReadLine();

    Console.WriteLine("Enter client last name: ");
    string lastName = Console.ReadLine();

    Console.WriteLine("Enter client phone: ");
    string phoneNumber = Console.ReadLine();

    Console.WriteLine("Enter client email: ");
    string email = Console.ReadLine();

    Clients client = new Clients(firstName, lastName, phoneNumber, email);
    clients.Add(client);    
}
void AddVehicles()
{
    Console.WriteLine("Enter vehicle brand: ");
    string brand = Console.ReadLine();

    Console.WriteLine("Enter vehicle model: ");
    string model = Console.ReadLine();

    Console.WriteLine("Enter vehicle year of manifacture: ");
    int yearOfManifacture = int.Parse(Console.ReadLine());

    Console.WriteLine("Enter vehicle license plate: ");
    string licensePlate = Console.ReadLine();

    Console.WriteLine("Enter the name of the client who owns the car: ");
    string clientName = Console.ReadLine();
    Clients client=clients.FirstOrDefault(c=>c.FirstName==clientName);

    Vehicles vehicle = new Vehicles(brand, model, yearOfManifacture, licensePlate, client);
    vehicles.Add(vehicle);
}
void AddRepairs()
{
    Console.WriteLine("Enter the date it comes in for repair: ");
    DateTime dateIn = DateTime.Parse(Console.ReadLine());

    Console.WriteLine("Enter the date the car is ready: ");
    DateTime dateOut = DateTime.Parse(Console.ReadLine());

    Console.WriteLine("Enter the total cost of repair: ");
    double totalCost = double.Parse(Console.ReadLine());

    Console.WriteLine("Enter repair type: ");
    string repairType = Console.ReadLine();

    Console.WriteLine("Enter license plate of the vehicle: ");
    string licensePlate= Console.ReadLine();
    Vehicles vehicle = vehicles.FirstOrDefault(l => l.LicensePlate == licensePlate);

    Repairs repair = new Repairs(dateIn, dateOut, totalCost, repairType, vehicle);
    repairs.Add(repair);
}
void ViewAllClients()
{
    foreach(var client in clients)
    {
        Console.WriteLine($"{client.FirstName} {client.LastName}");
    }
}
void ViewAllVehicles()
{
    foreach(var vehicle in vehicles)
    {
        Console.WriteLine($"{vehicle.Brand} - {vehicle.Model} ({vehicle.LicensePlate}), {vehicle.Client.FirstName} {vehicle.Client.LastName}");
    }

}
void ViewAllRepairs()
{
    foreach(var repair in repairs)
    {
        Console.WriteLine($"{repair.RepairType} - {repair.Vehicle.Brand} {repair.Vehicle.Model} ({repair.Vehicle.LicensePlate})");
    }
}
void ViewActiveClients()
{
    foreach (var client in clients)
    {
        if (repairs.Any(r => r.Vehicle.Client == client && r.DateOut > DateTime.Now))
        {
            Console.WriteLine($"{client.FirstName} {client.LastName}");
        }
    }
}
void ViewCurrentRepairs()
{
    foreach (var repair in repairs)
    {
        if (repair.DateOut > DateTime.Now)
        {
            Console.WriteLine($"{repair.RepairType} for {repair.Vehicle.Brand} {repair.Vehicle.Model} ({repair.Vehicle.LicensePlate})");
        }
    }
}
void ViewVehiclesInService()
{
    foreach (var repair in repairs)
    {
        if (repair.DateOut > DateTime.Now)
        {
            Console.WriteLine($"{repair.Vehicle.Brand} {repair.Vehicle.Model} ({repair.Vehicle.LicensePlate})");
        }
    }
}
void MostCommonRepairs()
{
    var mostCommon = repairs.GroupBy(r => r.RepairType).FirstOrDefault();
    Console.WriteLine($"Most common repair: {mostCommon.Key}");
}
void MostRepairedCarBrand()
{
    var mostRepaired = repairs.GroupBy(r => r.Vehicle.Brand).FirstOrDefault();
    Console.WriteLine($"Most repaired car brand: {mostRepaired.Key}");
}
void AverageRepairCost()
{
    double averageCost = repairs.Average(r => r.TotalCost);
    Console.WriteLine($"Average repair cost: {averageCost:F2} BGN");
}

