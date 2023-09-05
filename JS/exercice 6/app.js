const flecheDirection = document.querySelectorAll(".direction-fleche");
const cube = document.getElementById("carre");
const jeu = document.getElementById("jeu");
let isDown = false;
let mousePosition;

var positionDepart = [0, 0];

const mouvCarre = 100;

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
  let startX = e.clientX;
  let startY = e.clientY;

  jeu.addEventListener("mousemove", (e) => {
    if (isDown) {
      mousePosition = {
        x: e.clientX - startX,
        y: e.clientY - startY,
      };

      cube.style.setProperty("--X", mousePosition.y + "px");
      cube.style.setProperty("--Y", mousePosition.x + "px");
    }
  });

  cube.addEventListener("mouseup", (e) => {
    isDown = false;
  });
});
