function reverseArrayIterator (inputArray) {
    let index = inputArray.length - 1;

    return {
        [Symbol.iterator]: function () { return this; },
        ['next']: function () {
            if (index >= 0) {
                return { value: inputArray[index--], done: false };
            } else {
                return { done: true };
            }
        }
    };
}

let iterator = reverseArrayIterator([10, 20, 30]);

while (true) {
    let item = iterator.next();
    if (item.done) break;
    console.log(item.value);
}