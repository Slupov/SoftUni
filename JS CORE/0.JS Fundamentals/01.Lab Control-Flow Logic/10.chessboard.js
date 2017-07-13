function chessBoard(input) {
    let n = Number(input);
    let html = '<div class="chessboard">\n';
    for (var row = 0; row < n; row++) {
        html+= '\t <div>\n';
        let color = (row%2 == 0) ? 'black' : 'white';
        for (var col = 0; col < n; col++) {
            html+= `\t \t <span class="${color}"></span>\n`;
            color = (color == 'white') ? 'black' : "white";
        }
        html +='\t </div>\n';
    }

    let css = document.createElement("style");
    css.innerHTML = `
  body { background: #CCC; }
  .chessboard { display: inline-block; }
  .black, .white { 
     width:50px; height:50px;
     display: inline-block; }
  .black { background: black; }
  .white { background: white; }
`;
    /*document.getElementsByTagName("head")[0].appendChild(css);
     document.body.innerHTML = chessBoard(["5"]);*/


    return html + '</div>';
}