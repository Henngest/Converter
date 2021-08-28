using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    public class Unit
    {
        public string name { get; set; }
        public double multiplier { get; set; }
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
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (Object.ReferenceEquals(this, obj))
                return true;
            if (this.GetType() != obj.GetType())
                return false;
            Unit castedObject = (Unit)obj;
            return this.name == castedObject.name && this.multiplier == castedObject.multiplier;
        }
    }
}
