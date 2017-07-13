function createCar(commands) {
    let map = new Map();

    let carManager = {
        create: function ([name, ,parent]) {
            parent = map.has(parent) ? map.get(parent) : null;
            let newObj = Object.create(parent);
            map.set(name, newObj);
            return newObj;
        },
        set: function ([name, key, value]) {
            if(map.has(name)){
                let obj = map.get(name);
                obj[key] = value;
            }

        },
        print: function (name) {
            if(map.has(name)){
            let obj = map.get(name);
            console.log(
                Object.keys(obj).map((key)=>`${key}:${obj[key]}`).join
                (', '));}
        }
    };

    for (let command of commands) {
        let commandParameters = command.split(' ');
        let action = commandParameters.shift();
        carManager[action](commandParameters);
    }
}
createCar(['create c1', 'create c2 inherit c1'])
