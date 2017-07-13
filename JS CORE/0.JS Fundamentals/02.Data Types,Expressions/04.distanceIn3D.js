function distanceIn3D(input) {
    let x = Number(input[0]);
    let y = Number(input[1]);
    let z = Number(input[2]);
    let x2 = Number(input[3]);
    let y2 = Number(input[4]);
    let z2 = Number(input[5]);

    let distance = Math.sqrt(Math.pow(x-x2,2) + Math.pow(y-y2,2) + Math.pow(z-z2,2));

    console.log(distance);
}