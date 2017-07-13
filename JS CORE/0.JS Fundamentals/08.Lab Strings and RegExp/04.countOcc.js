function countOcc(input) {
    let searched = input[0];
    let text = input[1];
    let index = text.indexOf(searched);
    let count = 0;
    while (index > -1) {
        count++;
        index = text.indexOf(searched, index + 1);
    }
    return count;
}