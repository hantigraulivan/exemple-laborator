using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exemple.Domain
{
    public record CodProdus
    {
        private static readonly Regex ValidPattern = new("^[0-9]{2}$");
        private static List<string> ListaCoduriProduse = new List<string>();
        public string Value { get; }

        private CodProdus(string value)
        {
            if (ValidPattern.IsMatch(value))
            {
                Value = value;
                ListaCoduriProduse.Add(value);
            }
            else
            {
                throw new InvalidCodProdusException("The code must have 2 caracters long and must not have characters");
            }
        }

       /* public override string ToString()
        {
            return Value;
        }*/

        private static bool IsValid(string stringValue) => ValidPattern.IsMatch(stringValue);

        public static bool VerificareDacaSaMaiIntrodusProdusul(CodProdus CodProdusDeVerificat)
        {
            bool isValid = false;
            int i = 0;
            foreach(var cod in ListaCoduriProduse.ToList())
            {
                if (cod == CodProdusDeVerificat.Value)
                {
                    i++;
                }
            }
            if(i==1)
            {
                isValid = true;
            }
            return isValid;
        }

        public static bool VerificareExistentaCod(ReadOnlyCollection<ListaProduse> ListaP, CodProdus CodProdusDeVerificat)
        {
            bool isValid = false;
            foreach(var cod in ListaP)
            {
                if (cod.CodProdus == CodProdusDeVerificat.Value)
                {
                    isValid = true;
                }
            }          
            return isValid;
        }

        public static bool TryParseCodProdus(string stringValue, out CodProdus codProdus)
        {
            bool isValid = false;
            codProdus = null;

            if (IsValid(stringValue))
            {
                isValid = true;
                codProdus = new(stringValue);
            }

            return isValid;
        }
    }
}
