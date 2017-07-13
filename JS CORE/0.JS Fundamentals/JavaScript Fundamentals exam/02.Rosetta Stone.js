//66/100 CHECK ITERATION !!!
function rosettaStone(input) {
    let lines = Number(input.shift());
    let template = [];

    for (let i = 0; i < lines; i++) {
        let row = input.shift().split(" ").map(Number)
        template.push(row);
    }

    //make every line an array of numbers
    for (let i = 0; i < input.length; i++) {
        input[i] = input[i].split(" ").map(Number);
    }

    let resultMatrix = input;
    //we've got the template matrix
    //going through the matrix and adding the numbers
    for (let row = 0; row < resultMatrix.length; row++) {
        for (let col = 0; col < resultMatrix.length; col++) {
            resultMatrix[row][col] += template[row % lines][col % template[0].length];
        }
    }
    //console.log(' '.charCodeAt(0) % 64);

    //decoding the matrix
    for (let row = 0; row < resultMatrix.length; row++) {
        for (let col = 0; col < resultMatrix.length; col++) {
            resultMatrix[row][col] = String.fromCharCode(resultMatrix[row][col] % 27 + 64);
            if(resultMatrix[row][col] == '@'){
                resultMatrix[row][col] = " ";
            }
        }
    }
    let result = "";
    for (let row = 0; row < resultMatrix.length; row++) {
        for (let col = 0; col < resultMatrix.length; col++) {
            result += resultMatrix[row][col];
        }
    }

    console.log(result);
}

let test = ['2',
    '59 36',
    '82 52',
    '4 18 25 19 8',
    '4 2 8 2 18',
    '23 14 22 0 22',
    '2 17 13 19 20',
    '0 9 0 22 22'];
let test2 = [
    '1',
    '1 3 13',
    '12 22 14 13 25 0 4 24 23',
    '18 24 2 25 22 0 0 11 18',
    '8 25 6 26 8 23 13 4 14',
    '14 3 14 10 6 1 6 16 14',
    '11 12 2 10 24 2 13 24 0',
    '24 24 10 14 15 25 18 24 12',
    '4 24 0 8 4 22 19 22 14',
    '0 11 18 26 1 19 18 13 15',
    '8 15 14 26 24 14 26 24 14'
];

rosettaStone(test2);
