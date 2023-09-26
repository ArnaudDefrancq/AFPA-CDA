<?php
function chargerClasse($classe)
{
    require './Class/' . $classe . '.Class.php';
}
spl_autoload_register('chargerClasse');

// instanciation des employées
$employe1 = new Employe(["nom" => "jean", "prenom" => "pierre", "embauche" => "20-04-1999", "poste" => "chef", "salaire" => 180000, "service" => "chef"]);
$employe2 = new Employe(["nom" => "marc", "prenom" => "jean", "embauche" => "03-01-2001", "poste" => "sous-chef", "salaire" => 100000, "service" => "sous-chef"]);
$employe3 = new Employe(["nom" => "henri", "prenom" => "paul", "embauche" => "06-06-2020", "poste" => "artiste", "salaire" => 20000, "service" => "test"]);
$employe4 = new Employe(["nom" => "francis", "prenom" => "bis", "embauche" => "05-09-2002", "poste" => "penseur", "salaire" => 60000, "service" => "là"]);
$employe5 = new Employe(["nom" => "francis", "prenom" => "cis", "embauche" => "26-08-2005", "poste" => "derrière", "salaire" => 2000, "service" => "stage"]);

// tab des employees
$arrayEmployer = [$employe1, $employe2, $employe3, $employe4, $employe5];

// affiche la prime annuel par employe
echo 'Prime annuel :';
echo "\n";
foreach ($arrayEmployer as $employe) {
    echo $employe->primeAnnuel() . " €";
    echo "\n";
}

// Permet de savoir si le salaire est versé
if ($employe1->estVerser()) {
    echo "ordre de transfert a été envoyé à la banque";
    echo "\n";
} else {
    echo "l'ordre de transfert sera effectué le 30/11";
    echo "\n";
}


// nombre d'employe
echo "Il y a " . count($arrayEmployer) . " employer";
echo "\n";

// affiche les info par ordre alphabétique sur le nom et le prenom
function comparaisonNomPrenom($a, $b)
{
    if ($a->getNom() == $b->getNom()) {
        return strcmp($a->getPrenom(), $b->getPrenom());
    }
    return strcmp($a->getNom(), $b->getNom());
}

usort($arrayEmployer, "comparaisonNomPrenom");

foreach ($arrayEmployer as $personne) {
    echo $personne;
    echo "\n";
}
echo "\n";
echo "\n";

// affiche les info par ordre alphabétique sur le service, le nom et le prenom
function comparaisonServiceNomPrenom($a, $b)
{
    if ($a->getService() == $b->getService()) {
        if ($a->getNom() == $b->getNom()) {
            return strcmp($a->getPrenom(), $b->getPrenom());
        }
        return strcmp($a->getNom(), $b->getNom());
    }
    return strcmp($a->getService(), $b->getService());
}

usort($arrayEmployer, "comparaisonServiceNomPrenom");

foreach ($arrayEmployer as $personne) {
    echo $personne;
    echo "\n";
}
echo "\n";
echo "\n";
