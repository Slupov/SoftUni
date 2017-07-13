let expect = require("chai").expect;

function produce(){
    let data = [];
    return {
        add: function(item) {
            data.push(item);
        },
        delete: function(index) {
            if (Number.isInteger(index) && index >= 0 && index < data.length) {
                return data.splice(index, 1)[0];
            } else {
                return undefined;
            }
        },
        toString: function() {
            return data.join(", ");
        }
    };
};

describe('list',function () {
    //judge pravi sledvashte 2 za nas (reset)
    let list = {};
    beforeEach(function () {
        list = produce();
    })

    it('constructor should produce object with correct functions',function () {
        expect(typeof (list.add)).to.equal('function');
        expect(typeof (list.delete)).to.equal('function');
        expect(typeof (list.toString)).to.equal('function');
    })

    it('constructor should produce an empty list',function () {
        expect(list.toString()).to.equal('','toString did not produce expected result!')
    })

    describe('add',function () {
        it('should add correct value',function () {
            list.add(5);
            expect(list.toString()).equal('5','add did not added correct value');
        })

        //ne e nov obekt => mahame iifeto i slagame before each
        it('should add correct amount of times',function () {
            list.add('Pesho');
            expect(list.toString()).equal('Pesho','add did not added correct value');
        })

        it('should add correctly to the end of list',function () {
            list.add('Pesho');
            list.add('Stamat');
            list.add('Gosho');
            expect(list.toString()).equal('Pesho, Stamat, Gosho');
        })
    })

    describe("delete",function () {
        it('with string should return undefined',function () {
            expect(list.delete('Pesho')).equal(undefined,'Delete did not return correct value');
        })

        it('with floating point should return undefined',function () {
            expect(list.delete(3.14)).equal(undefined,'Delete did not return correct value');
        })

        it('with floating point should not delete any elements',function () {
            list.add(15);
            list.delete(3.14);
            expect(list.toString()).equal('15','Delete deleted an existing value');
        })

        it('with 0 and no items in list',function () {
            expect(list.delete(0)).equal(undefined,'Delete deleted an existing value');
            expect(list.toString()).equal('','Delete deleted an existing value');
        })

        it('with index equal to the length of the list should not delte anything',function () {
            list.add(5);
            list.add("two");
            expect(list.delete(2)).equal(undefined,'Delete deleted a not-existing value');
            expect(list.toString()).equal('5, two','Delete deleted an existing value');
        })

        it('with 0 and items should delete correct item',function () {
            list.add(5);
            expect(list.delete(0)).to.equal(5,'Delete deleted an existing value');
        })

        it('with a correct index should return correct item',function () {
            list.add(5);
            list.add(10);
            list.add(16);
            expect(list.delete(2)).to.equal(16,'Delete deleted an existing value');
        })

        it('with a correct index should return correct item',function () {
            list.add(5);
            list.add(10);
            list.add(16);
            list.delete(1);
            expect(list.toString()).to.equal('5, 16','Delete deleted an existing value');
        })


    })
});