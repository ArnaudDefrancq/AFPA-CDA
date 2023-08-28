<?php
//  tableau multidimensionnel

function saisirTab()
{
    $array = [];
    do {
        do {
            $value = (int) readline('Ajouter une valeur dans un tableau : ');
        } while (!preg_match("/^[0-9]+$/", $value)); // check valeur entrer

        if ($value != 0) array_push($array, ['x' => $value, 'y' => $value]);
    } while ($value != 0); // Si 0 termine la boucle

    var_dump($array);
}

saisirTab();
