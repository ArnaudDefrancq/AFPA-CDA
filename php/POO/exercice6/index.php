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
$perso = new Personne(["nom" => "arnaud", "prenom" => "moi"]);
// $perso->setIdPersonne(1);
// PersonneManager::delete("Personne", $perso);
// $perso1 = PersonneManager::getListe('personne');
PersonneManager::create($perso);
// var_dump(Parametre::getConfig());
