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

// Finir => si carte fausse retourne les 2 cartes

const inputSelects = document.querySelectorAll(".select-config");
const submitConfig = document.getElementById("submit");
const gameSection = document.getElementById("jeu");
const templateCarte = document.getElementsByTagName("template")[1];
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

  submitConfig.classList.add("event-stop");

  let newArrayCard = arrayCarte.splice(0, nbPaire * 2);

  init(newArrayCard);

  const images = document.querySelectorAll("[data-image]");

  choisirUneCarte(images);
});

/**
 * init le nb de carte, de jouer, mélange le tableau de carte et affiche les cartes
 */
const init = (array) => {
  melangerTableauDePaire(array);
};

/**
 * Mélange aléatoirement un tableau
 *
 * @param array  tableau a mélanger
 * @return array le tableau mélangee
 */
const melangerTableauDePaire = (tableauDePaire) => {
  const tableauMelanger = tableauDePaire.sort(() => 0.5 - Math.random());

  placerCarte(tableauMelanger);
};

/**
 * Affiche en HTML les paires retourné
 *
 * @param array tableau melanger
 */
const placerCarte = (tableauMelanger) => {
  for (let index = 0; index < tableauMelanger.length; index++) {
    let elemnt = templateCarte.content.cloneNode(true);
    gameSection.appendChild(elemnt);
    gameSection.innerHTML = gameSection.innerHTML.replace(
      "INDEX",
      tableauMelanger[index]
    );
  }
};

/**
 * Permet de retouner un carte quand le joueur clique sur une carte
 *
 * @param array tableau mélanger
 * @param int le joueur qui joue
 *
 * @return array tableau avec les cartes choisies par le joueur
 */
const choisirUneCarte = (images) => {
  let cartes = [];

  images.forEach((img) => {
    img.addEventListener("click", (e) => {
      filpCard(e, img);
      cartes.push(img.dataset.image);
      if (cartes.length == 2 && checkPaire(cartes)) {
        score++;
        cartes = [];
      } else if (cartes.length == 2 && !checkPaire(cartes)) {
      }
    });
  });
};

function filpCard(test, carte) {
  carte.setAttribute("src", "./Images/" + test.target.dataset.image + ".jpg");
}

/**
 * Permet de vérifier si les cartes choisies sont de paires
 * Si bon -> on laisse les cartes affichées et le joueur gagne 1 point
 * Si faux -> on retourne les cartes choisies
 *
 * @param array tableau de carte choisi par le joueur
 * @param int le joueur qui joue
 *
 * @return array tableau de paire trouvée
 */
const checkPaire = (choixCarte) => {
  if (choixCarte[0] == choixCarte[1]) {
    return true;
  } else {
    return false;
  }
};

/**
 * Check si toute les paires on était trouvée et affiche le joueur qui a gagné
 *
 * @param array tableau avec toute les paires
 * @param array tableau de paire trouvée
 */
const checkWin = (tableauDePaire, paireTrouver) => {};

/**
 * Détermine qui est le premier joueur et l'affiche
 *
 * @param int nombre de joueur
 * @return int numéro du joueur qui commence
 */
// const quiJoue = (nbJoueur) => {};

/**
 * Permet de déterminer qui sera le joueur suivant
 *
 * @param int nombre de joueur
 * @param int le joueur qui joue
 */
// const joueurSuivant = (nbJoueur, quiJoue) => {};
