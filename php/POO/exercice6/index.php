<?php
function chargerClasse($classe)
{
    require './Class/' . $classe . '.Class.php';
}
spl_autoload_register('chargerClasse');


DbConnect::init();
$perso = new Personne(["nom" => "dupon", "prenom" => "toto", "adresse" => "oui", "ville" => "dk"]);
PersonneManager::create($perso);
