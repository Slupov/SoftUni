function * solve(inputNumber) {
    let previousSequence = inputNumber.toString();

    while (true) {
        let resultString = '';

        for (let i = 0; i < previousSequence.length; i++) {
            let counter = 1;
            let currentDigit = previousSequence[i];
            let index = i + 1;
            while (index < previousSequence.length) {
                let nextDigit = previousSequence[index];
                if (nextDigit === currentDigit) {
                    counter++;
                    index++;
                } else {
                    break;
                }
            }

            i = index - 1;
            resultString += `${counter}${currentDigit}`;
        }

        previousSequence = resultString;
        yield resultString;
    }
}

let lookSequence = solve(1);
console.log(lookSequence.next().value);
console.log(lookSequence.next().value);
console.log(lookSequence.next().value);
console.log(lookSequence.next().value);
console.log(lookSequence.next().value);


// console.log("111".match(/[1]*/));
