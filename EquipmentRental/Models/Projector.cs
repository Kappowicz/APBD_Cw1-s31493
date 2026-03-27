namespace EquipmentRental.Models;

public class Projector : Equipment
{
    private string _lightSource;
    private int _brightness;
    public Projector(string name, string lightSource, int brightness) : base(name)
    {
        if (string.IsNullOrWhiteSpace(lightSource))
            throw new ArgumentException("Projector light source name cannot be empty!");
        
        if (brightness <= 0)
            throw new ArgumentException("Projector brightness can't have no ram!");
        
        _lightSource = lightSource;
        _brightness = brightness;
    }

    public override string ToString()
    {
        return base.ToString() + $" with specs: brightness {_brightness} with {_lightSource} light source";
    }
}