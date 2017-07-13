function spiceMustFlow(input){
    //how much on the 1st day
    let startingYield = Number(input[0]);
    let workersYield = 0;
    let days = 0;

    if(startingYield < 100){
        console.log(days);
        console.log(workersYield);
        return;
    }
    while(startingYield >= 100)
    {
        days++;
        workersYield += startingYield - 26;
        startingYield -= 10;
    }
    workersYield -= 26;


    console.log(days);
    console.log(workersYield);


}

spiceMustFlow(['10']);