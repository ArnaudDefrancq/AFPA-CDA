<?php
// factorielle

// demande un nombre
// calcul facto exemple : si 3 => 1*2*3
// return le resultat
// 8! = 40320

/**
 * Calcul la factorielle d'un nombre
 *
 * @param integer $nbDepart 
 * @return int
 */
function calculFactorielle(int $nbDepart)
{
    if ($nbDepart == 1) {
        return 1;
    } else {
        $nouveauNb = $nbDepart - 1;
        return $nbDepart * calculFactorielle($nouveauNb);
    }
}

// echo calculFactorielle(8);


// Epeler un mot


// Demander un mot
// Séparer les lettres
// Afficher les lettres 1 à 1

/**
 * Donne 1 à 1 les lettres d'un mot
 *
 * @param string $mot
 * @return string
 */
function epelerMot(string $mot)
{
    // split le mot et le mettre dans array
    $array = str_split($mot);

    // def le nombre de lettre
    $nbLettre = count($array);

    if ($nbLettre == 0) {
        echo $array[0];
    } else {
    }

    echo $nbLettre;
}

epelerMot('france');
