const para = document.querySelectorAll(".para");
const titres = document.querySelectorAll(".titre");
const titreH4 = document.querySelectorAll("[data-h4]");

para.forEach((elt) => {
  elt.addEventListener("click", (e) => {
    e.target.classList.forEach((color) => {
      if (color == "para") {
        elt.classList.remove("para");
        elt.classList.add("color1");
      }
      if (color == "color1") {
        elt.classList.remove("color1");
        elt.classList.add("color2");
      }
      if (color == "color2") {
        elt.classList.remove("color2");
        elt.classList.add("para");
      }
    });
  });
});

titres.forEach((titre) => {
  titre.addEventListener("click", (e) => {
    titres.forEach((titre) => {
      if (titre.classList.contains("color1")) {
        titre.classList.remove("color1");
        titre.classList.add("color2");
      } else if (titre.classList.contains("color2")) {
        titre.classList.remove("color2");
      } else {
        titre.classList.add("color1");
      }
    });
  });
});

titreH4.forEach((h4) => {
  h4.addEventListener("click", (e) => {
    titreH4.forEach((titre) => {
      if (titre.dataset.h4 == "h4") {
        if (titre.classList.contains("color1")) {
          titre.classList.remove("color1");
          titre.classList.add("color2");
        } else if (titre.classList.contains("color2")) {
          titre.classList.remove("color2");
        } else {
          titre.classList.add("color1");
        }
      }
    });
  });
});

// if (titre.classList.contains("titre-h4")) {
//   if (titre.classList.contains("color1")) {
//     titre.classList.remove("color1");
//     titre.classList.add("color2");
//   } else if (titre.classList.contains("color2")) {
//     titre.classList.remove("color2");
//   } else {
//     titre.classList.add("color1");
//   }
// }
