using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polizia_Giada
{
    class Area
    {
        //List<Agente> _agenti = new List<Agente>();
        public string CodiceArea { get; }

        public List<Agente> ListaAgenti { get; } = new List<Agente>();
        public Area(string codice)
        {
            CodiceArea = codice;
        }
        public override string ToString()
        {
            return "- "+CodiceArea;
        }
    }
}
