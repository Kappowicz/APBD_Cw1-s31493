namespace EquipmentRental.Models;

public class Rental
{
    public User _renter { get; }
    public int Id { get; private set; }
    private static int _currentAmountOfRentals = 0;
    public Equipment RentedEquipment { get; }
    private DateTime _startDate;
    private int _allowedRentalDays;
    private DateTime _actualReturnDate = DateTime.UnixEpoch;

    public Rental(User renter, Equipment rentedEquipment, DateTime startDate, int allowedRentalDays = 10)
    {
        _renter = renter;
        RentedEquipment = rentedEquipment;
        renter.Rent(rentedEquipment);
        RentedEquipment.SetRenter(renter);
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
            Console.WriteLine("Penalty applied: " + amountOfDaysAfterReturn * _renter.GetDailyPenaltyRate() + " PLN");
        }
        
        _renter.Return(RentedEquipment);
    }
    
    public bool Overlaps(DateTime from, DateTime to)
    {
        if (_actualReturnDate != DateTime.UnixEpoch)
        {
            return !(_startDate > to || from > _actualReturnDate);
        }
        
        return !(_startDate > to);
    }
    
    public bool Overlaps(DateTime from)
    {
        if (_actualReturnDate != DateTime.UnixEpoch)
        {
            return !(from > _actualReturnDate);
        }

        return false;
    }
}