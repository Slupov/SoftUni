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