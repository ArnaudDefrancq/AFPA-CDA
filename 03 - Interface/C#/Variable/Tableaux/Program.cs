// See https://aka.ms/new-console-template for more information
// 6 - Tableaux
// Exercice 6.1 - Exercice de compréhension
// Exercice 1
// 1er Console.WriteLine(c[k]) => a, R, k, J;
// 2ème Console.WriteLine(i) => b, S, l, K

// Exercice 2 
// Tab de k avec 10 cases : 1, 3, 6, 15, 21, 28, 36, 45, 55

//int[] k;
//k = new int[10];
//k[0] = 1;
//for (int i = 1; i < 10; i++)
//    k[i] = 0;
//for (int j = 1; j <= 3; j++)
//    for (int i = 1; i < 10; i++)
//        k[i] += k[i - 1];
//foreach (int i in k)
//    Console.WriteLine(i);

// Exercice 3
//1 4 9 16 25 36 49 64 81 100

// 6.2 - Prise en main
// Exercice 4 - Initialisation et affichage
//int[] tab;
//tab = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

//foreach (int i in tab)
//{
//    Console.WriteLine(i);
//}

// Exercice 5 - Initialisation avec une boucle
//int[] tab;
//tab = new int[10];

//for (int i = 0; i < tab.Length; i++)
//{
//    tab[i] = i + 1;
//    Console.WriteLine(tab[i]);
//}

// Exercice 6 - Somme
//Console.WriteLine(tab.Sum());

// Exercice 7 - Recherche
//int choixInt;

//do
//{
//    Console.WriteLine("Saisir un chiffre :  ");
//} while (!int.TryParse(Console.ReadLine(), out choixInt));

//if (tab.Contains(choixInt))
//{
//    Console.WriteLine(choixInt + " est dans le tableau");
//}
//else
//{
//    Console.WriteLine(choixInt + " n'est pas dans le tableau");
//}



//Console.WriteLine("Votre chiffre est " + dansTab + " présent dans le tableau");

// 6.3 - Indices
// Exercice 8 - Permutation circulaire
int[] tab;
tab = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
int elmt;

do
{
    Console.WriteLine("Saisir un chiffre pour effectuer la permutation circulaire : ");
} while (!int.TryParse(Console.ReadLine(), out elmt));

if (tab.Contains(elmt))
{



    foreach (int item in tab)
    {
        Console.WriteLine(item);
    }
}
else
{
    Console.Write(elmt + " n'est pas dans le tableau");
}