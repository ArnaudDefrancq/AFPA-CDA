// See https://aka.ms/new-console-template for more information
// 6 - Tableaux
// Exercice 6.1 - Exercice de compréhension
// Exercice 1
// 1er Console.WriteLine(c[k]) => a, R, k, J;
// 2ème Console.WriteLine(i) => b, S, l, K

// Exercice 2 
// Tab de k avec 10 cases : 1, 3, 6, 15, 21, 28, 36, 45, 55

// Exercice 3

// 6.2 - Prise en main
// Exercice 4 - Initialisation et affichage
//int[] tab;
//tab = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

//foreach (int i in tab)
//{
//    Console.WriteLine(i);
//}

// Exercice 5 - Initialisation avec une boucle
int[] tab;
tab = new int[10];

//for (int i = 0; i < tab.Length; i++)
//{
//    tab[i] = i + 1;
//    Console.WriteLine(tab[i]);
//}

// Exercice 6 - Somme
//Console.WriteLine(tab.Sum());

// Exercice 7 - Recherche
int choixInt;
int dansTab = 0;

do
{
    Console.WriteLine("Saisir un chiffre :  ");
} while (!int.TryParse(Console.ReadLine(), out choixInt));

foreach (int i in tab)
{
    if (i == choixInt)
    {
        dansTab++;
    }
}

Console.WriteLine("Votre chiffre est " + dansTab + " présent dans le tableau");




