<?php
//  tableau multidimensionnel


// $arrayTest = [
//     [
//         'x' => 1,
//         'y' => 1
//     ],
//     [
//         'x' => 2,
//         'y' => 2,
//     ]

// ];

// var_dump($arrayTest);


// retirer derniere valeur
function saisirTab()
{

    $array = [];
    do {

        do {

            $value = (int) readline('Ajouter une valeur dans un tableau : ');
        } while (!preg_match("/^[0-9]+$/", $value)); // check valeur entrer

        array_push($array, ['x' => $value, 'y' => $value]);
        array_pop($array); // retire le 0
    } while ($value != 0); // Si 0 termine la boucle

    var_dump($array);
}

saisirTab();
