// etape 1 :
// changer de place le cube blanc avec d'importe cube quand on click
// le cube blanc ne dois pas déclancher d'évenement
// solution :
// changer class, value ...
// bouger les 2 btn
// identifier le cube blanc avec un data spé
const allBtn = document.querySelectorAll(".btn");

placementAleatoire();

allBtn.forEach((btn) => {
  btn.addEventListener("click", game);
});

//---------------------------------------Function----------------------------------------------------
/**
 * Swap le btn clicke avec le btn blanc
 * @param {*} event
 */
function swapCube(btnClick, positionCubeBlanc) {
  positionCubeBlanc.innerHTML = btnClick.innerHTML;
  positionCubeBlanc.classList.remove("btn-blanc");
  positionCubeBlanc.classList.add("btn");
  btnClick.classList.add("btn-blanc");
  btnClick.classList.remove("btn");
  btnClick.innerHTML = "0";
}

/**
 * Permet de localiser la position du cube blanc
 */
function localisationCubeBlanc() {
  let btnBlanc;
  allBtn.forEach((btn) => {
    if (btn.classList.length == 2) btnBlanc = btn;
  });
  return btnBlanc;
}
/**
 * Fonction avec la logique de jeu
 * @param {*} event
 */
function game(event) {
  let btnClick = event.target;
  let btnClickLigne = event.target.dataset.ligne;
  let btnClickColonne = event.target.dataset.colonne;

  let positionCubeBlanc = document.querySelector(".btn-blanc");

  if (
    (btnClickColonne - positionCubeBlanc.dataset.colonne == 0 &&
      positionCubeBlanc.dataset.ligne - btnClickLigne == 1) ||
    (btnClickColonne - positionCubeBlanc.dataset.colonne == 0 &&
      positionCubeBlanc.dataset.ligne - btnClickLigne == -1) ||
    (btnClickLigne - positionCubeBlanc.dataset.ligne == 0 &&
      positionCubeBlanc.dataset.colonne - btnClickColonne == 1) ||
    (btnClickLigne - positionCubeBlanc.dataset.ligne == 0 &&
      positionCubeBlanc.dataset.colonne - btnClickColonne == -1)
  ) {
    swapCube(btnClick, positionCubeBlanc);
  }
}

/**
 * Place les chiffres de manière aléatoire
 */
function placementAleatoire() {
  let arrayBtnValue = [1, 2, 3, 4, 5, 6, 7, 8];

  let arrayMelanger = arrayBtnValue.sort(() => 0.5 - Math.random());

  let index = 0;

  allBtn.forEach((btn) => (btn.innerHTML = arrayMelanger[index++]));
}
