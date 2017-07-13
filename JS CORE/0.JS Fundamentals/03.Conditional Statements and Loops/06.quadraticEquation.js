function quadraticEquation(input) {
    let a = Number(input[0]);
    let b = Number(input[1]);
    let c = Number(input[2]);

    let discriminant = Math.pow(b, 2) - 4 * a * c;
    if (discriminant > 0) {
        let x1 = (Math.sqrt(discriminant) - b) / (2 * a);
        let x2 = (0 - Math.sqrt(discriminant) - b) / (2 * a);
        console.log(Math.min(x1, x2));
        console.log(Math.max(x1, x2));
    }
    else if (discriminant == 0) {
        let x1 = -b / (2 * a);
        console.log(x1);
    }
    else console.log("No");
}