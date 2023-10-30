using System;

namespace Boucles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 4 - Boucles
            // 4.1 - Compréhension
            // Exercice 1 
            //int a = 1, b = 0, n = 5;
            //while (a <= n)
            //{
            //    b += a++;
            //    Console.WriteLine("a : " + a + ", " + " b :" + b);
            //};

            // Exercice 2
            //int b = 0, c = 0, d = 3, m = 3, n = 4;

            //for (int a = 0; a < m; a++)
            //{
            //    d = 0;

            //    for (b = 0; b < n; b++)
            //    {
            //        d += b;
            //        c += d;
            //    }
            //    Console.WriteLine("a : " + a + ", b : " + b + " , c :" + c + " , d :" + d + " . ");
            //}

            // Exercice 3
            //int a, b, c, d;
            //a = 1; 
            //b = 2;
            //c = a / b;
            //d = (a == b) ? 3 : 4;
            //Console.WriteLine(c + " , " + d + " . ");
            //a = ++b;
            //b %= 3;
            //Console.WriteLine(a + " , " + b + " . ");
            //b = 1;
            //for (a = 0; a <= 10; a++)
            //    c = ++b;
            //Console.WriteLine(a + " , " + b + " , " + c + " , " + d + " . ");

            // 4.2 - Utilisation de toutes les boucles
            // Exercice 4 - Compte à rebours 
            //int nb;
            //do
            //{
            //    Console.WriteLine("Choisir un nb numérique positive");

            //} while (!int.TryParse(Console.ReadLine(), out nb) || nb < 0);

            //for (int i = nb; i >= 0; i--)
            //{
            //    Console.WriteLine(i);
            //}

            // Exercice 5 - Factorielle
            //int nbFactorielle;
            //int somme = 1;
            //do
            //{
            //    Console.WriteLine("Choisir un nb");
            //} while (!int.TryParse(Console.ReadLine(), out nbFactorielle) || nbFactorielle < 0);

            //for (int i = 1; i <= nbFactorielle; i++)
            //{
            //    somme *= i;
            //}
            //Console.WriteLine("La factorielle de " + nbFactorielle + " est " + somme);

            // 4.3 - Choix de la boucle la plus appropriée
        }
    }
}
