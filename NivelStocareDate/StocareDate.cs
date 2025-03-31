using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Librarie;


namespace NivelStocareDate
{
    public class StocareDate

    {
        public List<Profesor> Profesori { get; private set; } = new List<Profesor>();
        public List<Elev> Elevi { get; private set; } = new List<Elev>();

        public void AdaugaProfesor(Profesor profesor)
        {
            Profesori.Add(profesor);
        }
        public void AdaugaElev(Elev elev)
        {
            Elevi.Add(elev);
        }
    }
}

