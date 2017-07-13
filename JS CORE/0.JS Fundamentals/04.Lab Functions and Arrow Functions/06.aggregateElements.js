function aggregateElements(input) {
    let sum1 = 0;
    let sum2 = 0;
    let str = "";

    for (let i = 0; i < input.length; i++) {
        sum1 += Number(input[i]);
        sum2 += 1 / input[i];
        str += input[i];
    }

    console.log(sum1);
    console.log(sum2);
    console.log(str);

}