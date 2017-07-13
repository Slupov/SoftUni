function current(input) {
    let cars = [];
    let models = new Set();
    let aCar = {brand: undefined, model: undefined, produced: undefined};
    for (let row of input) {
        let current = row.split(' | ');
        if (!checkBrand(current[0],current[1])) {
            aCar = {};
            aCar.brand = current[0];
            aCar.model = current[1];
            aCar.produced = Number(current[2]);
            cars.push(aCar);
        }
        else {
            for (let car of cars) {
                if (car.model == current[1]) {
                    car.produced += Number(current[2]);
                }
            }
        }
    }

    for (let car of cars){
        let mod=car.brand;
        models.add(mod)
    }
    for(let br of models){
        console.log(br);
        for(let car of cars){
            if(car.brand==br)
                console.log(`###${car.model} -> ${car.produced}`);
        }
    }


    function checkBrand(brand,model) {
        let flag = false;
        for (let car of cars) {
            if (car.brand == brand && car.model==model) {
                flag = true;
            }
        }
        return flag;


    }
}