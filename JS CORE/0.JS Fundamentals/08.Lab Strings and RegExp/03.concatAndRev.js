function concatAndRev(input) {
    let all = input.join("");
    let chars = Array.from(all).reverse().join("");
    return chars;
}