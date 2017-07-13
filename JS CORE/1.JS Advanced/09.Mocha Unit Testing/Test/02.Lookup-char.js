let expect = require("chai").expect;
let lookupChar = require("../02.Lookup char").lookupChar;

describe("lookupChar(str,num)", function() {
    it("should return odd after 9", function() {
        let value=lookupChar('',4);
        expect(value).to.be.equal('Incorrect index');
    });
    it("should return odd after 9", function() {
        let value=lookupChar('',-1);
        expect(value).to.be.equal('Incorrect index');
    });
    it("should return odd after 9", function() {
        let value=lookupChar('1',1);
        expect(value).to.be.equal('Incorrect index');
    });
    it("should return odd after 9", function() {
        let value=lookupChar(3,1);
        expect(value).to.be.equal(undefined);
    });
    it("should return odd after 9", function() {
        let value=lookupChar('Uhuu',1);
        expect(value).to.be.equal('h');
    });
    it("should return odd after 9", function() {
        let value=lookupChar('d','1');
        expect(value).to.be.equal(undefined);
    });
    it("should return odd after 9", function() {
        let value=lookupChar('asa',3.4);
        expect(value).to.be.equal(undefined);
    });
});
