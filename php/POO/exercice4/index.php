<?php
function chargerClasse($classe)
{
    require './Class/' . $classe . '.Class.php';
}
spl_autoload_register('chargerClasse');


function creationMonstre()
{
    if (rand(0, 1) == 1) {
        return new MonstreF();
    } else {
        return new MonstreD();
    }
}



$debug = true;


// Création objet Joueur
$joueur = new Joueur([]);

function game($debug, $joueur)
{

    while (!$joueur->estVivant()) {
        // Créatiion soit montreF soit montreD
        $monstre = creationMonstre();

        while ($monstre->getVivant() && !$joueur->estVivant()) {
            echo "*********************************************";
            echo "\n";
            echo $joueur->attaque($monstre, $debug);
            echo "\n";
            if ($monstre->getVivant()) {
                echo $monstre->attaque($joueur, $debug);
                echo "\n";
            }
        }
        echo "\n";
    }
    echo "Vous avez tué " . MonstreF::$nbMonstreTue . " monstre facile et " . MonstreD::$nbMonstreTue . " monstre difficile";
    echo "\n";
    echo "Pour un total de " . MonstreF::$nbMonstreTue + (MonstreD::$nbMonstreTue * 2) . " points";
}


game($debug, $joueur);
