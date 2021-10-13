using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemple.Domain
{
    public record Cantitate
    {
        public byte Value { get; }

        public Cantitate(byte value)
        {
            if (value > 0 && value <= 250)
            {
                Value = value;
            }
            else
            {
                throw new InvalidCantitateException(value.ToString()+" is an invalid quantity value.");
            }
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
