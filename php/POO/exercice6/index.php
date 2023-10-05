<?php
function chargerClasse($classe)
{
    if (file_exists("./controller/" . $classe . ".Class.php"))
        require "./controller/" . $classe . ".Class.php";
    else if (file_exists("./model/" . $classe . ".Class.php"))
        require "./model/" . $classe . ".Class.php";
}
spl_autoload_register('chargerClasse');


// DbConnect::init();
// $perso = new Personne(["nom" => "dupon", "prenom" => "toto", "adresse" => "oui", "ville" => "dk"]);
// $perso->setIdPersonne(1);
// PersonneManager::create($perso);
// $perso1 = PersonneManager::getListe('personne');
// var_dump($perso1);


// $arrayTest = ["idPersonne", "nom", "prenom", "adresse", "ville"];
$arrayTest = ["nom" => false, "prenom" => true];

// echo count($arrayTest);



// PersonneManager::getColonne(); ok
echo PersonneManager::getOrderBy($arrayTest);
