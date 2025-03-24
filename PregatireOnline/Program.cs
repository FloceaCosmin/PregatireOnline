using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Librarie;
using NivelStocareDate;




namespace PregatiriOnline
{
    class Program
    {
        static StocareDate stocare = new StocareDate();
        static Administrator admin = new Administrator("Cosmin", "cosmin@yahoo.com");

        static Profesor prof1 = new Profesor("Matei", "matei@yahoo.com", Materie.Matematica, 0);
        static Profesor prof2 = new Profesor("Ana", "ana@yahoo.com", Materie.Informatica, 5);
        static Elev elev1 = new Elev("Marcu", "marcu@yahoo.com", "IV", 12);
        static Elev elev2 = new Elev("Ion", "ion@yahoo.com", "VIII", 14);


        static AdministrareProfesori_FisierText administrareProfesori = new AdministrareProfesori_FisierText("profesori.txt");
        static AdministrareElevi_FisierText administrareElevi = new AdministrareElevi_FisierText("elevi.txt");


        static void Main(string[] args)
        {
            CitireDateDinFisier();

            
            stocare.AdaugaProfesor(prof1);
            administrareProfesori.AddProfesor(prof1); 

            stocare.AdaugaProfesor(prof2);
            administrareProfesori.AddProfesor(prof2);

            stocare.AdaugaElev(elev1);
            administrareElevi.AddElev(elev1);

            stocare.AdaugaElev(elev2);
            administrareElevi.AddElev(elev2);

            bool running = true;

            while (running)
            {
                AfisareAdministrator(admin);
                Console.WriteLine("\nMeniu:");
                Console.WriteLine("1. Citire obiect (Profesor, Elev sau Administrator)");
                Console.WriteLine("2. Afiseaza ultima citire");
                Console.WriteLine("3. Afiseaza lista de Profesori");
                Console.WriteLine("4. Afiseaza lista de Elevi");
                Console.WriteLine("5. Cautare profesor sau elev");
                Console.WriteLine("6. Iesire");
                Console.Write("Alege o optiune: ");

                string optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        CitireObiect();
                        break;
                    case "2":
                        AfiseazaUltimaCitire();
                        break;

                    case "3":
                        AfisareProfesori(admin);
                        break;

                    case "4":
                        AfisareElevi(admin);
                        break;
                    case "5":
                        CautareInLista();
                        break;
                    case "6":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Optiune invalida! Incearca din nou.");
                        break;
                }
            }
        }

        
        static Utilizator ultimaCitire;

        static void CitireDateDinFisier()
        {


            int nrProfesori, nrElevi;


            Profesor[] profesori = administrareProfesori.GetProfesori(out nrProfesori);
            foreach (var profesor in profesori)
            {
                stocare.AdaugaProfesor(profesor);
            }

            Elev[] elevi = administrareElevi.GetElevi(out nrElevi);
            foreach (var elev in elevi)
            {
                stocare.AdaugaElev(elev);
            }
        }

        static void CitireObiect()
        {
            Console.WriteLine("\nAlege tipul de obiect de citit:");
            Console.WriteLine("P - Profesor");
            Console.WriteLine("E - Elev");
            Console.WriteLine("A - Administrator");
            Console.Write("Introduceti optiunea: ");
            string optiuneCitire = Console.ReadLine().ToUpper();

            switch (optiuneCitire)
            {
                case "P":
                    CitireSiSalvareProfesor();
                    break;

                case "E":
                    CitireSiSalvareElev();
                    break;

                case "A":
                    CitireSiSalvareAdministrator();
                    break;

                default:
                    Console.WriteLine("Optiune invalida! Incearca din nou.");
                    break;
            }
        }

        static void CitireSiSalvareProfesor()
        {
            Profesor prof = CitireProfesor();
            prof.TipUtilizator = "Profesor";
            ultimaCitire = prof;
            stocare.AdaugaProfesor(prof);
            administrareProfesori.AddProfesor(prof);

            Console.WriteLine("Profesorul a fost adaugat.");
        }

        static void CitireSiSalvareElev()
        {
            Elev elev = CitireElev();
            elev.TipUtilizator = "Elev";
            ultimaCitire = elev;
            stocare.AdaugaElev(elev);
            administrareElevi.AddElev(elev);

            Console.WriteLine("Elevul a fost adaugat.");
        }

        static void CitireSiSalvareAdministrator()
        {
            Console.WriteLine("!!!!!!!!!!Aceasta obtiune va actualiza administratorul deja existent!!!!!!!!!!!!!!!!");
            AfisareAdministrator(admin);


            Administrator adminNou = CitireAdministrator();
            adminNou.TipUtilizator = "Administrator";
            ultimaCitire = adminNou;
            admin = adminNou; 
            Console.WriteLine("Administratorul a fost actualizat.");
        }

        static void AfiseazaUltimaCitire()
        {
            if (ultimaCitire != null)
            {
                Console.WriteLine($"Ultima citire: {ultimaCitire.Info()}");
            }
            else
            {
                Console.WriteLine("Nu există o citire recentă.");
            }
        }

        static void AfisareProfesori(Administrator admin)
        {
            Console.WriteLine("\nLista Profesori:");
            foreach (var profesor in stocare.Profesori)
            {
                Console.WriteLine(profesor.Info());
            }
        }

        static void AfisareElevi(Administrator admin)
        {
            Console.WriteLine("\nLista Elevi:");
            foreach (var elev in stocare.Elevi)
            {
                Console.WriteLine(elev.Info());
            }
        }

        static void AfisareAdministrator(Administrator admin)
        {
            Console.WriteLine(admin.Info());
        }
        static void CautareInLista()
        {
            Console.WriteLine("\nCautare in lista:");
            Console.WriteLine("P - Cauta Profesor");
            Console.WriteLine("E - Cauta Elev");
            Console.Write("Introduceti optiunea: ");
            string optiuneCautare = Console.ReadLine().ToUpper();

            switch (optiuneCautare)
            {
                case "P":
                    CautaProfesor();
                    break;

                case "E":
                    CautaElev();
                    break;

                default:
                    Console.WriteLine("Optiune invalida! Incearca din nou.");
                    break;
            }
        }

        static void CautaProfesor()
        {
            Console.Write("Introduceti numele profesorului pe care doriti sa il cautati: ");
            string numeProfesor = Console.ReadLine();

            Profesor profesorGasit = Profesor.CautaProfesor(stocare.Profesori, numeProfesor);

            if (profesorGasit != null)
            {
                Console.WriteLine("\nProfesor gasit!");
                Console.WriteLine(profesorGasit.Info());
            }
            else
            {
                Console.WriteLine("Profesorul nu a fost gasit.");
            }
        }

        static void CautaElev()
        {
            Console.Write("Introduceti numele elevului pe care doriti sa il cautati: ");
            string numeElev = Console.ReadLine();

            Elev elevGasit = Elev.CautaElev(stocare.Elevi, numeElev);

            if (elevGasit != null)
            {
                Console.WriteLine("\nElev gasit!");
                Console.WriteLine(elevGasit.Info());
            }
            else
            {
                Console.WriteLine("Elevul nu a fost gasit.");
            }
        }




        static Profesor CitireProfesor()
        {
            Console.Write("Introduceti numele profesorului: ");
            string nume = Console.ReadLine();
            Console.Write("Introduceti emailul: ");
            string email = Console.ReadLine();
            Console.Write("Introduceti materia: ");
            string materie = Console.ReadLine();

            Console.Write("Introduceti punctajul: ");
            int punctaj = Convert.ToInt32(Console.ReadLine());

            return new Profesor(nume, email, materie, punctaj);
        }

        static Elev CitireElev()
        {
            Console.Write("Introduceti numele elevului: ");
            string nume = Console.ReadLine();
            Console.Write("Introduceti emailul: ");
            string email = Console.ReadLine();
            Console.Write("Introduceti clasa: ");
            string clasa = Console.ReadLine();
            Console.Write("Introduceti varsta: ");
            int varsta = Convert.ToInt32(Console.ReadLine());

            return new Elev(nume, email, clasa, varsta);
        }

        static Administrator CitireAdministrator()
        {
            Console.Write("Introduceti numele administratorului: ");
            string nume = Console.ReadLine();
            Console.Write("Introduceti emailul administratorului: ");
            string email = Console.ReadLine();

            return new Administrator(nume, email);
        }
    }
}
