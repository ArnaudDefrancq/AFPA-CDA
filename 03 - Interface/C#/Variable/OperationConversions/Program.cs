using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationConversions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exercice 1 - Successeur
            //Char caractere;
            //int caractereUnicode;
            //Console.WriteLine("Entrez un caractère : ");
            //caractere = Console.ReadLine()[0];
            //caractereUnicode = Convert.ToUInt16(caractere);
            //Console.WriteLine("UNICODE du caractère suivant = " + (caractereUnicode + 1));

            // Exercice 2 - Code UNICDE
            //for (Char i = '0'; i <= '9'; i++)
            //{
            //    int caractereUnicode;
            //    caractereUnicode = Convert.ToUInt16(i);
            //    Console.WriteLine(caractereUnicode);
            //}

            // Exercice 3 - Cartons et Camions
            //Double nbKiloCarton;
            //Double nbKiloMarchandise;
            //int nbCarton;
            //Console.WriteLine("Combien de kilo par carton : ");
            //nbKiloCarton = (Double) Convert.ToDouble(Console.ReadLine());
            //Console.WriteLine("Combien de kilo max pour le camion : ");
            //nbKiloMarchandise = (Double) Convert.ToDouble(Console.ReadLine());
            //nbCarton =  (int)(nbKiloMarchandise / nbKiloCarton);
            //Console.WriteLine("Voius pouvez mettre : " + nbCarton+ " cartons dans le camion");

            // Ecercice 4 - Pièce de monnaie Refaire cet exo avec une list
            //Double somme; // somme saisie 
            //int nbPiece05 = 0;
            //int nbPiece01 = 0;
            //int nbPiece001 = 0;
            //do // demande une somme
            //{
            //    Console.WriteLine("Entrez une somme comprise entre 0 et 0,99");
            //    somme = (Double)Convert.ToDouble(Console.ReadLine()); //Conversion en Double
            //} while (somme <= 0.0 || somme >= 1.0);
            //while (somme >= 0.5)
            //{
            //    somme -= 0.5;
            //    nbPiece05++;
            //};
            //while (somme >= 0.1)
            //{
            //    somme -= 0.1;
            //    nbPiece01++;
            //};
            //while (somme >= 0.1)
            //{
            //    somme -= 0.01;
            //    nbPiece001++;
            //};
            //Console.WriteLine("Il y a " + nbPiece05 + " pièce de 0.5, " + nbPiece01 + " pièce de 0.1 et " + nbPiece001 + " pièce de 0.01");
        }
    }
}
