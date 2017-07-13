function figureOfFourSquares(input) {
    let n = parseInt(input[0]);
    let spacesPerSquare = n - 2;
    let rows = n;
    let firstSymbol = '|';
    let secondSymbol = ' ';

    if (n % 2 == 0) {
        rows = n - 1;
    }

    //cuz softuni people cant write proper exercises
    if (n == 2) {
        console.log("+++\n+++\n+++");
    }
    else {
        for (let row = 0; row < rows; row++) {
            //first,last or middle row - change characters
            if (row == 0 || row == rows - 1 || row == parseInt(rows / 2)) {
                firstSymbol = '+';
                secondSymbol = '-';
            }
            console.log(`${firstSymbol}${secondSymbol.repeat(spacesPerSquare)}${firstSymbol}${secondSymbol.repeat(spacesPerSquare)}${firstSymbol}`);

            firstSymbol = '|';
            secondSymbol = ' ';
        }
    }

}