<?php
require_once('./Voiture.php');

$arrayVoiture = [
    'couleur' => 'grise',
    'marque' => 'fiat',
    'model' => 'punto',
    'nbKilometre' => 190000,
    'motorisation' => 'diesel'

];

// exercie 1 - 6
$voiture_1 = new Voiture($arrayVoiture);
// $voiture_1->__toString();
// echo "\n";

// exercice 1 - 7

$arrayVoiture2 = [
    'marque' => 'citröen',
    'model' => 'C4',
    'nbKilometre' => 10000,
];
$arrayVoiture3 = [
    'couleur' => 'rouge',
    'marque' => 'renault',
    'model' => 'kadjar',
];

$voiture_2 = new Voiture($arrayVoiture2);
$voiture_3 = new Voiture($arrayVoiture3);

// $voiture_2->__toString();
// echo "\n";
// $voiture_3->__toString();

// exercice 1 - 9 + 10
$voiture_1->__toString();
echo "\n";
$voiture_1->rouler(100000);
echo "\n";
$voiture_1->__toString();
