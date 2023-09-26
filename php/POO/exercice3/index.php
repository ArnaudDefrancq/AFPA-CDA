<?php
function chargerClasse($classe)
{
    require './Class/' . $classe . '.Class.php';
}
spl_autoload_register('chargerClasse');

$employe1 = new Employe(["nom" => "jean", "prenom" => "pierre", "embauche" => "20-04-1999", "poste" => "chef", "salaire" => 180000, "service" => "chef"]);
$employe2 = new Employe(["nom" => "marc", "prenom" => "jean", "embauche" => "03-01-2001", "poste" => "sous-chef", "salaire" => 100000, "service" => "sous-chef"]);
$employe3 = new Employe(["nom" => "henri", "prenom" => "paul", "embauche" => "06-06-2020", "poste" => "artiste", "salaire" => 20000, "service" => "test"]);
$employe4 = new Employe(["nom" => "patrick", "prenom" => "patout", "embauche" => "05-09-2002", "poste" => "penseur", "salaire" => 60000, "service" => "là"]);
$employe5 = new Employe(["nom" => "francis", "prenom" => "cis", "embauche" => "26-08-2005", "poste" => "derrière", "salaire" => 2000, "service" => "stage"]);

if ($employe1->estVerser()) {
    echo "ordre de transfert a été envoyé à la banque";
    echo "\n";
} else {
    echo "ordre de transfert a été envoyé à la banque sera effectué le 30/11";
    echo "\n";
}


$arrayEmployer = [$employe1, $employe2, $employe3, $employe4, $employe5];

foreach ($arrayEmployer as $employe) {
    echo $employe->primeAnnuel();
    echo "\n";
}
