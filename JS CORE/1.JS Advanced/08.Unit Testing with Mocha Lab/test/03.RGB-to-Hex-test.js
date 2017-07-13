let expect = require("chai").expect;
let rgbToHexColor = require("../03.RGB to Hex").rgbToHexColor;

describe("rgbToHexColor(red, green, blue)", function() {
    describe("Nominal cases (valid input)", function() {
        it("should return #FF9EAA on (255, 158, 170)", function() {
            let hex = rgbToHexColor(255, 158, 170);
            expect(hex).to.be.equal('#FF9EAA');
        });
        it("should return 0 for [0]", function() {
            expect(rgbToHexColor(255,255,255)).to.be.equal('#FFFFFF');
        });
        it("should return 0 for [0]", function() {
            expect(rgbToHexColor(256,255,255)).to.be.equal(undefined);
        });
        it("should return 0 for [0]", function() {
            expect(rgbToHexColor(255,-1,255)).to.be.equal(undefined);
        });
        it("should return 0 for [0]", function() {
            expect(rgbToHexColor(0,0,0)).to.be.equal('#000000');
        });
        it("should return 0 for [0]", function() {
            expect(rgbToHexColor(255,255,255)).to.be.equal('#FFFFFF');
        });
        it("should return 0 for [0]", function() {
            expect(rgbToHexColor(256,255,255)).to.be.equal(undefined);
        });
        it("should return 0 for [0]", function() {
            expect(rgbToHexColor(255,-1,255)).to.be.equal(undefined);
        });
        it("should return 0 for [0]", function() {
            expect(rgbToHexColor(3,4)).to.be.equal(undefined);
        });
    });
});

