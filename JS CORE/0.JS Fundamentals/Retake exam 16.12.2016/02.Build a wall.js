function buildAWall(input) {
    let temp = input.map(Number).sort((a, b) => a - b);

    let workingDays = 30 - temp[0];
    let concretePerFoot = 195;
    let concretePerDays = [];
    for (let i = 0; i < workingDays; i++) {
        concretePerDays.push(0);
    }
    let finalCost = 0;

    for (let i = 0; i < workingDays; i++) {
        for (let t = 0; t < input.length; t++) {
            if(input[t] < 30){
                input[t]++;
                concretePerDays[i] += concretePerFoot;
            }
        }
    }

    for (let price of concretePerDays) {
        finalCost += price;
    }
    
    console.log(concretePerDays.join(", "));
    console.log(finalCost*1900 + " pesos");

}

buildAWall([28, 25, 21]);