function populationInTowns(input) {
    let map = new Map();
    for (let line of input) {
        let [town, population] = line.split(/\s*<->\s*/);
        population = Number(population);

        map.has(town) ? map.set(town, map.get(town) + population) : map.set(town, population);
    }
    for (let [town,sum] of map) {
      console.log(town + " : " + sum);
    }
}

let txt = [
    'Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000'
];

populationInTowns(txt);