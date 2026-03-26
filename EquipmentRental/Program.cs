using EquipmentRental;

Student student = new Student("jan", "kowalski");
Student student2 = new Student("jan2", "kowalski");
Student student3 = new Student("jan3", "kowalski");

Laptop laptop = new("thinkpad", "intel", 32);
Laptop laptop2 = new("thinkpad", "amd", 4);
Laptop laptop3 = new("thinkpad", "amd", 16);

Rental rental = new(student, laptop, new DateTime(2020, 01, 01));
rental.Return(new DateTime(2020, 02, 01));

User.PrintExtension();

//Equipment.PrintExtension();

//Equipment.PrintExtension(Equipment.Status.Available);