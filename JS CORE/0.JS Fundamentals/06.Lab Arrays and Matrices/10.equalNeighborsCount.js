function equalNeighborsCount(matrixRows) {
    let matrix = matrixRows.map(
        row => row.split(' '));
    let neighbors = 0;
    for (let row = 0; row < matrix.length-1; row++)
        for (let col = 0; col < matrix[row].length; col++){

            if (matrix[row][col] == matrix[row + 1][col])
                neighbors++;
            if(matrix[row][col] == matrix[row][col+1])
                neighbors++;
        }

    for (let i = 0; i < matrix[matrix.length-1].length - 1; i++) {
        if (matrix[matrix.length-1][i] == matrix[matrix.length-1][i+1])
            neighbors++;
    }

    return neighbors;
}