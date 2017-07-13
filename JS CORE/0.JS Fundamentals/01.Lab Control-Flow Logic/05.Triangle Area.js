function triangleArea([a,b,c]) {
    [a,b,c] = [a,b,c].map(Number);
    let sp = (a+b+c)/2;
    console.log(Math.sqrt(sp*(sp-a)*(sp-b)*(sp-c)));
}