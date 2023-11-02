using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace Boucles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 4 - Boucles
            // 4.1 - Compréhension
            // Exercice 1 
            // a: 2,  b: 1
            // a: 3,  b: 3
            // a: 4,  b: 6
            // a: 5,  b: 10
            // a: 6,  b: 15
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
            // a : 2, b: 4 , c: 30 , d: 6.

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

            // 4.2 - Utilisation de toutes les boucles (refaire avec toutes les boucles possible)
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
            // Exercice 6 - Table de multiplication
            //int nbChoisi;

            //do
            //{
            //    Console.WriteLine("Choisir un nb et vous aurez sa table de multiplication : ");
            //} while (!int.TryParse(Console.ReadLine(), out nbChoisi));

            //for (int i = 0; i < 11; i++)
            //{
            //    Console.WriteLine(nbChoisi + " * " + i + " = " + (nbChoisi * i));
            //}

            // Exercice 7 - Tables de multiplications

            //Console.Write("/|");
            //for (int i = 0; i < 11; i++)
            //{
            //    Console.Write(i + "|");
            //}
            //Console.Write('\n');
            //for (int i = 0; i < 11; i++)
            //{
            //    Console.Write(i);
            //    Console.Write("|");
            //    for (int j = 0; j < 11; j++)
            //    {
            //        int result = i * j;
            //        Console.Write(result + "|");
            //    }
            //    Console.Write('\n');
            //}

            // Exercice 8 - Puissance
            //int b, n;
            //String valeurB, valeurN;

            //do
            //{
            //    Console.WriteLine("Saisir un nombre 'b' : ");
            //    valeurB = Console.ReadLine();
            //    Console.WriteLine("Saisir un nombre 'n' positif : ");
            //    valeurN = Console.ReadLine();
            //} while (!int.TryParse(valeurB, out b) || !int.TryParse(valeurN, out n) || n < 0);

            //Double result = Math.Pow(b, n);

            //Console.WriteLine("Resultat de " + b + " puissance " + n + " = " + result);

            // Exercice 9 - Joli carré
            //int saisirNb;

            //do
            //{
            //    Console.WriteLine("Saisir un nb (positif) : ");
            //} while (!int.TryParse(Console.ReadLine(), out saisirNb) || saisirNb < 0);
            //Console.WriteLine("n = " + saisirNb);

            //for (int i = 0; i < saisirNb; i++)
            //{
            //    Console.Write(" x ");
            //    for (int j = 0; j < saisirNb - 1; j++)
            //    {
            //        Console.Write(" x ");
            //    }
            //    Console.Write("\n");
            //}

            // 4.4 - Extension de la calculatrice
            // Exercice 10 - Calculatrice de poche / Exercice 11 - Puissance / Exercice 12 - Opérations unaires
            //Double a, b;
            //Char op;
            //String valeurA, valeurB;
            //List<Char> operateur = new List<Char> { '+', '-', '*', '/', '=', '$', 'r', 'f' };
            //do
            //{
            //    Console.WriteLine("Saisir la valeur de a : ");
            //    valeurA = Console.ReadLine();

            //} while (!Double.TryParse(valeurA, out a));



            //do
            //{
            //    Double result;
            //    // Demande l'opérateur
            //    do
            //    {
            //        Console.WriteLine("Saisir un signe opérateur (' = ' pour sortir) : ");
            //        op = Console.ReadLine()[0];
            //    } while (!operateur.Contains(op));

            //    if (op != '=')
            //    {
            //        if (op == 'r')
            //        {
            //            result = Math.Sqrt(a);
            //            Console.WriteLine(result);
            //            a = result;
            //        }
            //        else if (op == 'f')
            //        {
            //            Double nbTour = a;
            //            Double facto = 1;
            //            for (Double i = 1; i <= nbTour; i++)
            //            {
            //                facto *= i;
            //            }
            //            Console.WriteLine(facto);
            //            a = facto;
            //        }
            //        else
            //        {
            //            do
            //            {
            //                Console.WriteLine("Saisir un nombre : ");
            //                valeurB = Console.ReadLine();
            //            } while (!Double.TryParse(valeurB, out b));


            //            // Les opérations de calculs
            //            switch (op)
            //            {
            //                case '-':
            //                    result = (a - b);
            //                    Console.WriteLine(result);
            //                    a = result;
            //                    break;
            //                case '*':
            //                    result = (a * b);
            //                    Console.WriteLine(result);
            //                    a = result;
            //                    break;
            //                case '/':
            //                    if (b != 0)
            //                    {
            //                        result = (a / b);
            //                        Console.WriteLine(result);
            //                        a = result;
            //                        break;
            //                    }
            //                    else
            //                    {
            //                        Console.WriteLine("Diviser par 0 ! T'es pas malade !");
            //                        break;
            //                    };
            //                case '$':
            //                    result = Math.Pow(a, Math.Floor(b));
            //                    Console.WriteLine(result);
            //                    a = result;
            //                    break;
            //                default:
            //                    result = (a + b);
            //                    Console.WriteLine(result);
            //                    a = result;
            //                    break;

            //            }
            //        }
            //    }
            //} while (op != '=');
        }
    }
}
