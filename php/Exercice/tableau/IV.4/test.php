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

    // def le nb de colonne et  de ligne
    foreach ($tab as $key => $ligne) {
        $nbLigne++;
        foreach ($ligne as $colonne) {
            $nbColonne++;
        }
        echo "\n";
    }

    // Ajouter le nombre de lettre en fonction du nombre de colonne
    for ($i = 0; $i < ($nbColonne / $nbLigne); $i++) {
        $premierLigne[] = $aTo[$i];
    }

    // Ajouter la séparation en fonction du nombre de colonne
    for ($i = 0; $i < ($nbColonne / $nbLigne) + 1; $i++) {
        $separation[] = '----';
    }

    echo "\ |";


    //  Définition de la ligne qui def les colonnes
    foreach ($premierLigne as $lettre) {
        echo   " $lettre |";
    }

    echo "\n";

    // Seéparation ligne 1 - 2
    foreach ($separation as $sep) {
        echo $sep;
    }

    echo "\n";

    // Ajout des valeurs dans le tableau
    foreach ($tab as $key => $ligne) {

        echo "$key | ";
        foreach ($ligne as $colonne) {
            echo  "$colonne | ";
        }
        echo "\n";
    }
}



creationTab($array2D);


// Chercher une valeur dans un tableau 2D

function trouverValeur()
{
}
