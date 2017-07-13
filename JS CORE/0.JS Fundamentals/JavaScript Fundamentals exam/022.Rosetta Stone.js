function rosettaStone2(input) {

    let n = Number(input[0]);
    let pattern= [];
    let encryptedMatrix = [];
    
    for (let i = 1; i <= n; i++) {
        let row = input[i].split(' ');
        row = row.map(Number);
        pattern.push(row);

    }
    for (let j = n + 1; j < input.length; j++) {
        let row = input[j].split(' ');
        row = row.map(Number);
        encryptedMatrix.push(row);
    }

    if (n != 1) {
        for (let row = 0; row < encryptedMatrix.length; row++) {
            for (let col = 0; col < encryptedMatrix[row].length; col++) {
                encryptedMatrix[row][col] += pattern[row % n][col % pattern[row % n].length];
            }
        }
    }
    else {
        for (let row = 0; row < encryptedMatrix.length; row++) {
            for (let col = 0; col < encryptedMatrix[row].length; col++) {
                encryptedMatrix[row][col] += pattern[0][col % pattern[0].length];
            }
        }
    }
    for (let row = 0; row < encryptedMatrix.length; row++) {
        for (let col = 0; col < encryptedMatrix[row].length; col++) {
            if (encryptedMatrix[row][col] % 27 != 0)
                encryptedMatrix[row][col] = String.fromCharCode((encryptedMatrix[row][col] % 27) + 64);
            else
                encryptedMatrix[row][col] = String.fromCharCode(32);

        }
    }
    let result = '';
    for (let row of encryptedMatrix) {
        result += row.join('');
    }

    console.log(result);
}