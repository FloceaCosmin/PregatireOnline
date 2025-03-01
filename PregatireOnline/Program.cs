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
            Administrator admin = new Administrator();
            Profesor prof1 = new Profesor("Ion Popescu", "Matematică", "ion@email.com");

            admin.AdaugaProfesor(prof1);

            Elev elev1 = new Elev("Maria Ionescu");

            Console.WriteLine("Clasele au fost create cu succes!");
        }
    }
}
