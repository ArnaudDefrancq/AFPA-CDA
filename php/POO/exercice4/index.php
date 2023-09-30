<?php
function chargerClasse($classe)
{
    require './Class/' . $classe . '.Class.php';
}
spl_autoload_register('chargerClasse');




$debug = true;


function game($debug)
{
    // Création objet Joueur
    $joueur = new Joueur(["nom" => "Ti Nono"]);

    while (!$joueur->estVivant()) {
        // Créatiion soit montreF soit montreD
        $monstre = new MonstreF();

        while ($monstre->getVivant() && !$joueur->estVivant()) {
            echo $joueur->attaque($monstre, $debug);
            echo "\n";
            if ($monstre->getVivant()) {
                echo $monstre->attaque($joueur, $debug);
                echo "\n";
            }
            echo "monstre tuer : " . MonstreF::$nbMonstreTue;
            echo "\n";
        }
        echo Joueur::$pv;
        echo "\n";
    }
}


game($debug);
