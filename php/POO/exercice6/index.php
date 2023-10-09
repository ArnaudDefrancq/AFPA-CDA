<?php
function chargerClasse($classe)
{
    if (file_exists("./controller/" . $classe . ".Class.php"))
        require "./controller/" . $classe . ".Class.php";
    else if (file_exists("./model/" . $classe . ".Class.php"))
        require "./model/" . $classe . ".Class.php";
}
spl_autoload_register('chargerClasse');


DbConnect::init();
$perso = new Personne(["nom" => "test", "prenom" => "jean", "adresse" => "oui"]);
// $perso->setIdPersonne(1);
// PersonneManager::create($perso);
// $perso1 = PersonneManager::getListe('personne');
// var_dump($perso1);
PersonneManager::create("Personne", $perso);
