using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TraitementsConditionnels
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Exercice 3.1 - Prise en main
            // Exercice 1 - Majorité
            //int ageUtilisateur;
            //String checkAge;
            //String pattern = @"^\d+$";
            //Regex regex = new Regex(pattern);
            //do
            //{
            //    Console.WriteLine("Qu'elle est votre âge : ");
            //    checkAge = Console.ReadLine();
            //} while (!regex.IsMatch(checkAge));
            //ageUtilisateur = Convert.ToInt32(checkAge);
            //if (ageUtilisateur >= 18)
            //{
            //    Console.WriteLine("Vous êtes majeur");
            //}
            //else
            //{
            //    Console.WriteLine("Vous êtes mineur (et pas de fond)");
            //}

            // Exercice 2 - Valeur Absolue
            //Double valeurAbsolue;
            //Console.WriteLine("Entez une chiffre et vous aurez sa valeur absolue : ");
            //valeurAbsolue = (Double)Convert.ToDouble(Console.ReadLine());
            //Console.WriteLine(Math.Abs(valeurAbsolue));

            // Exercice 3 - Admission
            //Double noteEleve;
            //Console.WriteLine("Entrez votre note : ");
            //noteEleve = Double.Parse(Console.ReadLine());
            //if (noteEleve < 8)
            //{
            //    Console.WriteLine("Ajourné ");
            //}
            //else if (noteEleve < 10)
            //{
            //    Console.WriteLine("Rattrapage");
            //}
            //else
            //{
            //    Console.WriteLine("Admis");
            //};

            // Exercice 4 - Assurances
            //Double montantDommage;
            //Double montantRemboursment;
            //Double montantFranchise;
            //Double franchise = 0.1;
            //Console.WriteLine("Indiquez le montant des dommages : ");
            //montantDommage = Double.Parse(Console.ReadLine());
            //montantFranchise = Math.Floor(montantDommage * franchise);
            //if (montantFranchise < 4000)
            //{
            //    montantRemboursment = montantDommage - montantFranchise;
            //    Console.WriteLine("Vous avez un dommage de " + montantDommage + "€, vous serez remboursé à hauteur de " + montantRemboursment + "€ avec une franchise de " + montantFranchise + "€");
            //}
            //else
            //{
            //    Console.WriteLine("Votre franchise dépasse 4000 €");
            //}

            // Exercice 5 - Valeur distinctes parmi 2
            //List<int> listNombre = new List<int>();
            //int nbSaisi;
            //int nbDistinctes = 1;
            //String checkNombre;
            //String pattern = @"^\d+$";
            //Regex regex = new Regex(pattern);
            //do
            //{
            //    do
            //    {
            //        Console.WriteLine("Saisir un nombre entier : ");
            //        checkNombre = Console.ReadLine();
            //    } while (!regex.IsMatch(checkNombre));

            //    nbSaisi = Convert.ToInt32(checkNombre);
            //    listNombre.Add(nbSaisi);
            //} while (listNombre.Count != 2);
            //for (int i = 0; i < listNombre.Count; i++)
            //{
            //    int nbDepart = listNombre[0];
            //    if (nbDepart != listNombre[i])
            //    {
            //        nbDistinctes++;
            //        nbDepart = listNombre[i];
            //    }
            //}
            //Console.WriteLine("Il y a " + nbDistinctes + "valeur(s) distincte(s)");

            // Exercice 6 - Plus petite valeur
            //List<int> listNombre = new List<int>();
            //int nbSaisi;
            //int nombrePetit = 0;
            //String checkNombre;
            //String pattern = @"^\d+$";
            //Regex regex = new Regex(pattern);
            //do
            //{
            //    do
            //    {
            //        Console.WriteLine("Saisir un nombre entier : ");
            //        checkNombre = Console.ReadLine();
            //    } while (!regex.IsMatch(checkNombre));

            //    nbSaisi = Convert.ToInt32(checkNombre);
            //    listNombre.Add(nbSaisi);
            //} while (listNombre.Count != 3);

            //for (int i = 0; i < listNombre.Count; i++)
            //{
            //    nombrePetit = listNombre[0];

            //    if (nombrePetit > listNombre[i])
            //    {
            //        nombrePetit = listNombre[i];
            //    }
            //};
            //Console.WriteLine("Le nombre le plus petit est : " + nombrePetit);

            // Exercice 3.2 - Switch
            // Exercice 7 - Calculatrice
            //Char op;
            //Double a, b;
            //String valeurA;
            //String valeurB;
            //String pattern = @"^\d+$";
            //Regex regex = new Regex(pattern);

            //static bool checkOp(Char o) // Fonction qui check le signe
            //{
            //    List<Char> operateur = new List<Char> { '+', '-', '*', '/' };
            //    foreach (Char c in operateur)
            //    {
            //        if (o == c)
            //        {
            //            return true;
            //        }
            //    }
            //    return false;
            //};

            //do
            //{
            //    Console.WriteLine("Valeur de a : ");
            //    valeurA = Console.ReadLine();
            //    Console.WriteLine("Valeur de b : ");
            //    valeurB = Console.ReadLine();
            //} while (!regex.IsMatch(valeurA) || !regex.IsMatch(valeurB)); // Check valeur de A et B

            //a = Double.Parse(valeurA);
            //b = Double.Parse(valeurB);

            //do
            //{
            //    Console.WriteLine("Signe de l'opération : ");
            //    op = Console.ReadLine()[0];
            //} while (!checkOp(op)); // Check le signe
            //switch (op)
            //{
            //    case '-':
            //        Console.WriteLine(a + " - " + b + " = " + (a - b));
            //        break;
            //    case '*':
            //        Console.WriteLine(a + " * " + b + " = " + (a * b));
            //        break;
            //    case '/':
            //        if (b != 0)
            //        {
            //            Console.WriteLine(a + " / " + b + " = " + (a / b));
            //            break;
            //        }
            //        else
            //        {
            //            Console.WriteLine("Diviser par 0 ! T'es pas malade !");
            //            break;
            //        };
            //    default:
            //        Console.WriteLine(a + " + " + b + " = " + (a + b));
            //        break;
            //}

            // Exercice 3.3 - L'échiquier
            // Exercice 8 - Couleurs
            //int i, j;
            //String valeurI;
            //String valeurJ;
            //String pattern = @"^\d+$";
            //Regex regex = new Regex(pattern);

            //do
            //{
            //    do
            //    {
            //        Console.WriteLine("Valeur de i (1 - 8) : ");
            //        valeurI = Console.ReadLine();
            //        Console.WriteLine("Valeur de j (1 - 8) : ");
            //        valeurJ = Console.ReadLine();
            //    } while (!regex.IsMatch(valeurI) || !regex.IsMatch(valeurJ)); // Check valeur de A et B

            //    i = int.Parse(valeurI);
            //    j = int.Parse(valeurJ);

            //} while (i < 1 || i > 8 || j < 1 || j > 8);

            //if ((i + j) % 2 == 0)
            //{
            //    Console.WriteLine("Noir");
            //}
            //else
            //{
            //    Console.WriteLine("Blanc");
            //}

            // Exercice 9 - Cavaliers
            //int i, j, i2, j2;
            //String valeurI;
            //String valeurI2;
            //String valeurJ;
            //String valeurJ2;
            //String pattern = @"^\d+$";
            //Regex regex = new Regex(pattern);

            //do
            //{
            //    do
            //    {
            //        Console.WriteLine("Valeur de i (1 - 8) : ");
            //        valeurI = Console.ReadLine();
            //        Console.WriteLine("Valeur de j (1 - 8) : ");
            //        valeurJ = Console.ReadLine();
            //    } while (!regex.IsMatch(valeurI) || !regex.IsMatch(valeurJ)); // Check si c'est bien un chiffre

            //    i = int.Parse(valeurI);
            //    j = int.Parse(valeurJ);

            //} while (i < 1 || i > 8 || j < 1 || j > 8); // Check si il est bien dans l'air de jeu

            //Console.WriteLine("Coordonnée de la pièce : " + i + " , " + j);

            //do
            //{
            //    do
            //    {
            //        Console.WriteLine("Valeur de i2 (1 - 8) : ");
            //        valeurI2 = Console.ReadLine();
            //        Console.WriteLine("Valeur de j2 (1 - 8) : ");
            //        valeurJ2 = Console.ReadLine();
            //    } while (!regex.IsMatch(valeurI2) || !regex.IsMatch(valeurJ2)); // Check si c'est bien un chiffre

            //    i2 = int.Parse(valeurI2);
            //    j2 = int.Parse(valeurJ2);

            //} while (i2 < 1 || i2 > 8 || j2 < 1 || j2 > 8); // Check si il est bien dans l'air de jeu
            //Console.WriteLine("Coordonnée de déplacement de la pièce : " + i2 + " , " + j2);

            //if (Math.Abs(i - i2) == 2 && Math.Abs(j - j2) == 1 || Math.Abs(i - i2) == 1 && Math.Abs(j - j2) == 2)
            //{
            //    Console.WriteLine("Déplacement du cavalier ok");
            //}
            //else
            //{
            //    Console.WriteLine("Déplacement du cavalier interdit");
            //}

            // Exercice 10 - Autres pièce
            //int choixPiece;
            //String valeurPiece;
            //int i, j, i2, j2;
            //String valeurI;
            //String valeurI2;
            //String valeurJ;
            //String valeurJ2;
            //String pattern = @"^\d+$";
            //Regex regex = new Regex(pattern);

            //// Choix de la pièce
            //do
            //{
            //    do
            //    {
            //        Console.WriteLine("Choisir une pièce (0: cavalier, 1: tour, 2: fou, 3: dame, 4: roi): ");
            //        valeurPiece = Console.ReadLine();

            //    } while (!regex.IsMatch(valeurPiece)); // Check si c'est bien 

            //    choixPiece = int.Parse(valeurPiece);

            //} while (choixPiece < 0 || choixPiece > 4);

            //// Coordonnée de la pièce
            //do
            //{
            //    do
            //    {
            //        Console.WriteLine("Valeur de i (1 - 8) : ");
            //        valeurI = Console.ReadLine();
            //        Console.WriteLine("Valeur de j (1 - 8) : ");
            //        valeurJ = Console.ReadLine();
            //    } while (!regex.IsMatch(valeurI) || !regex.IsMatch(valeurJ)); // Check si c'est bien un chiffre

            //    i = int.Parse(valeurI);
            //    j = int.Parse(valeurJ);

            //} while (i < 1 || i > 8 || j < 1 || j > 8); // Check si il est bien dans l'air de jeu
            //Console.WriteLine("Coordonnée de la pièce : " + i + " , " + j);

            //// Coordonnée de déplacement
            //do
            //{
            //    do
            //    {
            //        Console.WriteLine("Valeur de i2 (1 - 8) : ");
            //        valeurI2 = Console.ReadLine();
            //        Console.WriteLine("Valeur de j2 (1 - 8) : ");
            //        valeurJ2 = Console.ReadLine();
            //    } while (!regex.IsMatch(valeurI2) || !regex.IsMatch(valeurJ2)); // Check si c'est bien un chiffre

            //    i2 = int.Parse(valeurI2);
            //    j2 = int.Parse(valeurJ2);

            //} while (i2 < 1 || i2 > 8 || j2 < 1 || j2 > 8); // Check si il est bien dans l'air de jeu


            //// Déplacement en fonction de la pièce choisie
            //switch (choixPiece)
            //{
            //    // tour
            //    case 1:
            //        if (Math.Abs(i - i2) == 0 && Math.Abs(j - j2) != 0 || Math.Abs(i - i2) != 0 && Math.Abs(j - j2) == 0)
            //        {
            //            Console.WriteLine("Déplacement de la tour OK");
            //            Console.WriteLine("Nouvelle coordonnée : " + i2 + " , " + j2);
            //        }
            //        else
            //        {
            //            Console.WriteLine("Déplacement interdit");
            //        }
            //        break;
            //    // fou
            //    case 2:
            //        if (Math.Abs(i - i2) == 1 && Math.Abs(j - j2) == 1)
            //        {
            //            Console.WriteLine("Déplacement du fou OK");
            //            Console.WriteLine("Nouvelle coordonnée : " + i2 + " , " + j2);
            //        }
            //        else
            //        {
            //            Console.WriteLine("Déplacement interdit");
            //        }
            //        break;
            //    // dame
            //    case 3:
            //        if (Math.Abs(i - i2) == 0 && Math.Abs(j - j2) != 0 || Math.Abs(i - i2) != 0 && Math.Abs(j - j2) == 0 || Math.Abs(i - i2) == 1 && Math.Abs(j - j2) == 1)
            //        {
            //            Console.WriteLine("Déplavcement de la dame OK");
            //            Console.WriteLine("Nouvelle coordonnée : " + i2 + " , " + j2);
            //        }
            //        else
            //        {
            //            Console.WriteLine("Déplacement interdit");
            //        }
            //        break;
            //    // roi
            //    case 4:
            //        if (Math.Abs(i - i2) + Math.Abs(j - j2) == 1)
            //        {
            //            Console.WriteLine("Déplavcement du roi OK");
            //            Console.WriteLine("Nouvelle coordonnée : " + i2 + " , " + j2);
            //        }
            //        else
            //        {
            //            Console.WriteLine("Déplacement interdit");
            //        }
            //        break;
            //    // cavalier
            //    default:
            //        if (Math.Abs(i - i2) == 2 && Math.Abs(j - j2) == 1 || Math.Abs(i - i2) == 1 && Math.Abs(j - j2) == 2)
            //        {
            //            Console.WriteLine("Déplacement du cavalier ok");
            //            Console.WriteLine("Nouvelle coordonnée : " + i + " , " + j);
            //        }
            //        else
            //        {
            //            Console.WriteLine("Déplacement du cavalier interdit");
            //        }
            //        break;
            //}

            // Exercice 3.4 - Heures et dates
            // Exercice 11 - Opérations sur les heures
        }
    }
}
