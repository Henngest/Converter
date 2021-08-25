using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    class ConverterClass
    {
        private Dictionary<String, List<String>> unitsDictionary;
        public ConverterClass()
        {
            unitsDictionary = new Dictionary<string, List<string>>();

            List<String> lengthUnits = new List<String>();
            lengthUnits.Add("cm");
            lengthUnits.Add("m");
            lengthUnits.Add("km");
            unitsDictionary.Add("Length", lengthUnits);

            List<String> weightUnits = new List<String>();
            weightUnits.Add("g");
            weightUnits.Add("kg");
            weightUnits.Add("t");
            unitsDictionary.Add("Weight", weightUnits);
        }
        public List<String> getUnitTypes() 
        {
            return unitsDictionary.Keys.ToList();
        }
        public List<String> getUnits(String unitType) 
        {
            return unitsDictionary[unitType];
        }
        public double convert(String fromUnit, String toUnit, double value) 
        {
            return value * 2;
        }
    }
}
