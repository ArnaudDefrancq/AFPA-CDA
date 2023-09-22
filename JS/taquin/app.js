// etape 1 :
// changer de place le cube blanc avec d'importe cube quand on click
// le cube blanc ne dois pas déclancher d'évenement
// solution :
// changer class, value ...
// bouger les 2 btn
// identifier le cube blanc avec un data spé

const allBtn = document.querySelectorAll(".btn");
allBtn.forEach((btn) => {
  btn.addEventListener("click", swapCube);
});

//---------------------------------------Function----------------------------------------------------
function swapCube(event) {
  let btnClick = event.target; // recup le btn clicker

  allBtn.forEach((btn) => {
    if (btn.innerHTML == "") {
      btn.innerHTML = btnClick.innerHTML;
      btn.classList.remove("btn-blanc");
      btnClick.classList.add("btn-blanc");
      btnClick.innerHTML = "";
    }
  });
}
