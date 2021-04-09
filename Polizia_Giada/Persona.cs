using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polizia_Giada
{
    abstract class Persona
    {
        public string Nome { get; }
        public string Cognome { get; }
        public string CodiceFiscale { get; }
        public Persona(string nome, string cognome, string codFisc)
        {
            Nome = nome;
            Cognome = cognome;
            CodiceFiscale = codFisc;
        }

        public override bool Equals(object obj)
        {
            Persona p = (Persona)obj;
            Persona p2 = this;

            if (p.CodiceFiscale == p2.CodiceFiscale)
                return true;

            return false;
        }
    }
}
