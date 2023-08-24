<?php
// Catégorie d'âge

//ma version. Pas de switch car pas d'inégalitée dans un switch.
$ageKids = readline('Entrer votre âge :');

function category (int $age) {
    switch ($age) {
        case $age <= 7:
            echo 'Poussin';
            break;
        case $age <= 9:
            echo 'Pupille';
            break;
        case $age <= 11:
            echo 'Minime';
            break;
        default:
            echo 'Cadet';
    }
};

category($ageKids);


//Correction
$age = readline("ton age : ");
$message = '';

if($age > 11){
    $message = 'Cadet';
}elseif($age > 9){
    $message = 'Minime';
}elseif($age > 7){
    $message = 'Pupille';
}elseif($age > 5){
    $message = 'Poussin';
}else{
    $message = 'trop jeune';
}
echo $message;