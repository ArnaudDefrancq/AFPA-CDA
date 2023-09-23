// etape 1 :
// changer de place le cube blanc avec d'importe cube quand on click
// le cube blanc ne dois pas déclancher d'évenement
// solution :
// changer class, value ...
// bouger les 2 btn
// identifier le cube blanc avec un data spé

const allBtn = document.querySelectorAll(".btn");
allBtn.forEach((btn) => {
  btn.addEventListener("click", game);
});

//---------------------------------------Function----------------------------------------------------
/**
 * Swap le btn clicke avec le btn blanc
 * @param {*} event
 */
function swapCube(event) {
  let btnClick = event.target;

  allBtn.forEach((btn) => {
    if (btn.innerHTML == "") {
      // check si le btn est vide
      btn.innerHTML = btnClick.innerHTML;
      btn.classList.remove("btn-blanc");
      btnClick.classList.add("btn-blanc");
      btnClick.innerHTML = "";
    }
  });
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
  let btnClickLigne = event.target.dataset.ligne;
  let btnClickColonne = event.target.dataset.colonne;

  let btnClick = event.target;

  let positionCubeBlanc = localisationCubeBlanc();

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
    positionCubeBlanc.innerHTML = btnClick.innerHTML;
    positionCubeBlanc.classList.remove("btn-blanc");
    btnClick.classList.add("btn-blanc");
    btnClick.innerHTML = "";
  }
}
