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