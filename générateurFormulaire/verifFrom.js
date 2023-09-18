const inputs = document.querySelectorAll(".input");
const btn = document.getElementById("btn");
const messageError = document.getElementById("error");

let inputName;
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

const checkSaisiName = (name) => {
  if (name.match(REGEX_NAME)) {
    return true;
  } else {
    return false;
  }
};

const checkSaisiPhone = (phone) => {
  if (phone.match(REGEX_PHONE)) {
    return true;
  } else {
    return false;
  }
};
const checkSaisiPostal = (postal) => {
  if (postal.match(REGEX_POSTAL)) {
    return true;
  } else {
    return false;
  }
};
const checkSaisiMail = (mail) => {
  if (mail.match(REGEX_MAIL)) {
    return true;
  } else {
    return false;
  }
};
const checkSaisiPasword = (password) => {
  if (password.match(REGEX_PASSWORD)) {
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
      if (!checkSaisiName(inputName)) input.classList.add("bad-input");
      return inputName;
    }
    if (input.name == "phone") {
      inputPhone = input.value;
      REGEX_PHONE = input.pattern;
      if (!checkSaisiName(inputPhone)) input.classList.add("bad-input");
      return inputPhone;
    }
    if (input.name == "postal") {
      inputPostal = input.value;
      REGEX_POSTAL = input.pattern;
      if (!checkSaisiName(inputPostal)) input.classList.add("bad-input");
      return inputPostal;
    }
    if (input.name == "email") {
      inputMail = input.value.toLowerCase();
      REGEX_MAIL = input.pattern;
      if (!checkSaisiName(inputMail)) input.classList.add("bad-input");
      return inputMail;
    }
    if (input.name == "password") {
      inputPassword = input.value;
      REGEX_PASSWORD = input.pattern;
      if (!checkSaisiName(inputPassword)) input.classList.add("bad-input");
      return inputPassword;
    }
  });

  if (
    checkSaisiName(inputName) &&
    checkSaisiPhone(inputPhone) &&
    checkSaisiPostal(inputPostal) &&
    checkSaisiMail(inputMail) &&
    checkSaisiPasword(inputPassword)
  ) {
    error.innerHTML = "";
    console.log("bon");
  } else {
    error.innerHTML = "Vous avez mal rempli le formulaire";
  }
};

document.addEventListener("submit", (e) => {
  e.preventDefault();
  controleSaisiInput();
});
