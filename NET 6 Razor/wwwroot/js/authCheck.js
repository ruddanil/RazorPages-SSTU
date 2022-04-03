function checkPassword(pass) {
    let decimal = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?!.*\s).{8,15}$/;
    return pass.value.match(decimal);
}

function checkSecondPassword(pass) {
    var diag_nap_uchr = document.getElementById("password");
    var diag_osn = document.getElementById('s');
    if (diag_nap_uchr.value === diag_osn.value) {
        alert("Совпадение");
    }
}

function checkSecondPassword2(password, secondPassword) {
    if (password.value === secondPassword.value) {
        alert("!!!");
    } else alert("???")
};