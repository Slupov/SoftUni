function nonDecreasingSubs(input) {
    let biggest = input.shift();
    console.log(biggest);
    input = input.map(Number);

    for (let i = 0; i < input.length; i++) {
        if (input[i] >= biggest) {
            biggest = input[i];
            console.log(biggest);
        }
    }
}