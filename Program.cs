using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargDeMasini;

namespace TargDeMasini
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string caleFisier = "vanzari.txt";
            ManagerVanzari managerVanzari = new ManagerVanzari(caleFisier);

            int optiune;
            do
            {
                Console.WriteLine("Meniu:\n");
                Console.WriteLine("1. Adăugare vânzare");
                Console.WriteLine("2. Afișare vânzări");
                Console.WriteLine("3. Afișare ultima vânzare");
                Console.WriteLine("4. Curățare consolă");
                Console.WriteLine("5. Căutare după producător");
                Console.WriteLine("6. Ieșire\n");
                Console.Write("Introduceți opțiunea: ");
                if (int.TryParse(Console.ReadLine(), out optiune))
                {
                    switch (optiune)
                    {
                        case 1:
                            AdaugaVanzareDeLaConsola(managerVanzari);
                            break;
                        case 2:
                            AfișareVanzări(managerVanzari);
                            break;
                        case 3:
                            AfișareUltimaVanzare(managerVanzari);
                            break;
                        case 4:
                            Console.Clear();
                            break;
                        case 5:
                            CautaDupaProducator(managerVanzari);
                            break;
                        case 6:
                            Console.WriteLine("La revedere!");
                            break;
                        default:
                            Console.WriteLine("Opțiune invalidă. Vă rugăm să introduceți o opțiune validă.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opțiune invalidă. Vă rugăm să introduceți o opțiune validă.");
                }

            } while (optiune != 6);
        }

        static void AfișareUltimaVanzare(ManagerVanzari managerVanzari)
        {
            InregistrareVanzare ultimaVanzare = managerVanzari.ObtineUltimaVanzare();
            if (ultimaVanzare != null)
            {
                Console.WriteLine("Ultima vânzare:");
                Console.WriteLine(ultimaVanzare);
            }
            else
            {
                Console.WriteLine("Nu există vânzări înregistrate.");
            }
        }

        static void AdaugaVanzareDeLaConsola(ManagerVanzari managerVanzari)
        {
            Console.WriteLine("Introduceți detaliile vânzării:");

            // Validarea producătorului
            string producator;
            do
            {
                Console.Write("Producător: ");
                producator = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(producator))
                {
                    Console.WriteLine("Producătorul nu poate fi gol. Vă rugăm să introduceți un producător valid.");
                }
            } while (string.IsNullOrWhiteSpace(producator));

            // Validarea modelului
            string model;
            do
            {
                Console.Write("Model: ");
                model = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(model))
                {
                    Console.WriteLine("Modelul nu poate fi gol. Vă rugăm să introduceți un model valid.");
                }
            } while (string.IsNullOrWhiteSpace(model));

            // Validarea anului
            int an;
            do
            {
                Console.Write("Anul fabricației: ");
                if (!int.TryParse(Console.ReadLine(), out an) || an < 1900 || an > DateTime.Now.Year)
                {
                    Console.WriteLine("Anul trebuie să fie un număr întreg între 1900 și anul curent.");
                }
            } while (an < 1900 || an > DateTime.Now.Year);

            // Validarea prețului
            decimal pret;
            do
            {
                Console.Write("Preț: ");
                if (!decimal.TryParse(Console.ReadLine(), out pret) || pret <= 0)
                {
                    Console.WriteLine("Prețul trebuie să fie un număr pozitiv.");
                }
            } while (pret <= 0);

            // Validarea culorii
            string culoare;
            do
            {
                Console.Write("Culoare: ");
                culoare = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(culoare))
                {
                    Console.WriteLine("Culoarea este obligatorie. Vă rugăm să introduceți un culoare validă.");
                }
            } while (string.IsNullOrWhiteSpace(culoare));

            // Validarea optiunilor
            string optiuni;
            do
            {
                Console.Write("Optiuni: ");
                optiuni = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(optiuni))
                {
                    Console.WriteLine("Optiunile sunt obligatorii. Vă rugăm să introduceți optiuni valide.");
                }
            } while (string.IsNullOrWhiteSpace(optiuni));


            // Validarea numelui cumpărătorului
            string numeCumparator;
            do
            {
                Console.Write("Numele cumpărătorului: ");
                numeCumparator = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(numeCumparator))
                {
                    Console.WriteLine("Numele cumpărătorului nu poate fi gol. Vă rugăm să introduceți un nume valid.");
                }
            } while (string.IsNullOrWhiteSpace(numeCumparator));

            // Validarea numelui vânzătorului
            string numeVanzator;
            do
            {
                Console.Write("Numele vânzătorului: ");
                numeVanzator = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(numeVanzator))
                {
                    Console.WriteLine("Numele vânzătorului nu poate fi gol. Vă rugăm să introduceți un nume valid.");
                }
            } while (string.IsNullOrWhiteSpace(numeVanzator));

            string id = Masina.GenerareIdUnic();

            InregistrareVanzare vanzare = new InregistrareVanzare(new Masina(model, producator, an, pret, culoare), DateTime.Now, numeCumparator, numeVanzator);
            managerVanzari.AdaugaVanzare(vanzare);
            Console.WriteLine("Vânzare adăugată cu succes.");
        }

        static void AfișareVanzări(ManagerVanzari managerVanzari)
        {
            List<InregistrareVanzare> vanzari = managerVanzari.CitesteVanzari();
            Console.WriteLine("Vânzări:\n");
            foreach (InregistrareVanzare vanzare in vanzari)
            {
                Console.WriteLine(vanzare);
                Console.Write("---------------------------------------------------------------------\n");
            }
        }

        static void CautaDupaProducator(ManagerVanzari managerVanzari)
        {
            Console.Write("Introduceți producătorul pentru căutare: ");
            string producator = Console.ReadLine();

            List<InregistrareVanzare> vanzariPotrivite = managerVanzari.CautaDupaProducator(producator);

            if (vanzariPotrivite.Count > 0)
            {
                Console.WriteLine($"Vânzări pentru producătorul '{producator}':");
                foreach (InregistrareVanzare vanzare in vanzariPotrivite)
                {
                    Console.WriteLine(vanzare);
                }
            }
            else
            {
                Console.WriteLine($"Nu s-au găsit vânzări pentru producătorul '{producator}'.");
            }
        }
    }
}
