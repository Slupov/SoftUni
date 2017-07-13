class Stringer {
    constructor(string, initialLength) {
        this.innerString = string;
        this.innerLength = initialLength;

    }

    increase(length) {
        this.innerLength += Number(length);
    }

    decrease(length) {
        this.innerLength -= Number(length);
        if (this.innerLength < 3) {
            this.innerLength = 0;
        }
    }

    toString(){
        if(this.innerLength == 0){
            return "...";
        }
        if(this.innerString.length > this.innerLength){
            return this.innerString.slice(0,this.innerLength) + "...";
        }
        return this.innerString;
    }
}
