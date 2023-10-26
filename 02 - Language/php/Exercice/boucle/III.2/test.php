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


// Façon réaliser l'exercice
// Départ => note les étapes importatnte  

// On collecte les prix
$total = 0; // contient le prix total
$nbArticle = 0;
do {
    // on demande les prix un par un
    do {
        $prix = readline("prix article : ");
    }
    // while(is_numeric($prix) && intval($prix)==$prix && $prix>=0);
    // is_numeric($prix)   vérifie que la chaine saisie ne contient que des chiffres
    // intval($prix)==$prix vérifie que le prix est entier

    while (!preg_match("/^[\d]+$/", $prix) || $prix < 0); // test si la saisie correpond au modèle de la regex c'est à dire numéric sans virgule
    $total += $prix;
    $nbArticle++;
} while ($prix != 0); // on s'arrete quand le prix est = à 0

// On récupère l'argent
echo 'Vous avez acheté ' . --$nbArticle . ' articles pour ' . $total . " euros\n";
do {
    $prixPaye = readline("montant payé : ");
} while (!preg_match("/^[\d]+$/", $prixPaye) || $prixPaye < $total);

// On rend la monnaie
$reste = $prixPaye - $total; // monnaie à rendre
while ($reste >= 10) {
    echo "billet de 10\n";
    $reste -= 10;
}
if ($reste >= 5) { // il ne peut y avoir qu'un seul billet de 5€
    echo "billet de 5\n";
    $reste -= 5;
}
while ($reste >= 1) {
    echo "pièce de 1\n";
    $reste -= 1;
}
