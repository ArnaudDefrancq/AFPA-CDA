// But du jeu : trouver toute les paires de carte
// On demande le nombre de joueur
// On demande le nombre de paire
// Placer aléatoirement les paires
// Quand le joueur click sur une carte, on montre la carte
// La carte reste tournée le temps que le joueur n'a pas choisit une autre carte
// Le joueur choisit une autre carte
// On test le choix : SI paire -> on retire ou on laisse les cartes et le joueur peut rejouer
//                    SI différent -> on laisse les carte et on les retourne et l'autre joueur joue
// Le jeu se termine quand toute les paires sont trouvées
// Le gagnant est celui avec le plus de paire

// Amélioration du jeu => ajout de plusieurs joueur, timer
// Retravailler le code en diminuant les variables globales
// ----------------------------------------------------------------------------------------------
var carteSelectionnee = [];
// ----------------------------------------------------------------------------------------------
const submitConfig = document.getElementById("submit");
submitConfig.addEventListener("click", game);

// ----------------------------------------------------------------------------------------------
function game() {
  submitConfig.classList.add("event-stop");

  var inputSelects = document.querySelectorAll(".select-config");

  // Création du tableau de paire
  let tab = creerTab(inputSelects[0].value);

  // Placer les cartes
  placerCarte(tab);

  // Logique du jeu
  let cartes = document.querySelectorAll(".img");
  cartes.forEach((carte) => {
    carte.addEventListener("click", logiqueDeJeu);
  });
}

/**
 * Créer et mélange un tableau de paire
 * @param {*} nbPair nombre de paire choisie par l'utilisateur
 * @returns
 */
function creerTab(nbPair) {
  let tab = [];
  for (let index = 0; index < nbPair; index++) {
    tab.push(index + 1);
    tab.push(index + 1);
  }
  tab.sort(() => 0.5 - Math.random());

  return tab;
}

/**
 * Place les cartes
 * @param {*} tableauMelanger
 */
function placerCarte(tableauMelanger) {
  let zoneJeu = document.getElementById("jeu");
  let templateCarte = document.getElementById("template-carte");

  for (let index = 0; index < tableauMelanger.length; index++) {
    let elemnt = templateCarte.content.cloneNode(true);
    zoneJeu.appendChild(elemnt);
    zoneJeu.innerHTML = zoneJeu.innerHTML.replace(
      "INDEX",
      tableauMelanger[index]
    );
  }
}

/**
 * Logique de jeu
 * @param {*} event
 */
const logiqueDeJeu = (event) => {
  let uneCarte = event.target;
  if (carteSelectionnee.length < 2) {
    flipCarte(event.target);

    if (!carteSelectionnee.includes(uneCarte)) {
      carteSelectionnee.push(uneCarte);
    }

    if (carteSelectionnee.length == 2) {
      if (verifierPaire(carteSelectionnee)) {
        carteSelectionnee.forEach((elemt) => {
          elemt.removeEventListener("click", logiqueDeJeu);
        });
        carteSelectionnee = [];
      } else {
        setTimeout(() => {
          carteSelectionnee.forEach((element) => {
            console.log(element);
            flipCarte(element);
          });

          //on vide le tableau des cartes cliquées
          carteSelectionnee = [];
        }, 1000);
      }
    }
  }
};

/**
 * Permet de retourner une carte si quand on click dessu
 * @param {*} img
 */
function flipCarte(img) {
  let imageData = img.dataset.image;
  if (img.getAttribute("src") == "./Images/plage.jpg") {
    img.setAttribute("src", "./Images/" + imageData + ".jpg");
  } else {
    img.setAttribute("src", "./Images/plage.jpg");
  }
}

/**
 * Vérifie si les cartes choisies sont des paires
 * @param {*} tab
 */
function verifierPaire(tab) {
  let carte_1 = tab[0].getAttribute("data-image");
  let index = 1;
  while (
    index < tab.length &&
    tab[index].getAttribute("data-image") == carte_1
  ) {
    index++;
  }
  if (index == tab.length) return true;
  return false;
}
