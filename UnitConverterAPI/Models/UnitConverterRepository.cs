using UnitConverterAPI.Models.Converters;
namespace UnitConverterAPI.Models
{
    public class UnitConverterRepository : IConverterRepository
    {
        private List<List<string>> validUnits =
         new List<List<string>>
         {
             new List<string>{ "g", "kg", "mg", "lbs"},
             new List<string>{"celsius", "fahrenheit", "kelvin"},
             new List<string>{"mm", "cm", "m", "km","mi"}
         };
       IConverter distanceConverter = new DistanceConverter();
       IConverter temperatureConverter = new TemperatureConverter();
       IConverter weightConverter = new WeightConverter();
        public (double, bool) Convert(double value, string fromUnit, string toUnit)
        {
            double result = default;
            bool unitsAreValid = validUnits.SelectMany(x => x).Contains(fromUnit) 
                && validUnits.SelectMany(x => x).Contains(toUnit);
            if (unitsAreValid)
            {
                switch (fromUnit)
                {
                    case "g":
                    case "kg":
                    case "mg":
                    case "lbs":
                        if (validUnits[0].Contains(toUnit))
                        {
                            result = weightConverter.Convert(value, fromUnit, toUnit);
                            return (result, true);
                        }
                        else
                        {
                            throw new Exception($"Cannot convert from {fromUnit} to {toUnit}.");
                        }    
                    case "celsius":
                    case "fahrenheit":
                    case "kelvin":
                        if (validUnits[1].Contains(toUnit))
                        {
                            result = temperatureConverter.Convert(value, fromUnit, toUnit);
                            return (result, true);
                        }
                        else
                        {
                            throw new Exception($"Cannot convert from {fromUnit} to {toUnit}.");
                        }    
                    case "mm":
                    case "cm":
                    case "m":
                    case "km":
                    case "mi":
                        if (validUnits[2].Contains(toUnit))
                        {
                            result = distanceConverter.Convert(value, fromUnit, toUnit);
                            return (result, true);
                        }
                        else
                        {
                            throw new Exception($"Cannot convert from {fromUnit} to {toUnit}.");
                        }   
                    default:
                        break;
                }
            }
            return (default, false);
        }
    }
}
