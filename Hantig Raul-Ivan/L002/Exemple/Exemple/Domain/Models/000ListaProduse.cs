using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemple.Domain
{
    public record ListaProduse(string CodProdus, string Cantitate, string Pret);
    static class ListProduse
    {
        private static List<ListaProduse> pistaProduse = new List<ListaProduse>();
        public static ReadOnlyCollection<ListaProduse> readOnlyProduse;
        private static bool alreadyExecuted = false;
        public static void elementelista()
        {
            if (alreadyExecuted != true)
            {
                pistaProduse.Add(new ListaProduse("01", "110", "100"));
                pistaProduse.Add(new ListaProduse("02", "120", "200"));
                pistaProduse.Add(new ListaProduse("03", "130", "300"));
                pistaProduse.Add(new ListaProduse("04", "140", "400"));
                pistaProduse.Add(new ListaProduse("05", "150", "500"));
                pistaProduse.Add(new ListaProduse("06", "160", "600"));
                pistaProduse.Add(new ListaProduse("07", "170", "700"));
                pistaProduse.Add(new ListaProduse("08", "180", "800"));
                pistaProduse.Add(new ListaProduse("09", "190", "900"));
                pistaProduse.Add(new ListaProduse("10", "200", "1000"));
                readOnlyProduse = new ReadOnlyCollection<ListaProduse>(pistaProduse);
                alreadyExecuted = true;
            }

        }
    }
}
