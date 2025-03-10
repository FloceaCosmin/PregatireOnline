using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PregatiriOnline
{
    public class Administrator : Utilizator
    {
        public List<Profesor> Profesori { get; private set; } = new List<Profesor>();
        public List<Elev> Elevi { get; private set; } = new List<Elev>();
        public Administrator(string nume, string email)
            : base(nume, email)
        {
        }
        public void AdaugaProfesor(Profesor profesor)
        {
            Profesori.Add(profesor);
        }
        public void AdaugaElev(Elev elev)
        {
            Elevi.Add(elev);
        }

        public string Info()
        {
            return "Amininstrator"+base.Info();
        }
    }
}

