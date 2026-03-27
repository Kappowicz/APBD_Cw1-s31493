using EquipmentRental.Models;
using EquipmentRental.Services;
using EquipmentRental.Services.Rental;

Student student = new Student("jan", "kowalski");
Student student2 = new Student("piotr", "nowak");
Student student3 = new Student("kamil", "kowalczyk");

IUserService userService = new UserService();
userService.AddUser(student);
userService.AddUser(student2);
userService.AddUser(student3);

Laptop laptop = new("thinkpad", "intel", 32);
Laptop laptop2 = new("xps", "amd", 4);
Laptop laptop3 = new("macbook", "apple", 16);

IEquipmentService equipmentService = new EquipmentService();
equipmentService.AddEquipment(laptop);
equipmentService.AddEquipment(laptop2);
equipmentService.AddEquipment(laptop3);

IRentalService rentalService = new RentalService();
rentalService.CreateRental(student, laptop, new DateTime(2020, 01, 01));

//there penalty will be applied
rentalService.EndRentalWithRepair(0);

//renting not available equipment error
try
{
    rentalService.CreateRental(student2, laptop, new DateTime(2127, 01, 02));
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

//renting already rented equipment error
try
{
    rentalService.CreateRental(student, laptop2, new DateTime(2020, 01, 01));
    rentalService.CreateRental(student2, laptop2, new DateTime(2127, 01, 02));
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

//print all data
userService.PrintExtension();
equipmentService.PrintExtension();
rentalService.PrintExtension();