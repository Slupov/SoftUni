class Rat {
    constructor(name) {
        this.name = name;
        this.unitedWith = [];
    }
    unite(allyRat) {
        if(allyRat.constructor.name === 'Rat') {
            this.unitedWith.push(allyRat);
        }
    }
    getRats() {
        return this.unitedWith;
    }
    toString() {
        let result = this.name;
        this.unitedWith.forEach((rat) => {
            result += `\n##${rat.name}`;
        });
        return result;
    }
}