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