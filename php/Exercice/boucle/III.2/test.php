<?php
// La bonne boucle

// Ajout des articles
do {
    $article = readline('Ajouter le  prix de l\'article : ');
} while ($article <= 0);

$arrayArticle = [];
array_push($arrayArticle, $article);



while ($article != 0) {
    $article = readline('Ajouter le  prix de l\'article : ');
    if ($article != 0) {
        array_push($arrayArticle, $article);
    }
}

$sumArticle = array_sum($arrayArticle);
$countArticle = count($arrayArticle);

echo 'Vous avez ' . $countArticle . ' articles' . "\n";
echo 'Pour un total de ' . $sumArticle . '€' . "\n";


// Rendre la monnaie 
do {
    $makeCurrency = readline('Payer avec : ');
} while ($makeCurrency <= $sumArticle);

$diff = $makeCurrency - $sumArticle;
$totalBillet = [];

// si 30 € a rendre => 10€, 10€, 10€ ...
while ($diff != 0) {
    if ($diff >= 10) {
        $diff -= 10;
        array_push($totalBillet, 10);
    } else {
        $diff -= 1;
        array_push($totalBillet, 1);
    }
}

rsort($totalBillet);

foreach ($totalBillet as $billet) {
    echo $billet . ' € ';
}
