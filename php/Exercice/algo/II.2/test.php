<?php
// conditions combinées aveugles
// if ($tutu > $toto + 4 || $tata === 'ok') {
//     echo $tutu + 1;
// } else {
//     echo $tutu - 1;
// }

$tutu = readline('tutu : ');
$toto = readline('toto : ');
$tata = readline('tata : ');
//  autre manière



if ($tutu < 4 - $toto && $tata === 'ok') {
    echo 'faux';
} else {
    echo 'vrai';
}

// correction

// tutu <= toto + 4 && tata != 'ok'