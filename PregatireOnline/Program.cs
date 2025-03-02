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
            Administrator admin = new Administrator("Cosmin","cosmin@yahoo,.com");
            Profesor prof1 = new Profesor("Ion Popescu", "Matematică", "ionP@yahoo.com",4,9);
            Profesor prof2 = new Profesor();
            prof2.CitireProf();
            prof1.AfisareProf();
            prof2.AfisareProf();

            admin.AdaugaProfesor(prof1);
            admin.AdaugaProfesor(prof2);
            foreach(var  prof in admin.GetProfesori())
            {
                Console.WriteLine($"Nume: {prof.Nume}, Materie: {prof.Materie}, Email: {prof.Email}");
            }

            Elev elev1 = new Elev("Maria Ionescu","IV",12,"mariaI@yahoo.com");
            Elev elev2= new Elev();
            elev2.CitireElev();
            elev1.AfisareElev();
            elev2.AfisareElev();
        }
         
    }
}
