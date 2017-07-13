function imperialUnits(input) {
    let inches = input;
    let feet = Math.floor(inches/12);
    let inchs = inches%12;

    console.log(`${feet}\'-${inchs}\"`);

}