class SortedList {
    constructor() {
        this.collection = [];
        this.size = 0;
    }

    add(element) {
        if (typeof element == "number") {
            this.collection.push(element);
            this.reSort()
        }
        this.size = this.collection.length;
    }


    remove(index) {
        if (index >= 0 && index < this.collection.length) {
            this.collection = this.collection.filter((x,i) => i!=index);
            this.size = this.collection.length;
            this.reSort();
        }
        else throw new Error;
    }

    get(index) {
        if (index >= 0 && index < this.collection.length) {
            return this.collection[index];
        }
    }

    reSort() {
        this.collection = this.collection.sort((a, b) => a - b);
    }
}

let arr = new SortedList();
arr.add(5);
arr.add(3);
arr.add(4);
arr.add(1);