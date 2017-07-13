function countWords(input) {
    let text = input[0];
    let words = text.split(/[^A-Za-z0-9_]+/g).filter(x=>x != "");
    let obj = {};
    for (let word of words) {
        obj[word] ? obj[word]++ : obj[word] = 1;
    }

    return JSON.stringify(obj);
}
let arr = ["Far too slow, you're far too slow."];
countWords(arr);