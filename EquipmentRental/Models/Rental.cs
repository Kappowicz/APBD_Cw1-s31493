namespace EquipmentRental.Models;

public class Rental
{
    public User _renter { get; }
    public int Id { get; private set; }
    private static int _currentAmountOfRentals = 0;
    private Equipment _rentedEquipment;
    private DateTime _startDate;
    private int _allowedRentalDays;
    private DateTime _actualReturnDate;

    public Rental(User renter, Equipment rentedEquipment, DateTime startDate, int allowedRentalDays = 10)
    {
        _renter = renter;
        _rentedEquipment = rentedEquipment;
        renter.Rent(rentedEquipment);
        _rentedEquipment.SetRenter(renter);
        _startDate = startDate;
        _allowedRentalDays = allowedRentalDays;
        Id = _currentAmountOfRentals;
        _currentAmountOfRentals++;
    }

    public void Return(DateTime returnDate)
    {
        _actualReturnDate = returnDate;

        int amountOfDaysAfterReturn = (_actualReturnDate - _startDate).Days;
        if (amountOfDaysAfterReturn > _allowedRentalDays)
        {
            Console.WriteLine("Penalty applied: " + amountOfDaysAfterReturn * _renter.GetDailyPenaltyRate());
        }
        
        _renter.Return(_rentedEquipment);
    }
    
    public bool Overlaps(DateTime from, DateTime to)
    {
        return !(_startDate > to || from > _actualReturnDate);
    }
}