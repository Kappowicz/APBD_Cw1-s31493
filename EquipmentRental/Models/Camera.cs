namespace EquipmentRental.Models;

public class Camera : Equipment
{
    private double _sensorSize;
    private int _fov;
    public Camera(string name, double sensorSize, int fov) : base(name)
    {
        if (sensorSize <= 0)
            throw new ArgumentException("Camera sensor size can't be negative!");
        
        if (fov <= 0)
            throw new ArgumentException("Camera fov can't be negative!");
        
        _sensorSize = sensorSize;
        _fov = fov;
    }

    public override string ToString()
    {
        return base.ToString() + $" with specs: sensor size {_sensorSize} with fov {_fov}";
    }
}