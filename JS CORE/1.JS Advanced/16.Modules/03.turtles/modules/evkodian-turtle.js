let Turtle = require('./turtle.js').Turtle;

class EvkodianTurtle extends Turtle {
    constructor (name, age, gender, evkodiumValue) {
        super(name, age, gender);
        this._evkodiumValue = Number(evkodiumValue);
    }

    get evkodium () {
        let resultObject = { value: this._evkodiumValue };

        if (this._gender == 'male') {
            resultObject.density = Number(this.age) * 3;
        } else {
            resultObject.density = Number(this.age) * 2;
        }

        return resultObject;
    }

     toString () {
        let resultString = `${super.toString()}\n`;
        resultString += `Evkodium: ${this.evkodium.value * this.evkodium.density}`;

        return resultString;
    }
}

module.exports.EvkodianTurtle = EvkodianTurtle;
