function* fibonacci () {
    let firstNum = 0;
    let secondNum = 1;
    let nextNum = firstNum + secondNum;

    yield 1;
    while (true) {
        yield nextNum;
        firstNum = secondNum;
        secondNum = nextNum;
        nextNum = firstNum + secondNum;
    }
}


let fib = fibonacci();
console.log(fib.next().value);
console.log(fib.next().value);
console.log(fib.next().value);
console.log(fib.next().value);
