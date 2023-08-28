<?php
// Les fonctions de bases

// Demander nombre de variable
// Typer les variables (int)

// 1 ou 2 dimensions
// Si 1 => ajouter des valeurs à X
// Si 2 => Ajouter des valeurs à X et Y


// $test = [
//     [
//         'x' => 1,
//         'y' => 1
//     ],
//     [
//         'x' => 2,
//         'y' => 3
//     ]
// ];


// var_dump($test);

// function saisirTableau(int $dimension)
{
    // $array = [];

    // if ($dimension == 2) {
    //     $arrayDim = [];
    //     do {


    //         do {
    //             $valueX = readline('Ajouter une valeur X : ');
    //             $valueY = readline('Ajouter une valeur Y : ');
    //         } while (!preg_match("/^[0-9]+$/", $valueX, $valueY));


    //         $arrayDim["x"] = $valueX;
    //         $arrayDim["y"] = $valueY;
    //     } while ($valueX != 0 && $valueY != 0);

    //     var_dump($arrayDim);
}

// array_push($array, $arrayDim);

// var_dump($array);
// };

// saisirTableau(2);




function saisirTab()
{

    $array = [];
    do {
        do {
            $value = readline('Ajouter une valeur dans un tableau : ');
        } while (!preg_match("/^[0-9]+$/", $value)); // check valeur entrer
        array_push($array, $value);
    } while ($value != 0); // Si 0 termine la boucle
    array_pop($array); // retire le 0
    var_dump($array);
}

saisirTab();
