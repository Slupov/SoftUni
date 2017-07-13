function cookingByNumbers(input) {
    let number = Number(input[0]);

    let divideByTwo = function (num) {
        return num / 2;
    };
    let squareRoot = function (num) {
        return Math.sqrt(num);
    };
    let addOne = function (num) {
        return num + 1;
    };
    let multiplyByThree = function (num) {
        return num * 3;
    };
    let subtractTwentyPer = function (num) {
        return num - num * 0.2;
    };


    for (let i = 1; i <= 5; i++) {
        let op = input[i];
        switch (op) {
            case "chop":
                console.log(divideByTwo(number));
                number = divideByTwo(number);
                break;
            case "dice":
                console.log(squareRoot(number));
                number = squareRoot(number);
                break;
            case "spice":
                console.log(addOne(number));
                number = addOne(number);
                break;
            case "bake":
                console.log(multiplyByThree(number));
                number = multiplyByThree(number);
                break;
            case "fillet":
                console.log(subtractTwentyPer(number));
                number = subtractTwentyPer(number);
                break;
        }
    }
}
