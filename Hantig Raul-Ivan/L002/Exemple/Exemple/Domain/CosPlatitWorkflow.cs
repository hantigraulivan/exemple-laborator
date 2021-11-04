using Exemple.Domain.Models;
using static Exemple.Domain.Models.CosPlatitEvent;
using static Exemple.Domain.CosOperation;
using System;
using static Exemple.Domain.Models.Cos;

namespace Exemple.Domain
{
    public class CosPlatitWorkflow
    {
        public ICosPlatitEvent Execute(CosPlatitCommand command)
        {
            CosClientNevalidat unvalidatedGrades = new CosClientNevalidat(command.InputCos);
            ICosProduse cos = CosClientValidare(unvalidatedGrades);
            cos = PublishExamGrades(cos);

            return cos.Match(
                    whenCosClientNevalidat: cosNevalidat => new CosPlatitFaildEvent("Unexpected unvalidated state") as ICosPlatitEvent,
                    whenCosClientGol: cosGol => new CosPlatitFaildEvent(cosGol.Reason),
                    whenCosClientValidat: cosValid => new CosPlatitFaildEvent("Unexpected validated state"),
                    whenCosClientPlatit: cosPublic => new CosPlatitSuccededEvent(cosPublic.Csv, cosPublic.PublishedDate, cosPublic.Adresa, cosPublic.PretTotal)
                );
        }
    }
}
