let Turtle = require('./turtle').Turtle;

class NinjaTurtle extends Turtle {
    constructor (name, age, gender, maskColor, weapon) {
        super(name, age, gender);
        this.level = 0;
        this.maskColor = maskColor;
        this.weapon = weapon;
    }

    grow (age) {
        this.level += age;
        super.grow(age);
    }

     toString () {
        let resultString = `${super.toString()}\n`;
        if (this.level < 25) {
            resultString += `${this.name.slice(0, 3)} wears a ${this.maskColor} mask, and is an apprentice with the ${this.weapon}.`;
        } else if (this.level < 100) {
            resultString += `${this.name.slice(0, 3)} wears a ${this.maskColor} mask, and is smokin strong with the ${this.weapon}.`;
        } else {
            resultString += `${this.name.slice(0, 3)} wears a ${this.maskColor} mask, and is BEYOND GODLIKE with the ${this.weapon}.`;
        }

        return resultString;
    }
}

module.exports.NinjaTurtle = NinjaTurtle;
