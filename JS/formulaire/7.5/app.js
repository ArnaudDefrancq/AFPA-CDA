const inputs = document.querySelectorAll(".input");
const btn = document.getElementById("btn");
const messageError = document.getElementById("error");

let inputName;
let inputPhone;
let inputPostal;
let inputMail;
let inputPassword;

let patternName;
let patternPhone;
let patternPostal;
let patternMail;
let patternPassword;

// let REGEX_NAME = //;
// let REGEX_PHONE = //;
// let REGEX_POSTAL = //;
// let REGEX_EMAIL = //;
// let REGEX_PASSWORD =//;

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
      patternName = input.pattern;
      console.log(patternName);
      if (!checkSaisiName(inputName, patternName)) {
        input.classList.add("bad-input");
      } else {
        input.classList.remove("bad-input");
      }
      return inputName;
    }
    if (input.name == "phone") {
      inputPhone = input.value;
      patternPhone = input.pattern;
      if (!checkSaisiPhone(inputPhone, patternPhone)) {
        input.classList.add("bad-input");
      } else {
        input.classList.remove("bad-input");
      }
      return inputPhone;
    }
    if (input.name == "postal") {
      inputPostal = input.value;
      patternPostal = input.pattern;
      if (!checkSaisiPostal(inputPostal, patternPostal)) {
        input.classList.add("bad-input");
      } else {
        input.classList.remove("bad-input");
      }
      return inputPostal;
    }
    if (input.name == "email") {
      inputMail = input.value.toLowerCase();
      patternMail = input.pattern;
      if (!checkSaisiMail(inputMail, patternMail)) {
        input.classList.add("bad-input");
      } else {
        input.classList.remove("bad-input");
      }
      return inputMail;
    }
    if (input.name == "password") {
      inputPassword = input.value;
      patternPassword = input.pattern;
      if (!checkSaisiPasword(inputPassword, patternPassword)) {
        input.classList.add("bad-input");
      } else {
        input.classList.remove("bad-input");
      }
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
  } else {
    error.innerHTML = "Vous avez mal rempli le formulaire";
  }
};

document.addEventListener("submit", (e) => {
  e.preventDefault();
  controleSaisiInput();
});
