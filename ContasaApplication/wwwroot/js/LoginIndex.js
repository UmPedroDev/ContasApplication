const container = document.querySelector('.container'); 
const registerBtn = document.querySelector('.register-btn'); 
const loginBtn = document.querySelector('.login-btn'); 
    
registerBtn.addEventListener('click', () => {
    container.classList.add('active');
});

loginBtn.addEventListener('click', () => {
    container.classList.remove('active');
});

var mostrarModal = '@(TempData["MostrarModal"] ?? "False")';
console.log("Valor de mostrarModal:", mostrarModal);


document.addEventListener("DOMContentLoaded", function () {
    var mensagemErro = document.getElementById("mensagemErro");

    if (mensagemErro && mensagemErro.innerText.trim() !== "") {
        console.log("Abrindo modal com mensagem:", mensagemErro.innerText);
        var modal = new bootstrap.Modal(document.getElementById("exampleModal"));
        modal.show();
    }
});

