namespace UnitConverterAPI.Models
{
    public interface IConverterRepository
    {
        (double,bool) Convert(double value, string fromUnit, string toUnit);
    }
}
