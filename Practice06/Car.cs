namespace Practice06;

public class Car
{
    public string Model { get; }
    public string Name { get; }
    public double DailyRentalRate { get; }
    public bool IsAvailable { get; private set; }
    public DateTime? RentalStart { get; private set; }
    public DateTime? RentalEnd { get; private set; }

    public Car(string model, string name, double dailyRentalRate)
    {
        Validate(model, nameof(model), "Model cannot be null or empty.");

        Validate(name, nameof(name), "Name cannot be null or empty.");

        ValidatePositive(dailyRentalRate, nameof(dailyRentalRate), "Daily rental rate must be greater than zero.");

        Model = model;
        Name = name;
        DailyRentalRate = dailyRentalRate;
        IsAvailable = true;
    }

    public double Rent(DateTime startDate, DateTime endDate)
    {
        EnsureAvailable();

        ValidateDates(startDate, endDate);

        RentalStart = startDate;
        RentalEnd = endDate;
        IsAvailable = false;

        var totalDays = (int)Math.Ceiling((endDate - startDate).TotalDays);
        return totalDays * DailyRentalRate;
    }

    public void Return()
    {
        EnsureRented();

        IsAvailable = true;
        RentalStart = null;
        RentalEnd = null;
    }

    private void Validate(string value, string paramName, string message)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException(message, paramName);
    }
    private static void ValidatePositive(double value, string paramName, string message)
    {
        if (value <= 0)
            throw new ArgumentException(message, paramName);
    }

    private void ValidateDates(DateTime startDate, DateTime endDate)
    {
        if (startDate >= endDate)
            throw new ArgumentException("Start date must be before end date.");

        if (startDate.Date < DateTime.Now.Date)
            throw new ArgumentException("Start date cannot be in the past.");
    }
    private void EnsureAvailable()
    {
        if (!IsAvailable)
            throw new InvalidOperationException($"{Model} - {Name} is not available for rent.");
    }

    private void EnsureRented()
    {
        if (IsAvailable)
            throw new InvalidOperationException($"{Model} - {Name} is not currently rented.");
    }
}