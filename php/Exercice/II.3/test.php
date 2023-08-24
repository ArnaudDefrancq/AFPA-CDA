<?php
// Condition combinées
$age = readline('Âge : ');
$sexe = readline('Sexe (f/h) : ');

if ($sexe === 'h' && $age > 20) {
    echo 'imposable';
} elseif ($sexe === 'f' && ($age < 35 && $age > 17)) {
    echo  'imposable';
} else {
    echo 'non imposable';
}