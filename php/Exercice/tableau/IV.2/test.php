<?php
// Tier un tableau avec sort ...

$array = [
    9, 50, 33, 65, 8, 26, 2, 44
];


$array2 = ['banane', 'pelle', 'abricot', 'cis', 'boucherie', 'mure'];


$arrayKey = [
    'prénom' => 'Anne-Fred',
    'age' => 66,
    'nationalité' => 'Française',
    'genre' => 'oui/non'
];


function compare($a)
{
    if (strlen($a) == 'age') return 'age';
}

uksort($arrayKey, 'compare');

foreach ($arrayKey as $key => $value) {
    echo $key . ' : ' . $value . "\n";
}





/* Les différents sort : 
    arsort — Trie un tableau en ordre décroissant et conserve l'association des index
    asort — Trie un tableau en ordre croissant et conserve l'association des index
    krsort — Trie un tableau en fonction des clés en ordre décroissant
    ksort — Trie un tableau en fonction des clés en ordre croissant
    rsort — Trie un tableau en ordre décroissant
    sort — Trie un tableau en ordre croissant
    uasort — Trie un tableau en utilisant une fonction de rappel
    uksort — Trie un tableau par ses clés en utilisant une fonction de rappel
    usort — Trie un tableau en utilisant une fonction de comparaison
    */
    
    /*
    arsort($array);
    var_dump($array);
    
    asort($array);
    var_dump($array);
    
    krsort($array);
    var_dump($array);
    
    ksort($array);
    var_dump($array);
    
    rsort($array);
    var_dump($array);
    
    sort($array);
    var_dump($array);
    
    fx cmp => compare les éléments du tableau
    function cmp($a, $b)
    {
        if ($a == $b) {
            return 0;
        }
        return ($a < $b) ? -1 : 1;
    }
    
    uasort($array, 'cmp');
    var_dump($array);
    */