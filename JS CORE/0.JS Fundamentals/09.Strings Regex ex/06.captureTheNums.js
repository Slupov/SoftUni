function captureTheNums(input) {
    let str = "";
    for (let string of input) {
        if (string.match(/\d+/)) {
            str += string.match(/\d+/g).join(" ") + " ";
        }
    }
    return str;
}