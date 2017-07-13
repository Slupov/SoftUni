function radioCrystals(input) {
    input = input.map(Number);
    let refinedCrystals = {};
    let target = input[0];
    processing(input);
    let result = refinedCrystals;

    // print result
    for (let crystal in result) {
        console.log(`Processing chunk ${result[crystal]["Init"]} microns`);
        for (let process in result[crystal]) {
            if (process == "Init") continue;
            if (process == "Finish") {
                console.log(`Finished crystal ${result[crystal][process]} microns`);
                break;
            }
            if (result[crystal][process] != 0) {
                console.log(`${process} x${result[crystal][process]}`);
                if (process != "X-ray")
                    console.log("Transporting and washing");
            }

        }
    }

    function processing(crystals) {
        let times = 0;
        // Order of work:
        // Process using different techniques
        // Add the process to the list, as finished
        // Clean and check if done
        for (let i = 1; i < crystals.length; i++) {
            let temp = crystals[i];
            let chunk = "chunk" + i;

            refinedCrystals[chunk] = {};
            refinedCrystals[chunk].Init = temp;

            // Cutting
            while (true) {
                if (temp / 4 < target) break;
                temp /= 4;
                times++;
            }

            refinedCrystals[chunk].Cut = times;
            temp = cleanAndMove(temp);
            if (isItDone(temp)) {
                refinedCrystals[chunk].Finish = temp;
                continue;
            }

            // Lapping
            while (true) {
                if (temp * 0.80 < target) break;
                temp *= 0.80;
                times++;
            }
            refinedCrystals[chunk].Lap = times;
            temp = cleanAndMove(temp);
            if (isItDone(temp)) {
                refinedCrystals[chunk].Finish = temp;
                continue;
            }

            // Grinding
            while (true) {
                if (temp - 20 < target) break;
                temp -= 20;
                times++;
            }
            refinedCrystals[chunk].Grind = times;
            temp = cleanAndMove(temp);
            if (isItDone(temp)) {
                refinedCrystals[chunk].Finish = temp;
                continue;
            }

            // Etching
            while (true) {
                if (temp - 2 < target - 1) break;
                temp -= 2;
                times++;
            }

            refinedCrystals[chunk].Etch = times;
            temp = cleanAndMove(temp);
            if (isItDone(temp)) {
                refinedCrystals[chunk].Finish = temp;
                continue;
            }

            // X-ray
            temp++;
            refinedCrystals[chunk]["X-ray"] = 1;
            refinedCrystals[chunk].Finish = temp;
        }

        function cleanAndMove(crystal) {
            times = 0;
            return Math.round(crystal);
        }

        function isItDone(crystal) {
            return crystal == target;
        }

    }

}