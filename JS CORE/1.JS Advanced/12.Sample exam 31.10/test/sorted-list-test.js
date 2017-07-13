let expect = require("chai").expect;
let SortedList = require("../sorted-list").SortedList;

describe("SortedList class", function() {
    let myList = {};
    //before every "it"
    //new empty collection in every "it"
    beforeEach(function () {
        myList = new SortedList();
    });

    it("should have a constructor", function() {
        expect(typeof SortedList).to.equal('function');

        //functions are all attached to the prototype
        expect(SortedList.prototype.hasOwnProperty('add')).to.equal(true, "Didnt find add function");

        expect(SortedList.prototype.hasOwnProperty('remove')).to.equal(true, "Didnt find remove function");

        expect(SortedList.prototype.hasOwnProperty('get')).to.equal(true, "Didnt find get function");

        //size kym prototype
        //ako beshe prop sys stoinost 6te6e da e kym instanciata
        expect(SortedList.prototype.hasOwnProperty('size')).to.equal(true, "Didnt find size function");

    });

    it("should have size property",function () {
        //checks if its getter too
        expect(myList.size).to.equal(0);
    })

    it("should have working add and get",function () {
        myList.add(4);
        expect(myList.get(0)).to.equal(4);
    })

    it("should have working sort",function () {
        myList.add(4);
        myList.add(3);
        myList.add(8);
        myList.add(1);
        expect(myList.get(0)).to.equal(1);
        expect(myList.get(1)).to.equal(3);
        expect(myList.get(2)).to.equal(4);
        expect(myList.get(3)).to.equal(8);
        expect(myList.size).to.equal(4);

    })

    it("remove should work",function () {
        myList.add(4);
        myList.add(3);
        myList.add(10);
        myList.add(1);
        myList.remove(1);
        expect(myList.get(0)).to.equal(1);
        expect(myList.get(1)).to.equal(4);
        expect(myList.get(2)).to.equal(10);
        expect(myList.size).to.equal(3);
    })

    it("should not work with negative index",function () {
        myList.add(4);
        myList.add(3);
        myList.add(10);
        myList.add(1);
        expect(() => myList.get(-1)).to.throw(Error);
        expect(() => myList.remove(-1)).to.throw(Error);

    })

    it("should not work with outside index",function () {
        myList.add(4);
        myList.add(3);
        myList.add(10);
        myList.add(1);
        myList.remove(1);
        expect(() => myList.get(4)).to.throw(Error);
        expect(() => myList.remove(4)).to.throw(Error);

    })

    it("should not work with empty collecton",function () {
        expect(() => myList.get(0)).to.throw(Error);
        expect(() => myList.remove(0)).to.throw(Error);

    })
});
