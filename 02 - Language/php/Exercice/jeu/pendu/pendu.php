<?php

/**
 * Demande le niveau de difficulté à l'utilisateur
 *
 * @return int niveau de difficulte
 */
function saisirDifficulte()
{
    do {
        $difficulte = readline("Sélectionner un niveau de difficulté (0 => facile / 1 => moyen / 2 => difficile) : ");
    } while (!preg_match("/^[0-2]+$/", $difficulte));
    return $difficulte;
}

/**
 * Demande le nombre de joueur
 *
 * @return int nombre de joueurs
 */
function saisirNbJoueur()
{
    do {
        $nbJoueur = readline("Sélectionner nombre de joueur : ");
    } while (!preg_match("/^[\d]+$/", $nbJoueur) || $nbJoueur == 0);
    return $nbJoueur;
}

/**
 * Demande le nombre de vie aux joueurs
 *
 * @return int nombre de vie
 */
function saisirNbVie()
{
    do {
        $nbVie = readline("Sélectionner un noubre de vie limité : ");
    } while (!preg_match("/^[\d]+$/", $nbVie) || $nbVie == 0);
    return $nbVie;
}

$nbVie = saisirNbVie();

/**
 * Choisi au hasard un mot dans une liste
 *
 * @return string mot qui doit être trouvé par les joueurs
 */
function determinerMotAChercher()
{
    $arrayDeMot = ["bonjour", "bonsoir", "merci", "abondance", "bouteille", "casquette"];

    $randomKey = array_rand($arrayDeMot, 1);

    $motAChercher = $arrayDeMot[$randomKey];

    return $motAChercher;
}

/**
 * initialise les paramètres du jeu
 *
 * @return array Tableau associatif qui retourne toute les variables d'initialisation
 */
function init()
{
    $arrayJeu = [
        'difficulte' => saisirDifficulte(),
        'nbJoueur' => saisirNbJoueur(),
        'motAChercher' => determinerMotAChercher()
    ];

    // return $arrayJeu;

    jeu($arrayJeu['motAChercher'], $arrayJeu['difficulte'], $arrayJeu['nbJoueur'], $arrayJeu['nbVie']);
}

function jeu($motAChercher, $difficulte, $nbJoueur)
{
    $propositions = [];

    $motCoder = coderMot($motAChercher, $difficulte);
    afficherMotCode($motCoder);

    $joueurEnCour = quiJoue($nbJoueur);
    joueurSuivant($nbJoueur, $joueurEnCour);

    $lettre = saisirLettre();

    verifierLettre($lettre, $motCoder, $motAChercher, $difficulte, $propositions);
}

/**
 * Affiche le mot codé
 *
 * @param array $motCode Tableau du mot codé
 * @return void
 */
function afficherMotCode(array $motCode)
{
    echo implode(' ', $motCode);
    echo "\n";
}
/**
 * Construit un tableau du mot en fonction de la difficulté
 *
 * @param string $mot Mot à chercher
 * @param integer $difficulte Difficulté de la partie indiquée
 * @return array Le tableau du mot
 */
function coderMot(string $mot, int $difficulte)
{
    $arrayMot = str_split($mot);
    $arrayLength = count($arrayMot) - 1;
    $arrayMotCode = [];
    switch ($difficulte) {
        case 1:
            $arrayMotCode[] = $arrayMot[0];
            for ($i = 1; $i < count($arrayMot); $i++) {
                array_push($arrayMotCode, '-');
            }
            return $arrayMotCode;
            break;
        case 2:
            for ($i = 0; $i < count($arrayMot); $i++) {
                array_push($arrayMotCode, '-');
            }
            return $arrayMotCode;
            break;
        default:
            $arrayMotCode[] = $arrayMot[0];
            for ($i = 1; $i < count($arrayMot) - 1; $i++) {
                array_push($arrayMotCode, '-');
            }
            $arrayMotCode[] = $arrayMot[$arrayLength];
            return $arrayMotCode;
    }
}


/**
 * Définit qui commence la partie
 *
 * @param int $nbJoueur 
 * @return int 
 */
function quiJoue(int $nbJoueur)
{
    $arrayJoueur = range(1, $nbJoueur);
    $randomKeyJoueur = array_rand($arrayJoueur, 1);
    $randomJoueur = $arrayJoueur[$randomKeyJoueur];

    echo "C'est au tour du joueur " . $randomJoueur  . " de jouer !";
    echo "\n";

    return $randomJoueur;
}

/**
 * Permet de décider qui va jouer
 *
 * @param integer $nbJoueur Le nombre de joueur
 * @param integer $joueurEnCours Le joueur qui vient de jouer
 * @return void
 */
function joueurSuivant(int $nbJoueur, int $joueurEnCours)
{
    if ($joueurEnCours == $nbJoueur) {
        $joueurEnCours = 1;
        return $joueurEnCours;
    } else {
        $joueurEnCours++;
        return $joueurEnCours;
    }

    // afficher
}

/**
 * Permet au joueur en cours de proposer une lettre
 *
 * @return string La lettre ayant été proposée
 */
function saisirLettre()
{
    do {
        $lettre = readline("Sélectionner une lettre : ");
    } while (!preg_match("/^[a-z]$/", $lettre));

    return $lettre;
}

/**
 * Vérifie si la lettre fait partie du mot ou pas
 *
 * @param string $lettre La lettre entrée par le joueur
 * @param array $motCode La partie du mot que le joueur connait
 * @param array $mot Le mot que le joueur doit trouvé
 * @param int $difficulte La difficulte de la partie
 * @param array $propositions Les lettre déjà proposées
 * @return void
 */
function verifierLettre(string $lettre, array $motCode, string $mot, int $difficulte, array $propositions)
{
    // if (in_array($lettre, $propositions));

    // On compare la lettre avec le tableau du mot
    // Si lvl 0 => on remplace toutes les  - par la lettre
    // Si lvl 1 => on remplace toutes les - par la lettre
    // Si lvl 2 => si plusieurs même lettres, on remplace que 1 - (aléatoire) par une lettre
}

/**
 * Vérifie si la lettre est correcte et pas encore ajoutée
 *
 * @param string $lettre
 * @param array $motcode
 * @param string $mot
 * @return bool
 */
function estCorrecte(string $lettre, array $motcode, string $mot)
{
}

/**
 * Ajoute la lettre au mot codé en fonction du niveau de difficulté
 *
 * @param string $lettre
 * @param array $motcode
 * @param string $mot
 * @param integer $difficulte
 * @return array Le mot codé
 */
function ajouterLettre(string $lettre, array $motcode, string $mot, int $difficulte)
{
}

/**
 * Clear la console et réaffiche le jeu dans l'état actuel
 *
 * @param integer $nbVie
 * @param array $motCode
 * @param integer $joueurEnCours
 * @param string $propositions
 * @return void
 */
function affichageGlobal(int $nbVie, array $motCode, int $joueurEnCours, string $propositions)
{
}

/**
 * Affiche le nombre de vie restante + pendu ?
 *
 * @param integer $nbVie
 * @return void
 */
function affichageVie(int $nbVie)
{
}

/**
 * Undocumented function
 *
 * @param array $motCode
 * @return int Etat de la partie (0 -1 1
 * 0 = en cours
 * -1 = perdu
 * 1 = gagne
 * */
function estGagne(array $motCode)
{
}

/**
 * Conclu le jeu Gagné ou Perdu
 *
 * @param boolean $resultat
 * @return void
 */
function conclusion($resultat)
{
}

init();
