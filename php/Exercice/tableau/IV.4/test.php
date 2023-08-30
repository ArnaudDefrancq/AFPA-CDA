<?php
// Afficher tableau 2D sous forme de plateau de jeu
/**
 * On vérifie que le nombre soit un entier positif ou negatif
 *
 * @param integer $nb
 * @param bool $positif Permet d'accepter ou non les négatifs
 * @return boolean
 */
function checkEntier(int $nb, bool $positif = false)
{
    if ($positif) {
        if (preg_match("/^[\d]+$/", $nb)) {
            return true;
        } else {
            return false;
        }
    } else {
        if (preg_match("/^(-)?[\d]+$/", $nb)) {
            return true;
        } else {
            return false;
        }
    }
}

function saisirTab2D(string $invite1, string $invite2)
{
    $array = [];
    do {
        $valueX = readline($invite1);
        $valueY = readline($invite2);

        if (checkEntier($valueX, true) && checkEntier($valueY, true)) array_push($array, ['x' => $valueX, 'y' => $valueY]); // Vérification de l'entrer et on push

    } while ($valueX != 0 && $valueY != 0); // Si 0 termine la boucle

    unset($array[count($array) - 1]);

    return $array;
}


// Afficher tableau 2D sous forme de plateau de jeu
// $array = saisirTab2D('x : ', 'y : ');

/**
 * Permet la visualisation du tableau dans la console
 *
 * @param array $tab 
 * @return array
 */
function creationTab(array $tab)
{
    // Générer 'lettre |' en foncion nombre colonne

    $nbColonne = count($tab[0]);

    $separation = '----';

    // Seéparation ligne 1 - 2
    for ($i = 0; $i < $nbColonne; $i++) {
        $separation = $separation . '----';
    }


    echo " \ |";


    //  Définition de la ligne qui def les colonnes
    for ($i = 0; $i < $nbColonne; $i++) {
        $lettre = chr($i + 65);
        echo " $lettre |";
    }

    echo "\n";

    echo $separation;


    echo "\n";

    // Ajout des valeurs dans le tableau
    foreach ($tab as $key => $ligne) {
        echo " $key |";
        foreach ($ligne as $colonne) {
            echo  " $colonne |";
        }
        echo "\n";
        echo $separation;
        echo "\n";
    }
}

// creationTab($array);


// Chercher une valeur dans un tableau 2D 

$arrayTest = [
    [1, 2],
    [3, 4],
    [4, 6],
];

/* Fonction possible : 
    array_search;
    in_array
*/