function DNAHelix(input) {
    let n = Number(input[0]);
    let pattern = "ATCGTTAGGG";
    let stars = 2;
    let dashes = 0;
    let firstPatternLetterPos = 0;
    let add = false;

    for (let i = 0; i < n; i++) {
        console.log(`${'*'.repeat(stars)}${pattern[firstPatternLetterPos]}${'-'.repeat(dashes)}${pattern[firstPatternLetterPos + 1]}${'*'.repeat(stars)}`);

        firstPatternLetterPos += 2;
        if (firstPatternLetterPos >= pattern.length - 1) {
            firstPatternLetterPos = 0;
        }
        if (stars == 0) {
            add = true;
        }
        if (stars == 2) {
            add = false;
        }
        if (add == false) {
            stars--;
            dashes += 2;
        }
        else {
            stars++;
            dashes -= 2;
        }

    }
}