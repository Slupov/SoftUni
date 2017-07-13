function stringStarts(input) {
    if (input[0].substring(0, input[1].length) == input[1]) {
        return true
    }
    return false;
}