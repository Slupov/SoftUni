function bunnyKill(input) {
    let bombBunnies = input.pop().split(' ').map(c => c.split(',').map(Number));
    let hangar = input.map(row => row.split(' ').map(Number));
    let snowballDealtDamage = 0;
    let bunniesKilled = 0;

    //snowball fucks all the bombers up
    for (let bombBunny of bombBunnies) {
        let y = bombBunny[0];
        let x = bombBunny[1];
        //if a bomber out of the matrix is given
        if(!isInBounds(y,x,hangar)){
            continue;
        }
        let bomberHealth = hangar[y][x];

        //snowball kills the living bomber
        if (bomberHealth > 0) {
            snowballDealtDamage += bomberHealth;
            bomberDealingDamage(y, x, hangar);
            hangar[y][x] = 0;
            bunniesKilled++;
        }
    }
    //snowball goes through all living creatures to gift them death
    for (let row = 0; row < hangar.length; row++) {
        for (let col = 0; col < hangar[row].length; col++) {
            //current bunny is not dead
            if (hangar[row][col] > 0) {
                snowballDealtDamage += hangar[row][col];
                hangar[row][col] = 0;
                bunniesKilled++;
            }
        }
    }

    console.log(snowballDealtDamage);
    console.log(bunniesKilled);

    function isInBounds(y, x, someMatrix) {
        if(y >= someMatrix.length){
            return false;
        }
        if (x < 0 || y < 0 || x>=someMatrix[y].length || y>=someMatrix.length) {
            return false;
        }
        if (!((x < someMatrix[y].length && x >= 0) && (y >= 0 && y < someMatrix.length))) {
            return false;
        }
        return true;
    }

    function bomberDealingDamage(bombY, bombX, matrix) {
        //deal damage to upper and lower rows neighbours
        for (let col = bombX - 1; col <= bombX + 1; col++) {
            if (isInBounds(bombY - 1, col, matrix)) {
                matrix[bombY - 1][col] -= matrix[bombY][bombX];
            }
            if (isInBounds(bombY + 1, col, matrix)) {
                matrix[bombY + 1][col] -= matrix[bombY][bombX];
            }
        }
        //deal damage to left and right column neighbours
        if(isInBounds(bombY,bombX-1,matrix)){
            matrix[bombY][bombX-1] -= matrix[bombY][bombX]
        }
        if(isInBounds(bombY,bombX+1,matrix)){
            matrix[bombY][bombX+1] -= matrix[bombY][bombX]
        }

    }
}

// let arr = [
//     '5 10 15 20',
//     '10 10 10 10',
//     '10 15 10 10',
//     '10 10 10 10',
//     '2,2 4,3'
//
// ];
// bunnyKill(arr);