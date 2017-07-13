let f = (function () {
    let sum = 0;
    return{
        add: (num) => sum+=num,
        subtract: (num) => sum-=num,
        multiply: (num) => sum*=num,
        divide: (num) => sum/=num,
    }
})();

console.log(f.add(5));
console.log(f.add(5));
console.log(f.add(5));
console.log(f.divide(5));
console.log(f.multiply(8));
