<?php
function chargerClasse($classe)
{
    require './Class/' . $classe . '.Class.php';
}
spl_autoload_register('chargerClasse');

// instanciation des employées
$agence1 = new Agence(["nomAgence" => "agence_1", "adresse" => "rue de Lille", "codePostal" => "59000", "ville" => "Lille", "restauration" => true]);
$employe1 = new Employe(["nom" => "jean", "prenom" => "pierre", "embauche" => "20-04-1999", "poste" => "chef", "salaire" => 180000, "service" => "chef", "agence" => $agence1]);

$agence2 = new Agence(["nomAgence" => "agence_2", "adresse" => "rue de Paris", "codePostal" => "70123", "ville" => "Paris", "restauration" => false]);
$employe2 = new Employe(["nom" => "marc", "prenom" => "jean", "embauche" => "03-01-2001", "poste" => "sous-chef", "salaire" => 100000, "service" => "sous-chef", "agence" => $agence2]);

$agence3 = new Agence(["nomAgence" => "agence_3", "adresse" => "rue de Popering", "codePostal" => "8970", "ville" => "Popering", "restauration" => false]);
$employe3 = new Employe(["nom" => "henri", "prenom" => "paul", "embauche" => "06-06-2020", "poste" => "artiste", "salaire" => 20000, "service" => "test", "agence" => $agence3]);

$agence4 = new Agence(["nomAgence" => "agence_4", "adresse" => "rue de Watou", "codePostal" => "8978", "ville" => "Watou", "restauration" => true]);
$employe4 = new Employe(["nom" => "francis", "prenom" => "bis", "embauche" => "05-09-2002", "poste" => "penseur", "salaire" => 60000, "service" => "là", "agence" => $agence4]);

$employe5 = new Employe(["nom" => "beton", "prenom" => "cis", "embauche" => "26-08-2005", "poste" => "derrière", "salaire" => 2000, "service" => "stage", "agence" => $agence1]);

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
echo "Il y a " . Employe::$_nbEmployer . " employer";
echo "\n";

// affiche les info par ordre alphabétique sur le nom et le prenom
// function comparaisonNomPrenom($a, $b)
// {
//     if ($a->getNom() == $b->getNom()) {
//         return strcmp($a->getPrenom(), $b->getPrenom());
//     }
//     return strcmp($a->getNom(), $b->getNom());
// }

usort($arrayEmployer, ["Employe", "compareToNomPrenom"]);

foreach ($arrayEmployer as $personne) {
    echo $personne;
    echo "\n";
}
echo "\n";

// affiche les info par ordre alphabétique sur le service, le nom et le prenom
// function comparaisonServiceNomPrenom($a, $b)
// {
//     if ($a->getService() == $b->getService()) {
//         if ($a->getNom() == $b->getNom()) {
//             return strcmp($a->getPrenom(), $b->getPrenom());
//         }
//         return strcmp($a->getNom(), $b->getNom());
//     }
//     return strcmp($a->getService(), $b->getService());
// }

usort($arrayEmployer, ["Employe", "compareToServiceNomPrenom"]);

foreach ($arrayEmployer as $personne) {
    echo $personne;
    echo "\n";
}
echo "\n";

// montant total masse salariale
echo 'Coût masse salariale : ';
// function coutMasseSalarial($arrayEmployer)
// {
//     $coutPrime = 0;
//     $coutSalaire = 0;

//     foreach ($arrayEmployer as $employe) {
//         $coutPrime = $coutPrime + $employe->primeAnnuel();
//     }

//     foreach ($arrayEmployer as $employe) {
//         $coutSalaire = $coutSalaire + $employe->getSalaire();
//     }

//     echo "montant total coût (salaire + prime) : " . ($coutPrime + $coutSalaire) . " €";
// }
// coutMasseSalarial($arrayEmployer);

echo Employe::masseSalariale() . " €";

echo "\n";
echo "\n";
// echo $employe1->getAgence()->getNomAgence();

function modeRestauration($arrayEmployer)
{
    foreach ($arrayEmployer as $employe) {
        echo "employe : " . $employe->getNom() . " - agence : " . $employe->getAgence()->getNomAgence() . " - restauration :" . ($employe->getAgence()->getRestauration() ? " restaurant d'entreprise" : " pas de restaurant d'entreprise");
        echo "\n";
    }
}

modeRestauration($arrayEmployer);
echo "\n";
