<?php
function chargerClasse($classe)
{
    require './Class/' . $classe . '.Class.php';
}
spl_autoload_register('chargerClasse');

$employe1 = new Employe(["embauche" => "26-08-2020"]);

echo $employe1->__toString();
