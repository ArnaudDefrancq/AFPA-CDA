const para = document.querySelectorAll(".para");
const titres = document.querySelectorAll(".titre");

para.forEach((elt) => {
  elt.addEventListener("click", (e) => {
    e.target.classList.forEach((color) => {
      console.log(e);
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
      titre.classList.add("color1");
      console.log(titre.classList);
    });
    console.log(e);
  });
});
