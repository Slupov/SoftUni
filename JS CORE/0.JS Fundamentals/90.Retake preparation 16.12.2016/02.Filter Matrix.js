function filterMatrix(input) {
    let targetLength = parseInt(input.pop());

    let sequence = input.join(' ').split(' ');

    let currentCount = 1;
    for (let i = 0; i < sequence.length; i++) {
        if (sequence[i] === sequence[i + 1]) {
            currentCount++;

            if (currentCount == targetLength) {
                for (let k = i + 1; k > i + 1 - targetLength; k--) {
                    sequence[k] = false;
                }
                currentCount = 1;
            }
        } else {
            currentCount = 1;
        }
    }

    let resultArr = [];
    let index = -1;
    for (let i = 0; i < input.length; i++) {
        let currentRow = input[i].split(' ');
        let outputRow = [];
        for (let j = 0; j < currentRow.length; j++) {
            if (sequence[++index] !== false) {
                outputRow.push(sequence[index]);
            }
        }
        resultArr.push(outputRow);
    }

    //printing the result
    for (let i = 0; i < resultArr.length; i++) {
        if (resultArr[i].length == 0) {
            console.log('(empty)');
        } else console.log(resultArr[i].join(' '));
    }
}

filterMatrix([
    '3 3 3 2 5 9 9 9 9 1 2',
    '1 1 1 1 1 2 5 8 1 1 7',
    '7 7 1 2 3 5 7 4 4 1 2',
    '2'
]);
console.log("---------------------------");
filterMatrix([
    '2 1 1 1',
    '1 1 1',
    '3 7 3 3 1',
    '2'
])