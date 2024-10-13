function togglePassword(inputId) {
    const input = document.getElementById(inputId);
    const eyeIcon = inputId === 'senha' ? document.getElementById('eye-senha') : document.getElementById('eye-confirmar-senha');
    
    if (input.type === "password") {
        // Mostrar a senha
        input.type = "text";
        // Trocar para ícone de olho com barra
        eyeIcon.classList.remove('fa-eye');
        eyeIcon.classList.add('fa-eye-slash');
    } else {
        // Esconder a senha
        input.type = "password";
        // Trocar para ícone de olho aberto
        eyeIcon.classList.remove('fa-eye-slash');
        eyeIcon.classList.add('fa-eye');
    }
}

// Evento para esconder a senha enquanto o usuário digita
const senhaInput = document.getElementById('senha');
const confirmarSenhaInput = document.getElementById('confirmar-senha');

senhaInput.addEventListener('input', () => {
    senhaInput.type = 'password'; // Sempre esconder a senha
    document.getElementById('eye-senha').classList.remove('fa-eye-slash'); // Desativar ícone
    document.getElementById('eye-senha').classList.add('fa-eye'); // Mostrar olho fechado
});

confirmarSenhaInput.addEventListener('input', () => {
    confirmarSenhaInput.type = 'password'; // Sempre esconder a senha
    document.getElementById('eye-confirmar-senha').classList.remove('fa-eye-slash'); // Desativar ícone
    document.getElementById('eye-confirmar-senha').classList.add('fa-eye'); // Mostrar olho fechado
});
