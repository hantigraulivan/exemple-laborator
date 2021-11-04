using Exemple.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Exemple.Domain.Models.Cos;

namespace Exemple.Domain
{
    public static class CosOperation
    {

        public static ICosProduse CosClientValidare( CosClientNevalidat cosProduse)
        {
            ListProduse.elementelista();
            
            List<CosValidat> cosValidat = new();
            bool isValidList = true;
            string invalidReson = string.Empty;
            string obtinerePret = string.Empty;
            decimal pretTotal = 0;
            bool punct = false;
            foreach(var CosN in cosProduse.CosCumparaturi)
            {
                if (!CodProdus.TryParseCodProdus(CosN.CodProdus, out CodProdus codProdus))
                {
                    invalidReson = $"Invalid cod produs ({CosN.CodProdus})";
                    isValidList = false;
                    break;
                }
                if(!CodProdus.VerificareExistentaCod(ListProduse.readOnlyProduse, codProdus))
                {
                    invalidReson = $"Produsul ({CosN.CodProdus}) nu exista ";
                    isValidList = false;
                    break;
                }
                if (!CodProdus.VerificareDacaSaMaiIntrodusProdusul(codProdus))
                {
                    invalidReson = $"Produsul ({CosN.CodProdus}) a fost introdus in cos de mai multe ori ";
                    isValidList = false;
                    break;
                }
                if (!Cantitate.TryParseCantitate(CosN.Cantitate, out Cantitate cantitateProdus))
                {
                    invalidReson = $"Invalid cantitate ({CosN.Cantitate})";
                    isValidList = false;
                    break;
                }
                if (!Cantitate.VerificareCantitate(ListProduse.readOnlyProduse, cantitateProdus))
                {
                    invalidReson = $"Cantitatea de ({CosN.Cantitate}) este prea mare";
                    isValidList = false;
                    break;
                }

                foreach (var codp in ListProduse.readOnlyProduse)
                {
                    if(codp.CodProdus == CosN.CodProdus)
                    {
                        obtinerePret = codp.Pret;
                    }
                }
                if (!Pret.TryParsePret(obtinerePret, out Pret pretProdus))
                {
                    invalidReson = $"Invalid pret ({obtinerePret})";
                    isValidList = false;
                    break;
                }

                CosValidat validCos = new(codProdus, cantitateProdus, cantitateProdus * pretProdus);
                pretTotal += validCos.Pret.Value;
                cosValidat.Add(validCos);
                punct = true;
            }

            Console.Write("Adresa de livrare: ");
            var adresaLivrare = Console.ReadLine();

            if(!Adresa.TryParseAdresa(adresaLivrare, out Adresa adresalivrare))
            {
                invalidReson = $"Adresa ({adresaLivrare}) este invalida";
                isValidList = false;
            }

            if (!Pret.TryParsePretDecimal(pretTotal, out Pret pretulCosului))
            {
                if(punct == true)
                {
                    invalidReson = $"Invalid pret ({pretTotal})";
                    isValidList = false;
                }
            }

            if (isValidList)
            {
                return new CosClientValidat(cosValidat, adresalivrare.Value, pretulCosului.Value);
            }
            else
            {
                return new CosClientGol(cosProduse.CosCumparaturi, invalidReson);
            }
        }

        public static ICosProduse PublishExamGrades(ICosProduse examGrades) => examGrades.Match(
            whenCosClientGol: cosGol => cosGol,
            whenCosClientPlatit: cosClientPlatit => cosClientPlatit,
            whenCosClientNevalidat: CosClientNevalidat => CosClientNevalidat,
            whenCosClientValidat: CosClientValidat =>
            {
                StringBuilder csv = new();
                CosClientValidat.CosCumparaturi.Aggregate(csv, (export, pr) => export.AppendLine($"{pr.CodProdus.Value}, {pr.Cantitate}, {pr.Pret}"));

                CosClientPlatit ccosClientPlatit = new(CosClientValidat.CosCumparaturi, csv.ToString(), DateTime.Now, CosClientValidat.Adresa, CosClientValidat.PretTotal);

                return ccosClientPlatit;
            });
    }
}
