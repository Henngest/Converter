using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    public class ConverterClass
    {
        private Dictionary<String, List<Unit>> unitsDictionary;
        private Unit unitObject;
        public ConverterClass()
        {
            unitsDictionary = new Dictionary<string, List<Unit>>();
            
            List<Unit> lengthUnits = new List<Unit>();
            lengthUnits.Add(new Unit("nm", 0.000000001));
            lengthUnits.Add(new Unit("μm", 0.000001));
            lengthUnits.Add(new Unit("mm", 0.001));
            lengthUnits.Add(new Unit("cm", 0.01));
            lengthUnits.Add(new Unit("m", 1));
            lengthUnits.Add(new Unit("km", 1000));
            lengthUnits.Add(new Unit("in", 0.0254));
            lengthUnits.Add(new Unit("ft", 0.3048));
            lengthUnits.Add(new Unit("yd", 0.9144));
            lengthUnits.Add(new Unit("mi", 1609.34));
            unitsDictionary.Add("Length", lengthUnits);

            List<Unit> weightUnits = new List<Unit>();
            weightUnits.Add(new Unit("mg", 0.000001));
            weightUnits.Add(new Unit("g", 0.001));
            weightUnits.Add(new Unit("kg", 1));
            weightUnits.Add(new Unit("t", 1000));
            weightUnits.Add(new Unit("lbs", 0.453592));
            weightUnits.Add(new Unit("oz", 0.0283495));
            unitsDictionary.Add("Weight", weightUnits);

            List<Unit> dataTransferRateUnits = new List<Unit>();
            dataTransferRateUnits.Add(new Unit("bps", 1.25e-7));
            dataTransferRateUnits.Add(new Unit("Kbps", 0.000125));
            dataTransferRateUnits.Add(new Unit("KBps", 0.001));
            dataTransferRateUnits.Add(new Unit("Mbps", 0.125));
            dataTransferRateUnits.Add(new Unit("MBps", 1));
            dataTransferRateUnits.Add(new Unit("Gbps", 125));
            dataTransferRateUnits.Add(new Unit("GBps", 1000));
            dataTransferRateUnits.Add(new Unit("Tbps", 125000));
            dataTransferRateUnits.Add(new Unit("TBps", 1e+6));
            unitsDictionary.Add("Data Transfer Rate", dataTransferRateUnits);

            List<Unit> timeUnits = new List<Unit>();
            timeUnits.Add(new Unit("ns", 1e-9));
            timeUnits.Add(new Unit("μs", 1e-6));
            timeUnits.Add(new Unit("ms", 0.001));
            timeUnits.Add(new Unit("s", 1));
            timeUnits.Add(new Unit("min", 60));
            timeUnits.Add(new Unit("h", 3600));
            timeUnits.Add(new Unit("d", 86400));
            timeUnits.Add(new Unit("wk", 604800));
            timeUnits.Add(new Unit("mo", 2.628e+6));
            timeUnits.Add(new Unit("yr", 31535965.4396976));
            unitsDictionary.Add("Time", timeUnits);
        }
        public List<String> getUnitTypes() 
        {
            return unitsDictionary.Keys.ToList();
        }
        public List<Unit> getUnits(String unitType) 
        {
            return unitsDictionary[unitType];
        }
        public void addUnits(string name, List<Unit> listUnits)
        {
            if (unitsDictionary.ContainsKey(name))
                unitsDictionary.Remove(name);
            unitsDictionary.Add(name, listUnits);
        }
        public double convert(String fromUnit, String toUnit, double value, string selectedUnitType) 
        {
            double tempMultiplier = 0;
            double tempDenominator = 0;
            foreach (Unit unit in unitsDictionary[selectedUnitType])
            {
                if (unit.name == fromUnit)
                    tempMultiplier = unit.multiplier;
                if (unit.name == toUnit)
                    tempDenominator = unit.multiplier;
            }
            if (tempMultiplier == 0 || tempDenominator == 0)
                throw new ArgumentException("Unit not available");
            return value * tempMultiplier / tempDenominator;
        }
    }
}
