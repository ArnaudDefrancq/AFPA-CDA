const flecheDirection = document.querySelectorAll(".direction-fleche");
const cube = document.getElementById("carre");
const jeu = document.getElementById("jeu");
const barriere = document.querySelectorAll("[data-barriere]");
const items = document.querySelectorAll("[data-item]");
let isDown = false;
let mousePosition;
var positionDepart = [0, 0];
const mouvCarre = 50;
let positionDepartX, positionDepartY;
let nbItems = items.length;
const timerSpan = document.getElementById("timer");

cube.style.setProperty("--X", positionDepart[0] + "px");
cube.style.setProperty("--Y", positionDepart[1] + "px");

const deplacerCube = (X, Y) => {
  let deplacerCarreBon = true;
  let recupererItem = true;
  let styleCube = window.getComputedStyle(cube, null);
  let topCube = parseInt(styleCube.top);
  let leftCube = parseInt(styleCube.left);
  let widthCube = parseInt(styleCube.width);
  let heightCube = parseInt(styleCube.height);

  // console.log("cube : ", topCube, leftCube, widthCube, heightCube);

  barriere.forEach((elt) => {
    let styleBarriere = window.getComputedStyle(elt);
    let topBarriere = parseInt(styleBarriere.top);
    let leftBarriere = parseInt(styleBarriere.left);
    let widthBarriere = parseInt(styleBarriere.width);
    let heightBarriere = parseInt(styleBarriere.height);

    deplacerCarreBon =
      deplacerCarreBon &&
      checkCollision(
        topBarriere,
        leftBarriere,
        widthBarriere,
        heightBarriere,
        topCube + X,
        leftCube + Y,
        widthCube,
        heightCube
      );
  });

  items.forEach((item) => {
    let styleItem = window.getComputedStyle(item);
    let topItem = parseInt(styleItem.top);
    let leftItem = parseInt(styleItem.left);
    let widthItem = parseInt(styleItem.width);
    let heightItem = parseInt(styleItem.height);

    recupererItem =
      recupererItem &&
      recupItems(
        topItem,
        leftItem,
        widthItem,
        heightItem,
        topCube + X,
        leftCube + Y,
        widthCube,
        heightCube
      );

    if (!recupererItem) {
      supprItems(topItem, leftItem, topCube + X, leftCube + Y, item);
    }

    if (nbItems == 0) {
      alert("gagné");
    }
  });

  if (deplacerCarreBon) {
    cube.style.setProperty("--X", (positionDepart[0] += X) + "px");
    cube.style.setProperty("--Y", (positionDepart[1] += Y) + "px");
  }

  if (items.length == 0) {
    console.log("gagner");
  }
};

const checkCollision = (tb, lb, wb, hb, tc, lc, wc, hc) => {
  if (lc < lb + wb && lc + wc > lb && tc < tb + hb && tc + hc > tb) {
    return false;
  }
  return true;
};

const recupItems = (tb, lb, wb, hb, tc, lc, wc, hc) => {
  if (lc < lb + wb && lc + wc > lb && tc < tb + hb && tc + hc > tb) {
    return false;
  }
  return true;
};

const supprItems = (tb, lb, tc, lc, itm) => {
  if (lc == lb && tc == tb) {
    nbItems--;
    itm.remove();
  }
  return false;
};

document.addEventListener("keydown", (e) => {
  switch (e.keyCode) {
    case 40:
      if (positionDepart[0] < jeu.offsetHeight - mouvCarre) {
        deplacerCube(mouvCarre, 0);
      }
      break;
    case 38:
      if (positionDepart[0] > 0) {
        deplacerCube(-mouvCarre, 0);
      }
      break;
    case 37:
      if (positionDepart[1] > 0) {
        deplacerCube(0, -mouvCarre);
      }
      break;
    case 39:
      if (positionDepart[1] < jeu.offsetWidth - mouvCarre) {
        deplacerCube(0, mouvCarre);
      }
      break;
    default:
      break;
  }
});

// let i = 0;

// setInterval(() => {
//   i++;
//   timerSpan.innerHTML = i++;
//   if (nbItems == 0) {
//     console.log("stop");
//   }
// }, 1000);

// cube.addEventListener("mousedown", (e) => {
//   isDown = true;

//   positionDepartX = e.clientX;
//   positionDepartY = e.clientX;
// });
// jeu.addEventListener("mousemove", (e) => {
//   if (isDown) {
//     mousePosition = {
//       x: e.clientX - jeu.getBoundingClientRect().left - mouvCarre / 2,
//       y: e.clientY - jeu.getBoundingClientRect().top - mouvCarre / 2,
//     };

//     if (mousePosition.x < jeu.offsetWidth - mouvCarre && mousePosition.x > 0) {
//       cube.style.setProperty("--Y", mousePosition.x + "px");
//     }

//     if (mousePosition.y < jeu.offsetHeight - mouvCarre && mousePosition.y > 0) {
//       cube.style.setProperty("--X", mousePosition.y + "px");
//     }
//   }
// });
// cube.addEventListener("mouseup", () => {
//   isDown = false;
// });
// flecheDirection.forEach((fleche) => {
//   fleche.addEventListener("click", () => {
//     if (positionDepart[0] < jeu.offsetHeight - mouvCarre) {
//       if (fleche.dataset.down == "down") {
//         cube.style.setProperty("--X", (positionDepart[0] += mouvCarre) + "px");
//       }
//     }
//     if (positionDepart[0] > 0) {
//       if (fleche.dataset.up == "up") {
//         cube.style.setProperty("--X", (positionDepart[0] += -mouvCarre) + "px");
//       }
//     }
//     if (positionDepart[1] > 0) {
//       if (fleche.dataset.left == "left") {
//         cube.style.setProperty("--Y", (positionDepart[1] += -mouvCarre) + "px");
//       }
//     }

//     if (positionDepart[1] < jeu.offsetWidth - mouvCarre) {
//       if (fleche.dataset.right == "right") {
//         cube.style.setProperty("--Y", (positionDepart[1] += mouvCarre) + "px");
//       }
//     }
//   });
// });

// lc == lb + wb && lc + wc == lb && tc == tb + hb && tc + hc == tb
