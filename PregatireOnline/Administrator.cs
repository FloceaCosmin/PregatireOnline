using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PregatiriOnline
{
    public class Administrator : Utilizator
    {
        private List<Profesor> profesori = new List<Profesor>();
        public Administrator(string nume, string email)
            : base(nume, email)
        {
        }
        public void AdaugaProfesor(Profesor profesor)
        {
            profesori.Add(profesor);
        }

        public List<Profesor> GetProfesori()
        {
            return profesori;
        }

        public string Info()
        {
            return base.Info()+"(Administrator)";
        }
    }
}

