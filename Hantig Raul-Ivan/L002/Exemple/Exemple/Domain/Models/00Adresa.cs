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
        private static readonly Regex ValidPattern = new("[a-z]+");

        public string Value { get; }

        private Adresa(string value)
        {
            if (IsValid(value))
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

        private static bool IsValid(string stringValue) => ValidPattern.IsMatch(stringValue);

        public static bool TryParseAdresa(string stringValue, out Adresa adresaProdus)
        {
            bool isValid = false;
            adresaProdus = null;

            if (IsValid(stringValue))
            {
                isValid = true;
                adresaProdus = new(stringValue);
            }

            return isValid;
        }
    }
}
