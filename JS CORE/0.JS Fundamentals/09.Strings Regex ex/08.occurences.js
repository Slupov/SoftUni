function occurences(input) {
    let text = input[0].toLowerCase();
    let searched = input[1].toLowerCase();

    let regex = new RegExp("\\" + "b" + searched + "\\" + "b", "g");
    let match = regex.exec(text);
    let count = 0;

    while (match != null) {
        count++;
        match = regex.exec(text);
    }

    return count;
}