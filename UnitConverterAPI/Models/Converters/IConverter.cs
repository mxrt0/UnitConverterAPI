namespace UnitConverterAPI.Models.Converters
{
    public interface IConverter
    {
        double Convert(double value, string fromUnit, string toUnit);
    }
}
