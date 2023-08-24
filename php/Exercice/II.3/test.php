<?php
// Condition combinées
$age = readline('Âge : ');
$sexe = readline('Sexe (f/h) : ');

if (($sexe == 'h' && $age > 20) || ($sexe == 'f' && ($age < 36 && $age > 17))) {
    echo 'imposable';
} else {
    echo 'non imposable';
}