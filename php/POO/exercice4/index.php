<?php
function chargerClasse($classe)
{
    require './Class/' . $classe . '.Class.php';
}
spl_autoload_register('chargerClasse');

// Création objet Joueur
$joueur = new Joueur();

// Créatiion soit montreF soit montreD
// if (rand(0, 1) == 0) {
$montre = new MonstreF();
// } else {
//     $montre = new MonstreD();
// }

// Lancer le dé
$deMonstre = new De();
