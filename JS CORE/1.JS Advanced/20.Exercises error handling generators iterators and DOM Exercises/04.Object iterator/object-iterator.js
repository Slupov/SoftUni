function makeIterable (object) {
    let keys = Object.keys(object).sort((a, b) => {
        return b.localeCompare(a);
    });
    let index = 0;
    
    return {
        [Symbol.iterator]: function () {return this;},
        ['next']: function () {
            if (index >= keys.length) {
                return { done: true };
            } else {
                return { value: keys[index++], done: false };
            }
        }
    };
}


let obj = {name: "gosho", "13": true, book: "Lord of the Drinks", 2: 2, age: 15, passportNumber: 12345678};
let iterator = makeIterable(obj);
while(true){
  let res = iterator.next();
  if(res.done) break;
  console.log(res.value);
}

