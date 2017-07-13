class Laptop{
    constructor(weight){
        this._weight = weight;
    }

    get weight(){
        return this._weight;
    }
}

Laptop.weight = 20;


let f = (function() {
    let counter = 0;
    return function() {
        console.log(++counter);
    }
})();

for (let i = 0; i < 5; i++) {
    f();
};