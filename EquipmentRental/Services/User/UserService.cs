using EquipmentRental.Exceptions;
using EquipmentRental.Models;

namespace EquipmentRental.Services;

public class UserService : IUserService
{
    private List<User> _users = [];

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public User GetUserById(int id)
    {
        return _users.FirstOrDefault(user => user.Id == id) ?? throw new UserNotFoundException(id);
    }
    
    public void PrintExtension()
    {
        foreach (var usr in _users)
        {
            Console.WriteLine(usr);
        }
    }
}