using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargDeMasini;

namespace TargDeMasini
{
    public class ManagerVanzari
    {
        private string caleFisier;

        public ManagerVanzari(string caleFisier)
        {
            this.caleFisier = caleFisier;
        }

        // Metoda pentru a adăuga o vânzare și a o scrie în fișier
        public void AdaugaVanzare(InregistrareVanzare vanzare)
        {
            using (StreamWriter writer = File.AppendText(caleFisier))
            {
                writer.WriteLine($"{vanzare.Masina.Producator},{vanzare.Masina.Model},{vanzare.Masina.An},{vanzare.Masina.Pret},{vanzare.Masina.Culoare},{vanzare.NumeCumparator},{vanzare.NumeVanzator},{vanzare.DataVanzare}");
            }
        }

        // Metoda pentru a citi vânzările din fișier
        public List<InregistrareVanzare> CitesteVanzari()
        {
            List<InregistrareVanzare> vanzari = new List<InregistrareVanzare>();

            if (File.Exists(caleFisier))
            {
                using (StreamReader reader = new StreamReader(caleFisier))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parti = line.Split(',');

                        if (parti.Length == 10)
                        {
                            string id = parti[0];
                            string producator = parti[1];
                            string model = parti[2];
                            int an = int.Parse(parti[3]);
                            decimal pret = decimal.Parse(parti[4]);
                            string culoare = parti[5];
                            string numeCumparator = parti[6];
                            string numeVanzator = parti[7];
                            DateTime dataVanzare = DateTime.Parse(parti[8]);

                            Masina masina = new Masina(model, producator, an, pret, culoare);
                            InregistrareVanzare vanzare = new InregistrareVanzare(masina, dataVanzare, numeCumparator, numeVanzator);
                            vanzari.Add(vanzare);
                        }
                        else
                        {
                            // Linia nu are suficiente câmpuri, ignorăm linia sau tratăm eroarea
                            Debug.WriteLine($"Linie incompletă: {line}");
                        }
                    }
                }
            }

            return vanzari;
        }


        public InregistrareVanzare ObtineUltimaVanzare()
        {
            InregistrareVanzare ultimaVanzare = null;
            if (File.Exists(caleFisier))
            {
                using (StreamReader reader = new StreamReader(caleFisier))
                {
                    string ultimaLinie = null;
                    string linie;
                    while ((linie = reader.ReadLine()) != null)
                    {
                        ultimaLinie = linie;
                    }

                    if (ultimaLinie != null)
                    {
                        string[] parti = ultimaLinie.Split(',');
                        string id = parti[0];
                        string producator = parti[1];
                        string model = parti[2];
                        int an = int.Parse(parti[3]);
                        decimal pret = decimal.Parse(parti[4]);
                        string culoare = parti[5];
                        string optiuni = parti[6];
                        string numeCumparator = parti[7];
                        string numeVanzator = parti[8];
                        DateTime dataVanzare = DateTime.Parse(parti[9]);

                        Masina masina = new Masina(model, producator, an, pret, culoare);
                        ultimaVanzare = new InregistrareVanzare(masina, dataVanzare, numeCumparator, numeVanzator);
                    }
                }
            }

            return ultimaVanzare;
        }

        public List<InregistrareVanzare> CautaDupaProducator(string producator)
        {
            List<InregistrareVanzare> vanzariPotrivite = new List<InregistrareVanzare>();

            if (File.Exists(caleFisier))
            {
                using (StreamReader reader = new StreamReader(caleFisier))
                {
                    string linie;
                    while ((linie = reader.ReadLine()) != null)
                    {
                        string[] parti = linie.Split(',');
                        if (parti.Length >= 5 && parti[1].Equals(producator, StringComparison.OrdinalIgnoreCase))
                        {
                            string id = parti[0];
                            string model = parti[2];
                            int an = int.Parse(parti[3]);
                            decimal pret = decimal.Parse(parti[4]);
                            string culoare = parti[5];
                            string optiuni = parti[6];
                            string numeCumparator = parti[7];
                            string numeVanzator = parti[8];
                            DateTime dataVanzare = DateTime.Parse(parti[9]);

                            Masina masina = new Masina(model, producator, an, pret, culoare);
                            InregistrareVanzare vanzare = new InregistrareVanzare(masina, dataVanzare, numeCumparator, numeVanzator);
                            vanzariPotrivite.Add(vanzare);
                        }
                    }
                }
            }

            return vanzariPotrivite;
        }
    }
}
