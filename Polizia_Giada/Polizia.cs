using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polizia_Giada
{
    static class Polizia
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConnessionePolizia"].ConnectionString;

        public static List<Agente> VisualizzaAgenti()
        {
            List<Agente> _agenti = new List<Agente>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("Select * from AgenteDiPolizia", conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Agente a = new Agente((int)reader["idAgente"], (string)reader["Nome"], (string)reader["Cognome"],
                                            (string)reader["CodiceFiscale"], (DateTime)reader["DataDiNascita"],
                                            (int)reader["AnniDiServizio"]);
                    _agenti.Add(a);
                }
                conn.Close();
                return _agenti;
            }
        }
        public static List<Area> VisualizzaAree()
        {
            List<Area> _aree = new List<Area>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("Select * from AreaMetropolitana", conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Area a = new Area((string)reader["CodiceArea"]);
                    _aree.Add(a);
                }
                conn.Close();
                return _aree;
            }
        }
        public static List<Agente> VisualizzaAgentiperAerea(string codArea)
        {
            Area a = new Area(codArea);

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(@"Select * from AgenteDiPolizia
                                                    JOIN AssegnazioneArea on idAgente = id_Agente
                                                    JOIN AreaMetropolitana ON AssegnazioneArea.id_Area = AreaMetropolitana.idAreaMetropolitana
                                                    where CodiceArea= @idArea", conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@idArea", codArea);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Agente agente = new Agente((int)reader["idAgente"], (string)reader["Nome"], (string)reader["Cognome"],
                                            (string)reader["CodiceFiscale"], (DateTime)reader["DataDiNascita"],
                                            (int)reader["AnniDiServizio"]);
                    a.ListaAgenti.Add(agente);
                }
                conn.Close();
                return a.ListaAgenti;
            }
        }
        public static List<Agente> VisualizzaAgentiperAnni(int anni)
        {
            List<Agente> _agentiPerAnni = new List<Agente>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(@"Select * from AgenteDiPolizia
                                                    where AnniDiServizio >= @anniDiServizio", conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@anniDiServizio", anni);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Agente agente = new Agente((int)reader["idAgente"], (string)reader["Nome"], (string)reader["Cognome"],
                                            (string)reader["CodiceFiscale"], (DateTime)reader["DataDiNascita"],
                                            (int)reader["AnniDiServizio"]);
                    _agentiPerAnni.Add(agente);
                }
                conn.Close();
                return _agentiPerAnni;
            }
        }
        public static Agente InserisciAgente(string nome, string cognome, DateTime data, string codice, int anni)
        {
            DataSet dsAgenti = new DataSet();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlDataAdapter da = new SqlDataAdapter(@"Select * from AgenteDiPolizia", conn))
            {
                da.Fill(dsAgenti, "AgenteDiPolizia");

                DataTable tabellaAgente = dsAgenti.Tables["AgenteDiPolizia"];

                tabellaAgente.Rows.Add(0, nome, cognome, codice, data, anni);

                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                conn.Open();
                da.Update(tabellaAgente);
                SqlCommand cmd = new SqlCommand("Select @@identity", conn);

                int id = (int)(decimal)cmd.ExecuteScalar();

                conn.Close();

                return new Agente(id, nome, cognome, codice, data, anni);
            }
        }
    }
}