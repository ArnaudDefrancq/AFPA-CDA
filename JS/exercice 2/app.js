const quantite = document.getElementById("quantite");
const prixUnitaire = document.getElementById("prixUnitaire");
const prix = document.getElementById("prix");
const tableau = document.getElementById("tableau");

const nombreDeLigneDepart = 5;

const createLabel = (nom, chiffre) => {
  const label = document.createElement("label");
  label.setAttribute("for", nom + "-" + chiffre);
  label.innerText = nom;

  return label;
};

const createInput = (nom, chiffre) => {
  const input = document.createElement("input");
  input.setAttribute("type", "number");
  input.setAttribute("name", nom + "-" + chiffre);
  input.setAttribute("id", nom + "-" + chiffre);

  return input;
};

const generateTableau = (section, nomTableau) => {
  for (let i = 0; i <= 5; i++) {
    const divLabelInput = document.createElement("div");
    divLabelInput.classList.add("divLabelInput");

    const newLabel = createLabel(nomTableau, i);
    const newInput = createInput(nomTableau, i);

    divLabelInput.appendChild(newLabel);
    divLabelInput.appendChild(newInput);

    section.appendChild(divLabelInput);
  }
};

generateTableau(quantite, "quantite");
generateTableau(prixUnitaire, "prix-unitaire");
generateTableau(prix, "prix");

const inputPrix0 = document.getElementById("prix0");
const inputPrix1 = document.getElementById("prix1");
const inputPrix2 = document.getElementById("prix2");
const inputPrix3 = document.getElementById("prix3");
const inputPrix4 = document.getElementById("prix4");
const inputPrix5 = document.getElementById("prix5");

quantite.addEventListener("change", (e) => {
  console.log(e.target, e.target.value);
});
