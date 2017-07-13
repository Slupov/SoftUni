//71/100
function spyMaster(input) {
    let specialKey = input.shift();
    let tempSpecialKey = specialKey.toLowerCase();

    let encodedMessageRegex = new RegExp(`( |^)(${tempSpecialKey}) +([A-Z!%$#]{8,})( |\\.|,|$){1}`, 'g');

    for (let line of input) {
        //console.log("before : " + line);
        let lowerCaseLine = line.toLowerCase();
        let indexOfSpecialKey = lowerCaseLine.indexOf(tempSpecialKey);

        while(indexOfSpecialKey!=-1){
            let currentSpecialKey = line.substring(indexOfSpecialKey, indexOfSpecialKey + specialKey.length);

            encodedMessageRegex = new RegExp(`( |^)(${currentSpecialKey}) +([A-Z!%$#]{8,})( |\\.|,|$){1}`, 'g');

            let match = encodedMessageRegex.exec(line);

            while (match) {
                //console.log("match:" + match[0]);
                line = line.replace(match[3], decode(match[3]));
                match = encodedMessageRegex.exec(line);
            }

            indexOfSpecialKey = lowerCaseLine.indexOf(tempSpecialKey,indexOfSpecialKey+3);
        }
        console.log(line);
        //console.log();

    }

    function decode(text) {
        let map = {
            '!': '1', '%': '2',
            "#": '3', '$': '4'
        };
        return text.replace(/[!%$#]/g, ch => map[ch]).toLowerCase();
    }
}

let test = [
    'specialKey',
    'In this text the specialKey HELLOWOA$is correct, but',
    'the following specialKey $HelloWorl#d and spEcIaLKEy HOLLO are not, while',
    'SpeCIaLkeY   SOM%%ETH$IN and SPECIALKEY ##$$##$$ are!'
];
// let test2 = [
//     'enCode',
//     'Some messages are just not encoded what can you do?',
//     'RE - ENCODE THEMNOW! - he said.',
//     'Damn encode, ITSALLHETHINKSABOUT, eNcoDe BULL$#!%.'
// ];
  spyMaster(test);