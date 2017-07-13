let expect = require("chai").expect;
let Console = require("../05.C# console").Console;

describe("C# Console class", function() {
    it("should have a constructor", function() {
        expect(typeof Console).to.equal('function')
    })

    it("should return the string param if writeLine(string)", function () {
        expect(Console.writeLine("Pesho")).to.equal("Pesho")
    })

    it("should return the JSON of a param if writeLine(object)", function () {
        expect(Console.writeLine({name: "Pesho"})).to.equal(JSON.stringify({name: "Pesho"}))
    })

    it("should throw a TypeError if writeLine(templateString, parameters) and templateString is not a string", function () {
        expect(() => Console.writeLine(5, 'heyo', [5, 10], '123')).to.throw(TypeError)
    })

    it("should throw a TypeError if writeLine(object, parameters) and templateString is not a string", function () {
        expect(() => Console.writeLine({name: "Pesho"}, 'heyo', [5, 10], '123')).to.throw(TypeError)
    })

    it("should throw a TypeError if writeLine(array, parameters) and templateString is not a string", function () {
        expect(() => Console.writeLine([], 'heyo', [5, 10], '123')).to.throw(TypeError)
    })

    it("should throw a RangeError if the number of parameters does not correspond to the number of placeholders ", function () {
        expect(() => Console.writeLine("The sum of {0} and {1} is {2}", 3,7)).to.throw(RangeError)
    })

    it("should throw a RangeError if the number of parameters does not correspond to the number of placeholders ", function () {
        expect(() => Console.writeLine("The sum of {0} and {1} is {2}", 3,7,2,4,2)).to.throw(RangeError)
        expect(() => Console.writeLine('Tani {0} {1}', 'meow', 'test', 'test string')).to.throw(RangeError);
        expect(() => Console.writeLine('Dog and  {12}', 'Cat')).to.throw(RangeError);
        expect(() => Console.writeLine('Cat and  {-1}', 'Dog')).to.throw(TypeError);
    })

    it("should throw a RangeError if the placeholders have indexes not withing the parameters range", function () {
        expect(() => Console.writeLine("The sum of {0} and {1} {2} {3} is", 3,7)).to.throw(RangeError)
    })

    it("should replace all placeholders ", function () {
        expect(Console.writeLine("The sum of {0} and {1} is {2}",5,8,13)).to.equal("The sum of 5 and 8 is 13")

        expect(Console.writeLine('A number: {0}. An array: {1}', 5, [9, 10])).to.equal('A number: 5. An array: 9,10', 'Function did not return correct output');

    })
})
