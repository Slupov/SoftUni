let calc;
beforeEach(function() {
    calc = createCalculator();
});
it("should return 5 after {add 3; add 2}", function() {
    calc.add('b'); calc.add(2); let value = calc.get();
    expect(value).to.be.equal.NaN;
});
it("should return 5 after {add 3; add 2}", function() {
    calc.add(); calc.add(0.2) ; calc.subtract(-1); let value = calc.get();
    expect(value).to.be.equal.NaN;
});

it("should return 5 after {add 3; add 2}", function() {
    let value = calc.get();
    expect(value).to.be.equal(0);
});
it("should return 5 after {add 3; add 2}", function() {
    calc.add(-3.8); calc.add(0.299) ; calc.subtract(-1); let value = calc.get();
    expect(value).to.be.equal(-2.501);
});
it("should return 5 after {add 3; add 2}", function() {
    calc.add(3.8); calc.add(0.2) ; calc.subtract(-1); let value = calc.get();
    expect(value).to.be.equal(5);
});
it("should return 5 after {add 3; add 2}", function() {
    calc.add('6'); calc.add(2); let value = calc.get();
    expect(value).to.be.equal(8);
});