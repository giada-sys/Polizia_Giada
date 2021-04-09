using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polizia_Giada
{
    class Agente:Persona
    {
        public int IDAgente { get; }
        public DateTime DataNascita { get; }
        public int AnniDiServizio { get; }
        public Agente(int idAgente,string nome, string cognome, string codFisc, DateTime dataNascita, int anniServizio)
            :base (nome, cognome, codFisc)
        {
            IDAgente = idAgente;
            DataNascita = dataNascita;
            AnniDiServizio = anniServizio;
        }

        public override string ToString()
        {
            string s = "Codice Fiscale: "+CodiceFiscale+"\tNome e Cognome: "+ Nome+Cognome+"\tAnni Di Servizio: "+ AnniDiServizio;
            return s;
        }

    }
}
