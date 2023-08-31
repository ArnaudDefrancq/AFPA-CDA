<?php
// Jeu Master Mind

/* But du jeu => 
    - Une combinaison de couleur (mini 4)
    - Trouver la combinaison avec un nombre de coup définit
    - Si bien placé => "X"
    - Si mal placé => "Y"
    - On ne signale pas l'utilisateur quelle couleur est bon ou non
*/

/**
 * Fonction pour initialiser les variables
 *
 * @return array Tableau asso avec les variables
 * 
 */
function init()
{
}

/**
 * Défini le nombre de essai
 *
 * @return int Nombre de essai
 */
function nbEssai()
{
}

/**
 * Détermine la longeur de la combinaison
 *
 * @return array Tableau de jeu
 */
function longueurDeLaCombinaison()
{
}

/**
 * Détermine la combinaison de couleur aléatoire. Les couleurs seront définies par une lettre
 *
 * @param array $tableauDeJeu Tableau de jeu
 * @return array Tableau de la combinaison a trouver
 */
function determineCombinaison(array $tableauDeJeu)
{
}

// ------------------------------------------------------ //

/**
 * Fonction qui va lancer le jeu
 * 
 * @param int $nbEssai Nombre déterminer de vie
 * @param array $combinaisonDetermine Combinaison a trouver
 * @return void
 */
function jeu(int $nbEssai, array $combinaisonDetermine)
{
}
/*
    Déroulement du jeu : 
    - Le joueur propose une combinaison de couleur
    - Afficher la proposition (et maintenir afficher les propositions)
    - On compare la combinaison donnée par l'utilisateur et la combinaison déterminée (comparaison de la couleur et de l'index)
    - Afficher le resultat (si bon => 'O', si mauvais => 'X')
    - Afficher le nombre de vie restante diminue à chaque tour
    - On vérifie quand le joueur gagne
*/

/**
 * Proposition de couleur du joueur
 *
 * @return array array Proposition
 */
function propositionCombinaison()
{
}

/**
 * Affiche la proposition du joueur
 *
 * @param array $propositionJoueur
 */
function affichageProposition(array $propositionJoueur)
{
}

/**
 * Compare la proposition du joueur par rapport à la combinaison déterminée
 *
 * @param array $proposition
 * @param array $combinaisonDetermine
 * @return boolean
 */
function comparaisonPropositoinCombinaison(array $proposition, array $combinaisonDetermine)
{
}

/**
 * Affiche le résultat nombre de X => bien placé et nombre de O => bon mais mal placé
 *
 */
function affichageResultat()
{
}

/**
 * Affiche le nombre d'essai
 *
 * @param int $nbEssai 
 */
function affichageNbEssai(int $nbEssai)
{
}

/**
 * Détermine si le joueur a gagné
 *
 * @return int 0 => jeu conntinu, -1 => perdu, 1 => gagné
 */
function gagneOuNon()
{
}

// ------------------------------------------------------ //

/**
 * Fonction de fin de partie
 *
 * @return void
 */
function finDuJeu()
{
}
