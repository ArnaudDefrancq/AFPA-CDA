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

const checkSaisiName = (name, input) => {
  if (name.match(REGEX_NAME)) {
    input.classList.add("good-input");
    return true;
  } else {
    input.classList.add("bad-input");
    return false;
  }
};

const checkSaisiPhone = (phone, input) => {
  if (phone.match(REGEX_PHONE)) {
    input.classList.add("good-input");
    return true;
  } else {
    input.classList.add("bad-input");
    return false;
  }
};
const checkSaisiPostal = (postal, input) => {
  if (postal.match(REGEX_POSTAL)) {
    input.classList.add("good-input");
    return true;
  } else {
    input.classList.add("bad-input");
    return false;
  }
};
const checkSaisiMail = (mail, input) => {
  if (mail.match(REGEX_EMAIL)) {
    input.classList.add("good-input");
    return true;
  } else {
    input.classList.add("bad-input");
    return false;
  }
};
const checkSaisiPasword = (password, input) => {
  if (password.match(REGEX_PASSWORD)) {
    input.classList.add("good-input");
    return true;
  } else {
    input.classList.add("bad-input");
    return false;
  }
};

const controleSaisiInput = () => {
  inputs.forEach((input) => {
    if (input.name == "name") {
      inputName = input.value.toLowerCase();
      checkSaisiName(inputName, input);
      return inputName;
    }
    if (input.name == "phone") {
      inputPhone = input.value;
      checkSaisiPhone(inputPhone, input);
      return inputPhone;
    }
    if (input.name == "postal") {
      inputPostal = input.value;
      checkSaisiPostal(inputPostal, input);
      return inputPostal;
    }
    if (input.name == "email") {
      inputMail = input.value.toLowerCase();
      checkSaisiMail(inputMail, input);
      return inputMail;
    }
    if (input.name == "password") {
      inputPassword = input.value;
      checkSaisiPasword(inputPassword, input);
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
