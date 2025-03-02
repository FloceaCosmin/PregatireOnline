using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PregatiriOnline
{
    public class Elev
    {
        public string Nume { get; set; }
        public string Clasa { get; set; }
        public int Varsta { get; set; }
        public string Email { get; set; }

        public Elev(string nume, string clasa, int varsta, string email)
        {
            Nume = nume;
            Clasa = clasa;
            Varsta = varsta;
            Email = email;
        }
        public Elev() { }
        public void CitireElev()
        {
            Console.WriteLine("Introdu numele elevului:");
            Nume = Console.ReadLine();
            Console.Write("Introdu clasa elevului: ");
            Clasa = Console.ReadLine();
            Console.Write("Introdu vârsta elevului: ");
            Varsta = Convert.ToInt32(Console.ReadLine());
            Console.Write("Introdu emailul elevului: ");
            Email = Console.ReadLine();
        }
        public void AfisareElev()
        {
            Console.WriteLine($"Numele Elevului: {Nume}, clasa: {Clasa}, varsta:{Varsta} ani, email:{Email}");
        }
    }
}
