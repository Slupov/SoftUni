function breakfastRobot(input) {
    let commandProcessor = (function () {
        let stock = {
            protein: 0,
            carbohydrate: 0,
            fat: 0,
            flavour: 0
        };

        let apple = Object.create(stock);
        let coke = Object.create(stock);
        let burger = Object.create(stock);
        let omelet = Object.create(stock);
        let cheverme = Object.create(stock);

        //not in closure?
        apple.carbohydrate = 1;
        apple.flavour = 2;

        coke.carbohydrate = 10;
        coke.flavour = 20;

        burger.carbohydrate = 5;
        burger.fat = 7;
        burger.flavour = 3;

        omelet.protein = 5;
        omelet.fat = 1;
        omelet.flavour = 1;

        cheverme.protein = 10;
        cheverme.carbohydrate = 10;
        cheverme.fat = 10;
        cheverme.flavour = 10;

        //returning an object containing functions

        return {
            restock: function (microelement, quantity) {
                stock[microelement] += Number(quantity);
                console.log("Success");
            },
            prepare: function (recipe, quantity) {
                for (let element in stock) {
                    if (recipe[element] * Number(quantity) > stock[element]) {
                        return console.log(`Error: not enough ${element} in stock`);
                    }
                }

                for (let element in stock) {
                    //10 - 2 = NaN element = carbohydrate , quantity = 1
                    console.log(` TEST ${element} -> ${Number(recipe[element])}`);
                    stock[element] -= Number(recipe[element]) * Number(quantity);
                }
                return console.log("Success");
            },
            report: function () {
                console.log(`protein=${stock.protein} carbohydrate=${stock.carbohydrate} fat=${stock.fat} flavour=${stock.flavour}`);
            }
        }
    })();

    for (let command of arguments) {
        let [cmdName,token, amount] = command.split(" ");
        commandProcessor[cmdName](token, amount);
    }
}

breakfastRobot(
    "restock carbohydrate 10",
    "restock flavour 10",
    "prepare apple 1",
    "restock fat 10",
    "prepare burger 1",
    "report"
);