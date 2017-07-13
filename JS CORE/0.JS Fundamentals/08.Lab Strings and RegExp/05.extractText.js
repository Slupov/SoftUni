function extractText(input) {
    let text = input[0];
    let regex = new RegExp(/\((.*?)\)/g);
    let substrings = text.match(regex);
    console.log(substrings.map(x => x.slice(1, x.length - 1)).join(", "));
}