const flecheDirection = document.querySelectorAll(".direction-fleche");
const cube = document.getElementById("carre");
const jeu = document.getElementById("jeu");
let isDown = false;
let mousePosition;

var positionDepart = [];

const mouvCarre = 100;

let positionDepartX, positionDepartY;

cube.style.setProperty("--X", positionDepart[0] + "px");
cube.style.setProperty("--Y", positionDepart[1] + "px");

flecheDirection.forEach((fleche) => {
  fleche.addEventListener("click", () => {
    if (positionDepart[0] < jeu.offsetHeight - mouvCarre) {
      if (fleche.dataset.down == "down") {
        cube.style.setProperty("--X", (positionDepart[0] += mouvCarre) + "px");
      }
    }
    if (positionDepart[0] > 0) {
      if (fleche.dataset.up == "up") {
        cube.style.setProperty("--X", (positionDepart[0] += -mouvCarre) + "px");
      }
    }
    if (positionDepart[1] > 0) {
      if (fleche.dataset.left == "left") {
        cube.style.setProperty("--Y", (positionDepart[1] += -mouvCarre) + "px");
      }
    }

    if (positionDepart[1] < jeu.offsetWidth - mouvCarre) {
      if (fleche.dataset.right == "right") {
        cube.style.setProperty("--Y", (positionDepart[1] += mouvCarre) + "px");
      }
    }
  });
});

window.addEventListener("keydown", (e) => {
  switch (e.keyCode) {
    case 40:
      if (positionDepart[0] < jeu.offsetHeight - mouvCarre) {
        cube.style.setProperty("--X", (positionDepart[0] += mouvCarre) + "px");
      }
      break;
    case 38:
      if (positionDepart[0] > 0) {
        cube.style.setProperty("--X", (positionDepart[0] += -mouvCarre) + "px");
      }
      break;
    case 37:
      if (positionDepart[1] > 0) {
        cube.style.setProperty("--Y", (positionDepart[1] += -mouvCarre) + "px");
      }
      break;
    case 39:
      if (positionDepart[1] < jeu.offsetWidth - mouvCarre) {
        cube.style.setProperty("--Y", (positionDepart[1] += mouvCarre) + "px");
      }
      break;
    default:
      break;
  }
});

cube.addEventListener("mousedown", (e) => {
  isDown = true;

  positionDepartX = e.clientX;
  positionDepartY = e.clientX;
});
jeu.addEventListener("mousemove", (e) => {
  if (isDown) {
    mousePosition = {
      x: e.clientX - jeu.getBoundingClientRect().left - mouvCarre / 2,
      y: e.clientY - jeu.getBoundingClientRect().top - mouvCarre / 2,
    };

    if (mousePosition.x < jeu.offsetWidth - mouvCarre && mousePosition.x > 0) {
      cube.style.setProperty("--Y", mousePosition.x + "px");
    }

    if (mousePosition.y < jeu.offsetHeight - mouvCarre && mousePosition.y > 0) {
      cube.style.setProperty("--X", mousePosition.y + "px");
    }
  }
});
cube.addEventListener("mouseup", () => {
  isDown = false;
});
