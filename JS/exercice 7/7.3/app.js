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
let REGEX_EMAIL = /^((?!\.)[\w\-_.]*[^.])(@\w+)(\.\w+(\.\w+)?[^.\W])$/;
let REGEX_PASSWORD =
  /^(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?=.*[^\w\d\s:])([^\s]){8,}$/;

const checkSaisiName = (name) => {
  if (name.match(REGEX_NAME)) {
    console.log("bon");
    return true;
  } else {
    console.log("faux");
    return false;
  }
};

const checkSaisiPhone = (phone) => {
  if (phone.match(REGEX_PHONE)) {
    console.log("bon");

    return true;
  } else {
    console.log("faux");

    return false;
  }
};
const checkSaisiPostal = (postal) => {
  if (postal.match(REGEX_POSTAL)) {
    console.log("bon");

    return true;
  } else {
    console.log("faux");

    return false;
  }
};
const checkSaisiMail = (mail) => {
  if (mail.match(REGEX_EMAIL)) {
    console.log("bon");

    return true;
  } else {
    console.log("faux");

    return false;
  }
};
const checkSaisiPasword = (password) => {
  if (password.match(REGEX_PASSWORD)) {
    console.log("bon");
    return true;
  } else {
    console.log("faux");

    return false;
  }
};

const controleSaisiInput = () => {
  inputs.forEach((input) => {
    if (input.name == "name") {
      inputName = input.value.toLowerCase();
      console.log(input);
      return inputName;
    }
    if (input.name == "phone") {
      inputPhone = input.value;
      console.log(input);
      return inputPhone;
    }
    if (input.name == "postal") {
      inputPostal = input.value;
      console.log(input);
      return inputPostal;
    }
    if (input.name == "email") {
      inputMail = input.value.toLowerCase();
      console.log(input);
      return inputMail;
    }
    if (input.name == "password") {
      inputPassword = input.value;
      console.log(input);
      return inputPassword;
    }
  });

  console.log(inputMail, inputPassword, inputPhone, inputPostal, inputName);

  //   if (
  //     checkSaisiName(inputName) &&
  //     checkSaisiPhone(inputPhone) &&
  //     checkSaisiPostal(inputPostal) &&
  //     checkSaisiMail(inputMail) &&
  //     checkSaisiPasword(inputPassword)
  //   ) {
  //     error.innerHTML = "";
  //     console.log("bon");
  //   } else {
  //     error.innerHTML = "Vous avez mal remplit le formulaire";
  //   }
};

document.addEventListener("submit", (e) => {
  e.preventDefault();
  controleSaisiInput();
});
