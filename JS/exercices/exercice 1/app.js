// Variante 1 (2 img dans le html)

// ------------------------------------------------------ //
const ampoules1 = document.getElementById("eteinte");
const ampoules2 = document.getElementById("allumer");

ampoules1.addEventListener("click", (e) => {
  if (e.target.classList != "noDisplay") {
    ampoules1.classList.add("noDisplay");
    ampoules2.classList.remove("noDisplay");
  }
});
ampoules2.addEventListener("click", (e) => {
  if (e.target.classList != "noDisplay") {
    ampoules2.classList.add("noDisplay");
    ampoules1.classList.remove("noDisplay");
  }
});

// ------------------------------------------------------ //

// const div = document.getElementById("div");
// const ampoules = document.querySelectorAll(".ampoule");

// div.addEventListener("click", (e) => {
//   ampoules.forEach((elt) => {
//     if (elt.classList.length != 1) {
//       elt.classList.remove("noDisplay");
//     } else {
//       elt.classList.add("noDisplay");
//     }
//   });
// });

// ------------------------------------------------------ //

// Variante 1 div

// ------------------------------------------------------ //

// const body = document.getElementById("body");

// Ajout de l'image sur le DOM
// const img = document.createElement("img");
// img.setAttribute("src", "../1 IMG/ampoule eteinte.PNG");
// img.classList.add("ampoule");

// body.appendChild(img);

// Modif de l'image
// img.addEventListener("click", (e) => {
//   if (e.target.attributes[0].textContent != "../1 IMG/ampoule eteinte.PNG") {
//     img.setAttribute("src", "../1 IMG/ampoule eteinte.PNG");
//   } else {
//     img.setAttribute("src", "../1 IMG/ampoule allumee.png");
//   }
// });
