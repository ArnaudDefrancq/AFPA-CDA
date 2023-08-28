<?php
// Gestion de l'affichage

/* Boucle : 
    - Ajoute dans un tab tout les chiffres
    - Faire la somme du tableau
*/

$value = readline('Entrer un chiffre entier : ');

$sum = [];

for ($i = 0; $i < $value + 1; $i++) {
    array_push($sum, $i);

    if ($i == $value) {
        echo $i;
    } else {
        echo $i . ' + ';
    }
};

$sumValue = array_sum($sum);





echo  ' = ' . $sumValue;
