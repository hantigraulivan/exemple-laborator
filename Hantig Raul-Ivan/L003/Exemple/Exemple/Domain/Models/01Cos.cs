using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemple.Domain.Models
{
    [AsChoice]
    public static partial class Cos
    {
        public interface ICosProduse { }

        public record CosClientGol  : ICosProduse
        {
            public CosClientGol(IReadOnlyCollection<CosNevalidat> cosCumparaturi, string reason)
            {
                CosCumparaturi = cosCumparaturi;
                Reason = reason;
            }
            public IReadOnlyCollection<CosNevalidat> CosCumparaturi { get; }
            public string Reason { get; }
        }

        public record CosClientNevalidat : ICosProduse
        {
            internal CosClientNevalidat(IReadOnlyCollection<CosNevalidat> cosCumparaturi)
            {
                CosCumparaturi = cosCumparaturi;
            }
            public IReadOnlyCollection<CosNevalidat> CosCumparaturi { get;  }
        }

        public record CosClientValidat : ICosProduse
        {
            internal CosClientValidat(IReadOnlyCollection<CosValidat> cosCumparaturi, string adresa, decimal pretTotal)
            {
                CosCumparaturi = cosCumparaturi;
                Adresa = adresa;
                PretTotal = pretTotal;
            }
            public IReadOnlyCollection<CosValidat> CosCumparaturi { get; }
            public string Adresa { get; }
            public decimal PretTotal { get; }
        }


        public record CosClientPlatit : ICosProduse
        {
            internal CosClientPlatit(IReadOnlyCollection<CosValidat> cosCumparaturi, string csv, DateTime publishedDate, string adresa, decimal pretTotal)
            {
                CosCumparaturi = cosCumparaturi;
                PublishedDate = publishedDate;
                Csv = csv;
                Adresa = adresa;
                PretTotal = pretTotal;
            }
            public IReadOnlyCollection<CosValidat> CosCumparaturi { get; }
            public DateTime PublishedDate { get; }
            public string Csv { get; }
            public string Adresa { get; }
            public decimal PretTotal { get; }
        }
    }
}
