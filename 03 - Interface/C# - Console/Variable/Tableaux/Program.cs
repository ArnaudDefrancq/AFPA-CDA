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
// Exercice 8 - Permutation circulaire avec deux tableaux
//int[] newTab = new int[10];
//int lastElmt = tab[tab.Length - 1];
//newTab[0] = lastElmt;
//for (int i = 1; i < newTab.Count(); i++)
//{
//    newTab[i] = tab[i - 1];
//}

//foreach (int i in newTab)
//{
//    Console.WriteLine(i);
//}
// Exercice 9 - Permutation circulaire sans deuxième tableau
//int[] tab;
//tab = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

//for (int i = 0; i < tab.Count() - 1; i++)
//{
//	int premier = tab[0];
//	for (int j = 0; j < tab.Count() - 1; j++)
//	{
//		tab[j] = tab[j + 1];
//	}
//	tab[tab.Length - 1] = premier;
//}

//int dernier = tab[tab.Count() - 1];

//for (int i = tab.Count() - 1; i > 0; i--)
//{
//	tab[i] = tab[i - 1];

//}

//tab[0] = dernier;
//foreach (int i in tab)
//{
//	Console.WriteLine(i);
//}

// Exercice 10 - Miroir
//Array.Reverse(tab);
//foreach (int i in tab)
//{
//    Console.WriteLine(i);
//}

// 6.4 - Recherche séquentielle
// Exercice 11 - Modification du tableau
//Double[] tab;
//tab = new Double[20];

//for (int i = 1; i < tab.Count(); i++)
//{
//	Double carre = Math.Pow(i, 2);
//	tab[i] = (carre % 17);
//}

//foreach (int i in tab)
//{
//	Console.WriteLine(i);
//}

// Exercice 12 - Min / Max
//Double max = tab[0];
//Double min = tab[0];


//for (int i = 1; i < tab.Count(); i++)
//{
//    if (max <= tab[i])
//    {
//        max = tab[i];
//    }

//    if (min >= tab[i])
//    {
//        min = tab[i];
//    }
//}

//Console.WriteLine(max + " est la valeur la plus grande et " + min + " est la valeur la plus faible");

// Exercice 13 - Recherche séquentielle
//Double x;
//do
//{
//    Console.WriteLine("Saisir une valeur x : ");
//} while (!Double.TryParse(Console.ReadLine(), out x));

//for (int i = 0; i < tab.Length; i++)
//{
//    if (tab[i] == x)
//    {
//        Console.WriteLine("Il se trouve au index : " + i);
//    }
//}

// Exercice 14 - recherche séquentielle avec stockage des indices (tab dans l'exercice 11)
//Double[] newTab = { };
//Double x;
//do
//{
//	Console.WriteLine("Saisir une valeur x : ");
//} while (!Double.TryParse(Console.ReadLine(), out x));

//for (int i = 0; i < tab.Count(); i++)
//{
//	if (tab[i] == x)
//	{
//		Double item = Convert.ToDouble(i);
//		newTab = newTab.Append(item).ToArray();
//	}
//}

//if (newTab.Count() == 0)
//{
//	Console.WriteLine(x + " n'est pas dans le tableau");
//}
//else
//{
//	Console.WriteLine(x + " est dans le tableau au(x) index : ");
//	foreach (Double item in newTab)
//	{
//		Console.WriteLine("index : " + item);
//	}
//}

// 6.5 - Morceaux choisis
// Exercice 15 - Pièces de monnaie
//Double[] valeurPiece = { 0.5d, 0.2d, 0.1d, 0.05d, 0.02d, 0.01d };
//Double[] nombrePiece = { };
//Double somme;

//do
//{
//	Console.WriteLine("Entrez une somme comprise entre 0 et 0,99");
//} while (!Double.TryParse(Console.ReadLine(), out somme) || somme > 0.99 || somme < 0);

//while (somme > 0.001)
//{

//	foreach (Double val in valeurPiece)
//	{
//		if (somme >= val)
//		{
//			nombrePiece = nombrePiece.Append(val).ToArray();
//			somme -= val;
//		}
//	}
//}


//foreach (Double val in nombrePiece)
//{
//	Console.WriteLine(val);
//}

