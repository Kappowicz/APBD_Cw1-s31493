using EquipmentRental.Enums;
using EquipmentRental.Exceptions;
using EquipmentRental.Models;

namespace EquipmentRental.Services;

public class RentalService : IRentalService
{
    private readonly List<Rental> _rentals = [];
    
    public void CreateRental(User renter, Equipment equipment, DateTime start, int allowedRentalDays = 10)
    {
        if (equipment.ItemStatus != EquipmentStatus.Available)
        {
            if (equipment.ItemStatus == EquipmentStatus.Rented)
            {
                throw new EquipmentAlreadyRentedException(equipment.Id);
            }
            throw new EquipmentNotAvailableException(equipment.Id);
        }
        
        bool rentalConflict = _rentals.Any(rental =>
            rental.RentedEquipment == equipment
            && rental.Overlaps(start));

        if (!rentalConflict)
        {
            renter.Rent(equipment);
            equipment.SetRenter(renter);
            _rentals.Add(new Models.Rental(renter, equipment, start, allowedRentalDays));
        }
        else
        {
            throw new RentalConflictException(renter, equipment, start);
        }
    }
    
    public void EndRentalWithoutRepair(int rentalId)
    {
        var rental = _rentals.FirstOrDefault(rental => rental.Id == rentalId) ?? throw new RentalNotFoundException(rentalId);
        
        rental.Return(DateTime.Now);
        rental.RentedEquipment.ReturnWorkingEquipment();
        rental.Renter.Return(rental.RentedEquipment);
    }
    
    public void EndRentalWithRepairNeeded(int rentalId)
    {
        var rental = _rentals.FirstOrDefault(rental => rental.Id == rentalId) ?? throw new RentalNotFoundException(rentalId);
        
        rental.Return(DateTime.Now);
        rental.RentedEquipment.ReturnBrokenEquipment();
        rental.Renter.Return(rental.RentedEquipment);
    }

    public void PrintExtension()
    {
        foreach (var rental in _rentals)
        {
            Console.WriteLine(rental);
        }
    }

    public void PrintOverdueRentals()
    {
        foreach (var rental in _rentals)
        {
            DateTime compareAgainst = rental.ActualReturnDate?? DateTime.Now;
            if ((compareAgainst - rental.StartDate).Days > rental.AllowedRentalDays)
            {
                Console.WriteLine(rental);
            }
        }
    }
}