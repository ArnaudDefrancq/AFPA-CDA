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

const inputSelects = document.querySelectorAll(".select-config");
const submitConfig = document.getElementById("submit");
const gameSection = document.getElementById("jeu");
const templateCarte = document.getElementsByTagName("template")[1];
const configSection = document.getElementById("config");
const arrayCarte = [1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8];
var joueur;
var nbPaire;
var score = 0;

submitConfig.addEventListener("click", () => {
  inputSelects.forEach((elemnt) => {
    if (elemnt.id == "nb-joueur") {
      return (joueur = elemnt.value);
    } else {
      return (nbPaire = elemnt.value);
    }
  });

  configSection.classList.add("display-none");

  let newArrayCard = arrayCarte.splice(0, nbPaire * 2);

  init(newArrayCard);

  const images = document.querySelectorAll("[data-image]");

  game(images);
});

// --------------------------------INITIATION DU JEU---------------------------------------------
// init le jeu
function init(arrayInitial) {
  melangerTableauDePaire(arrayInitial);
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
        checkWin(nbPaire);
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
        console.log(cartesCliquees, cartes);
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
  if (score == paire) alert("gagner");
};
