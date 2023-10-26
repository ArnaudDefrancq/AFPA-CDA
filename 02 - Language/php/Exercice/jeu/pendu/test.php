<?php
// Jeu pendu

// Consigne => Trouverle mot avec un nombre coup défini

/*
    - Choix de la dificulté
    - Def le nombre de vie
    - Prendre un mot aléatoire
    - afficher le nb de lettre
    - Donner une lettre
    - Validation valeur entrer
    - Comparaison mot lettre
    - Si bon =>  essai +1 et lettre affichhé (ou non)
    - Si mauvais => essai + 1 et erreur annoncé (ou pas)
*/

/*
Variables:
    - nbVie (int)
    - array avec les mots (array)
    - nivau de difficulté (int)
    - mot choisit (array)
    - mot a trouvé (array)
    - lettre check (array)
*/



/**
 * Permet de choisir la difficulté du jeu 0 => facile, 1 => moyen et 2 => difficile
 * Et vérifie que l'input est correct
 * 
 * @return integer
 */
function difficulté()
{
}

/**
 * Permet de choisir un mot aléatoire dans un tableau de mot donné
 * 
 * @param array $arrayMot array des mots a choisir
 * @return array
 */
function choixMotDeviner(array $arrayMot)
{
}

/**
 * Permet d'afficher le nombre de lettre qui compose le mot sans afficher le mot (Les lettres seront remplacées par un '-' ou '_')
 * En fonction de la difficulté : 
 * 0 => affiche 1er et dernière lettre
 * 1 => affiche que la 1er
 * 2 => affiche 0 lettre 
 *
 * @param array $mot mot a faire deviner
 * @return array
 */
function affichageNbLettre(array $mot)
{
}

/**
 * Permet de demander a l'utilisateur de rentrer une lettre de son choix.
 * Vérifie si l'input est correct
 *
 * @param string $invite Demande un lettre
 * @return string
 */
function demandeLettre(string $invite)
{
}

/**
 * Permet de faire une comparaison entre la lettre entrée et le mot choisit.
 * Si bon
 * Ajout de la lettre trouvé dans le tableau du mot a trouvé (à la bonne place)
 * en fonction difficulté:
 * 0 => affiche toute les lettres
 * 1 => affiche 1 lettre (même si plusieurs correspondances)
 * 2 => affiche pas de lettre mais annonce qu'elle est bonne
 * 
 * Si mauvais en fonction difficulté: 
 * 0 => annonce que lettre est mauvaise + nbVie -1 
 * 1 => annonce que lettre est mauvaise + nbVie -1 
 * 2 => annonce que lettre est mauvaise + nbVie -1 
 * 
 *
 * @param array $mot mot a deviner
 * @param integer $nbVie
 * @return boolean
 */
function comparaisonLettreMot(array $mot, int $nbVie)
{
}

/**
 * Calcul le nombre de vie restante
 * Si 0 vie = perdu 
 * 
 * @param integer $nbVie
 * @return int
 */
function checkNbVie(int $nbVie)
{
}

/**
 * Affiche le nombre de vie
 *
 * @param int $nbVie
 * @return mixed
 */
function affichageNbVie(int $nbVie)
{
}

/**
 * Vérifie que le mot a bien été trouvé
 * Compare les 2 array
 *
 * @param array $motChoisit mot a deviné
 * @param array $motTrouve mot trouvé grace au lettre
 * @return boolean si true = win
 */
function checkWin(array $motChoisit, array $motTrouve)
{
}
