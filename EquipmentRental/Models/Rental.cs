namespace EquipmentRental.Models;

public class Rental
{
    public User Renter;
    public int Id { get; private set; }
    private static int _currentAmountOfRentals = 0;
    public Equipment RentedEquipment { get; }
    public DateTime StartDate { get; }
    public int AllowedRentalDays { get; set; }
    public DateTime? ActualReturnDate = null;

    public Rental(User renter, Equipment rentedEquipment, DateTime startDate, int allowedRentalDays)
    {
        Renter = renter;
        RentedEquipment = rentedEquipment;
        StartDate = startDate;
        AllowedRentalDays = allowedRentalDays;
        Id = _currentAmountOfRentals;
        _currentAmountOfRentals++;
    }

    public void Return(DateTime returnDate)
    {
        ActualReturnDate = returnDate;

        int amountOfDaysAfterReturn = (returnDate - StartDate).Days;
        if (amountOfDaysAfterReturn > AllowedRentalDays)
        {
            Console.WriteLine("Penalty applied: " + amountOfDaysAfterReturn * Renter.GetDailyPenaltyRate() + " PLN");
        }
    }
    
    public bool Overlaps(DateTime from)
    {
        if (ActualReturnDate != null)
        {
            return !(from > ActualReturnDate);
        }

        return true;
    }

    public override string ToString()
    {
        string outputReturnDate = ActualReturnDate != null ? ActualReturnDate.ToString() : "still rented";
        return $"Renter: {Renter.GetUniqueName()} rented: {RentedEquipment.GetUniqueName()} from: {StartDate} to: {outputReturnDate}";
    }
}