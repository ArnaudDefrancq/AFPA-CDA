<?php
function chargerClasse($classe)
{
    require './Class/' . $classe . '.Class.php';
}
spl_autoload_register('chargerClasse');

$debug = true;

// Création objet Joueur
$joueur = new Joueur();

// Créatiion soit montreF soit montreD
// if (rand(0, 1) == 0) {
$monstre = new MonstreD();
// } else {
//     $montre = new MonstreD();
// }


echo $monstre->attaqueDifficile($joueur, $debug);
