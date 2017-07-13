function printAnArray(input) {
    let delimiter = input.pop();
    console.log(input.join(delimiter));
}

function printEveryNth(input) {
    let step = Number(input.pop());
    for (let i = 0; i < input.length; i += step) {
        console.log(input[i]);
    }
}

function addOrRemove(input) {
    let num = 0;
    let array = [];

    for (let i = 0; i < input.length; i++) {
        num++;
        if (input[i] == "add") {
            array.push(num)
        }
        else if (input[i] == "remove") {
            array.pop();
        }
    }
    if (array.length != 0) {
        array.forEach(x => console.log(x));

    }
    else console.log("Empty");
}

function rotateArray(input) {
    let rotations = input.pop();

    for (let i = 0; i < rotations % array.length; i++) {
        input.unshift(input.pop());
    }
    console.log(input.join(" "));
}

function nonDecreasingSubs(input) {
    let biggest = input.shift();
    console.log(biggest);
    input = input.map(Number);

    for (let i = 0; i < input.length; i++) {
        if (input[i] >= biggest) {
            biggest = input[i];
            console.log(biggest);
        }
    }
}

function sortAnArray(input) {
    input.sort(function (a, b) {
        var aSize = a.length;
        var bSize = b.length;

        var aCap = a.toUpperCase();
        var bCap = b.toUpperCase();

        if (aSize == bSize) {
            return (aCap < bCap) ? -1 : 1;
        }
        else if (aSize > bSize) return 1;
        else if (aSize < bSize) return -1;
    }).forEach(x => console.log(x));
}

function magicMatrices(input) {
    let sum = 0;
    input[0].split(" ").map(Number).forEach(x=>sum += x);
    for (let i = 0; i < input.length; i++) {
        input[i] = input[i].split(" ").map(Number);
    }
    //check rows
    for (let row of input) {
        let sum1 = 0;
        for (let col of row) {
            sum1 += col;
        }
        if (sum1 != sum) return false;
    }
    //check cols
    for (let col = 0; col < input.length; col++) {

        let sum1 = 0;
        for (let row = 0; row < input.length; row++) {
            sum1 += input[row][col];
        }
        if (sum1 != sum) return false;

    }

    return true;
}

function spiralMatrix([input]) {
    let [rows, cols] = input.split(' ').map(Number);
    let direction = "right";
    let row = 0;
    let col = 0;

    //defining the matrix
    let matrix = new Array(rows);
    for (let i = 0; i < rows; i++) {
        matrix[i] = new Array(cols);
    }

    for (let i = 1; i <= rows * cols; i++) {
        if (direction == "right" && (col > cols - 1 || matrix[row][col] != undefined)) {
            direction = "down";
            col--;
            row++;
        }
        if (direction == "down" && (row > rows - 1 || matrix[row][col] != undefined)) {
            direction = "left";
            row--;
            col--;
        }
        if (direction == "left" && (col < 0 || matrix[row][col] != undefined)) {
            direction = "up";
            col++;
            row--;
        }

        if (direction == "up" && row < 0 || matrix[row][col] != undefined) {
            direction = "right";
            row++;
            col++;
        }

        matrix[row][col] = i;

        if (direction == "right") {
            col++;
        }
        if (direction == "down") {
            row++;
        }
        if (direction == "left") {
            col--;
        }
        if (direction == "up") {
            row--;
        }
    }

    for (let r = 0; r < rows; r++) {
        console.log(`${matrix[r].join(" ")}`);
    }

}

function diagonalAttack(input) {

    for (let i = 0; i < input.length; i++) {
        input[i] = input[i].split(" ").map(Number);
    }

    let mainDiagonalSum = 0;
    let secondDiagonalSum = 0;

    for (let row = 0; row < input.length; row++) {
        mainDiagonalSum += input[row][row];
        secondDiagonalSum += input[row][input.length - row - 1];
    }


    if (mainDiagonalSum == secondDiagonalSum) {
        for (let row = 0; row < input.length; row++) {
            for (let col = 0; col < input.length; col++) {
                if (row + col == input.length - 1 || row == col) {
                    continue;
                }
                else {
                    input[row][col] = mainDiagonalSum;
                }
            }
        }
    }

    input.forEach(r=>console.log(r.join(" ")));
}

function orbit(input) {
    let dimensions = input[0].split(" ");
    let rows = Number(dimensions[0]);
    let cols = Number(dimensions[1]);

    let star = 1;
    let starCoords = input[1].split(" ");
    let starX = Number(starCoords[0]);
    let starY = Number(starCoords[1]);

    //defining the matrix
    let matrix = [];
    for (let row = 0; row < rows; row++) {
        matrix[row] = [];
        for (let col = 0; col < cols; col++) {
            matrix[row][col] = 0;
        }
    }

    matrix[starX][starY] = star;

    function isInBounds(x, y, someMatrix) {
        if(x < 0){
            return false
        }
        if (!((y < someMatrix[x].length && y >= 0)
            &&
            (x >= 0 && x < someMatrix.length))) {
            return false;
        }
        return true;
    }

    function isMatrixFull(someMatrix) {
        for (let row = 0; row < someMatrix.length; row++) {
            for (let col = 0; col < someMatrix[row].length; col++) {
                if (matrix[row][col] == 0) {
                    return false;
                }
            }
        }
        return true;
    }

    //change only the contour of the current submatrix
    let matrixOffset = 0;
    while (isMatrixFull(matrix) == false) {
        matrixOffset++;
        star++;
        //change upper and lower contour
        for (let col = starY - matrixOffset; col <= starY + matrixOffset; col++) {
            if (isInBounds(starX - matrixOffset, col, matrix)) {
                matrix[starX - matrixOffset][col] = star;
            }
            if (isInBounds(starX + matrixOffset, col, matrix)) {
                matrix[starX + matrixOffset][col] = star;
            }
        }
        //change left and right contour
        for (let row = starX - matrixOffset; row <= starX + matrixOffset; row++) {
            if (isInBounds(row, starY - matrixOffset, matrix)) {
                matrix[row][starY - matrixOffset] = star;
            }
            if (isInBounds(row, starY + matrixOffset, matrix)) {
                matrix[row][starY + matrixOffset] = star;
            }
        }

    }

    //print the new matrix
    matrix.forEach(r => console.log(r.join(" ")));


}

orbit(['5 5', '2 2']);