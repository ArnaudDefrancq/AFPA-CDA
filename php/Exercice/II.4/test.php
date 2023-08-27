<?php
// Conditions implicites
$candidat1 = readline('score 1 : ');
$candidat2 = readline('score 2 : ');
$candidat3 = readline('score 3 : ');
$candidat4 = readline('score 4 : ');


$election = [$candidat2, $candidat3, $candidat4];



if ($candidat1 > 50) {
    echo 'élu';
} elseif ($candidat1 >= 12.5) {
    foreach ($election as $score) {
        if ($candidat1 > $score) {
            echo 'favorable';
        } elseif ($candidat1 < $score) {
            echo 'défavorable';
        }
    }
} else {
    echo 'ne passe pas le premier tour';
}



// Correction 

$age = readLine('Age : ');
$permis = readLine('Années de permis : ');
$accident = readLine('Nombre d\'accidents : ');
$gold = readLine('Client depuis plus d\'un an ? : ');

$score = 0;

$couleur = ['rouge', 'orange', 'verte', 'bleue'];

if ($age > 25) {
    $score++;
}

if ($permis > 2) {
    $score++;
}

$score -= $accident;

if ($gold && $score >= 0) {
    $score++;
}

if ($score >= 0) {
    echo 'Vous avez droit à l\'assurance de couleur ' . $couleur[$score];
} else {
    echo 'Vous ne pouvez pas souscrire à une assurance';
}
