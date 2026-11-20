using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzeumok
{
    public class Belepes
    {
        public string Idobelyegzo { get; set; }
        public int JegyAzonosito { get; set; }
        public int HelyszinAzonosito { get; set; }
        public string JegyTipus { get; set; }

        public Belepes(string idobelyegzo, int jegyAzonosito, int helyszinAzonosito, string jegyTipus)
        {
            Idobelyegzo = idobelyegzo;
            JegyAzonosito = jegyAzonosito;
            HelyszinAzonosito = helyszinAzonosito;
            JegyTipus = jegyTipus;
        }
    }
}