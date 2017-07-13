let Turtle = require('./turtle.js').Turtle;

class GalapagosTurtle extends Turtle {
    constructor (name, age, gender) {
        super(name, age, gender);
        this._thingsEaten = [];
    }

    get thingsEaten () {
        return this._thingsEaten;
    }

    eat (food) {
        this._thingsEaten.push(food);
    }

     grow (age) {
        super.grow(age);
        this._thingsEaten = [];
    }

    toString () {
        let resultString = `${super.toString()}\n`;
        resultString += `Things, eaten this year: ${this.thingsEaten.join(', ')}`;

        return resultString;
    }
}

module.exports.GalapagosTurtle = GalapagosTurtle;
