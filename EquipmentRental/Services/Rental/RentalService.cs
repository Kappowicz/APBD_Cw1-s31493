using EquipmentRental.Enums;
using EquipmentRental.Exceptions;
using EquipmentRental.Models;

namespace EquipmentRental.Services.Rental;

public class RentalService : IRentalService
{
    private readonly List<Models.Rental> _rentals = [];
    
    public void CreateRental(User renter, Equipment equipment, DateTime start)
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
            _rentals.Add(new Models.Rental(renter, equipment, start));
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
    }
    
    public void EndRentalWithRepairNeeded(int rentalId)
    {
        var rental = _rentals.FirstOrDefault(rental => rental.Id == rentalId) ?? throw new RentalNotFoundException(rentalId);
        
        rental.Return(DateTime.Now);
        rental.RentedEquipment.ReturnBrokenEquipment();
    }

    public void PrintExtension()
    {
        foreach (var rental in _rentals)
        {
            Console.WriteLine(rental);
        }
    }

    public void PrintOvedueRentals()
    {
        foreach (var rental in _rentals)
        {
            if ((DateTime.Today - rental.StartDate).Days > rental.AllowedRentalDays)
            {
                Console.WriteLine(rental);
            }
        }
    }
}