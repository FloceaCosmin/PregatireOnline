using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PregatiriOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Administrator admin = new Administrator("Cosmin", "cosmin@yahoo.com");
            AfisareAdministrator(admin);

            Profesor prof1 = new Profesor("Matei", "matei@yahoo.com", "Mate", 0);
            Profesor prof2 = CitireProfesor();

            admin.AdaugaProfesor(prof1);
            admin.AdaugaProfesor(prof2);

            
            Console.WriteLine("\nLista Profesorilor:");
            AfisareProfesori(admin);


            Elev elev1 = new Elev("Marcu", "marcu@yahoo.com", "IV", 12);
            Elev elev2 = CitireElev();

            
            Console.WriteLine("\nLista Elevilor:");
            AfisareElev(elev1);
            AfisareElev(elev2);
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

        static void AfisareProfesori(Administrator admin)
        {
            foreach (var profesor in admin.GetProfesori())
            {
                Console.WriteLine(profesor.Info());
            }
        }
        static void AfisareAdministrator(Administrator admin)
        {
            Console.WriteLine(admin.Info());
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

        static void AfisareElev(Elev elev)
        {
            Console.WriteLine(elev.Info());
        }
    }
}
