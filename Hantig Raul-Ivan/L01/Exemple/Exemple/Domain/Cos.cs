using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemple.Domain
{
    [AsChoice]
    public static partial class Cos
    {
        public interface ICosProduse { }

        public record CosClientGol(IReadOnlyCollection<CosGol> CosCumparaturi) : ICosProduse; 

        public record CosClientNevalidat(IReadOnlyCollection<CosGol> CosCumparaturi, string reason) : ICosProduse;

        public record CosClientValidat(IReadOnlyCollection<CosValidat> CosCumparaturi) : ICosProduse;

        public record CosClientPlatit(IReadOnlyCollection<CosValidat> CosCumparaturi, DateTime PublishedDate) : ICosProduse;
    }
}
