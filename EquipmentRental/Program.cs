using EquipmentRental.Enums;
using EquipmentRental.Models;
using EquipmentRental.Services;

var student = new Student("jan", "kowalski");
var employee = new Employee("piotr", "nowak");

IUserService userService = new UserService();
userService.AddUser(student);
userService.AddUser(employee);

var laptop = new Laptop("thinkpad", "intel", 32);
var projector = new Projector("xaomi", "led", 500);
var camera = new Camera("sony", 10.2, 16);

IEquipmentService equipmentService = new EquipmentService();
equipmentService.AddEquipment(laptop);
equipmentService.AddEquipment(projector);
equipmentService.AddEquipment(camera);

IRentalService rentalService = new RentalService();
rentalService.CreateRental(student, laptop, new DateTime(2020, 01, 01));

Console.WriteLine("there penalty will be applied, because 2026 - 2020 to days is bigger than students possible rent duration");
rentalService.EndRentalWithRepairNeeded(0);
laptop.SetAsInRepair();

rentalService.CreateRental(student, projector, new DateTime(2026, 01, 01), 9999);

Console.WriteLine("renting not available (repairRequired) equipment error");
try
{
    rentalService.CreateRental(employee, laptop, new DateTime(2127, 01, 02));
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Console.WriteLine("renting already rented equipment error");
try
{
    rentalService.CreateRental(student, projector, new DateTime(2020, 01, 01));
    rentalService.CreateRental(employee, projector, new DateTime(2127, 01, 02));
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Console.WriteLine("print userservice");
userService.PrintExtension();
Console.WriteLine("print equipmentservice");
equipmentService.PrintExtension();
Console.WriteLine("print available equipment");
equipmentService.PrintExtension(EquipmentStatus.Available);
Console.WriteLine("print rentalservice");
rentalService.PrintExtension();
Console.WriteLine("print overdue rentals");
rentalService.PrintOverdueRentals();

//TODO: branches
