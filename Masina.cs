using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargDeMasini
{
    public class Masina
    {
        //public string Id { get; set; }
        public string Model { get; set; }
        public string Producator { get; set; }
        public int An { get; set; }
        public decimal Pret { get; set; }
        public string Culoare { get; set; }
        

        public Masina(string model, string producator, int an, decimal pret, string culoare)
        {
            //Id = id;
            Model = model;
            Producator = producator;
            An = an;
            Pret = pret;
            Culoare = culoare;
           
        }

        public override string ToString()
        {
            return $" Producator:{Producator}, Model: {Model}, Anul: {An}, Pret: {Pret:C}, Culoare: {Culoare}";
        }

        static Random random = new Random();

        static public string GenerareIdUnic()
        {
            // Generăm un șir de caractere aleatorii folosind numere și litere mici
            string caractere = "abcdefghijklmnopqrstuvwxyz0123456789";

            // Generăm un șir de 8 caractere
            char[] idCaractere = new char[8];
            for (int i = 0; i < 8; i++)
            {
                idCaractere[i] = caractere[random.Next(caractere.Length)];
            }

            // Convertim șirul de caractere într-un șir și îl returnăm
            return new string(idCaractere);
        }
    }
}
