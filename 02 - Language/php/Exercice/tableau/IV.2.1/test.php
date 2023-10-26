<?php
// Les tableaux associatifs

// Ecrire fonction pour déclarer un tableau associatif key en lettre
// Définir la key
// Définir la valeur pour la key
// return un tableau
// Ecrire une fonction pour chercher une valeur dans le tableau
// Tri possible sur le tableau

/**
 * Fonction qui permet la création de tableau associatif
 * 
 * @return array
 */
function creeTabAsso()
{
    $array = [];

    do {

        $key = readline('Nom de la key (stop pour terminer saisi) : ');
        $valeur = readline('Valeur de la key (stop pour terminer saisi) : ');

        $array[$key] = $valeur;
    } while ($key != 'stop');

    array_pop($array);

    return $array;
}


// creeTabAsso();


$arrayDemo = [
    'nom' => 'moi',
    'age' => 27,
    'permis' => 'normalement',
    'natF' => true
];


// Recherche dans tableau asso
echo array_search(27, $arrayDemo) . "\n"; // donne key avec une val

if (in_array(27, $arrayDemo)) echo 'trouvé'; // détermine si une valeur est dans le tableau


// tri tableau asso
