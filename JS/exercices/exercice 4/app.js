const listDessert = document.getElementById("list-dessert");
const btn = document.getElementById("btn");

let dessert = window.prompt("Ajouter un dessert :");

const li = document.createElement("li");
li.setAttribute("class", "list");
li.innerText = dessert;
listDessert.appendChild(li);

btn.addEventListener("click", (e) => {
  const allLi = document.querySelectorAll(".list");
  if (allLi.length > 0) {
    var dernierElement = allLi[allLi.length - 1];
    dernierElement.remove();
  }

  console.log(allLi);
});
