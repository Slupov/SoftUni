(function () {
    let nextId = 0;

    class Extensible {
        constructor() {
            this.id = nextId;
            nextId++;
        }

        extend(template) {
            for (let prop in template) {
                if (template.hasOwnProperty(prop)) {
                    if (typeof template[prop] == 'function') {
                        Object.getPrototypeOf(this)[prop] = template[prop]
                    } else {
                        this[prop] = template[prop]
                    }
                }
            }
        }
    }
    return Extensible;
}
)();



let e1 = new Extensible();
console.log(e1);
let e2 = new Extensible();
console.log(e2);