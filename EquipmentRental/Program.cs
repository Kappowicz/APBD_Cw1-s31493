using EquipmentRental;
using EquipmentRental.Models;
using EquipmentRental.Services;
using EquipmentRental.Services.Rental;

Student student = new Student("jan", "kowalski");
Student student2 = new Student("jan2", "kowalski");
Student student3 = new Student("jan3", "kowalski");

Laptop laptop = new("thinkpad", "intel", 32);
Laptop laptop2 = new("thinkpad", "amd", 4);
Laptop laptop3 = new("thinkpad", "amd", 16);

IUserService userService = new UserService();
userService.AddUser(student);
userService.AddUser(student2);
userService.AddUser(student3);

IEquipmentService equipmentService = new EquipmentService();
equipmentService.AddEquipment(laptop);
equipmentService.AddEquipment(laptop2);
equipmentService.AddEquipment(laptop3);

IRentalService rentalService = new RentalService();
try
{
    rentalService.CreateRental(student, laptop, new DateTime(2020, 01, 01));
    rentalService.EndRental(0);
    rentalService.CreateRental(student2, laptop, new DateTime(2020, 01, 02));
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

userService.PrintExtension();
equipmentService.PrintExtension();
rentalService.PrintExtension();

//Equipment.PrintExtension();

//Equipment.PrintExtension(Equipment.Status.Available);