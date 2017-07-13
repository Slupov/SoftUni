function current(input) {
    let juices = [];
    let emptyJuices = [];
    for (let j of input) {
        let currentJuice = j.split('=>').map(x => x.trim());
        currentJuice[1] = Number(currentJuice[1]);
        if (currentJuice[0] in juices) {
            juices[`${currentJuice[0]}`] += currentJuice[1];
        }
        else {
            if (currentJuice[1] >= 1000)
                juices[`${currentJuice[0]}`] = currentJuice[1];
            else {
                if (currentJuice[0] in emptyJuices)
                    emptyJuices[`${currentJuice[0]}`] += currentJuice[1];
                else
                    emptyJuices[`${currentJuice[0]}`] = currentJuice[1];
                if (emptyJuices[`${currentJuice[0]}`] >= 1000) {
                    juices[`${currentJuice[0]}`] = emptyJuices[`${currentJuice[0]}`];
                }
            }
        }
    }

    for (let juice in juices) {
        let quantity = Math.floor(juices[juice] / 1000);
        if (quantity != 0)
            console.log(`${juice} => ${quantity}`);
    }
}