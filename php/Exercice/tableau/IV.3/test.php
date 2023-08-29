<?php
//  tableau multidimensionnel

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


/**
 * Permet de former un tableau à 2 dimensions 
 *
 * @param string $invite1 première variable entrée
 * @param string $invite2 deuxième variable entrée
 * @return array
 */
function saisirTab2D(string $invite1, string $invite2)
{
    $array = [];
    do {
        $valueX = readline($invite1);
        $valueY = readline($invite2);

        if (checkEntier($valueX, true) && checkEntier($valueY, true)) array_push($array, ['x' => $valueX, 'y' => $valueY]); // Vérification de l'entrer et on push

    } while ($valueX != 0 && $valueY != 0); // Si 0 termine la boucle

    unset($array[count($array) - 1]);

    print_r($array);
}

saisirTab2D('x : ', 'y : ');

// Afficher tableau 2D sous forme de plateau de jeu
