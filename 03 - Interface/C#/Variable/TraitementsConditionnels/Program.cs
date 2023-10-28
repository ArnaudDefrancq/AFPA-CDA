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
            List<int> listNombre = new List<int>();
            int nbSaisi;
            int nombrePetit;
            String checkNombre;
            String pattern = @"^\d+$";
            Regex regex = new Regex(pattern);
            do
            {
                do
                {
                    Console.WriteLine("Saisir un nombre entier : ");
                    checkNombre = Console.ReadLine();
                } while (!regex.IsMatch(checkNombre));

                nbSaisi = Convert.ToInt32(checkNombre);
                listNombre.Add(nbSaisi);
            } while (listNombre.Count != 3);

            for (int i = 0; i < listNombre.Count; i++)
            {
                nombrePetit = listNombre[0];

                if (nombrePetit > listNombre[i])
                {

                }
            }
        }
    }
}
