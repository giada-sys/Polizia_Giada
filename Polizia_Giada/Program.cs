using System;
using System.Collections.Generic;

namespace Polizia_Giada
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Distretto di Polizia");
            Console.WriteLine();

            do
            {
                Console.WriteLine();
                Console.WriteLine("Menù");
                Console.WriteLine("1. Visualizza tutti gli Agenti");
                Console.WriteLine("2. Visualizza Agenti per Area");
                Console.WriteLine("3. Visualizza Agenti per Anni di Servizio");
                Console.WriteLine("4. Inserire Agente");
                Console.WriteLine("0. Esci");

                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        //Visualizza tutti gli agenti
                        //Codice Fiscale: - Nome e Cognome: - Anni di Servizio: - 
                        MostraAgenti();
                        break;
                    case '2':
                        //Visualizza Agenti per area
                        //Input Utente
                        MostraAgentePerArea();
                        break;
                    case '3':
                        //Visualizza Agenti per anno di servizio
                        //Input Utente
                        MostraAgentiPerAnni();
                        break;
                    case '4':
                        //Inserire Agente
                        InserisciAgente();
                        break;
                    case '0':
                        //Esci
                        return;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Scelta non valida;");
                        break;
                }

            } while (true);
        }

        private static void InserisciAgente()
        {
            string nome="";
            string cognome = "";
            DateTime data;
            string codFisc = "";
            int anni = 0;

            Console.WriteLine();
            Console.WriteLine("Inserire Anagrafica Agente di Polizia:");
            do
            {
                Console.WriteLine();
                Console.Write("Nome: ");
                nome = Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine("Cognome: ");
                cognome = Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine("Data di Nascita: ");
                DateTime.TryParse(Console.ReadLine(), out data);
               
                Console.WriteLine();
                Console.WriteLine("Codice Fiscale (max 16 char): ");
                codFisc= Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine("Anni di Servizio: ");
                int.TryParse(Console.ReadLine(), out anni);

                Console.WriteLine("Hai inserito tutti i dati correttamente (Y/N)?");
            } while (Console.ReadKey().Key == ConsoleKey.N);

            Console.WriteLine();
            Agente a = Polizia.InserisciAgente(nome, cognome, data, codFisc, anni);
            Console.WriteLine($"Agente Inserito Correttamente \n\n{a.ToString()}");

        }

        private static void MostraAgentiPerAnni()
        {
            Console.WriteLine();
            Console.WriteLine("Inserire Anni di servizio:");
            int.TryParse(Console.ReadLine(), out int anni);

            foreach (Agente a in Polizia.VisualizzaAgentiperAnni(anni))
                Console.WriteLine(a.ToString());
        }

        private static void MostraAgentePerArea()
        {
            Console.WriteLine();
            Console.WriteLine("Inserire un'area tra le seguenti:");
            foreach (Area a in Polizia.VisualizzaAree())
                Console.WriteLine(a.ToString());
            string areaScelta = Console.ReadLine();

           // Polizia.VisualizzaAgentiperAerea(areaScelta);

            foreach(Agente a in Polizia.VisualizzaAgentiperAerea(areaScelta))
                   Console.WriteLine(a.ToString());
        }

        private static void MostraAgenti()
        {
            Console.WriteLine();
            List<Agente> listaAgenti = Polizia.VisualizzaAgenti();
            foreach (Agente a in listaAgenti)
                Console.WriteLine(a.ToString());
        }
    }
}