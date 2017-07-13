function binaryToDecimal(input){
    let binary = input.toString();
    let sum = 0;
    let power = 0;
    for (var i = binary.length -1 ; i >= 0; i--) {
        if(binary[i] == '1'){
            sum += Math.pow(2,power);
        }
        power++;
    }
    console.log(sum);
}