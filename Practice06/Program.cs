Console.WriteLine("=== Car Rental System ===\n");

Car car = new("Sedan", "Toyota", 50);

try
{
    ProcessRental(car, 3);

    ProcessReturn(car);
}
catch (Exception ex)
{
    Console.WriteLine($"\nError: {ex.Message}");
}

void ProcessRental(Car car, int rentalDays)
{
    Console.WriteLine("Processing Rental...\n");

    var startDate = DateTime.Today;
    var endDate = startDate.AddDays(rentalDays);

    var totalCost = car.Rent(startDate, endDate);

    Console.WriteLine($"Car      : {car.Model} - {car.Name}");
    Console.WriteLine($"Period   : {startDate:MM/dd/yyyy} - {endDate:MM/dd/yyyy}");
    Console.WriteLine($"Total    : ${totalCost:F2}");
    Console.WriteLine($"Status   : {(car.IsAvailable ? "Available" : "Rented")}");
    Console.WriteLine(new string('-', 40) + "\n");
}

void ProcessReturn(Car car)
{
    Console.WriteLine("Processing Returns:\n");

    car.Return();

    Console.WriteLine($"Returned : {car.Model} - {car.Name}");
    Console.WriteLine($"Status   : {(car.IsAvailable ? "Available" : "Rented")}");
    Console.WriteLine(new string('-', 40) + "\n");
}