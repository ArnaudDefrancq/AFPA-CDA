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
            //do
            //{
            //    Console.WriteLine("Quel est votre âge : ");
            //} while (!int.TryParse(Console.ReadLine(), out ageUtilisateur));

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
            //List<Double> listNombre = new List<Double>();
            //Double nbSaisi;
            //Double nbPetit;
            //do
            //{
            //    do
            //    {
            //        Console.WriteLine("Saisir un nombre entier : ");

            //    } while (!Double.TryParse(Console.ReadLine(), out nbSaisi));

            //    listNombre.Add(nbSaisi);

            //    nbPetit = listNombre[0];

            //    if (listNombre.Count > 1)
            //    {
            //        if (nbSaisi < nbPetit)
            //        {
            //            nbPetit = nbSaisi;
            //        }

            //    }

            //} while (listNombre.Count != 3);

            //Console.WriteLine("Le nombre le plus petit est : " + nbPetit);

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
            //do
            //{
            //    do
            //    {
            //        Console.WriteLine("Valeur de i (1 - 8) : ");
            //        valeurI = Console.ReadLine();
            //        Console.WriteLine("Valeur de j (1 - 8) : ");
            //        valeurJ = Console.ReadLine();
            //    } while (!int.TryParse(valeurI, out i) || !int.TryParse(valeurJ, out j)); // Check valeur de i et j
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
            //        if (Math.Abs(i - i2) == Math.Abs(j - j2))
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
            //int heureDebut, minuteDebut, heureFin, minuteFin;
            //String pattern = @"^\d+$";
            //Regex regex = new Regex(pattern);
            //String hDep, mDep, hFin, mFin;
            //do
            //{
            //    do
            //    {
            //        Console.WriteLine("Entrez une heure de début : ");
            //        hDep = Console.ReadLine();

            //        Console.WriteLine("Entrez les minutes de début: ");
            //        mDep = Console.ReadLine();

            //        Console.WriteLine("Entrez une heure de fin : ");
            //        hFin = Console.ReadLine();

            //        Console.WriteLine("Entrez les minutes de fin: ");
            //        mFin = Console.ReadLine();

            //    } while (!regex.IsMatch(hDep) || !regex.IsMatch(mDep) || !regex.IsMatch(hFin) || !regex.IsMatch(mFin));
            //    heureDebut = int.Parse(hDep);
            //    minuteDebut = int.Parse(mDep);
            //    heureFin = int.Parse(hFin);
            //    minuteFin = int.Parse(mFin);
            //} while (heureDebut < 0 || heureDebut > 23 || minuteDebut < 0 || minuteDebut > 59 || heureFin < 0 || heureFin > 23 || minuteFin < 0 || minuteFin > 59);

            //Console.WriteLine(heureDebut + ":" + minuteDebut + " heure début " + heureFin + ":" + minuteFin + " heure de fin");


            //if (heureDebut > heureFin || heureDebut == heureFin && minuteDebut > minuteFin)
            //{
            //    Console.WriteLine("Temps invalide");
            //}
            //else
            //{
            //    int heureDiff = heureFin - heureDebut;
            //    int minuteDiff = minuteFin - minuteDebut;

            //    if (minuteDiff < 0)
            //    {
            //        heureDiff -= 1;
            //        minuteDiff = 60 - Math.Abs(minuteDiff);
            //    }
            //    Console.WriteLine(heureDiff + ":" + minuteDiff + " de différence");
            //}

            // Exercice 12 - Lejour d'après
            //int jour, mois, annee;
            //int jourPlus, moisPlus, anneePlus;
            //String valeurJour, valeurMois, valeurAnnee;
            //do
            //{
            //    do
            //    {
            //        Console.WriteLine("Entrez un jour : ");
            //        valeurJour = Console.ReadLine();

            //        Console.WriteLine("Entrez un mois: ");
            //        valeurMois = Console.ReadLine();

            //        Console.WriteLine("Entrez une année : ");
            //        valeurAnnee = Console.ReadLine();
            //    } while (!int.TryParse(valeurJour, out jour) || !int.TryParse(valeurMois, out mois) || !int.TryParse(valeurAnnee, out annee));
            //} while (jour < 0 || jour > 31 || mois < 1 || mois > 12);

            //static bool estBissextile(int an)
            //{
            //    if (an % 4 == 0)
            //    {
            //        if (an % 100 == 0 && an % 400 != 0)
            //        {
            //            return false;
            //        }
            //    }
            //    else if (an % 4 == 0)
            //    {
            //        if (an % 100 == 0 && an % 400 == 0)
            //        {
            //            return true;
            //        }

            //    }
            //    return false;
            //}

            //Console.WriteLine(jour + " " + mois + " " + annee);

            //moisPlus = mois;
            //anneePlus = annee;

            //if (jour == 31 && 12 % mois == 0)
            //{
            //    jourPlus = 1;
            //    if (mois == 12)
            //    {
            //        moisPlus = 1;
            //        anneePlus = annee + 1;
            //    }
            //    else
            //    {
            //        moisPlus = mois + 1;
            //    }
            //}
            //else if (jour == 28 && mois == 2 && estBissextile(annee))
            //{
            //    jourPlus = 1;
            //    moisPlus = 3;
            //}
            //else if (jour == 29 && mois == 2)
            //{
            //    jourPlus = 1;
            //    moisPlus = 3;
            //}
            //else
            //{
            //    jourPlus = jour + 1;
            //}

            //Console.WriteLine(jourPlus + " " + moisPlus + " " + anneePlus);

            // 3.5 - Intervalles et rectangles
            // Exercice 13 - Intervalles bien formés 
            Double a, b;
            Double x;
            String valeurA, valeurB;

            do
            {
                Console.WriteLine("valeur de A : ");
                valeurA = Console.ReadLine();

                Console.WriteLine("Valeur de B : ");
                valeurB = Console.ReadLine();
            } while (!Double.TryParse(valeurA, out a) || !Double.TryParse(valeurB, out b));

            Console.WriteLine("intervalle : " + a + b);

            // Exercice 14 - Appartenance
            do
            {
                Console.WriteLine("Valeur de x : ");
            } while (!Double.TryParse(Console.ReadLine(), out x));

            if (a < x && x < b)
            {
                Console.WriteLine("X est dans l'intervalle");
            }

            // Exercice 15 - Rectangle
            Double xHautGauche, xBasDroite, yHautGauche, yBasDroite;
            String valeurXHG, valeurYHG, valeurXBD, valeurYBD;

            do
            {
                Console.WriteLine("Coordonnée point xHautGauche : ");
                valeurXHG = Console.ReadLine();
                Console.WriteLine("Coordonnée point yHautGauche : ");
                valeurYHG = Console.ReadLine();
                Console.WriteLine("Coordonnée point xBasDroite : ");
                valeurXBD = Console.ReadLine();
                Console.WriteLine("Coordonnée point yBasDroite : ");
                valeurYBD = Console.ReadLine();
            } while (!Double.TryParse(valeurXHG, out xHautGauche) || !Double.TryParse(valeurYHG, out yHautGauche) || !Double.TryParse(valeurXBD, out xBasDroite) || !Double.TryParse(valeurYBD, out yBasDroite));

            // Exercice 16 - Appartenance
            Double p1, p2;
            String valeurP1, valeurP2;

            do
            {
                Console.WriteLine("Valeur p1 : ");
                valeurP1 = Console.ReadLine();
                Console.WriteLine("Valeur p2 : ");
                valeurP2 = Console.ReadLine();
            } while (true);
        }
    }
}
