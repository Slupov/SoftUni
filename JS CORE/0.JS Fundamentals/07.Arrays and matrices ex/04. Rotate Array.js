function rotateArray(input) {
    let rotations = input.pop();

    for (let i = 0; i < rotations % array.length; i++) {
        input.unshift(input.pop());
    }
    console.log(input.join(" "));
}