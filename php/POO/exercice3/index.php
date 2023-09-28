<?php
function chargerClasse($classe)
{
    require './Class/' . $classe . '.Class.php';
}
spl_autoload_register('chargerClasse');

// instanciation des employées
#region
// enfant 
$enfant1 = new Enfant(["age" => 8]);
$enfant2 = new Enfant(["age" => 20]);
$enfant3 = new Enfant(["age" => 16]);
$enfant4 = new Enfant(["age" => 12]);
$enfant5 = new Enfant(["age" => 9]);
$enfant6 = new Enfant(["age" => 15]);

// agence
$agence1 = new Agence(["nomAgence" => "agence_1", "adresse" => "rue de Lille", "codePostal" => "59000", "ville" => "Lille", "restauration" => true]);
$agence2 = new Agence(["nomAgence" => "agence_2", "adresse" => "rue de Paris", "codePostal" => "70123", "ville" => "Paris", "restauration" => false]);
$agence3 = new Agence(["nomAgence" => "agence_3", "adresse" => "rue de Popering", "codePostal" => "8970", "ville" => "Popering", "restauration" => false]);
$agence4 = new Agence(["nomAgence" => "agence_4", "adresse" => "rue de Watou", "codePostal" => "8978", "ville" => "Watou", "restauration" => true]);

// employer
$employe1 = new Employe(["nom" => "jean", "prenom" => "pierre", "embauche" => "20-04-1999", "poste" => "chef", "salaire" => 180000, "service" => "chef", "agence" => $agence1, "enfant" => [$enfant1]]);
$employe2 = new Employe(["nom" => "marc", "prenom" => "jean", "embauche" => "03-01-2001", "poste" => "sous-chef", "salaire" => 100000, "service" => "sous-chef", "agence" => $agence2, "enfant" => [$enfant3, $enfant6]]);
$employe3 = new Employe(["nom" => "henri", "prenom" => "paul", "embauche" => "06-06-2023", "poste" => "artiste", "salaire" => 20000, "service" => "test", "agence" => $agence3, "enfant" => []]);
$employe4 = new Employe(["nom" => "francis", "prenom" => "bis", "embauche" => "05-09-2002", "poste" => "penseur", "salaire" => 60000, "service" => "là", "agence" => $agence4, "enfant" => [$enfant2, $enfant4, $enfant5]]);
$employe5 = new Employe(["nom" => "beton", "prenom" => "cis", "embauche" => "26-08-2005", "poste" => "derrière", "salaire" => 2000, "service" => "stage", "agence" => $agence1, "enfant" => [$enfant2, $enfant4, $enfant5, $enfant6]]);
#endregion

// tab des employees
$arrayEmployer = [$employe1, $employe2, $employe3, $employe4, $employe5];

#region
// // affiche la prime annuel par employe
// echo 'Prime annuel :';
// echo "\n";
// foreach ($arrayEmployer as $employe) {
//     echo $employe->primeAnnuel() . " €";
//     echo "\n";
// }
// echo "\n";

// // Permet de savoir si le salaire est versé
// $dateDuJour = new DateTime();

// $jourPrime = ("31-11");

// if ($jourPrime < $dateDuJour) {
//     foreach ($arrayEmployer as $employe) {
//         echo "L'ordre de transfert a été envoyé à la banque pour " . $employe->getNom() . " " . $employe->getPrenom() . " d'un montant de " . $employe->primeAnnuel() . "\n";
//     }
// } else {
//     echo "L'ordre de transfert n'a pas été envoyé à la banque\n";
// }
// echo "\n";

// // nombre d'employe
// echo "Il y a " . Employe::$_nbEmployer . " employer";
// echo "\n";

// // affiche les info par ordre alphabétique sur le nom et le prenom
// usort($arrayEmployer, ["Employe", "compareToNomPrenom"]);
// echo "\n";

// foreach ($arrayEmployer as $personne) {
//     echo $personne;
//     echo "\n";
// }
// echo "\n";

// // affiche les info par ordre alphabétique sur le service, le nom et le prenom
// usort($arrayEmployer, ["Employe", "compareToServiceNomPrenom"]);

// foreach ($arrayEmployer as $personne) {
//     echo $personne;
//     echo "\n";
// }
// echo "\n";

// // montant total masse salariale
// echo 'Coût masse salariale : ';
// function coutMasseSalarial($arrayEmployer)
// {
//     $coutMasseSalarial = 0;

//     foreach ($arrayEmployer as $employe) {
//         $coutMasseSalarial += $employe->masseSalarial();
//     }

//     echo $coutMasseSalarial . " €";
// }
// coutMasseSalarial($arrayEmployer);


// echo "\n";
// echo "\n";
// // echo $employe1->getAgence()->getNomAgence();

// // restauration d'entreprise
// function modeRestauration($arrayEmployer)
// {
//     foreach ($arrayEmployer as $employe) {
//         echo "employe : " . $employe->getNom() . " - agence : " . $employe->getAgence()->getNomAgence() . " - restauration :" . ($employe->getAgence()->getRestauration() ? " restaurant d'entreprise" : " pas de restaurant d'entreprise");
//         echo "\n";
//     }
// }

// modeRestauration($arrayEmployer);
// echo "\n";

// // Permet de donner des cheques
// foreach ($arrayEmployer as $employe) {
//     if ($employe->estChequeVacance()) {
//         echo $employe->getNom() . " CHEQUE !";
//         echo "\n";
//     } else {
//         echo $employe->getNom() . " PAS CHEQUE";
//         echo "\n";
//     }
// }

// echo "\n";


#endregion
// Cheque pour la NOEL  !!

foreach ($arrayEmployer as $employe) {
    echo $employe->aDesEnfants() ? $employe->getNom() . " a des enfants et peut avoir des cheques noel" : $employe->getNom() . " n'a pas d'enfant et ne peut pas avoir de cheque";
    echo "\n";
}
echo "\n";

function chequeNoel($arrayEmployer)
{
    $totalCheque = 0;

    foreach ($arrayEmployer as $employe) {
        echo $employe->getNom() . " : ";
        foreach ($employe->getEnfant() as $enfant) {
            if ($enfant->getAge() < 11) {
                $totalCheque += 20;
                echo " 20 € ";
            } elseif ($enfant->getAge() < 16) {
                $totalCheque += 30;
                echo " 30 € ";
            } elseif ($enfant->getAge() < 19) {
                $totalCheque += 50;
                echo " 50 € ";
            }
        };
        echo "\n";
        echo "somme cheque " . $totalCheque . " €";
        echo "\n";
        $totalCheque = 0;
    }
}

chequeNoel($arrayEmployer);
