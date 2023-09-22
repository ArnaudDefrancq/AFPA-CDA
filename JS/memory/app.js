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

const submitConfig = document.getElementById("submit");
// const gameSection = document.getElementById("jeu");
// const templateCarte = document.getElementsByTagName("template")[1];
// const configSection = document.getElementById("config");
// const resetGame = document.getElementById("win-container");
// const btnREset = document.getElementById("reset");

submitConfig.addEventListener("click", () => {
  var inputSelects = document.querySelectorAll(".select-config");

  // Création du tableau de paire
  let tab = creerTab(inputSelects[0].value);

  // Mélanger le tableau
});

// configSection.classList.add("display-none");

// let newArrayCard = arrayCarte.splice(0, nbPaire * 2);

// init(newArrayCard);

// const images = document.querySelectorAll("[data-image]");

// game(images);
// });

// --------------------------------INITIATION DU JEU---------------------------------------------
function creerTab(nbPair) {
  let tab = [];
  for (let index = 0; index < nbPair; index++) {
    tab.push(index + 1);
    tab.push(index + 1);
  }
  console.log(tab);
}

// Mélange les cartes
function melangerTableauDePaire(tableauDePaire) {
  const tableauMelanger = tableauDePaire.sort(() => 0.5 - Math.random());

  placerCarte(tableauMelanger);
}

// Affiche les cartes
function placerCarte(tableauMelanger) {
  for (let index = 0; index < tableauMelanger.length; index++) {
    let elemnt = templateCarte.content.cloneNode(true);
    gameSection.appendChild(elemnt);
    gameSection.innerHTML = gameSection.innerHTML.replace(
      "AUTRE",
      tableauMelanger[index]
    );
    gameSection.innerHTML = gameSection.innerHTML.replace(
      "INDEX",
      tableauMelanger[index]
    );
  }
}
// ----------------------------------------------------------------------------------------------

// --------------------------------JEU-----------------------------------------------------------

const game = (images) => {
  let cartes = [];
  let cartesCliquees = 0;

  // Fonction pour retourner une carte
  function retournerCarte(img) {
    const imageData = img.dataset.image;
    if (img.getAttribute("src") === "./Images/plage.jpg") {
      img.setAttribute("src", "./Images/" + imageData + ".jpg");
    } else {
      img.setAttribute("src", "./Images/plage.jpg");
    }
  }

  // Fonction pour vérifier la paire
  function verifierPaire() {
    if (cartes.length == 2) {
      const carte1 = cartes[0];
      const carte2 = cartes[1];

      if (carte1.dataset.image == carte2.dataset.image) {
        score++;
        cartes = [];
        cartesCliquees = 0;
        if (checkWin(nbPaire)) {
          resetGame.classList.remove("visibility");
          gameSection.classList.add("event-stop");
          resetGame.addEventListener("click", () => {
            location.reload();
          });
        }
      } else {
        setTimeout(() => {
          retournerCarte(carte1);
          retournerCarte(carte2);
          cartes = [];
          cartesCliquees = 0;
        }, 1000);
      }
    }
  }

  images.forEach((img) => {
    img.addEventListener("click", () => {
      if (cartesCliquees < 2 && !cartes.includes(img)) {
        retournerCarte(img);
        cartes.push(img);
        cartesCliquees++;
        verifierPaire();
      }
    });
  });
};

// check la win
const checkWin = (paire) => {
  if (score == paire) {
    return true;
  }
};
