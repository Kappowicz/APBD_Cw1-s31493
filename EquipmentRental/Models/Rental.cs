namespace EquipmentRental.Models;

public class Rental
{
    private User _renter;
    public int Id { get; private set; }
    private static int _currentAmountOfRentals = 0;
    public Equipment RentedEquipment { get; }
    public DateTime StartDate { get; }
    public int AllowedRentalDays { get; set; }
    private DateTime _actualReturnDate = DateTime.UnixEpoch;

    public Rental(User renter, Equipment rentedEquipment, DateTime startDate, int allowedRentalDays = 10)
    {
        //TODO: refactor this
        _renter = renter;
        RentedEquipment = rentedEquipment;
        renter.Rent(rentedEquipment);
        RentedEquipment.SetRenter(renter);
        StartDate = startDate;
        AllowedRentalDays = allowedRentalDays;
        Id = _currentAmountOfRentals;
        _currentAmountOfRentals++;
    }

    public void Return(DateTime returnDate)
    {
        _actualReturnDate = returnDate;

        int amountOfDaysAfterReturn = (_actualReturnDate - StartDate).Days;
        if (amountOfDaysAfterReturn > AllowedRentalDays)
        {
            Console.WriteLine("Penalty applied: " + amountOfDaysAfterReturn * _renter.GetDailyPenaltyRate() + " PLN");
        }
        
        _renter.Return(RentedEquipment);
        RentedEquipment.ReturnWorkingEquipment();
    }
    
    public bool Overlaps(DateTime from)
    {
        if (_actualReturnDate != DateTime.UnixEpoch)
        {
            return !(from > _actualReturnDate);
        }

        return false;
    }

    public override string ToString()
    {
        string outputReturnDate = _actualReturnDate == DateTime.UnixEpoch ? "still rented" : _actualReturnDate.ToShortDateString();
        return $"Renter: {_renter.GetUniqueName()} rented: {RentedEquipment.GetUniqueName()} from: {StartDate} to: {outputReturnDate}";
    }
}