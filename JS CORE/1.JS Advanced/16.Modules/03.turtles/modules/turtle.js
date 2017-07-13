class Turtle {
    constructor (name, age, gender) {
        if (new.target === Turtle) {
            throw new Error('Cannot create an instance of an abstract class');
        }

        this._name = name;
        this._age = age;
        this._gender = gender;
    }

    get name () {
        return this._name;
    }

    get age () {
        return this._age;
    }

    get gender () {
        return this._gender;
    }

    grow (age) {
        this._age += age;
    }

    toString () {
        let resultString = `Turtle: ${this.name}\n`;
        resultString += `Aged - ${this.age}; Gender - ${this.gender}`;

        return resultString;
    }
}

module.exports.Turtle = Turtle;
