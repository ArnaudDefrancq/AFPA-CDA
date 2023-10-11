<?php
require "./GenerateForm.php";

$arrayTest = [
    "personne" => [
        "idPersonne" => "integer",
        "nom" => "varchar",
        "age" => "integer",
        "inscription" => "datetime"
    ],
    "ville" => [
        "idVille" => 'integer',
        "nom" => 'varchar'
    ]
];


var_dump($arrayTest);

var_dump(GenerateForm::generateFromClass($arrayTest));
