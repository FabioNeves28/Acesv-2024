window.jsPDF = window.jspdf.jsPDF;

document.getElementById('btnDownload').addEventListener('click', function () {
    var doc = new jsPDF('l', 'pt', 'letter');
    var fontSize = 10;
    var maxTableWidth = 700;
    var table = document.getElementById('tabela');
    var tableString = doc.autoTableHtmlToJson(table);
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
    var tableWidth = table.offsetWidth;
    if (tableWidth > maxTableWidth) {
        var rowCountPerPage = 25;
        var rowCount = tableString.data.length;
        var currentPage = 1;
        var startRowIndex = 0;
        var endRowIndex = rowCountPerPage;
        while (startRowIndex < rowCount) {
            doc.addPage();
            drawTablePart(startRowIndex, endRowIndex);
            currentPage++;
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

    doc.save('relatorio.pdf');
});