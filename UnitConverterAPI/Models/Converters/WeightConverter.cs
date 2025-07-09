namespace UnitConverterAPI.Models.Converters
{
    public class WeightConverter : IConverter
    {
        private Dictionary<string, Func<double, decimal>> _conversionTable =
         new Dictionary<string, Func<double, decimal>>
         {
           { "kg-lbs", v => (decimal)(v) * 2.20462m }, { "lbs-kg", v => (decimal)(v) / 2.20462m },
           { "g-lbs", v => (decimal)(v) * 0.00220462m }, { "lbs-g", v => (decimal)(v) / 0.00220462m },
           { "mg-lbs", v => (decimal)(v) * 0.00000220462m }, { "lbs-mg", v => (decimal)(v) / 0.00000220462m },
           { "kg-g", v => (decimal)(v) * 1000m }, { "g-kg", v => (decimal)(v) / 1000m },
           { "g-mg", v => (decimal)(v) * 1000m }, { "mg-g", v => (decimal)(v) / 1000m },
           { "kg-mg", v => (decimal)(v) * 1_000_000m }, { "mg-kg", v => (decimal)(v) / 1_000_000m },
         };

        public double Convert(double weight, string fromUnit, string toUnit)
        {
            return (double)_conversionTable[$"{fromUnit}-{toUnit}"](weight);
        }
    }
}
