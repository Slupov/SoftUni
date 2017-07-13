function solve (recipes) {
    class Candy {
        constructor (topping, filling, spice) {
            this.topping = topping;
            this.filling = filling;
            this.spice = spice;
        }

        set topping (value) {
            let validToppings = ['milk chocolate', 'white chocolate', 'dark chocolate'];
            if (!validToppings.includes(value)) {
                throw new TypeError('Invalid topping value');
            }

            this._topping = value;
        }

        get topping () {
            return this._topping;
        }

        set filling (value) {
            if (value.length > 3) {
                throw new TypeError('Filling length is more than 3');
            }
            
            if (value.length === 1 && value[0] === '') {
                this._filling = null;
            } else {
                let validFillings = ['hazelnut', 'caramel', 'strawberry', 'blueberry', 'yogurt', 'fudge'];
                for (let filling of value) {
                    if (!validFillings.includes(filling)) {
                        throw new TypeError('Invalid filling');
                    }
                }
                this._filling = value.join(',');
            }
        }

        get filling () {
            return this._filling;
        }

        set spice (value) {
            if (value === 'asbestos' || value === 'poison') {
                throw new Error('Invalid spice');
            }

            if (value === '') {
                this._spice = null;
            } else {
                this._spice = value;
            }
        }

        get spice () {
            return this._spice;
        }
    }
    let resultArr = [];
    
    for (let recipe of recipes) {
        let tokens = recipe.split(':');

        if (tokens.length !== 3) {
            continue;
        }

        let topping = tokens[0];
        let filling = tokens[1].split(',');
        let spice = tokens[2];

        try {
            let candy = new Candy(topping, filling, spice);
            resultArr.push(candy);
        } catch (e) {}
    }

    return resultArr;
}
