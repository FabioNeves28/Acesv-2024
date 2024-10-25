document.querySelectorAll('.faq-item').forEach(item => {
    item.addEventListener('click', () => {
        const content = item.querySelector('.faq-content');
        const icon = item.querySelector('.toggle-icon');

        if (item.classList.contains('active')) {
            item.classList.remove('active');
            icon.textContent = '+';
        } else {
            document.querySelectorAll('.faq-item').forEach(i => {
                i.classList.remove('active');
                i.querySelector('.toggle-icon').textContent = '+';
            });
            item.classList.add('active');
            icon.textContent = '-';
        }
    });
});
