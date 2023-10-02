<?php
function chargerClasse($classe)
{
    require './Class/' . $classe . '.Class.php';
}
spl_autoload_register('chargerClasse');


$arrayConnection = [
    "dbName" => "exercicebdd",
    "host" => "localhost",
    "driver" => "mysql",
    "root" => "root",
    "password" => ""
];

// $dbb = new DBConnect()