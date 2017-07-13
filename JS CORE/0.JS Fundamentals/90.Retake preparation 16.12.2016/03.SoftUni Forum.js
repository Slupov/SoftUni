function softuniForum(input) {
    let bannedUsers = input.pop().split(' ');

    let usernameRegex =
        /(#)([A-Za-z][A-Za-z-_0-9]+[A-Za-z0-9])/g;

    let codeZone = false;

    for (let line of input) {
        if(line === "<code>"){
            codeZone = true;
        }
        else if(line === "</code>"){
            codeZone = false;
        }

        if(codeZone){
            console.log(line);
        }
        else{
            let match = usernameRegex.exec(line);
            if(match === null){
                console.log(line);
                continue;
            }
            let username = match[2];
            let replacementTag = `<a href="/users/profile/show/${username}">${username}</a>`;

            if(bannedUsers.includes(username)){
                replacementTag = "*".repeat(username.length)
            }

            line = line.replace(usernameRegex,replacementTag)
            console.log(line);
        }
    }
}

// softuniForum([
//     "#RoYaL: I'm not sure what you mean,",
//     "but I am confident that I've written",
//     "everything correctly. Ask #iordan_93",
//     "and #pesho if you don't believe me",
//
//     "<code>",
//     "#trying to print stuff",
//     "#pesho is typing",
//     'print("yoo")',
//     "</code>",
//
//     "#pesho is typing",
//     "pesho gosho"
//
// ])

// softuniForum([
// '#trifon',
// '#Mega_trifon',
// '#mega_trifon-ApoV',
// '#are_trifone',
// '#machkai_trifkaa',
// '#balgaria_nad-sichk0',
// '#Von_ApovBerger',
// 'Pitah go kolegata kakyw e problema, ama na nito edin ot teq',
// 'iusarneimi ne mi otgowarq kakwo da parwq??!',
// 'za kontakti: #stamat',
// 'stamat'
// ]);

softuniForum([
    'The quick, brown fox jumps over a lazy dog.',
        'DJs flock by when MTV ax quiz prog. Junk MTV',
    'quiz graced by fox whelps. Bawds jog, flick quartz,',
    'vex nymphs. #Waltz, bad nymph, for quick jigs vex!',
    'Fox nymphs grab #1quick-jived waltz. Brick quiz whangs',
'jumpy veldt fox. #Bright_ vixens jump; dozy fowl quack. Quick',
'wafting zephyrs vex #bold Jim. Quick zephyrs blow, vexing daft Jim.',
    'Sex-charged fop',
'blew my junk TV quiz.',
    'How quickly daft',
'jumping zebras vex. Two driven jocks',
'help fax my big quiz. Quick, Baz,',
    'get my woven flax jodhpurs!',
    '"Now fax quiz Jack!" my #brave ghost pled.',
    'brave bold'
]);