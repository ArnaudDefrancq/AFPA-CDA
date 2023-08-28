<?php
// La bonne boucle

// Ajout des articles
$article = readline('Ajouter le  prix de l\'article : ');
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

// Payement des artciles
$currency = readline('Payer vos articles : ');
$arrayCurrency = [];
$sumCurrency = 0;
array_push($arrayCurrency, $currency);

while ($sumArticle != $sumCurrency) {
    $currency = readline('Payer vos articles : ');
    array_push($arrayCurrency, $currency);
    $sumCurrency = array_sum($arrayCurrency);

    if ($sumArticle < $sumCurrency) {
        array_pop($arrayCurrency);
        echo 'Vous avez donner trop' . "\n";
    }

    if ($sumArticle == $sumCurrency) {
        echo 'Vos achats sont payer !';
    }
}
