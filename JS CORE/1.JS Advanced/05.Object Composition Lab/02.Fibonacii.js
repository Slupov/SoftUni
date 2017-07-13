function fibonacci(n) {
    let fib = (()=> {
        let f0 = 0, f1 = 1;
        return function () {
            let oldF0 = f0, oldF1 = f1;
            f0 = oldF1;
            f1= oldF0 + f0;
            return oldF1;
        }
    })();

    let fibNumbers = [];
    for (let i = 1; i <= n; i++) {
        fibNumbers.push(fib());
    }
    return fibNumbers;
}