function medenkaWars(input) {
    let vitkorDealtDamage = 0;
    let naskorDealtDamage = 0;

    let vitkorConsecutiveAttacks = 0;
    let naskorConsecutiveAttacks = 0;

    let vitkorPreviousDamage = Number.NEGATIVE_INFINITY;
    let naskorPreviousDamage = Number.NEGATIVE_INFINITY;


    for (let i = 0; i < input.length; i++) {
        let currentInputLine = input[i].split(" ");

        let countOfMedenkas = Number(currentInputLine[0]);
        let medenkaType = currentInputLine[1];

        if (medenkaType == "white") {
            let medenkaDamage = countOfMedenkas * 60;

            if (medenkaDamage == vitkorPreviousDamage) {
                vitkorConsecutiveAttacks++;
            }
            else {
                vitkorConsecutiveAttacks = 1;
            }

            //check if special attack
            if (vitkorConsecutiveAttacks == 2) {
                vitkorDealtDamage += medenkaDamage * 2.75;
                vitkorPreviousDamage = medenkaDamage * 2.75;
                //next doesnt count as consecutive because its normal
                vitkorConsecutiveAttacks = 0;
            }
            else{
                vitkorDealtDamage += medenkaDamage;
                vitkorPreviousDamage = medenkaDamage;
            }
        }
        else {
            let medenkaDamage = countOfMedenkas * 60;

            if (medenkaDamage == naskorPreviousDamage) {
                naskorConsecutiveAttacks++;
            }
            else {
                naskorConsecutiveAttacks = 1;
            }

            if (naskorConsecutiveAttacks == 5) {
                naskorDealtDamage += medenkaDamage * 4.5;
                naskorPreviousDamage = medenkaDamage * 4.5;
                naskorConsecutiveAttacks = 0;
            }
            else{
                naskorDealtDamage += medenkaDamage;
                naskorPreviousDamage = medenkaDamage;
            }
        }

    }

    if(vitkorDealtDamage > naskorDealtDamage){
        console.log("Winner - Vitkor");
        console.log("Damage - " + vitkorDealtDamage);
    }
    else{
        console.log("Winner - Naskor");
        console.log("Damage - " + naskorDealtDamage);
    }
}

medenkaWars([
    '5 white medenkas',
    '5 dark medenkas',
    '4 white medenkas',
]);