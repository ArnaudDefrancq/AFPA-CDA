<?php
require_once "./Rectangle.php";

$rectangle = [
    "longueur" => 8,
    "largeur" => 8
];


$rectangle_1 = new Rectangle($rectangle);


echo $rectangle_1->__toString();
