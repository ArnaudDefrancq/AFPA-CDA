<?php
require_once "./Rectangle.class.php";
require_once "./Triangle.class.php";
require_once "./Cercle.class.php";

$array = [
    "longueur" => 8,
    "largeur" => 10
];

$arrayCercle = [
    'diametre' => 5
];


$rectangle_1 = new Rectangle($array);
$triangle_1 = new Triangle($array);
$cercle_1 = new Cercle($arrayCercle);


echo $rectangle_1->__toString();
echo "\n";
echo $triangle_1->__toString();
echo "\n";
echo $cercle_1->__toString();
