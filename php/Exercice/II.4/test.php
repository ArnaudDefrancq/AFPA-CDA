<?php
// Conditions implicites
$candidat1 = readline('score 1 : ');
$candidat2 = readline('score 2 : ');
$candidat3 = readline('score 3 : ');
$candidat4 = readline('score 4 : ');




if ($candidat1 > 50) {
    echo 'élu';
} elseif ($candidat1 >= 12.5) {
    
} else {
    echo 'ne passe pas le premier tour';
}