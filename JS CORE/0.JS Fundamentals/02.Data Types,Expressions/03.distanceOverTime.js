function distanceOverTime(input) {
    let v1 = Number(input[0]);
    let v2 = Number(input[1]);
    let t = Number(input[2])/3600;

    let delta = Math.abs(v1*t - v2*t);
    console.log(delta*1000);
}