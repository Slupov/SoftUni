function storeCatalogue(input) {
    let map = new Map();

    for (let line of input) {
        let startingChar = line[0];
        if (map.has(startingChar)) {
            map.get(startingChar).push(line);
        }
        else {
            map.set(startingChar, new Array());
            map.get(startingChar).push(line);
        }
    }

    for (let key of Array.from(map.keys()).sort()) {
        console.log(key);
        for (let value of Array.from(map.get(key)).sort()) {
            value = value.split(" :");
            value = value[0]+":" + value[1];
          console.log("  " + value);
        }
    }
}

console.log(storeCatalogue([
    'Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10'
]));