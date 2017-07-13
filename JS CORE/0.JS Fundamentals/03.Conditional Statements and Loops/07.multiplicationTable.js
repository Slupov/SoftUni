function multiplicationTable(input) {
    let n = Number(input[0]);
    let html = "<table border=\"1\">\n";

    //first row
    let rowContent = "\t<tr><th>x</th>";
    for (let i = 1; i <= n; i++) {
        rowContent += `<th>${i}</th>`;
    }
    rowContent += "</tr>\n";
    html += rowContent;

    //other rows
    for (let row = 1; row <= n; row++) {
        rowContent = "\t<tr>";
        rowContent += `<th>${row}</th>`;

        for (let col = 1; col <= n; col++) {
            rowContent += `<td>${row * col}</td>`;
        }
        rowContent += "</tr>\n";
        html += rowContent;
        rowContent = "";
    }
    html += "</table>";

    return html;
}