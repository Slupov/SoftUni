function modifyAverage(input) {
    function digitsAverage(num) {
        let numArr = num.toString();
        let avg = 0;
        for (let i = 0; i < numArr.length; i++) {
            avg += Number(numArr[i]);
        }
        avg = avg / (numArr.length);
        return avg;
    }

    let num = input[0];

    while (!(digitsAverage(num) > 5)) {
        num += '9';
    }

    console.log(num);
}