function matchTheDates(texts) {
    let re = /\b[0-9]{1,2}-[A-Z][a-z]{2}-[0-9]{4}\b/g;
    for (let line in texts) {
        let m = re.exec(texts[line]);
        while (m) {
            let temp = m[0].split('-');
            console.log(m[0] + ` (Day: ${temp[0]}, Month: ${temp[1]}, Year: ${temp[2]})`);
            m = re.exec(texts[line]);

        }
    }

}