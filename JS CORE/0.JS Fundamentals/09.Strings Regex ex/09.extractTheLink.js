function extractTheLink(input) {
    let text = input.join('\n');
    let pattern = "www\\.([a-zA-Z0-9-]+)(\\.[a-z]+)+";
    let regex = new RegExp(pattern, "g");
    let matches = text.match(regex);
    //console.log(pattern);
    if (matches) {
        console.log(matches.join("\n"));
    }
}