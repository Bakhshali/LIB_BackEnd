function PasswordShowHidden() {
    var input = document.getElementById("myInput")
    var hidden = document.getElementById("hide1")
    var show = document.getElementById("hide2")

    if (input.type === 'password') {
        input.type = "text";
        show.style.display = "block";
        hidden.style.display = "none";
    }
    else {
        input.type = "password";
        show.style.display = "none";
        hidden.style.display = "block";
    }
}