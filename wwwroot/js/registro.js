function togglePassword(inputId) {
    const input = document.getElementById(inputId);
    const eyeIcon = inputId === 'senha' ? document.getElementById('eye-senha') : document.getElementById('eye-confirmar-senha');
    
    if (input.type === "password") {
                input.type = "text";
                eyeIcon.classList.remove('fa-eye');
        eyeIcon.classList.add('fa-eye-slash');
    } else {
                input.type = "password";
                eyeIcon.classList.remove('fa-eye-slash');
        eyeIcon.classList.add('fa-eye');
    }
}

const senhaInput = document.getElementById('senha');
const confirmarSenhaInput = document.getElementById('confirmar-senha');

senhaInput.addEventListener('input', () => {
    senhaInput.type = 'password';     document.getElementById('eye-senha').classList.remove('fa-eye-slash');     document.getElementById('eye-senha').classList.add('fa-eye'); });

confirmarSenhaInput.addEventListener('input', () => {
    confirmarSenhaInput.type = 'password';     document.getElementById('eye-confirmar-senha').classList.remove('fa-eye-slash');     document.getElementById('eye-confirmar-senha').classList.add('fa-eye'); });
