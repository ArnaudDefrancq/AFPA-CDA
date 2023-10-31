// See https://aka.ms/new-console-template for more information
// 5 Chaînes de caractères
// 5.1 Prise en main
// Exercice 5.1 - Prise en main
//String phrase = "Les framboises sont perchées sur le tabouret de mon grand-père.";

//for (int i = 0; i < phrase.Length; i++)
//{
//    Console.WriteLine(phrase[i]);
//}

// Exercice 2 - Extraction
//String phrase = "";
//String phraseConcat = "";
//int i, j;
//String valeurI, valeurJ;

//do
//{
//    Console.WriteLine("Saisir une phrase : ");
//    phrase = Console.ReadLine();
//} while (phrase.Length < 3);

//do
//{
//    Console.WriteLine("Saisir un indice i : ");
//    valeurI = Console.ReadLine();

//    Console.WriteLine("Saisir un indice j : ");
//    valeurJ = Console.ReadLine();
//} while (!int.TryParse(valeurI, out i) || !int.TryParse(valeurJ, out j));

//if (i < j)
//{
//    for (int index = i; index < j; index++)
//    {
//        phraseConcat = phraseConcat + phrase[index];
//    }
//}
//else
//{
//    Console.WriteLine("Valeur pas bonne");
//}

//Console.WriteLine(phraseConcat);

// Exercice 3 - Extraction sans concaténation
//String phrase = "";
//String phraseConcat = "";
//int i, j;
//String valeurI, valeurJ;

//do
//{
//    Console.WriteLine("Saisir une phrase : ");
//    phrase = Console.ReadLine();
//} while (phrase.Length < 3);

//do
//{
//    Console.WriteLine("Saisir un indice i : ");
//    valeurI = Console.ReadLine();

//    Console.WriteLine("Saisir un indice j : ");
//    valeurJ = Console.ReadLine();
//} while (!int.TryParse(valeurI, out i) || !int.TryParse(valeurJ, out j));

//if (i < j)
//{
//    Char separator = '%';
//    phraseConcat = phrase.Insert(i, "%");
//    phraseConcat = phraseConcat.Insert(j, "%");

//    String[] newPhrase = phraseConcat.Split(separator);

//    Console.WriteLine(newPhrase[1]);
//}
//else
//{
//    Console.WriteLine("Valeur pas bonne");
//}

// Exercice 4 - Substitution
//String phrase;
//Char a, b;


//Console.WriteLine("Saisir une phrase : ");
//phrase = Console.ReadLine();

//Console.WriteLine("Saisir une lettre a :");
//a = Console.ReadLine()[0];
//Console.WriteLine("Saisir une lettre b : ");
//b = Console.ReadLine()[0];

//if (phrase.Contains(b))
//{
//    Console.WriteLine(phrase.Replace(b, a));
//}
//else
//{
//    Console.WriteLine("La lettre " + b + " n'est pas dans la phrase");
//}

// Exercice 5 - Substitution sans Replace
//using System.Text;

//StringBuilder phrase = new StringBuilder();
//Char a, b;

//Console.WriteLine("Saisir une phrase : ");
//phrase.Append(Console.ReadLine());

//Console.WriteLine("Saisir une lettre a :");
//a = Console.ReadLine()[0];
//Console.WriteLine("Saisir une lettre b : ");
//b = Console.ReadLine()[0];

//for (int i = 0; i < phrase.Length; i++)
//{
//    if (phrase[i] == b)
//    {
//        phrase[i] = a;
//    }
//}

//Console.WriteLine(phrase);

// 5.2 - Morceaux choisis
// Exercice 6 - Extensions
//String nomFichier;
//Char separator = '.';

//Console.WriteLine("Saisir nom du fichier : ");
//nomFichier = Console.ReadLine();

//String[] extension = nomFichier.Split(separator, StringSplitOptions.RemoveEmptyEntries);
//int nbExtension = extension.Count();

//Console.WriteLine("." + extension[nbExtension - 1]);

// Exercice 7 - Expressions arithmétiques
//String expression = "";
//int index = 0;

//Console.WriteLine("Ecrire votre expréssion : ");
//expression = Console.ReadLine();

//if (expression[index] == ')')
//{
//    Console.WriteLine("Commence par une fermante");
//}
//else if (expression[index] == '(')
//{
//    Console.WriteLine("Termine par une ouvrante");
//}
//else
//{
//    int nbParenthese = 0;
//    int nbTour = 0;

//    while (nbParenthese > 0 || nbTour != expression.Length)
//    {
//        if (expression[index] == ')') nbParenthese--;
//        if (expression[index] == '(') nbParenthese++;
//        index++;
//        nbTour++;
//    }
//    if (nbParenthese == 0) Console.WriteLine("Autant de ( et de  )");
//    else if (nbParenthese < 0) Console.WriteLine("Trop de fermante");
//    else Console.WriteLine("trop d'ouvrante");
//}