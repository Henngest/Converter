using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    class Unit
    {
        private string name { get; set; }
        private double multiplier { get; set; }
        public Unit() { }
        public Unit(string name, double multiplier)
        {
            this.name = name;
            this.multiplier = multiplier;
        }
        public override string ToString()
        {
            return name;
        }
    }
}
