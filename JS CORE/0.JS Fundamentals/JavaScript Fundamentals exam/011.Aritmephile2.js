function arithmephile(input) {
    let numbers = input.map(Number);
    let products = [];
    let product = 1;
    for (let i = 0; i < numbers.length; i++) {
        if (numbers[i] < 10 && numbers[i] >= 0) {
            if (i + numbers[i] < numbers.length) {
                for (let j = i + 1; j <= i + numbers[i]; j++) {
                    product *= numbers[j];
                }
                products.push(product);
                product = 1;
            }

        }
    }
    products.sort((a, b)=>b - a);
    console.log(products[0]);
}