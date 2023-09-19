const inputs = document.querySelectorAll(".input");
const btn = document.getElementById("btn");
const messageError = document.getElementById("error");
const spanError = document.querySelectorAll("[data-span]");
const eye = document.querySelector(".show");

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

// Check les inputs avec les REGEX
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

// Check si tous les inputs sont vides
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

// check 1 par 1 si les inputs sont vides
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
        if (checkSaisiName(inputName)) {
          input.classList.remove("bad-input");
        } else {
          input.classList.add("bad-input");
        }
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
        if (checkSaisiPhone(inputPhone)) {
          input.classList.remove("bad-input");
        } else {
          input.classList.add("bad-input");
        }
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
        if (checkSaisiPostal(inputPostal)) {
          input.classList.remove("bad-input");
        } else {
          input.classList.add("bad-input");
        }
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
        if (checkSaisiMail(inputMail)) {
          input.classList.remove("bad-input");
        } else {
          input.classList.add("bad-input");
        }
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
        if (checkSaisiPasword(inputPassword)) {
          input.classList.remove("bad-input");
        } else {
          input.classList.add("bad-input");
        }
      });
    }
  });
};

// controle tous les inputs avec les REGEX
const controleSaisiInput = () => {
  inputs.forEach((input) => {
    if (input.name == "name") {
      inputName = input.value.toLowerCase();

      if (!checkSaisiName(inputName)) {
        console.log("ici name");
        input.classList.add("bad-input");
      } else {
        input.classList.remove("bad-input");
        console.log("la name");
      }

      return inputName;
    }
    if (input.name == "phone") {
      inputPhone = input.value;

      if (!checkSaisiPhone(inputPhone)) {
        console.log("ici phone");
        input.classList.add("bad-input");
        // span.innerHTML = "Numéro de téléphone français";
      } else {
        input.classList.remove("bad-input");
        // span.innerHTML = "";
        console.log("la phone");
      }
      return inputPhone;
    }
    if (input.name == "postal") {
      inputPostal = input.value;

      if (!checkSaisiPostal(inputPostal)) {
        console.log("ici postal");
        input.classList.add("bad-input");
        // span.innerHTML = "Code postal français";
      } else {
        input.classList.remove("bad-input");
        // span.innerHTML = "";
        console.log("la postal");
      }

      return inputPostal;
    }
    if (input.name == "email") {
      inputMail = input.value.toLowerCase();

      if (!checkSaisiMail(inputMail)) {
        input.classList.add("bad-input");
        // span.innerHTML = "Adresse mail non valide";
        console.log("ici mail");
      } else {
        input.classList.remove("bad-input");
        // span.innerHTML = "";
        console.log("la mail");
      }

      return inputMail;
    }
    if (input.name == "password") {
      inputPassword = input.value;

      if (!checkSaisiPasword(inputPassword)) {
        console.log("ici password");

        input.classList.add("bad-input");
        // span.innerHTML =
        //   "Min 8 caracètes, 1 caractère spécial, 1 minuscule, 1 majuscule et 1 chiffre";
      } else {
        input.classList.remove("bad-input");
        // span.innerHTML = "";
        console.log("la password");
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
    error.innerHTML = "Vous avez mal remplit le formulaire";
  }
};

allInput();

document.addEventListener("submit", (e) => {
  e.preventDefault();
  controleSaisiInput();
});

eye.addEventListener("mousedown", () => {
  inputs.forEach((input) => {
    if (input.name == "password") {
      input.type = "text";
    }
  });
});
eye.addEventListener("mouseup", () => {
  inputs.forEach((input) => {
    if (input.name == "password") {
      input.type = "password";
    }
  });
});
