using DefaultNamespace;

Laptop laptop = new("thinkpad", Equipment.Status.Available, "intel", 32);
Laptop laptop2 = new("thinkpad", Equipment.Status.Rented, "amd", 4);
Laptop laptop3 = new("thinkpad", Equipment.Status.Available, "amd", 16);

Equipment.PrintExtension();


