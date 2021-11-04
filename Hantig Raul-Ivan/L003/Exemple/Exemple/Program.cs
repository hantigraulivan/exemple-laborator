using Exemple.Domain;
using System;
using System.Collections.Generic;
using static Exemple.Domain.Models.Cos;
using static Exemple.Domain.CosOperation;
using Exemple.Domain.Models;

namespace Exemple
{
    class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            var listaProduse = ReadListOfGrades().ToArray();
            CosPlatitCommand command = new(listaProduse);
            CosPlatitWorkflow workflow = new CosPlatitWorkflow();
            var result = workflow.Execute(command);

            result.Match(
                    whenCosPlatitFaildEvent: @event =>
                    {
                        Console.WriteLine($"Plata esuata: {@event.Reason}");
                        return @event;
                    },
                    whenCosPlatitSuccededEvent: @event =>
                    {
                        Console.WriteLine($"Plata efectuata cu succes.");
                        Console.WriteLine(@event.Csv);
                        Console.WriteLine("Pretul total este :"+@event.PretTotal);
                        Console.WriteLine("Produsele vor fi livrate la adresa: "+@event.AdresaLivrare);
                        return @event;
                    }
                );

            Console.WriteLine("Hello World!");
        }

        private static List<CosNevalidat> ReadListOfGrades()
        {
            List <CosNevalidat> listaProduse = new();
            do
            {
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

                listaProduse.Add(new (codProdus, cantitate));
            } while (true);
            return listaProduse;
        }

        private static string? ReadValue(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
