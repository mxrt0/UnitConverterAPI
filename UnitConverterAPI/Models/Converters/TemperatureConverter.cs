namespace UnitConverterAPI.Models.Converters
{
    public class TemperatureConverter : IConverter
    {
        private Dictionary<string, Func<double, double>> _conversionTable =
        new Dictionary<string, Func<double, double>>
        {
            {"celsius-fahrenheit", v => (v * 1.8) + 32 },
            {"fahrenheit-celsius", v => (v - 32) * 0.56 },
            {"celsius-kelvin", v => v + 273.15 },
            {"kelvin-celsius", v => v - 273.15 },
            {"fahrenheit-kelvin", v => (v - 32) * 0.56 + 273.15},
            {"kelvin-fahrenheit", v => (v - 273.15) * 1.8 + 32},
        };

        public double Convert(double temperature, string fromUnit, string toUnit)
        {
            return _conversionTable[$"{fromUnit}-{toUnit}"](temperature);
        }
    }
}
