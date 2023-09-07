const inputs = document.querySelectorAll(".input");
const btn = document.getElementById("btn");
let inputPhone;
let inputPostal;
let inputMail;
let inputPassword;

const REGEX_NAME = /^[a-z]{3,40}$/;
const REGEX_PHONE = /(0|\+33)[1-9]( *[0-9]{2}){4}/;
const REGEX_POSTAL = /^[\d]{5}$/;
const REGEX_MAIL = /^[a-z0-9.]+@[a-z]+.[a-z]+/;
const REGEX_PASSWORD =
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
      inputName = input.value;
    }
    if (input.name == "phone") {
      inputPhone = input.value;
    }
    if (input.name == "postal") {
      inputPostal = input.value;
    }
    if (input.name == "email") {
      inputMail = input.value;
    }
    if (input.name == "password") {
      inputPassword = input.value;
    }
  });

  if (
    checkSaisiName(inputName) &&
    checkSaisiPhone(inputPhone) &&
    checkSaisiPostal(inputPostal) &&
    checkSaisiMail(inputMail) &&
    checkSaisiPasword(inputPassword)
  ) {
    console.log("bon");
  } else {
    console.log("faux");
  }
};

document.addEventListener("submit", (e) => {
  e.preventDefault();
  controleSaisiInput();
});
