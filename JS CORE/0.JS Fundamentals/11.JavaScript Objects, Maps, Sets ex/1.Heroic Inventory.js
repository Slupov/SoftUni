function heroicInventory(input) {
    let output = [];
    for (let line of input) {
        let currentHeroInfo = line.split(" / ");
        let currentName = currentHeroInfo[0].trim();
        let currentLevel = Number(currentHeroInfo[1]);

        let currentItems = [];

        let hero = {
            name: currentName,
            level: currentLevel,
            items: currentItems
        };

        if (currentHeroInfo.length == 3) {
            currentItems = currentHeroInfo[2].split(",").map(i => i.trim());
            hero.items = currentItems;
        }
        output.push(hero);
    }
    console.log(JSON.stringify(output));
}
