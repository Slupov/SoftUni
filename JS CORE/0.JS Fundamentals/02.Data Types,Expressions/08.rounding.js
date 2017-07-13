function rounding(input) {
    let num=Number(input[0]);
    let precision=Number(input[1]);
    if(precision>15) precision=15;
    let rounded = Math.round(num*Math.pow(10,precision))/Math.pow(10,precision);

    console.log(rounded);
}