function carFactory(obj) {
    let resultCar = {};
    resultCar.model = obj.model;

    let engine = {power:0 , volume: 1800};
    let smallEngine = Object.create(engine);
    smallEngine.power = 90; smallEngine.volume = 1800;

    let normalEngine = Object.create(engine);
    normalEngine.power = 120; normalEngine.volume = 2400;

    let monsterEngine = Object.create(engine);
    monsterEngine.power = 200; monsterEngine.volume = 3500;

    let coupe = {type: 'coupe', color: obj.color};
    let hatchback = {type: 'hatchback', color: obj.color};

    let wheelSize = 0;
    if(obj.wheelsize % 2 == 0){
        wheelSize = obj.wheelsize-1;
    }else{
        wheelSize = obj.wheelsize;
    }

    function chooseEngine() {
        if(obj.power <= smallEngine.power){
            return smallEngine;
        }
        else if(obj.power > smallEngine.power && obj.power<= normalEngine.power){
            return normalEngine;
        }
        else if(obj.power > normalEngine.power && obj.power <= monsterEngine.power){
            return monsterEngine;
        }
    }

    resultCar.engine = chooseEngine();
    obj.carriage = "coupe" ? resultCar.carriage = coupe : resultCar.carriage = hatchback;

    resultCar.wheels = [];
    for (let i = 0; i < 4; i++) {
        resultCar.wheels.push(wheelSize);
    }

    return resultCar;



}

let car = {
    model: 'VW Golf II',
    power: 90,
    color: 'red',
    carriage: 'hatchback',
    wheelsize: 14
};
console.log(carFactory(car));
