function countWithMaps(input) {
    let text = input[0];
    let words = text.toLowerCase().split(/[^A-Za-z0-9_]+/g).filter(x=>x != "");

    let map = new Map();
    for (let word of words) {
        map.has(word) ? map.set(word, map.get(word) + 1) : map.set(word, 1);
    }

    let allWords = Array.from(map.keys()).sort();
    allWords.forEach(w => console.log(`'${w}' -> ${map.get(w)} times`));

}

let test = ["Far too slow, you're far too slow."];
countWithMaps(test);

