using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PregatiriOnline
{
    public class Profesor
    {
        public string Nume;
        public string Materie;
        public string Email;
        public int NrElevi;
        public int Punctaj;

        public Profesor(string nume, string materie, string email, int nrElevi, int punctaj)
        {
            Nume = nume;
            Materie = materie;
            Email = email;
            NrElevi = nrElevi;
            Punctaj = punctaj;
        }
        public Profesor()
        { }
        public void CitireProf()
        {
            Console.WriteLine("Introduceti numele Profesorului:");
            Nume = Console.ReadLine();
            Console.WriteLine("Introduceti materia Profesorului:");
            Materie = Console.ReadLine();
            Console.WriteLine("Introduceti emailul Profesorului:");
            Email = Console.ReadLine();
            Console.WriteLine("Introduceti numarul elevilor:");
            NrElevi = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Introduceti punctajul Profesorului:");
            Punctaj = Convert.ToInt32(Console.ReadLine());


        }

        public void AfisareProf()
        {
            Console.WriteLine($"Nume Profesor:{Nume}, Materie:{Materie}, Email Profesor:{Email}, NrElevi:{NrElevi}, Punctaj:{Punctaj}");
        }
    }
}

