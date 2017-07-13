function checkIfEnds(input) {
    if (input[0].substring(input[0].length - input[1].length, input[0].length) == input[1]) {
        return true
    }
    return false;
}