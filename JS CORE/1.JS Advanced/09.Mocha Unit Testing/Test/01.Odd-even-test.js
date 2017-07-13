let expect = require("chai").expect;
let isOddOrEven = require("../01.Odd-even.js").isOddOrEven;

describe("isOddOrEven", function () {
    it("with a number parameter, should return undefined", function () {
        expect(isOddOrEven(13)).to.equal(undefined);
    });

    it("with an object parameter, should return undefined", function () {
        expect(isOddOrEven({name: "pesho"})).to.be.equal(undefined, "Function did not return the correct result!")
    });

    it("with a odd lengthy parameter, should return undefined", function () {
        expect(isOddOrEven("abc")).to.be.equal("odd", "Function did not return the correct result!")
    });

    it("with a even lengthy parameter, should return undefined", function () {
        expect(isOddOrEven("abcd")).to.be.equal("even");
    });
});