<?php
function chargerClasse($classe)
{
    if (file_exists("./controller/" . $classe . ".Class.php"))
        require "./controller/" . $classe . ".Class.php";
    else if (file_exists("./model/" . $classe . ".Class.php"))
        require "./model/" . $classe . ".Class.php";
}
spl_autoload_register('chargerClasse');

Parametre::getConfig();
DbConnect::init();
// $perso = new Personne(["idPersonne" => 7]);
// $perso->setIdPersonne(1);
// PersonneManager::delete("Personne", $perso);
$test = [
    "nom",
    "prenom"
];

$perso1 = PersonneManager::getList($test, null, null, null, true);

var_dump($perso1);
// PersonneManager::delete($perso);
// Parametre::getConfig();
