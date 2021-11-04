using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemple.Domain.Models
{
    [AsChoice]
    public static partial class CosPlatitEvent
    {
        public interface ICosPlatitEvent { }

        public record CosPlatitSuccededEvent : ICosPlatitEvent
        {
            public string Csv{ get;}
            public DateTime PublishedDate { get; }
            public string AdresaLivrare { get; }
            public decimal PretTotal { get; }

            internal CosPlatitSuccededEvent(string csv, DateTime publishedDate, string adresaLivrare, decimal pretTotal)
            {
                Csv = csv;
                PublishedDate = publishedDate;
                AdresaLivrare = adresaLivrare;
                PretTotal = pretTotal;
            }
        }

        public record CosPlatitFaildEvent : ICosPlatitEvent
        {
            public string Reason { get; }

            internal CosPlatitFaildEvent(string reason)
            {
                Reason = reason;
            }
        }
    }
}
