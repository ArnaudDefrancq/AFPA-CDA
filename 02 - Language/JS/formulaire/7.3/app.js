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
<<<<<<< HEAD
    return true;
  } else {
=======
    input.classList.add("good-input");
    return true;
  } else {
    input.classList.add("bad-input");
>>>>>>> 055bf097dd0616c9a2e99ab92f8bfcc467b7261e
    return false;
  }
};

const checkSaisiPhone = (phone, input) => {
  if (phone.match(REGEX_PHONE)) {
<<<<<<< HEAD
    return true;
  } else {
=======
    input.classList.add("good-input");
    return true;
  } else {
    input.classList.add("bad-input");
>>>>>>> 055bf097dd0616c9a2e99ab92f8bfcc467b7261e
    return false;
  }
};
const checkSaisiPostal = (postal, input) => {
  if (postal.match(REGEX_POSTAL)) {
<<<<<<< HEAD
    return true;
  } else {
=======
    input.classList.add("good-input");
    return true;
  } else {
    input.classList.add("bad-input");
>>>>>>> 055bf097dd0616c9a2e99ab92f8bfcc467b7261e
    return false;
  }
};
const checkSaisiMail = (mail, input) => {
  if (mail.match(REGEX_EMAIL)) {
<<<<<<< HEAD
    return true;
  } else {
=======
    input.classList.add("good-input");
    return true;
  } else {
    input.classList.add("bad-input");
>>>>>>> 055bf097dd0616c9a2e99ab92f8bfcc467b7261e
    return false;
  }
};
const checkSaisiPasword = (password, input) => {
  if (password.match(REGEX_PASSWORD)) {
<<<<<<< HEAD
    return true;
  } else {
=======
    input.classList.add("good-input");
    return true;
  } else {
    input.classList.add("bad-input");
>>>>>>> 055bf097dd0616c9a2e99ab92f8bfcc467b7261e
    return false;
  }
};

const controleSaisiInput = () => {
  inputs.forEach((input) => {
    if (input.name == "name") {
      inputName = input.value.toLowerCase();
<<<<<<< HEAD
      if (!checkSaisiName(inputName)) {
        input.classList.add("bad-input");
      } else {
        input.classList.remove("bad-input");
      }
=======
      checkSaisiName(inputName, input);
>>>>>>> 055bf097dd0616c9a2e99ab92f8bfcc467b7261e
      return inputName;
    }
    if (input.name == "phone") {
      inputPhone = input.value;
<<<<<<< HEAD
      if (!checkSaisiPhone(inputPhone)) {
        input.classList.add("bad-input");
      } else {
        input.classList.remove("bad-input");
      }
=======
      checkSaisiPhone(inputPhone, input);
>>>>>>> 055bf097dd0616c9a2e99ab92f8bfcc467b7261e
      return inputPhone;
    }
    if (input.name == "postal") {
      inputPostal = input.value;
<<<<<<< HEAD
      if (!checkSaisiPostal(inputPostal)) {
        input.classList.add("bad-input");
      } else {
        input.classList.remove("bad-input");
      }
=======
      checkSaisiPostal(inputPostal, input);
>>>>>>> 055bf097dd0616c9a2e99ab92f8bfcc467b7261e
      return inputPostal;
    }
    if (input.name == "email") {
      inputMail = input.value.toLowerCase();
<<<<<<< HEAD
      if (!checkSaisiMail(inputMail)) {
        input.classList.add("bad-input");
      } else {
        input.classList.remove("bad-input");
      }
=======
      checkSaisiMail(inputMail, input);
>>>>>>> 055bf097dd0616c9a2e99ab92f8bfcc467b7261e
      return inputMail;
    }
    if (input.name == "password") {
      inputPassword = input.value;
<<<<<<< HEAD
      if (!checkSaisiPasword(inputPassword)) {
        input.classList.add("bad-input");
      } else {
        input.classList.remove("bad-input");
      }
=======
      checkSaisiPasword(inputPassword, input);
>>>>>>> 055bf097dd0616c9a2e99ab92f8bfcc467b7261e
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
    error.innerHTML = "Vous avez mal remplit le formulaire";
  }
};

document.addEventListener("submit", (e) => {
  e.preventDefault();
  controleSaisiInput();
});
