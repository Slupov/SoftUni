function townsToJSON(input) {
    let townsArr= [];
    for (let town of input.slice(1)) {
        let [empty,townName,lat,lng] = town.split("|").map(x => x.trim());

        let townObj = {Town: townName, Latitude: Number(lat), Longitude: Number(lng)};
        townsArr.push(townObj);
    }
    return JSON.stringify(townsArr);
}

console.log(townsToJSON([
    "| Town | Latitude | Longitude |",
    "| Sofia | 42.69| 23.32 |",
    "| Beijing | 39.91 | 116.36 |"]));