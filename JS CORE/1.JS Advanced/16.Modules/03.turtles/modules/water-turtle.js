let Turtle = require('./turtle.js').Turtle;

class WaterTurtle extends Turtle {
    constructor (name, age, gender, waterPool) {
        super(name, age, gender);
        this._waterPool = waterPool;
    }

    get currentWaterPool () {
        return this._waterPool;
    }

    travel (waterPool) {
        this._waterPool = waterPool;
        super.grow(5);
    }

    toString () {
        let resultString = `${super.toString()}\n`;
        resultString += `Currently inhabiting ${this.currentWaterPool}`;

        return resultString;
    }
}

module.exports.WaterTurtle = WaterTurtle;
