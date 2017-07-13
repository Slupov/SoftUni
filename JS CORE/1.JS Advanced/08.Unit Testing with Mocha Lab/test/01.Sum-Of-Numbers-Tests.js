let expect = require("chai").expect;
let sum = require("../01.SumOfNumbers").sum;

describe("sum(arr)", function() {
    it("should return 3 for [1, 2]", function() {
        expect(sum([1, 2])).to.be.equal(3);
    });

    it("should return 1 for [1]", function () {
        expect(sum([1])).to.be.equal(1);
    });
    it("should return 0 for []", function () {
        expect(sum([])).to.be.equal(0);
    });

    it("should return undefined for ['str1','str2']", function () {
        expect(sum(['str1','str2'])).to.be.NaN;
    });
});
