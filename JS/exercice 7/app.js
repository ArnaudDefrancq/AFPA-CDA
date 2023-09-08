const inputs = document.querySelectorAll(".input");
const btn = document.getElementById("btn");
const messageError = document.getElementById("error");

let inputPhone;
let inputPostal;
let inputMail;
let inputPassword;

let REGEX_NAME = /^[a-z]{3,40}$/;
let REGEX_PHONE = /(0|\+33)[1-9]( *[0-9]{2}){4}/;
let REGEX_POSTAL = /^[\d]{5}$/;
let REGEX_MAIL = /^[a-z0-9.]+@[a-z]+.[a-z]+/;
let REGEX_PASSWORD =
  /^(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?=.*[^\w\d\s:])([^\s]){8,}$/;

const checkSaisiName = (name, regex) => {
  if (name.match(regex)) {
    return true;
  } else {
    return false;
  }
};

const checkSaisiPhone = (phone, regex) => {
  if (phone.match(regex)) {
    return true;
  } else {
    return false;
  }
};
const checkSaisiPostal = (postal, regex) => {
  if (postal.match(regex)) {
    return true;
  } else {
    return false;
  }
};
const checkSaisiMail = (mail, regex) => {
  if (mail.match(regex)) {
    return true;
  } else {
    return false;
  }
};
const checkSaisiPasword = (password, regex) => {
  if (password.match(regex)) {
    return true;
  } else {
    return false;
  }
};

const controleSaisiInput = () => {
  inputs.forEach((input) => {
    if (input.name == "name") {
      inputName = input.value.toLowerCase();
      REGEX_NAME = input.pattern;
      if (!checkSaisiName(inputName, REGEX_NAME))
        input.classList.add("bad-input");
      return inputName, REGEX_NAME;
    }
    if (input.name == "phone") {
      inputPhone = input.value;
      REGEX_PHONE = input.pattern;
      if (!checkSaisiName(inputPhone, REGEX_PHONE))
        input.classList.add("bad-input");
      return inputPhone, REGEX_PHONE;
    }
    if (input.name == "postal") {
      inputPostal = input.value;
      REGEX_POSTAL = input.pattern;
      if (!checkSaisiName(inputPostal, REGEX_POSTAL))
        input.classList.add("bad-input");
      return inputPostal, REGEX_POSTAL;
    }
    if (input.name == "email") {
      inputMail = input.value.toLowerCase();
      REGEX_MAIL = input.pattern;
      if (!checkSaisiName(inputMail, REGEX_MAIL))
        input.classList.add("bad-input");
      return inputMail, REGEX_MAIL;
    }
    if (input.name == "password") {
      inputPassword = input.value;
      REGEX_PASSWORD = input.pattern;
      if (!checkSaisiName(inputPassword, REGEX_PASSWORD))
        input.classList.add("bad-input");
      return inputPassword, REGEX_PASSWORD;
    }
  });

  if (
    checkSaisiName(inputName, REGEX_NAME) &&
    checkSaisiPhone(inputPhone, REGEX_PHONE) &&
    checkSaisiPostal(inputPostal, REGEX_POSTAL) &&
    checkSaisiMail(inputMail, REGEX_MAIL) &&
    checkSaisiPasword(inputPassword, REGEX_PASSWORD)
  ) {
    error.innerHTML = "";
    console.log("bon");
  } else {
    error.innerHTML = "Vous avez mal remplit le formulaire";
  }
};

document.addEventListener("submit", (e) => {
  e.preventDefault();
  controleSaisiInput();
});

// pattern=""
// title="Il doit contenir minuscule, majuscule, min 8 caractères, 1 chiffre et 1 caractère spécial"

// pattern=""
// title="Il faut une adresse mail valide"

// pattern=""
// title="Code postal à 5 chiffres"

// pattern=""
// title="Saisir un numéro français"

// pattern=""
// title="min 3 caractères et pas de chiffre"
