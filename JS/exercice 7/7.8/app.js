const inputs = document.querySelectorAll(".input");
const btn = document.getElementById("btn");
const messageError = document.getElementById("error");
const spanError = document.querySelectorAll("[data-span]");
const showPasswordBtn = document.getElementById("show");
const password = document.getElementById("password");

let inputName = "";
let inputPhone = "";
let inputPostal = "";
let inputMail = "";
let inputPassword = "";

let REGEX_NAME = /^[a-z]{3,40}$/;
let REGEX_PHONE = /(0|\+33)[1-9]( *[0-9]{2}){4}/;
let REGEX_POSTAL = /^[\d]{5}$/;
let REGEX_EMAIL = /^((?!\.)[\w\-_.]*[^.])(@\w+)(\.\w+(\.\w+)?[^.\W])$/;
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
  if (mail.match(REGEX_EMAIL)) {
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

const checkAllInput = (name, phone, postal, mail, password) => {
  if (
    name != "" &&
    phone != "" &&
    postal != "" &&
    mail != "" &&
    password != ""
  ) {
    btn.classList.remove("btn-event");
  } else {
    btn.classList.add("btn-event");
  }
};

const allInput = () => {
  inputs.forEach((input) => {
    if (input.name == "name") {
      input.addEventListener("input", (e) => {
        inputName = e.target.value.toLowerCase();
        checkAllInput(
          inputName,
          inputPhone,
          inputPostal,
          inputMail,
          inputPassword
        );
      });
    }
    if (input.name == "phone") {
      input.addEventListener("input", (e) => {
        inputPhone = e.target.value;
        checkAllInput(
          inputName,
          inputPhone,
          inputPostal,
          inputMail,
          inputPassword
        );
      });
    }
    if (input.name == "postal") {
      input.addEventListener("input", (e) => {
        inputPostal = e.target.value;
        checkAllInput(
          inputName,
          inputPhone,
          inputPostal,
          inputMail,
          inputPassword
        );
      });
    }
    if (input.name == "email") {
      input.addEventListener("input", (e) => {
        inputMail = e.target.value.toLowerCase();
        checkAllInput(
          inputName,
          inputPhone,
          inputPostal,
          inputMail,
          inputPassword
        );
      });
    }
    if (input.name == "password") {
      input.addEventListener("input", (e) => {
        inputPassword = e.target.value;
        checkAllInput(
          inputName,
          inputPhone,
          inputPostal,
          inputMail,
          inputPassword
        );
      });
    }
  });
};

const controleSaisiInput = () => {
  inputs.forEach((input) => {
    if (input.name == "name") {
      inputName = input.value.toLowerCase();
      spanError.forEach((span) => {
        if (span.attributes[1].value == "name" && !checkSaisiName(inputName)) {
          input.classList.add("bad-input");
          span.innerHTML = "min 3 caractères et aucun chiffre";
        } else {
          input.classList.remove("bad-input");
          span.innerHTML = "";
        }
      });
      return inputName;
    }
    if (input.name == "phone") {
      inputPhone = input.value;
      spanError.forEach((span) => {
        if (
          span.attributes[1].value == "phone" &&
          !checkSaisiPhone(inputPhone)
        ) {
          input.classList.add("bad-input");
          span.innerHTML = "Numéro de téléphone français";
        } else {
          input.classList.remove("bad-input");
          span.innerHTML = "";
        }
      });
      return inputPhone;
    }
    if (input.name == "postal") {
      inputPostal = input.value;
      spanError.forEach((span) => {
        if (
          span.attributes[1].value == "postal" &&
          !checkSaisiPostal(inputPostal)
        ) {
          input.classList.add("bad-input");
          span.innerHTML = "Code postal français";
        } else {
          input.classList.remove("bad-input");
          span.innerHTML = "";
        }
      });
      return inputPostal;
    }
    if (input.name == "email") {
      inputMail = input.value.toLowerCase();
      spanError.forEach((span) => {
        if (span.attributes[1].value == "mail" && !checkSaisiMail(inputMail)) {
          input.classList.add("bad-input");
          span.innerHTML = "Adresse mail non valide";
        } else {
          input.classList.remove("bad-input");
          span.innerHTML = "";
        }
      });
      return inputMail;
    }
    if (input.name == "password") {
      inputPassword = input.value;
      spanError.forEach((span) => {
        if (
          span.attributes[1].value == "password" &&
          !checkSaisiPasword(inputPassword)
        ) {
          input.classList.add("bad-input");
          span.innerHTML =
            "Min 8 caracètes, 1 caractère spécial, 1 minuscule, 1 majuscule et 1 chiffre";
        } else {
          input.classList.remove("bad-input");
          span.innerHTML = "";
        }
      });
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

allInput();

document.addEventListener("submit", (e) => {
  e.preventDefault();
  controleSaisiInput();
});
showPasswordBtn.addEventListener("click", () => {
  let show = password.value;
  password.innerHTML = show;
});
