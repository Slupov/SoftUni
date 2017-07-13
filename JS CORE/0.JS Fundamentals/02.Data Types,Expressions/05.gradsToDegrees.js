function gradsToDegrees(input) {
    let grad = Number(input);
    let degrees = (grad*0.9)%360;

    if(degrees<0){
        console.log(360+degrees);
    }
    else console.log(degrees);
}