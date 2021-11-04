using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            if (IsValid(value))
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

        private static bool IsValid(byte numericalValue) => numericalValue > 0 && numericalValue <= 250;

        public static bool VerificareCantitate(ReadOnlyCollection<ListaProduse> ListaP, Cantitate CantitateDeVerificat)
        {
            bool isValid = false;
            foreach (var cantitate in ListaP)
            {
                if(TryParseCantitate(cantitate.Cantitate, out Cantitate cantitateProdus))
                {
                    if (cantitateProdus.Value >= CantitateDeVerificat.Value)
                    {
                        isValid = true;
                    }
                } 
            }
            return isValid;
        }

        public static bool TryParseCantitate(string stringCantitate, out Cantitate cantitateProdus)
        {
            bool isValid = false;
            cantitateProdus = null;

            if (byte.TryParse(stringCantitate, out byte cantitateNumerica))
            {
                if (IsValid(cantitateNumerica))
                {
                    isValid = true;
                    cantitateProdus = new(cantitateNumerica);
                }
            }
            return isValid;
        }
    }
}
