namespace UnitConverterAPI.Models.Converters
{
    public class DistanceConverter : IConverter
    {
        private Dictionary<string, Func<double, double>> _conversionTable =
        new Dictionary<string, Func<double, double>>
        {
            {"km-mi", v => v / 1.61 }, {"mi-km", v => v * 1.61 },
            {"m-km", v => v / 1000 }, {"km-m", v => v * 1000 },
            {"cm-m", v => v / 100 }, {"m-cm", v => v * 100 },
            {"mm-cm", v => v / 10 }, {"cm-mm", v => v * 10 },
            { "mi-m", v => v * 1609.34 }, { "m-mi", v => v / 1609.34 },
            { "mi-cm", v => v * 160_934 }, { "cm-mi", v => v / 160_934 },
            { "mi-mm", v => v * 1_609_340 }, { "mm-mi", v => v / 1_609_340 },
            { "km-cm", v => v * 100_000 }, { "cm-km", v => v / 100_000 },
            { "km-mm", v => v * 1_000_000 }, { "mm-km", v => v / 1_000_000 },
            { "m-mm", v => v * 1000 }, { "mm-m", v => v / 1000 },
        };
        
        public double Convert(double distance, string fromUnit, string toUnit)
        {
           return _conversionTable[$"{fromUnit}-{toUnit}"](distance);
        }
    }
}
