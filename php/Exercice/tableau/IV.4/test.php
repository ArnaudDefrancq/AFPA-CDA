<?php
// Afficher tableau 2D sous forme de plateau de jeu
$array2D = [
    [1, 2, 3, 4],
    [5, 6, 7, 8],

];

/**
 * Permet la visualisation du tableau dans la console
 *
 * @param array $tab 
 * @return array
 */
function creationTab(array $tab)
{
    // Générer 'lettre |' en foncion nombre colonne

    $aTo = range('a', 'z'); // tableau de  a -> z

    $nbColonne = 0;
    $nbLigne = 0;

    $premierLigne = [];

    $separation = [];


    foreach ($tab as $key => $ligne) {
        // echo $key;
        $nbLigne++;
        foreach ($ligne as $colonne) {
            $nbColonne++;
            // echo $colonne;
        }
        echo "\n";
    }

    for ($i = 0; $i < ($nbColonne / $nbLigne); $i++) {
        $premierLigne[] = $aTo[$i];
    }
    for ($i = 0; $i < ($nbColonne / $nbLigne) + 1; $i++) {
        $separation[] = '----';
    }


    echo "\ |";

    foreach ($premierLigne as $lettre) {
        echo   " $lettre |";
    }

    echo "\n";

    foreach ($separation as $sep) {
        echo $sep;
    }

    echo "\n";

    foreach ($tab as $key => $ligne) {
        echo "$key | ";
        foreach ($ligne as $colonne) {
            echo  "$colonne | ";
        }
        echo "\n";
    }
}



creationTab($array2D);
