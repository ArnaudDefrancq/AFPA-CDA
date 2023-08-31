<?php

/**
 * choisie un mot random a partir d'un tableau de mot 
 *
 * @param array $tabMot tableau de mot 
 * @return string mot random selectionné
 */
function motRandom($tabMot)
{
}
/**
 * Undocumented function definie la difficulté du jeu
 *
 * @return int de 1 a 3 pour la difficulté du jeu
 */
function verificationSaisieDiff()
{
}
/**
 * definie la taille du tab grace au nombre de lettre du mot mit en argument
 *
 * @param string $motRandom mot random
 * @param int $diff definie si on affiche la premiere lettre 
 * @return array tableau de taille du mot rempli de - pour indiquer la taille de la du mot au joueur
 */
function tailleMot($motRandom, $diff)
{
}
/**
 *  affiche le mot cache 
 * @param string $motRandom mot random choisi pour le jeu
 * @return void
 */
function affichageMotCache($motRandom)
{
}
/**
 * Undocumented function affiche les lettres deja utilisées
 *
 * @param array $tabLettre tableau de lettres deja utilisées
 * @return void
 */
function afficherTabLettre($tabLettre)
{
}
/**
 * Undocumented function premet de verifier que lutilisateur saisie une lettre valide 
 * @param int $vie envele une vie si la lettre saisie est invalide
 * @return string retourne une lettre 
 */
function verificationSaisieLettre($vie)
{
}
/**
 * Undocumented function ajoute la lettre saisie dans le tableau de lettres deja utilisées
 *
 * @param string $lettre lettre saisie 
 * @return array tableau de lettres deja utilisées
 */
function ajoutLettreTab($lettre)
{
}
/**
 * Undocumented function convertie le motRandom en tableau et verifie si la lettre fait partie du mot et enleve une vie si faux ou remplace la lettre dans le tabMot si vrai
 *
 * @param string $lettre lettre selectionnée par l'utilisateur
 * @param array $tabMot tableau de la fonction tailleMot
 * @param int $vie vie du joueur
 * @param array $motRandom mot random selectionné
 * @return void la vie restante du joueur et le tableau de la fonction tailleMot
 */
function verifierLettreEtUpdate($lettre, $tabMot, $vie, $motRandom)
{
}
