window.jsPDF = window.jspdf.jsPDF;

document.getElementById('btnDownload').addEventListener('click', function () {
    var doc = new jsPDF('l', 'pt', 'letter');
    var fontSize = 10;
    var maxTableWidth = 700;
    var table = document.getElementById('tabela');
    var tableClone = table.cloneNode(true);

    var headerRow = tableClone.querySelector('thead tr');
    var editHeader = headerRow.querySelector('th:nth-child(2)');
    if (editHeader) {
        headerRow.removeChild(editHeader);
    }

    var rows = tableClone.querySelectorAll('tbody tr');
    rows.forEach(row => {
        var editCell = row.querySelector('td:nth-child(2)');
        if (editCell) {
            row.removeChild(editCell);
        }
    });

    var tableString = doc.autoTableHtmlToJson(tableClone);
    doc.setFontSize(fontSize);
    var margin = {
        top: 30,
        right: 30,
        bottom: 30,
        left: 30
    };

    function drawTablePart(startRowIndex, endRowIndex) {
        var dataPart = tableString.data.slice(startRowIndex, endRowIndex);
        doc.autoTable({
            head: [tableString.columns],
            body: dataPart,
            startY: margin.top + 10,
            styles: {
                cellWidth: 'wrap'
            },
            margin: margin
        });
    }

    // Cálculo do tamanho da tabela
    var tableWidth = table.offsetWidth;
    if (tableWidth > maxTableWidth) {
        var rowCountPerPage = 25;
        var rowCount = tableString.data.length;
        var startRowIndex = 0;
        var endRowIndex = rowCountPerPage;

        // Gerar a primeira página sem addPage()
        drawTablePart(startRowIndex, endRowIndex);
        startRowIndex = endRowIndex;
        endRowIndex = Math.min(startRowIndex + rowCountPerPage, rowCount);

        // Loop para adicionar as páginas seguintes
        while (startRowIndex < rowCount) {
            doc.addPage();
            drawTablePart(startRowIndex, endRowIndex);
            startRowIndex = endRowIndex;
            endRowIndex = Math.min(startRowIndex + rowCountPerPage, rowCount);
        }
    } else {
        doc.autoTable({
            head: [tableString.columns],
            body: tableString.data,
            styles: {
                cellWidth: 'wrap'
            },
            margin: margin
        });
    }

    // Salvar o PDF
    doc.save('relatorio.pdf');
});
