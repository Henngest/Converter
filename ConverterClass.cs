using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    class ConverterClass
    {
        public List<String> getUnitTypes() 
        {
            List<String> lista = new List<String>();
            lista.Add("Length");
            lista.Add("Weight");
            return lista;
        }
        public List<String> getUnits(String unitType) 
        {
            List<String> lista = new List<String>();
            lista.Add("cm");
            lista.Add("m");
            lista.Add("km");
            return lista;
        }
        public double convert(String fromUnit, String toUnit, double value) 
        {
            return value * 2;
        }
    }
}
