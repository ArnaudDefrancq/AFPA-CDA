<?php
function chargerClasse($classe)
{
    require './Class/' . $classe . '.Class.php';
}
spl_autoload_register('chargerClasse');

// tab avec les valeurs
$arrayRectangle = [
    "longueur" => 8,
    "largeur" => 10
];
$arrayTriangle = [
    "longueur" => 7,
    "largeur" => 4
];

$arrayCercle = [
    'diametre' => 5
];

// création des objets
$rectangle_1 = new Rectangle($arrayRectangle);
$triangle_1 = new Triangle($arrayTriangle);
$cercle_1 = new Cercle($arrayCercle);
$parallelepipede_1 = new Parallelepipede(['longueur' => 8, 'largeur' => 10, 'hauteur' => 6]);
$pyramide_1 = new Pyramide(['longueur' => 8, 'largeur' => 10, 'hauteur' => 6]);
$sphere_1 = new Sphere($arrayCercle);

// affichage
echo $rectangle_1->__toString();
echo "\n";
echo $triangle_1->__toString();
echo "\n";
echo $cercle_1->__toString();
echo "\n";
echo $parallelepipede_1->__toString();
echo "\n";
echo $pyramide_1->__toString();
echo "\n";
echo $sphere_1->__toString();
