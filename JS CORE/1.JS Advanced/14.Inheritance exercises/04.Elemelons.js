function solve() {
    class Melon {
        constructor(weight, melonSort) {
            if (new.target === Melon) {
                throw new TypeError("Abstract class cannot be instantiated directly");
            }

            this.weight = weight;
            this.melonSort = melonSort;
            this._elementIndex = this.weight * this.melonSort.length;
            this.elements = ['Fire', 'Earth', 'Air', 'Water'];
            this.element = this.constructor.name.slice(0, -5);
        }

        get elementIndex() {
            return this._elementIndex
        };

        toString() {
            return `Element: ${this.element}\nSort: ${this.melonSort}\nElement Index: ${this._elementIndex}`
        }
    }

    class Watermelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
        }
    }
    class Firemelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
        }
    }
    class Earthmelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
        }
    }
    class Airmelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
        }
    }
    class Melolemonmelon extends Watermelon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
            this.element = "Water";
        }

        morph() {
            let currentElement = this.elements.shift();
            this.element = currentElement;
            this.elements.push(currentElement);
        }
    }

    return {Melon, Watermelon, Firemelon, Earthmelon , Airmelon, Melolemonmelon};
}

//let test = new Melon(100, "Test");
//Throws error

let watermelon = new Watermelon(12.5, "Kingsize");
console.log(watermelon.toString());

// Element: Water
// Sort: Kingsize
// Element Index: 100
console.log();

let testmelon = new Melolemonmelon(12.5, "Golqma");
console.log(testmelon.toString());
