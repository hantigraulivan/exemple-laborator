using Exemple.Domain;
using System;
using System.Collections.Generic;
using static Exemple.Domain.Cos;

namespace Exemple
{
    class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            var listaProduse = ReadListOfGrades().ToArray();
            CosClientGol cosGol = new(listaProduse);
            ICosProduse result = CosClientValidat(cosGol);
            result.Match(
                whenCosClientGol: unvalidatedResult => cosGol,
                whenCosClientPlatit: publicatPlata => publicatPlata,
                whenCosClientNevalidat: nevalidResult => nevalidResult,
                whenCosClientValidat: validatedResult => CosClientPlatit(validatedResult)
            );

            Console.WriteLine("Hello World!");
        }

        private static List<CosGol> ReadListOfGrades()
        {
            List <CosGol> listaProduse = new();
            do
            {
                //read registration number and grade and create a list of greads
                var codProdus = ReadValue("Cod produs: ");
                if (string.IsNullOrEmpty(codProdus))
                {
                    break;
                }

                var cantitate = ReadValue("Cantitate: ");
                if (string.IsNullOrEmpty(cantitate))
                {
                    break;
                }

                var adresa = ReadValue("Adresa: ");
                if (string.IsNullOrEmpty(adresa))
                {
                    break;
                }

                listaProduse.Add(new (codProdus, cantitate, adresa));
            } while (true);
            return listaProduse;
        }

        private static ICosProduse CosClientValidat(CosClientGol cosGol) =>
            random.Next(100) > 50 ?
            new CosClientNevalidat(new List<CosGol>(), "Random errror")
            : new CosClientValidat(new List<CosValidat>());

        private static ICosProduse CosClientPlatit(CosClientValidat cosValidat) =>
            new CosClientPlatit(new List<CosValidat>(), DateTime.Now);

        private static string? ReadValue(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
