let expect = require("chai").expect;

function createList() {
    let data = [];
    return {
        add: function (item) {
            data.push(item)
        },
        shiftLeft: function () {
            if (data.length > 1) {
                let first = data.shift();
                data.push(first);
            }
        },
        shiftRight: function () {
            if (data.length > 1) {
                let last = data.pop();
                data.unshift(last);
            }
        },
        swap: function (index1, index2) {
            if (!Number.isInteger(index1) || index1 < 0 || index1 >= data.length ||
                !Number.isInteger(index2) || index2 < 0 || index2 >= data.length ||
                index1 === index2) {
                return false;
            }
            let temp = data[index1];
            data[index1] = data[index2];
            data[index2] = temp;
            return true;
        },
        toString: function () {
            return data.join(", ");
        }
    };
}

describe('list',function () {

    let list = {};
    beforeEach(function () {
        list = createList();
    });

    describe('function properties',function () {
        it('list should posses correct functions',function () {
            expect(typeof (list.add)).to.equal('function');
            expect(typeof (list.shiftLeft)).to.equal('function');
            expect(typeof (list.shiftRight)).to.equal('function');
            expect(typeof (list.swap)).to.equal('function');
            expect(typeof (list.toString)).to.equal('function');

        });

        it('should be an empty string when constructed',function () {
            expect(list.toString()).to.equal('')
        });
    })

    describe('add',function () {
        it('should add correct values',function () {
            list.add(1);
            list.add('stoyo');
            list.add('12');
            list.add("hero");
            list.add(13);

            expect(list.toString()).equal('1, stoyo, 12, hero, 13');
        });

        it('shouldnt add nothing',function () {
            list.add();
            expect(list.toString()).to.equal('');
        });

        it('should add a string value',function () {
            list.add('hero');
            expect(list.toString()).to.equal('hero')
        });

        it('should add correct amount of times',function () {
            list.add('Pesho');
            expect(list.toString()).equal('Pesho');
        })

        it('should add correctly to the end of list',function () {
            list.add('Pesho');
            list.add('Stamat');
            list.add('Gosho');
            expect(list.toString()).equal('Pesho, Stamat, Gosho');
        })

        it('should add correct value',function () {
            list.add(1);
            list.add("two");
            list.add(3);
            list.add(["four"]);
            expect(list.toString()).equal('1, two, 3, four');
        })

        it('should add correct value',function () {
            list.add({});
            list.add(6);
            list.add("gosho");
            expect(list.toString()).equal('[object Object], 6, gosho');
        })

    });

    describe('shiftLeft',function () {
        it('should shift left correctly',function () {
            list.add(1);
            list.add('damn');
            list.add('this');
            list.add(18);

            list.shiftLeft();

            expect(list.toString()).equal('damn, this, 18, 1');

            list.shiftLeft();
            expect(list.toString()).equal('this, 18, 1, damn');

            list.shiftLeft();
            expect(list.toString()).equal('18, 1, damn, this');

        });
        it('should do nothing on shift left without elements',function () {
            list.shiftLeft();
            expect(list.toString()).equal('');
        });

        it('sshould do nothing on shift left with 1 elements',function () {
            list.add('Pesho');
            list.shiftLeft();
            expect(list.toString()).equal('Pesho');
        });

        it('should shift correct value',function () {
            list.add(5);
            list.add({name:"pesho"});
            list.add("gosho");

            list.shiftLeft();

            expect(list.toString()).to.equal('[object Object], gosho, 5');
        })

    });

    describe('shiftRight',function () {
        it('should shift right correctly',function () {
            list.add(5);
            expect(list.toString()).equal('5');

            list.shiftRight();
            expect(list.toString()).equal('5');

            list.shiftRight();
            list.add("damn");
            list.shiftRight();
            expect(list.toString()).equal('damn, 5');

        });
        it('should shift left correctly',function () {
            list.add('damn');
            list.shiftRight();
            expect(list.toString()).equal('damn');
        });

        it('should shift right nothing',function () {

            list.shiftRight();
            expect(list.toString()).equal('');
        });

        it('should shift right correctly',function () {
            list.add(12);
            list.add('damn');
            list.add('this');
            list.add(13);

            list.shiftRight();
            expect(list.toString()).equal('13, 12, damn, this');
            list.shiftLeft();
            expect(list.toString()).equal('12, damn, this, 13');

        });

        it('should shift correct value',function () {
            list.add(5);
            list.add({name:"pesho"});
            list.add("gosho");

            list.shiftRight();

            expect(list.toString()).to.equal('gosho, 5, [object Object]');
        })

    });
    describe('swap',function () {
        it('should do nothing with same values',function () {
            list.add(5);
            list.add('gosho');
            list.add('18');
            list.add(19);

            list.swap(2,2);
            expect(list.toString()).equal('5, gosho, 18, 19');
            expect(list.swap(2,2)).equal(false);
        });

        it('should do nothing with not integer values',function () {
            list.add(5);
            list.add('gosho');
            list.add('18');
            list.add(19);

            list.swap(3,2.5);
            expect(list.toString()).equal('5, gosho, 18, 19');

            expect(list.swap(2,3.5)).equal(false);
        });

        it('should swap  correctly with correct values',function () {
            list.add(5);
            list.add('gosho');
            list.add('18');
            list.add(19);


            list.swap(1,3);
            expect(list.toString()).equal('5, 19, 18, gosho');
            expect(list.swap(1,3)).equal(true);
        });

        it('should not swap with non integer 1st value',function () {
            list.add(5);
            list.add('gosho');
            list.add('18');
            list.add(19);

            list.swap(1.3,2);
            expect(list.toString()).equal('5, gosho, 18, 19');

            expect(list.swap(1.3,2)).equal(false);
        });
        it('should not swap with out of range value',function () {
            list.add(5);
            list.add('gosho');
            list.add('18');
            list.add(19);


            list.swap(1,4);
            expect(list.toString()).equal('5, gosho, 18, 19');
            expect(list.swap(1,4)).equal(false);
        });

        it('should not swap with string  1st value',function () {
            list.add(5);
            list.add('gosho');
            list.add('18');
            list.add(19);


            list.swap("1",2);
            expect(list.toString()).equal('5, gosho, 18, 19');
            expect(list.swap("1",2)).equal(false);
        });
        it('should not swap with string 2nd value',function () {
            list.add(5);
            list.add('gosho');
            list.add('18');
            list.add(19);


            list.swap(0,"2");
            expect(list.toString()).equal('5, gosho, 18, 19');
            expect(list.swap(0,"2")).equal(false);
        });

        it('should not swap with string 2nd value',function () {
            list.add(5);
            list.add('something');
            list.add(5);
            list.add('something');


            list.swap(0,2);
            expect(list.toString()).equal('5, something, 5, something');
            expect(list.swap(0,2)).equal(true);
        });
    })
});
