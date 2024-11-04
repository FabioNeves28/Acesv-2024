document.addEventListener('DOMContentLoaded', function () {
    document.getElementById('btnDownloadPdf').addEventListener('click', function () {
        const { jsPDF } = window.jspdf;

        var doc = new jsPDF({
            orientation: 'landscape',
            unit: 'pt',
            format: [1000, 700]
        });

        const table = document.querySelector('table').cloneNode(true);

        const editButtons = table.querySelectorAll('.no-pdf');
        editButtons.forEach(button => button.remove());

        doc.autoTable({
            html: table,
            startY: 10,
            styles: {
                fontSize: 10,
                valign: 'bottom',
                halign: 'left'
            },
            columnStyles: {
                2: { valign: 'bottom', halign: 'left' } 
            },
            theme: 'grid'
        });

        doc.save('financeiro.pdf');
    });
});
