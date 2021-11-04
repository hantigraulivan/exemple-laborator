using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemple.Domain
{
    public record Pret
    {
        public decimal Value { get; }

        public Pret(decimal value)
        {
            if (IsValid(value))
            {
                Value = value;
            }
            else
            {
                throw new InvalidCantitateException(value.ToString() + " is an invalid price value.");
            }
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        private static bool IsValid(decimal numericalValue) => numericalValue > 0 && numericalValue <= 99999;

        public static Pret operator *(Cantitate a, Pret b) => new Pret(a.Value * b.Value);

        public static bool TryParsePret(string stringPret, out Pret pretProdus)
        {
            bool isValid = false;
            pretProdus = null;

            if (decimal.TryParse(stringPret, out decimal cantitateNumerica))
            {
                if (IsValid(cantitateNumerica))
                {
                    isValid = true;
                    pretProdus = new(cantitateNumerica);
                }
            }

            return isValid;
        }

        public static bool TryParsePretDecimal(decimal decPret, out Pret pretProdus)
        {
            bool isValid = false;
            pretProdus = null;
            if (IsValid(decPret))
            {
                isValid = true;
                pretProdus = new(decPret);
            }
            return isValid;
        }
    }
}
