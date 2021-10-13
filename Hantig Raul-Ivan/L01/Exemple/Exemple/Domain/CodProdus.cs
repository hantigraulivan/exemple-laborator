using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exemple.Domain
{
    class CodProdus
    {
        private static readonly Regex ValidPattern = new("^[0-9]{10}$");

        public string Value { get; }

        private CodProdus(string value)
        {
            if (ValidPattern.IsMatch(value))
            {
                Value = value;
            }
            else
            {
                throw new InvalidCodProdusException("The code must be at most 10 caracters long and must not have characters");
            }
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
