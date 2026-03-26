namespace EquipmentRental;

public class Rental
{
    private User _renter;
    private Equipment _rentedEquipment;
    private DateTime _startDate;
    private int _allowedRentalDays;
    private DateTime _actualReturnDate;

    public Rental(User renter, Equipment rentedEquipment, DateTime startDate, int allowedRentalDays = 10)
    {
        _renter = renter;
        _rentedEquipment = rentedEquipment;
        _startDate = startDate;
        _allowedRentalDays = allowedRentalDays;
    }

    public void Return(DateTime returnDate)
    {
        _actualReturnDate = returnDate;

        int amountOfDaysAfterReturn = _actualReturnDate.Subtract(_startDate).Days;
        if (amountOfDaysAfterReturn > _allowedRentalDays)
        {
            Console.WriteLine("Penalty applied: " + amountOfDaysAfterReturn * _renter.GetDailyPenaltyRate());
        }
    }
}