using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargDeMasini
{
    public class InregistrareVanzare
    {
        public Masina Masina { get; set; }
        public DateTime DataVanzare { get; set; }
        public string NumeCumparator { get; set; }
        public string NumeVanzator { get; set; }

        public InregistrareVanzare(Masina masina, DateTime dataVanzare, string numeCumparator, string numeVanzator)
        {
            Masina = masina;
            DataVanzare = dataVanzare;
            NumeCumparator = numeCumparator;
            NumeVanzator = numeVanzator;
        }

        public override string ToString()
        {
            return $"Vândut: {Masina}, Cumpărător: {NumeCumparator}, Vânzător: {NumeVanzator}, Data vânzării: {DataVanzare}";
        }
    }
}
