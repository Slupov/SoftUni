// 80/100 probably a mistake in the nested digits or overflow of loop
function arithmephile(input) {
    let biggestProduct = 1;

    for (let i = 0; i < input.length; i++) {
        let number = Number(input[i]);
        if (number >= 0 && number <= 9) {
            //multiplying next number numbers
            let currentProduct = 1;

            for (let j = i + 1; j <= i + number; j++) {
                currentProduct *= input[j];
            }
            if (currentProduct > biggestProduct) {
                biggestProduct = currentProduct;
            }
        }
    }
    console.log(biggestProduct);
}

let test = [
    '10',
    '20',
    '2',
    '30',
    '44',
    '123',
    '3',
    '56',
    '20',
    '24'
];

arithmephile(test);