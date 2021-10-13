using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exemple.Domain
{
    public record Adresa
    {
        private static readonly Regex ValidPattern = new(@"^([a-zA-Z]+\s+str+\s+[a-zA-Z]+\s+nr+[0-9]+)$");

        public string Value { get; }

        private Adresa(string value)
        {
            if (ValidPattern.IsMatch(value))
            {
                Value = value;
            }
            else
            {
                throw new InvalidAdresaException("Not match the pattern!!!");
            }
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
