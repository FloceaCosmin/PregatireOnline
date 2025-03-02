using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PregatiriOnline
{
    public class Administrator
    {

        public string Nume;
        public string Email;

        public Administrator(string nume, string email)
        {
            Nume = nume;
            Email = email;
        }

        private List<Profesor> profesori = new List<Profesor>();

        public void AdaugaProfesor(Profesor profesor)
        {
            profesori.Add(profesor);
        }

        public List<Profesor> GetProfesori()
        {
            return profesori;
        }
    }
}
