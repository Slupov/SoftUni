function* random (seed) {
    let previouX = seed;

    while (true) {
        let xN = (previouX * previouX) % (4871 * 7919);
        let result = xN;

        if (result >= 100) {
            result = result % 100;
        }

        yield result;
        previouX = xN;
    }
}

let rnd = random(100);

for (let i = 0; i < 10; i++) {
  console.log(rnd.next().value);
}

