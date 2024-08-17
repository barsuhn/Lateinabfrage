using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lateinabfrage
{
    struct Vokabeln
    {
        public Vokabeln()
        {
            Latein = new List<string>();
            Deutsch = new List<string>();
        }

        public List<string> Latein;
        public List<string> Deutsch;
    }
}
